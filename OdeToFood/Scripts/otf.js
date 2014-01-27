
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
            var $newHtml = $(data)            
            $target.replaceWith($newHtml);
            $newHtml.effect("highlight");
        });
        return false;
    };

    var submitAutocompleteForm = function (event, ui) {
        var $input = $(this);
        $input.val(ui.item.label);

        var $form = $input.parents("form:first");
        $form.submit();

    };

    var createAutocomplete = function () {
        var $input = $(this);
        var options = {
            source: $input.attr("data-otf-autocomplete"),
            select: submitAutocompleteForm,
            messages: {
                noResults: '',
                results: function () { }
            }
        };
        $input.autocomplete(options);

    };

    var getPage = function () {
        var $a = $(this);
        var options = {
            url: $a.attr("href"),
            type: "get",
            data: $("form").serialize()
        };

        $.ajax(options).done(function (data) {
            var target = $a.parents("div.pagedList").attr("data-otf-target");        
            //$newHtml = $(data);
            $(target).replaceWith(data);
            //$newHtml.effect("highlight");

        });
        return false;
    };

    $("form[data-otf-ajax='true']").submit(ajaxFormSubmit);
    $("input[data-otf-autocomplete]").each(createAutocomplete);

    $(".main-content").on("click", ".pagedList a", getPage);

});