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

    $(document).on("change", "form :input", function () {
        $(this).closest('form').data('changed', true);
    })

    $(".ec-edit-comment").click(function () {
        var commentDiv = $(this).closest(".ec-comment");
        var commentHolder = commentDiv.find(".ec-comment-holder");
        var commentId = commentDiv.attr("data-comment-id");

        commentHolder.find("[data-widget-name=CommentViewerWidget]").hide();
        $.get("/widgets/easyComment/showCommentEditor", {
            id: commentId,
            showLabel: false,
            editModel: true,
        }, function (html) {
            commentDiv.find(".ec-comment-holder").append(html);
        })
    });

    $(document).on("click", ".ec-button-cancel", function () {
        var btnCancel = $(this);
        
        var cancelEdit = function () {
            var commentDiv = btnCancel.closest(".ec-comment");
            var commentHolder = commentDiv.find(".ec-comment-holder");
            commentHolder.find("[data-widget-name=CommentViewerWidget]").show();
            commentHolder.find("[data-widget-name=CommentEditorWidget]").remove();
        }

        if ($(this).closest('form').data('changed')) {
            abp.message.confirm(l("AreYouSureYouWantToCancelEditingWarningMessage"))
                .done(function (result) {
                    if (result) {
                        cancelEdit();
                    }
                })
        } else {
            cancelEdit();
        }
    });
})

