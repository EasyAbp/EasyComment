(function () {
    abp.widgets.commentViewerWidget = function ($wrapper) {
        var getContent = function () {
            return $wrapper.find("p.ec-content").text();
        }
        
        return {
            getContent: getContent
        }
    }
})();