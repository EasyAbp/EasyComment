$(function () {

    var l = abp.localization.getResource("EasyComment");

    var service = easyAbp.easyComment.comments.comment;
    var createModal = new abp.ModalManager(abp.appPath + "EasyComment/Comments/CommentManagement/CreateModal");
    var editModal = new abp.ModalManager(abp.appPath + "EasyComment/Comments/CommentManagement/EditModal");

    var dataTable = $("#CommentTable").DataTable(abp.libs.datatables.normalizeConfiguration({
        processing: true,
        serverSide: true,
        paging: true,
        searching: false,
        autoWidth: false,
        scrollCollapse: true,
        order: [[1, "asc"]],
        ajax: abp.libs.datatables.createAjax(service.getList),
        columnDefs: [
            {
                rowAction: {
                    items:
                        [
                            {
                                text: l("Edit"),
                                visible: abp.auth.isGranted("EasyComment.Comment.Update"),
                                action: function (data) {
                                    editModal.open({ id: data.record.id });
                                }
                            },
                            {
                                text: l("Delete"),
                                visible: abp.auth.isGranted("EasyComment.Comment.Delete"),
                                confirmMessage: function (data) {
                                    return l("CommentDeletionConfirmationMessage");
                                },
                                action: function (data) {
                                        service.delete(data.record.id)
                                        .then(function () {
                                            abp.notify.info(l("SuccessfullyRemoveComment"));
                                            dataTable.ajax.reload();
                                        });
                                }
                            }
                        ]
                }
            },
            { data: "itemType" },
            { data: "itemKey" },
            { data: "content" },
            { data: "replyTo" },
        ]
    }));

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $("#NewCommentButton").click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});