(function (window) {
    'use strict';

    function SplashScreenAction() {
        if ("undefined" == typeof jQuery) {
            throw new Error("SplashScreen.js requires jQuery");
        }

        var SplashScreen = {};

        SplashScreen.open = function (properties) {
            $('#ss-overlay').remove();//RemoveIfCalledBefore

            var Holder = '<div id="ss-overlay" class="precontainer" style="display: none;" >\n\
                            <div class="prelogo">\n\
                                <img src="/image/logo_TDT_Devil-circle_light.png" alt="Logo" />\n\
                            </div>\n\
                            <div class="preloader">\n\
                                <hr /><hr /><hr /><hr />\n\
                            </div>\n\
                        </div>'
            
            $(Holder).appendTo('body').fadeIn(300);

            if (properties) {
                if (properties.backgroundColor) {
                    $("#ss-overlay").css("backgroundColor", properties.backgroundColor);
                }

                if (properties.backgroundColor) {
                    $("#ss-message").css("color", properties.textColor);
                }
            }
        };

        SplashScreen.close = function () {
            $('#ss-overlay').fadeOut(300, function () {
                $(this).remove();
            });
        };

        return SplashScreen;
    }

    if (typeof (SplashScreen) === 'undefined') {
        window.SplashScreen = SplashScreenAction();
    }

})(window);
