(function () {
    abp.widgets.CommentViewerWidget = function ($wrapper) {
        var getContent = function () {
            return $wrapper.find("p.ec-content").text();
        }
        
        return {
            getContent: getContent
        }
    }
})();