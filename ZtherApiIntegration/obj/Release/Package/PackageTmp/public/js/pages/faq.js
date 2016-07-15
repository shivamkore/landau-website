$(function() {
    $('#faq .faq-dropdown').click(function() {
        $(this).children('span').toggleClass('rotate');
        $(this).next('p').slideToggle();
    });
});
