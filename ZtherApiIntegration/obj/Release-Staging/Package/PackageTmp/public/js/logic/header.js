$(function () {
    var favCount = window.localStorage.getItem('favoriteCount');
    var count = favCount == null ? 0 : favCount;

    var favoriteSpan = $(".num .num-circle span");
    for (var i = 0 ; i < favoriteSpan.length; i++){
        favoriteSpan[i].innerHTML = count;
    }
});
