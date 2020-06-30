$(function () {
    var l = abp.localization.getResource("EasyComment");

    var getEnclosedWidget = function (e) {
        return e.closest(".abp-widget-wrapper");
    };

    $(".ec-button-new-comment").click(function (e) {
        e.preventDefault();

        var form = e.currentTarget.closest("form");
        if (!$(form).valid()) return;

        var widget = getEnclosedWidget(form);
        var service = easyAbp.easyComment.comments.comment;
        var itemType = $(widget).find("#ItemType").val();
        var itemKey = $(widget).find("#ItemKey").val();
        var content = $(widget).find(".ec-textarea-new-comment").val();

        service.addComment({
            itemType: itemType,
            itemKey: itemKey,
            content: content,
            // TODO: replyTo: replyTo
        })
            .then(function () {
                abp.notify.info(l("SuccessfullyPublishComment"));
                var widgetManager = new abp.WidgetManager($(widget).parent());
                widgetManager.init();
                widgetManager.refresh();
            });
    });

    $(".ec-edit-comment").click(function (e) {
        var content = $(e.currentTarget).closest(".ec-comment").find("p.ec-content").text();
        var widget = getEnclosedWidget($(e.currentTarget));

        var textarea = widget.find("textarea.ec-textarea-new-comment");
        textarea.val(content);
        textarea.focus();
    })
})

