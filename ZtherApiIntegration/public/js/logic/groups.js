$(function () {

    $('.checkbox_btn').each(function () {
        $(this).on('click', function () {
            $(this).parent().next().val(!$(this).prev()[0].checked);
        });
    });

    //industry click
    $('.industry_container .anchorState').on('click', function (e) {
        $('#hiddenIndustry').val($(this).attr('value'));
    });

    $('.industry_container .select .mobile').on('change', function (e) {
        $('#hiddenIndustry').val($(this).val());
    });


    //state click
    $('.state_container .anchorState').on('click', function (e) {
        $('#hiddenState').val($(this).attr('value'));
    });

    $('.state_container .select .mobile').on('change', function (e) {
        $('#hiddenState').val($(this).val());
    });

    //Out Fitted click
    $('.ammount_container .anchorOutfitted').on('click', function (e) {
        $('#hiddenOutFitted').val($(this).attr('value'));
    });

    $('.ammount_container .select .mobile').on('change', function (e) {
        $('#hiddenOutFitted').val($(this).val());
    });
});