$(function () {
    const l = abp.localization.getResource("EasyComment");
    const service = easyAbp.easyComment.comments.comment;

    $(".ec-button-publish").click(function (e) {
        e.preventDefault();

        const form = $(this).closest("form");
        if (!$(form).valid()) return;

        const commentsWidget = $(form).closest("[data-widget-name=CommentsWidget]");
        const widgetManager = new abp.WidgetManager({wrapper: $(commentsWidget).parent()});
        widgetManager.init();   
        
        const itemType = $(commentsWidget).find("#ItemType").val();
        const itemKey = $(commentsWidget).find("#ItemKey").val();
        const editorWidget = $(form).closest("[data-widget-name=CommentEditorWidget]");
        const content = abp.widgets.CommentEditorWidget($(editorWidget)).getContent();

        service.addComment({
            itemType: itemType,
            itemKey: itemKey,
            content: content,
            // TODO: replyTo: replyTo
        })
            .then(function () {
                widgetManager.refresh();
                abp.notify.info(l("SuccessfullyPublishComment"));
            });
    });

    const getViewerWidget = function (commentDiv) {
        return commentDiv.find(".ec-comment-holder [data-widget-name=CommentViewerWidget]")
    };

    const getEditorWidget = function (commentDiv) {
        return commentDiv.find(".ec-comment-holder [data-widget-name=CommentEditorWidget]")
    };

    $(document).on("click", ".ec-action-edit", function () {
        const commentDiv = $(this).closest(".ec-comment");
        const commentId = commentDiv.attr("data-comment-id");
        const viewerWidget = getViewerWidget(commentDiv);

        viewerWidget.hide();
        $.get("/widgets/easyComment/showCommentEditor", {
            id: commentId,
            showLabel: false,
            editModel: true,
        }, function (html) {
            commentDiv.find(".ec-comment-holder").append(html);
        })
    });

    $(document).on("change", "form :input", function () {
        $(this).closest('form').data('changed', true);
    });

    const cancelEdit = function (commentDiv) {
        getViewerWidget(commentDiv).show();
        getEditorWidget(commentDiv).remove();
    };

    $(document).on("click", ".ec-button-cancel", function () {
        const commentDiv = $(this).closest(".ec-comment");
        const form = $(this).closest("form");
        
        if ($(form).data('changed')) {
            abp.message.confirm(l("AreYouSureYouWantToCancelEditingWarningMessage"))
                .done(function (result) {
                    if (result) {
                        cancelEdit(commentDiv);
                    }
                })
        } else {
            cancelEdit(commentDiv);
        }
    });

    $(document).on("click", ".ec-button-edit", function (e) {
        e.preventDefault();

        const commentDiv = $(this).closest(".ec-comment");
        const form = $(this).closest("form"); 
        
        if (!$(form).valid()) return;
        
        if (!$(form).data('changed')) {
            cancelEdit(commentDiv);
            return;
        }
        
        const commentId = commentDiv.attr("data-comment-id");
        const viewerWidget = getViewerWidget(commentDiv);
        const editorWidget = getEditorWidget(commentDiv);

        service.updateContent({
            id: commentId,
            content: abp.widgets.CommentEditorWidget($(editorWidget)).getContent()
        }).then(function () {
            editorWidget.remove();
            const widgetManager = new abp.WidgetManager({
                wrapper: $(viewerWidget).parent(),
                filterCallback: function () {
                    return {
                        id: commentId,
                        fromServer: true
                    }
                }
            });
            widgetManager.init();
            widgetManager.refresh();
            abp.notify.info(l("SuccessfullyEditComment"));
        })
    });
})
