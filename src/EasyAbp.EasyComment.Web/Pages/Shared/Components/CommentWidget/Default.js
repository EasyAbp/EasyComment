(function () {
    $(document).on("click", ".ec-action-edit", function () {
        const action = $(this);
        const commentWidgetWrapper = easyCommentHelper.getCommentWidgetWrapper(action);
        const commentId = commentWidgetWrapper.find(".ec-comment").attr("data-comment-id");
        const commentViewerWidgetWrapper = easyCommentHelper.getCommentViewerWidgetWrapper(action);

        action.closest(".dropdown").hide();
        commentViewerWidgetWrapper.hide();
        $.get("/widgets/easyComment/showCommentEditor", {
            id: commentId,
            editModel: true,
            content: "",
        }, function (html) {
            commentViewerWidgetWrapper.parent().append(html);
            const editorWidget = easyCommentHelper.getCommentEditorWidgetWrapper(action);
            abp.widgets.CommentEditorWidget(editorWidget).setFocus();
        })
    });
})();