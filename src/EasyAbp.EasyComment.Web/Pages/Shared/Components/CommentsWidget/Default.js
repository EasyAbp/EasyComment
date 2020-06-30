$(function () {
    var l = abp.localization.getResource("EasyComment");

    var getCommentWidget = function (e) {
        return e.parents(".abp-widget-wrapper").last();
    };
    
    $(".ec-button-publish").click(function (e) {
        e.preventDefault();

        var form = $(this).closest("form");
        if (!$(form).valid()) return;

        var widget = getCommentWidget(form);
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

    $(".ec-edit-comment").click(function () {
        var commentDiv = $(this).closest(".ec-comment");
        var commentId = commentDiv.attr("data-comment-id");
        
        $.get("/widgets/easyComment/showCommentEditor", {
            id: commentId,
            showLabel: false,
            editModel: true,
        }, function (html) {
            commentDiv.find(".ec-comment-holder").html(html);
        })
    })
})

