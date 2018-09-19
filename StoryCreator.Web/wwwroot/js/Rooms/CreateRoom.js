
$(document).ready(function () {
    bindClickActionSubmitBtn();
    bindClickContentSubmitBtn();
    bindClickSubmitBtn();
});

function bindClickActionSubmitBtn() {
    $('#submitActionBtn').click(function (evt) {
        onSubmitAction(evt);
    });
}

function bindClickContentSubmitBtn() {
    $('#submitContentBtn').click(function (evt) {
        onSubmitContent(evt);
    });
}

function bindClickSubmitBtn() {
    $('#submitBtn').click(function (evt) {
        onSubmitRoom(evt);
    });
}

function onSubmitAction(e) {

    e.preventDefault();

    $.ajax({
        type: 'post',
        url: './CreateRoomAction',
        data: $('#createRoomActionForm').serialize(),
        success: function (result) {
            $('#roomActions').empty().append(result);
            bindClickActionSubmitBtn();
        },
        error: function (result) {
        }

    });
}

function onSubmitContent(e) {
    $.ajax({
        type: 'post',
        url: './CreateRoomContent',
        data: $('#createRoomContentForm').serialize(),
        success: function (result) {
            $('#roomContents').empty().append(result);
            bindClickContentSubmitBtn();
        },
        error: function (result) {
        }

    });
}

function onSubmitRoom(e) {

    var roomFormData = $('#createRoomForm').serialize();
    var contentFormData = $('#createRoomContentForm').serialize();
    var actionFormData = $('#createRoomActionForm').serialize();
    var formData = roomFormData + '&' + contentFormData + '&' + actionFormData;

    $.ajax({
        type: 'post',
        url: './Create',
        data: formData,
        success: function (result) {
            $('#roomPage').parent().empty().append(result);
            bindClickContentSubmitBtn();
        },
        error: function (result) {
        }

    });
}

