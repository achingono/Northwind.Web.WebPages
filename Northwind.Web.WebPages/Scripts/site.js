// define initial state of the view model
var viewModel = {
    Selected: {
        Item: ko.observable({}),
        Template: ko.observable("")
    },
    Page: {
        Number: ko.observable(-1),
        Size: ko.observable(0),
        List: ko.observableArray([]),
        Show: function (page) {
            var currentPage = viewModel.Page.Number();

            return ((viewModel.Page.List().length <= 10)
                    || (currentPage < 5 && page < 10)
                    || page == currentPage
                    || (currentPage >= 5 && (
                        ((currentPage > page) && (currentPage - page) <= 5) 
                        || ((page > currentPage) && (page - currentPage) <= 5))));
        }
    }
};
// initialize view model when document is ready
$(function () {
    // get a reference to the body
    var body = $('body');
    var pageSize = parseInt(body.data('page-size')) || 0;
    var count = parseInt(body.data('count') || 0);

    if (count > 0 && pageSize > 0) {
        // update the page size property of the view model
        viewModel.Page.Size(pageSize);

        // update the pages array
        var pages = Math.round(count / pageSize);
        for (var i = 0; i < pages; i++) {
            viewModel.Page.List.push(i);
        }
    }

    // subscribe to the view model's page number
    viewModel.Page.Number.subscribe(function (newValue) {
        // grab the data we need
        // to make our first api call
        var apiUrl = body.data('api-url');
        var apiProperty = body.data('api-property');
        var pageNumber = newValue; //viewModel.Page.Number();
        var pageSize = viewModel.Page.Size();

        if (pageNumber > 0 && pageSize > 0) {
            apiUrl = apiUrl + '?$skip=' + (pageNumber * pageSize) + '&$top=' + pageSize;
        }
        else if (pageSize > 0) {
            apiUrl = apiUrl + '?$top=' + pageSize;
        }

        // make the call
        $.get(apiUrl, function (data) {
            // update the view model
            if (apiProperty && apiProperty != null && apiProperty != '') {
                if (viewModel[apiProperty]) {
                    ko.mapping.fromJS(data, {}, viewModel[apiProperty]);
                }
                else {
                    viewModel[apiProperty] = ko.mapping.fromJS(data);
                    // render the UI
                    ko.applyBindings(viewModel);
                }
            }
        });
    });

    // whenever an object with attribute "data-template" is clicked
    body.on('click', '[data-template]', function (e) {
        // get a reference to the clicked item
        var target = $(e.currentTarget)
        // get the specified template
        var template = target.data('template');
        // get the specified data id
        var id = target.data('id');
        // get the api url specifed on the body tag
        var apiUrl = body.data('api-url');

        // make an ajax call and update the view model
        $.get(apiUrl + '/' + id, function (data) {
            ko.mapping.fromJS(data, {}, viewModel.Selected.Item);
            viewModel.Selected.Template(template);
        });
    })
    // whenever a hyperlink with attribute "data-page" is clicked
    .on('click', 'a[data-page]', function (e) {
        // get a reference to the clicked item
        var target = $(e.currentTarget)
        // get the specified page number
        var page = target.data('page');
        // get the current page number from the view model
        var currentPage = viewModel.Page.Number();
        // regular expression to match signed integers
        var expression = /^\s*[+-]\d+\s*$/;

        // update the page number 
        if (expression.test(page)) {
            // the page is a signed integer, 
            // so we calculate by adding/subtracting from the current page
            var newPage = eval('currentPage' + page);
            if (newPage >= 0 && newPage < viewModel.Page.List().length) {
                viewModel.Page.Number(newPage);
            }
        }
        else if (page >= 0 && page < viewModel.Page.List().length) {
            // the page is just a number
            // so assign it directly
            viewModel.Page.Number(page);
        }
    });

    var modal = $('#modal');
    // when the modal is made visible
    modal.on('click', '.btn-primary', function () { // attach a click event to the primary button
        // find the first form in the modal
        var form = modal.find('form:first');
        // no need to proceed if there is no form
        if (form == null) return;
        // validate form first
        //if (form.valid()) {
        // submit form by ajax
        $.ajax({
            type: form.attr('method'),
            url: form.attr('action'),
            data: form.serialize(),
            cache: false
        }).done(function () {
            $('#modal .alert').remove();
            modal.find('.modal-body:first')
                     .prepend('<div class="alert alert-success fade in"><a class="close" data-dismiss="alert" href="#">&times;</a><strong>Great!</strong> Your data was submitted successfully.</div>');
        }).fail(function () {
            $('#modal .alert').remove();
            modal.find('.modal-body:first')
                     .prepend('<div class="alert alert-error fade in"><a class="close" data-dismiss="alert" href="#">&times;</a><strong>Ooops!</strong> Something went wrong. Please fix it an try again.</div>');
        });
        //}
        //else {
        //    // attach appropriate classes if there is an error
        //    form.addErrorClasses();
        //}
    }).on('keypress', function (e) { // trigger the primary button if the enter key is pressed
        if (e.which == 13) {
            modal.find('.btn-primary').click();
        }
    }).on('hidden', function () {   // when the modal is hidden
        $('#modal .alert').remove();
    });
    // update the page number to trigger ajax call
    viewModel.Page.Number(0);
});