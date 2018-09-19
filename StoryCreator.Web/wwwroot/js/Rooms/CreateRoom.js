
$(document).ready(function () {
    bindClickActionSubmitBtn();
    bindClickContentSubmitBtn();
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

