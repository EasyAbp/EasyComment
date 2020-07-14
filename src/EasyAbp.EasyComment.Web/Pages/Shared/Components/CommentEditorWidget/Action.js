(function () {
    const l = abp.localization.getResource("EasyComment");
    const service = easyAbp.easyComment.comments.comment;

    $(document).on("change", "form :input", function () {
        $(this).closest('form').data('changed', true);
    });

    $(document).on("click", ".ec-editor-button-publish", function (e) {
        e.preventDefault();

        const form = $(this).closest("form");
        if (!$(form).valid()) return;

        const wrapper = $(this).closest(".abp-widget-wrapper[data-widget-name=CommentEditorWidget]");
        abp.widgets.CommentEditorWidget(wrapper).addNewComment(l("SuccessfullyPublishComment"))
    });

    $(document).on("click", ".ec-editor-button-cancel", function () {
        const $action = $(this);
        const form = $action.closest("form");

        if ($(form).data('changed')) {
            abp.message.confirm(l("AreYouSureYouWantToCancelEditingWarningMessage"))
                .done(function (result) {
                    if (result) {
                        easyCommentHelper.cancelEdit($action);
                    }
                })
        } else {
            easyCommentHelper.cancelEdit($action);
        }
    });

    $(document).on("click", ".ec-editor-button-save", function (e) {
        e.preventDefault();

        const $action = $(this);
        const form = $action.closest("form");
        if (!$(form).valid()) return;

        if (!$(form).data('changed')) {
            easyCommentHelper.cancelEdit($action);
            return;
        }

        const commentWidgetWrapper = easyCommentHelper.getCommentWidgetWrapper($action);
        const commentId = commentWidgetWrapper.find(".ec-comment").attr("data-comment-id");
        const editorWidget = easyCommentHelper.getCommentEditorWidgetWrapper($action);
        const replyTo = editorWidget.data("replyTo");

        if (replyTo) {
            abp.widgets.CommentEditorWidget(editorWidget).addNewComment(l("SuccessfullyReplyComment"), replyTo);
        } else {
            service.updateContent({
                id: commentId,
                content: abp.widgets.CommentEditorWidget(editorWidget).getContent()
            }).then(function () {
                const widgetManager = easyCommentHelper.getWidgetManager($action, "CommentWidget");
                easyCommentHelper.cancelEdit($action);
                widgetManager.refresh();
                abp.notify.info(l("SuccessfullyEditComment"));
            });
        }
    });
})();