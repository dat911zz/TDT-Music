function SelectLanguage(item) {
    if ($(item).hasClass('langen')) {
        $show = $('.dropdown-item.langvi');
        $hide = $('.dropdown-item.langen');
    }
    else {
        $hide = $('.dropdown-item.langvi');
        $show = $('.dropdown-item.langen');
    }
    $($show).removeClass('hide');
    $($hide).addClass('hide');
    $('#spNameLanguage').html($($hide).children('img').clone());
}