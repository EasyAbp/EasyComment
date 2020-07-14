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
        const $btn = $(this);
        const form = $btn.closest("form");

        if ($(form).data('changed')) {
            abp.message.confirm(l("AreYouSureYouWantToCancelEditingWarningMessage"))
                .done(function (result) {
                    if (result) {
                        easyCommentHelper.cancelEdit($btn);
                    }
                })
        } else {
            easyCommentHelper.cancelEdit($btn);
        }
    });

    $(document).on("click", ".ec-editor-button-save", function (e) {
        e.preventDefault();

        const $btn = $(this);
        const form = $btn.closest("form");
        if (!$(form).valid()) return;

        if (!$(form).data('changed')) {
            easyCommentHelper.cancelEdit($btn);
            return;
        }

        const commentWidgetWrapper = easyCommentHelper.getCommentWidgetWrapper($btn);
        const commentId = commentWidgetWrapper.find(".ec-comment").attr("data-comment-id");
        const editorWidget = easyCommentHelper.getCommentEditorWidgetWrapper($btn);
        const replyTo = editorWidget.data("replyTo");

        if (replyTo) {
            abp.widgets.CommentEditorWidget(editorWidget).addNewComment(l("SuccessfullyReplyComment"), replyTo);
        } else {
            service.updateContent({
                id: commentId,
                content: abp.widgets.CommentEditorWidget(editorWidget).getContent()
            }).then(function () {
                commentWidgetWrapper.empty();
                const widgetManager = easyCommentHelper.getWidgetManager($btn, "CommentWidget");
                widgetManager.refresh();
                abp.notify.info(l("SuccessfullyEditComment"));
            });
        }
    });
})();