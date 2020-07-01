(function () {
    abp.widgets.CommentEditorWidget = function ($wrapper) {
        var getContent = function () {
            return $wrapper.find(".ec-editor-textarea").val()
        }
        
        return {
            getContent: getContent
        }
    }
})();