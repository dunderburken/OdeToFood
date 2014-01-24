
$(function () {

    var ajaxFormSubmit = function () {

        var $form = $(this);        
        var options = {
            url: $form.attr("action"),
            type: $form.attr("method"),
            data: $form.serialize()
        };
        console.log(options);
        $.ajax(options).done(function (data) {
            var $target = $($form.attr("data-otf-target"));
            $target.replaceWith(data);
            console.log($target);
        });
        return false;
    };

    $("form[data-otf-ajax='true']").submit(ajaxFormSubmit);

});