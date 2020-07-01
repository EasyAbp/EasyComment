(function () {
    abp.widgets.CommentViewerWidget = function ($wrapper) {
        const getContent = function () {
            return $wrapper.find("p.ec-viewer-content").text();
        };

        return {
            getContent: getContent
        }
    }
})();