
$(function () {

    searchNameSpace = function () {        
        var pageNr = 1;
        var viewAll = false;
        var searchTerm = getParameterByName('search_term_string');
        return { viewAll: viewAll, pageNr: pageNr, searchTerm: searchTerm }
    }();


});

function getParameterByName(name) {
    name = name.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
    var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
        results = regex.exec(location.search);
    return results === null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
}


function refreshProducts() {

    $('#catalog_container .loading_mask').show();

    $.ajax({
        url: "/Search/Paginate",
        type: "GET",
        data: { searchTerm: searchNameSpace.searchTerm, viewAll: searchNameSpace.viewAll, pageNr: searchNameSpace.pageNr }
    })
        .fail(function (jqXHR, textStatus) {
            $('#catalog_container .loading_mask').hide();
        })
        .done(function (response) {
            $("#catalog_container").html(response);
            
            $('#catalog_container .loading_mask').hide();
        });
}

function nextPage() {
    searchNameSpace.pageNr++;
    refreshProducts();
}

function previousPage() {
    if (searchNameSpace.pageNr > 1) {
        searchNameSpace.pageNr--;
        refreshProducts();
    }
}

function onViewAll() {

    if ($(".view_all").text().indexOf("View") >= 0) {
        searchNameSpace.pageNr = -1;
        searchNameSpace.viewAll = true;
    }
    else {
        searchNameSpace.pageNr = 1;
        searchNameSpace.viewAll = false;
    }

    refreshProducts();
}