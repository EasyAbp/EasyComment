$(function() {
    var l = abp.localization.getResource("EasyComment");
    
    $(".ec-button-new-comment").click(function (e) {
        e.preventDefault();

        var form = e.currentTarget.closest("form");
        if (!$(form).valid()) return;

        var widgetWrapper = $(form).closest(".abp-widget-wrapper");
        var service = easyAbp.easyComment.comments.comment;
        var itemType = $(widgetWrapper).find("#ItemType").val();
        var itemKey = $(widgetWrapper).find("#ItemKey").val();
        var content = $(widgetWrapper).find(".ec-textarea-new-comment").val();

        service.addComment({
            itemType: itemType,
            itemKey: itemKey,
            content: content,
            // TODO: replyTo: replyTo
        })
            .then(function () {
                abp.notify.info(l("SuccessfullyPublishComment"));
                var widgetManager = new abp.WidgetManager($(widgetWrapper).parent());
                widgetManager.init();
                widgetManager.refresh();
            });
    })
})

