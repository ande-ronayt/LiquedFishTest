$(function () {
    Hide();
    $('.select-wrapper select').on('change', function () {
        var type = $('.select-wrapper select').val();
        Hide()
        if (type == 0) {
            $('#loadUrl').show();
        }
        else if (type == 2) {
            $('#uploadFile').show();
        }
    });
})

function Hide() {
    $('#loadUrl').hide();
    $('#uploadFile').hide();
}