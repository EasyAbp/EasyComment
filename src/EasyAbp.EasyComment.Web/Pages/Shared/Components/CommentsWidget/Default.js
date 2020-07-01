$(function () {
    const l = abp.localization.getResource("EasyComment");
    const service = easyAbp.easyComment.comments.comment;

    const addNewComment = function(form, successMessage, replyTo) {
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
            replyTo: replyTo
        })
            .then(function () {
                widgetManager.refresh();
                abp.notify.info(successMessage);
            });
    };
    
    $(".ec-editor-button-publish").click(function (e) {
        e.preventDefault();
        const form = $(this).closest("form");
        if (!$(form).valid()) return;

        addNewComment(form, l("SuccessfullyPublishComment"))
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

        $(this).closest(".dropdown").hide();
        viewerWidget.hide();
        $.get("/widgets/easyComment/showCommentEditor", {
            id: commentId,
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
        commentDiv.find(".dropdown").show();
    };

    $(document).on("click", ".ec-editor-button-cancel", function () {
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

    $(document).on("click", ".ec-editor-button-save", function (e) {
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
        const replyTo = $(editorWidget).data("replyTo");

        if (replyTo) {
            addNewComment(form, l("SuccessfullyReplyComment"), replyTo);
        } else {
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
            });
        }
    });

    $(document).on("click", ".ec-action-reply", function () {
        const commentDiv = $(this).closest(".ec-comment");
        const creatorId = commentDiv.attr("data-creator-id");

        $(this).closest(".dropdown").hide();
        $.get("/widgets/easyComment/showCommentEditor", {
            label: l("Reply"),
            editModel: true,
        }, function (html) {
            commentDiv.find(".ec-comment-holder").append(html);
            const editorWidget = getEditorWidget(commentDiv);
            $(editorWidget).data("replyTo", creatorId);
        });
    });
})
