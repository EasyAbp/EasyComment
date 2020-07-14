(function () {
    abp.widgets.CommentViewerWidget = function ($wrapper) {
        const getFilters = function () {
            const commentWidget = $wrapper.closest(".ec-comment");
            const commentId = commentWidget.attr("data-comment-id");

            return {
                id: commentId,
                fromServer: true
            }
        }
        
        const getContent = function () {
            return $wrapper.find("p.ec-viewer-content").text();
        };
        
        const getReferenceContent = function () {
            const content = getContent();
            return content.split('\n').map(s => `> ${s}`).join('\n');
        }

        return {
            getFilters: getFilters,
            getContent: getContent,
            getReferenceContent: getReferenceContent
        }
    }
})();