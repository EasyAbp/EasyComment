﻿(function () {
    abp.widgets.commentEditorWidget = function ($wrapper) {
        var getContent = function () {
            return $wrapper.find(".ec-textarea-new-comment").val()
        }
        
        return {
            getContent: getContent
        }
    }
})();