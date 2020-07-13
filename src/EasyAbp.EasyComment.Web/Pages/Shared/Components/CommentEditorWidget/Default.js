(function () {
    abp.widgets.CommentEditorWidget = function ($wrapper) {
        const getContent = function () {
            return $wrapper.find(".ec-editor-textarea").val();
        };

        const setFocus = function () {
            const content = getContent();
            const textarea = $wrapper.find(".ec-editor-textarea");
            textarea.focus();
            textarea.val("");
            textarea.val(content);
        };

        const addNewComment = function (successMessage, replyTo) {
            const commentsZoneWidget = $wrapper.closest(".ec-comments-zone");
            const itemType = $(commentsZoneWidget).attr("data-item-type");
            const itemKey = $(commentsZoneWidget).attr("data-item-key");
            const service = easyAbp.easyComment.comments.comment;
            
            service.addComment({
                itemType: itemType,
                itemKey: itemKey,
                content: getContent(),
                replyTo: replyTo
            })
                .then(function () {
                    const widgetManager = easyCommentHelper.getWidgetManager($wrapper, "CommentsZoneWidget");
                    widgetManager.refresh();
                    abp.notify.info(successMessage);
                });
        };

        return {
            getContent: getContent,
            setFocus: setFocus,
            addNewComment: addNewComment
        }
    }
})();