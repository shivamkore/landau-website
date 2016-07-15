
$(function () {

    filtersNameSpace = function () {
        var fit = [];
        var sort = null;
        var color = [];
        var size = [];
        var gender = null;
        var collection = null;
        var category = null;
        var pageNr = 1;
        var viewAll = false;

        function addOrRemoveAttribute(array, attr, specialSearch) {
            var index = -1;
            if (specialSearch) {
                for (var i = 0; i < array.length; i++) {
                    if (array[i].replace(/'/g, "") == attr) {
                        index = i;
                        break;
                    }
                }
            }
            else
                index = array.indexOf(attr);

            if (index >= 0)
                array.splice(index, 1);
            else
                array.push(attr);
        };

        return { viewAll: viewAll, pageNr: pageNr, sort: sort, color: color, size: size, fit: fit, collection: collection, category: category, gender: gender, addOrRemoveAttribute: addOrRemoveAttribute }
    }();
    
    //remove filter click
    $('.filter_list').on('click', function (e) {
        filtersNameSpace.pageNr = 1;

        var target = e.target;
        var attr = $(target).attr("value");

        if ($(this).parent().hasClass("color"))
            filtersNameSpace.addOrRemoveAttribute(filtersNameSpace.color, attr, true);
        else if ($(this).parent().hasClass("fit_type"))
            filtersNameSpace.addOrRemoveAttribute(filtersNameSpace.fit, attr, true);
        else if ($(this).parent().hasClass("size"))
            filtersNameSpace.addOrRemoveAttribute(filtersNameSpace.size, attr, true);


        refreshProducts();
    });
    
    //filters click
    $('.dropdownFilter').on('click', function (e) {
        
        filtersNameSpace.pageNr = 1;

        var attr = $(this).data("name");

        if ($(this).parent().hasClass("sort_by"))
            filtersNameSpace.sort = attr;
        else if ($(this).parent().hasClass("color"))
            filtersNameSpace.addOrRemoveAttribute(filtersNameSpace.color, attr);
        else if ($(this).parent().hasClass("fit_type"))
            filtersNameSpace.addOrRemoveAttribute(filtersNameSpace.fit, attr);
        else if ($(this).parent().hasClass("size"))
            filtersNameSpace.addOrRemoveAttribute(filtersNameSpace.size, attr);


        refreshProducts();
    });


    $('.mob_dropdownFilter').on('click', function (e) {
        
        filtersNameSpace.pageNr = 1;

        var attr = $(this).data("name");

        if ($(this).parent().parent().hasClass("mob_sort_by"))
            filtersNameSpace.sort = attr;
        else if ($(this).parent().parent().hasClass("mob_colors"))
            filtersNameSpace.addOrRemoveAttribute(filtersNameSpace.color, attr);
        else if ($(this).parent().parent().hasClass("mob_fit_type"))
            filtersNameSpace.addOrRemoveAttribute(filtersNameSpace.fit, attr);
        else if ($(this).parent().parent().hasClass("mob_size"))
            filtersNameSpace.addOrRemoveAttribute(filtersNameSpace.size, attr);
        
    });
        
    $('.apply_btn').on('click', function (e) {
        refreshProducts();
        $('#catalog_container .mobile_right_filters .exit_btn').trigger('click')
    });

    $('.clear_btn').on('click', function (e) {
        resetFiltersMobile();
    });
    
    $('.reset_button').on('click', function (e) {
        resetFiltersMobile();
        refreshProducts();
    });
    
});

function setValues(gender, category, collection, fit) {
    $(document).ready(function () {
        filtersNameSpace.gender = gender;
        filtersNameSpace.category = category;
        filtersNameSpace.collection = collection;

        if (fit != null && fit !="")
            filtersNameSpace.fit.push(fit);
    });
}

function resetFiltersMobile() {
    resetFilters();

    $('.ul-category').children().each(function (index) {
        $(this).removeClass("active");
    });
}

function resetFiltersDesktop() {
    resetFilters();

    $('.select_group').children().each(function (index) {
        $(this).removeClass("active");
    });

    $('.filters').find('.filter_list').each(function (index) {
        $(this).html("");
    });

    refreshProducts();
}

function resetFilters() {
    filtersNameSpace.sort = null;
    filtersNameSpace.color = [];
    filtersNameSpace.fit = [];
    filtersNameSpace.size = [];
    filtersNameSpace.pageNr = 1;
}

function refreshProducts() {

    $('#catalog_container .loading_mask').show();

    $.ajax({
        url: "/Catalog/ProductsFilter",
        type: "GET",
        traditional: true,
        data: { viewAll: filtersNameSpace.viewAll, pageNr: filtersNameSpace.pageNr, collection: filtersNameSpace.collection, gender: filtersNameSpace.gender, category: filtersNameSpace.category, fit: filtersNameSpace.fit, size: filtersNameSpace.size, color: filtersNameSpace.color, sort: filtersNameSpace.sort }
    })
        .fail(function (jqXHR, textStatus) {
            //alert(textStatus);
            $('#catalog_container .loading_mask').hide();
        })
        .done(function (response) {
            $("#prodGroup").html(response.groupsView);
            $("#prodRows").html(response.rowsView);
            $("#bottomPagination").html(response.paginationView);
            $("#topPagination").html(response.paginationView);

            $('#catalog_container .loading_mask').hide();
        });
}

function nextPage() {
    filtersNameSpace.pageNr++;
    refreshProducts();
}

function previousPage() {
    if (filtersNameSpace.pageNr > 1) {
        filtersNameSpace.pageNr--;
        refreshProducts();
    }
}

function onViewAll() {    

    if ($(".view_all").text().indexOf("View") >= 0) {
        filtersNameSpace.pageNr = -1;
        filtersNameSpace.viewAll = true;
    }
    else {
        filtersNameSpace.pageNr = 1;
        filtersNameSpace.viewAll = false;
    }

    refreshProducts();
}