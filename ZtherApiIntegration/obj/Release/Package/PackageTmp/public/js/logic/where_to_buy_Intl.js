$(function () {
    var path = window.location.pathname.split('/');
    searchValues = {
        pageNum: 1,
        filter: path[path.length-1]
    };
   
    $('.international_container a[href$="' + window.location.pathname + '"]').parent().addClass('selected');

    $('.search_bar .right li a').on('click', function () {
        $(this).parent().addClass("selected");
    });

    $(".search_bar .left button").on('click', function (e) {
        redirectToUSRetailers();
    });

    $(".search_bar .left .text").keypress(function (event) {
        if (window.event)
            key = window.event.keyCode;     //IE
        else
            key = e.which;     //firefox

        if (key == 13) {
            event.preventDefault();
            $(".search_bar .left button").click();
            event.keyCode = 0
        }
    });

});

function redirectToUSRetailers() {
    
    var searchFilter = $(".search_bar .dropdown_wrapper input").val();
    if (searchFilter.length > 0) {
        var url = $('#hdnUrl').val();
        var redirectURL = url + "?filter=" + $(".search_bar .dropdown_wrapper input").val();
        window.location.replace(redirectURL);
    }
}

function refreshRetailers() {
    $.ajax({
        url: "/WhereToBuy/RefreshIntRetailers",
        type: "GET",
        data: {
            countryCode: searchValues.filter,
            pageNumber: searchValues.pageNum
        }
    })
    .fail(function (jqXHR, textStatus) {
    })
    .done(function (response) {
        $("#retailDealer").html(response);
    });

}

function nextPage() {
    searchValues.pageNum++;
    refreshRetailers();
}

function previousPage() {
    searchValues.pageNum--;
    refreshRetailers();
}