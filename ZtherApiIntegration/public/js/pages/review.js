$(function(){
    $('.star').on('click',function(){
        var i = 0;
        for (i; i <= $(this).index(); i++) {
            $(this).parent().children().eq(i).attr('srcset', 'public/images/detail/icons/star_filled.png').attr('src', 'public/images/detail/icons/star_filled.png');
        }
        var rating = i;
        for (i; i < 5; i++) {
            $(this).parent().children().eq(i).attr('srcset', 'public/images/detail/icons/star_empty.png').attr('src', 'public/images/detail/icons/star_empty.png');
        }

        $('select[name="star_rating"]').val(rating);
        switch(rating){
            case 1:
                $('.rating_title').html('Poor');
                break;
            case 2:
                $('.rating_title').html('Below Average');
                break;
            case 3:
                $('.rating_title').html('Average');
                break;
            case 4:
                $('.rating_title').html('Above Average');
                break;
            case 5:
                $('.rating_title').html('Excellent');
                break;
        }
    });
});
