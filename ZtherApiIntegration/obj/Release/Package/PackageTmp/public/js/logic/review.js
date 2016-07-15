$(function () {
    $('.star').on('click', function () {
        var i = 0;
        for (i; i <= $(this).index() ; i++) {
            $(this).parent().children().eq(i).attr('srcset', 'public/images/review/star_filled.png');
        }
        var rating = i;

        $('#hiddenRating').val(rating);
    });
});