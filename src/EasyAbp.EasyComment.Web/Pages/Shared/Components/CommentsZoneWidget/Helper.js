var easyCommentHelper = easyCommentHelper || {};
(function () {

    easyCommentHelper = {
        getWidgetManager: function ($element, widgetName) {
            const wrapper = $element.closest(`.abp-widget-wrapper[data-widget-name=${widgetName}]`);
            const manager = new abp.WidgetManager($(wrapper).parents());
            manager.init();
            
            return manager;
        },
        
        getCommentWidgetWrapper: function ($element) {
            return $element.closest(".abp-widget-wrapper[data-widget-name=CommentWidget]");
        },

        getCommentViewerWidgetWrapper: function ($element) {
            const commentWidgetWrapper = easyCommentHelper.getCommentWidgetWrapper($element);
            return commentWidgetWrapper.find(".abp-widget-wrapper[data-widget-name=CommentViewerWidget]");
        },

        getCommentEditorWidgetWrapper: function ($element) {
            const commentWidgetWrapper = easyCommentHelper.getCommentWidgetWrapper($element);
            return commentWidgetWrapper.find(".abp-widget-wrapper[data-widget-name=CommentEditorWidget]");
        },

        cancelEdit: function ($element) {
            easyCommentHelper.getCommentViewerWidgetWrapper($element).show();
            easyCommentHelper.getCommentWidgetWrapper($element).find(".dropdown").show();
            easyCommentHelper.getCommentEditorWidgetWrapper($element).remove();
        }
    }
})();