(function () {
    const l = abp.localization.getResource("EasyComment");
    const service = easyAbp.easyComment.comments.comment;

    $(document).on("click", ".ec-action-edit", function () {
        const $action = $(this);
        const commentWidgetWrapper = easyCommentHelper.getCommentWidgetWrapper($action);
        const commentId = commentWidgetWrapper.find(".ec-comment").attr("data-comment-id");
        const commentViewerWidgetWrapper = easyCommentHelper.getCommentViewerWidgetWrapper($action);

        $action.closest(".dropdown").hide();
        commentViewerWidgetWrapper.hide();
        $.get("/widgets/easyComment/showCommentEditor", {
            id: commentId,
            editModel: true,
            content: "",
        }, function (html) {
            commentViewerWidgetWrapper.parent().append(html);
            const editorWidget = easyCommentHelper.getCommentEditorWidgetWrapper($action);
            abp.widgets.CommentEditorWidget(editorWidget).setFocus();
        })
    });

    const showReplyEditor = function ($action, reference) {
        const commentWidgetWrapper = easyCommentHelper.getCommentWidgetWrapper($action);
        const creatorId = commentWidgetWrapper.find(".ec-comment").attr("data-creator-id");
        const commentViewerWidgetWrapper = easyCommentHelper.getCommentViewerWidgetWrapper($action);

        $action.closest(".dropdown").hide();
        $.get("/widgets/easyComment/showCommentEditor", {
            label: l("Reply"),
            editModel: true,
            content: reference
        }, function (html) {
            commentViewerWidgetWrapper.parent().append(html);
            const editorWidget = easyCommentHelper.getCommentEditorWidgetWrapper($action);
            editorWidget.data("replyTo", creatorId);
            abp.widgets.CommentEditorWidget(editorWidget).setFocus();
        });
    };
    
    $(document).on("click", ".ec-action-reply", function () {
        showReplyEditor($(this));
    });

    $(document).on("click", ".ec-action-reference", function () {
        const $action = $(this);
        const commentViewerWidgetWrapper = easyCommentHelper.getCommentViewerWidgetWrapper($action);
        const referenceText = abp.widgets.CommentViewerWidget(commentViewerWidgetWrapper).getReferenceContent();
        showReplyEditor($action, referenceText + "\n\n");
    });

    $(document).on("click", ".ec-action-remove", function () {
        const $action = $(this);
        const commentWidgetWrapper = easyCommentHelper.getCommentWidgetWrapper($action);
        const commentId = commentWidgetWrapper.find(".ec-comment").attr("data-comment-id");

        abp.message.confirm(l("CommentDeletionConfirmationMessage"))
            .done(function (result) {
                if (result) {
                    service.removeComment(commentId)
                        .then(function () {
                            const widgetManager = easyCommentHelper.getWidgetManager($action, "CommentsZoneWidget");
                            widgetManager.refresh();
                            abp.notify.info(l("SuccessfullyRemoveComment"));
                        })
                }
            })
    });
})();