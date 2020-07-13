(function () {
    abp.widgets.CommentViewerWidget = function ($wrapper) {
        const getContent = function () {
            return $wrapper.find("p.ec-viewer-content").text();
        };
        
        const getReferenceContent = function () {
            const content = getContent();
            return content.split('\n').map(s => `> ${s}`).join('\n');
        }

        return {
            getContent: getContent,
            getReferenceContent: getReferenceContent
        }
    }
})();