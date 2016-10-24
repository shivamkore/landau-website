$(function () {
    //state click
    $('.anchorState').on('click', function (e) {
        $('#hiddenState').val($(this).attr('value'));
    });

    $('.select .mobile').on('change', function (e) {
        $('#hiddenState').val($(this).val());
    });
});