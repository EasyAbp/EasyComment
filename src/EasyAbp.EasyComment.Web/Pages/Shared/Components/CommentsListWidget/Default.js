(function () {
    $(document).on("click", ".ec-button-load-more", function () {
        const $action = $(this);
        const commentsZoneWidget = $action.closest(".ec-comments-zone");
        const itemType = commentsZoneWidget.attr("data-item-type");
        const itemKey = commentsZoneWidget.attr("data-item-key");
        const sorting = commentsZoneWidget.attr("data-sorting");
        const maxResultCount = commentsZoneWidget.attr("data-max-result-count");
        const loadedCount = $action.attr("data-loaded-count");

        $.get("/widgets/easyComment/showCommentsList", {
            itemType: itemType,
            itemKey: itemKey,
            sorting: sorting,
            loadedCount: loadedCount,
            maxResultCount: maxResultCount
        }, function (html) {
            $action.replaceWith($(html).find(".ec-comments-list").children());
        })
    });
})();