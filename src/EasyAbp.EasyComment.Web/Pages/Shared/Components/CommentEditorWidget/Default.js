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

        return {
            getContent: getContent,
            setFocus: setFocus
        }
    }
})();