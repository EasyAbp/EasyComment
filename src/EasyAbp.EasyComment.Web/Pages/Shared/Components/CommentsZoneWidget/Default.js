(function () {
    abp.widgets.CommentsZoneWidget = function ($wrapper) {
        const getFilters = function () {
            const commentsZoneWidget = $wrapper.find(".ec-comments-zone");
            const itemType = commentsZoneWidget.attr("data-item-type");
            const itemKey = commentsZoneWidget.attr("data-item-key");
            const sorting = commentsZoneWidget.attr("data-sorting");
            const maxResultCount = commentsZoneWidget.attr("data-max-result-count");

            return {
                itemType: itemType,
                itemKey: itemKey,
                sorting: sorting,
                maxResultCount: maxResultCount
            } 
        }

        return {
            getFilters: getFilters,
        };
    }
})();