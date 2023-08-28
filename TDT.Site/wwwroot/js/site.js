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

function ChangeGallery(i) {
    var gal = $('.gallery-item');
    $('.gallery-item-first').removeClass('gallery-item-first').addClass('gallery-item-add');
    $('.gallery-item-previous').removeClass('gallery-item-previous').addClass('gallery-item-first');
    $('.gallery-item-selected').removeClass('gallery-item-selected').addClass('gallery-item-previous');
    $('.gallery-item-next').removeClass('gallery-item-next').addClass('gallery-item-selected');
    $('.gallery-item-last').removeClass('gallery-item-last').addClass('gallery-item-next');
    $(gal).eq(i).removeClass('gallery-item-add').addClass('gallery-item-last');
    return i + 1 >= $(gal).length ? 0 : i + 1;
}