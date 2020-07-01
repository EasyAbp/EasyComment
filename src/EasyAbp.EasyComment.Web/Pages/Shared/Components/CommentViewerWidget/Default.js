(function () {
    abp.widgets.CommentViewerWidget = function ($wrapper) {
        var getContent = function () {
            return $wrapper.find("p.ec-viewer-content").text();
        }
        
        return {
            getContent: getContent
        }
    }
})();