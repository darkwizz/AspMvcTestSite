function onAjaxSuccess(data) {
    $('#results').html(data);
    $('table').dblclick(addBookForm);
}

function addBookForm() {
    if ($('#forWriting').length) {
        alert('Already added');
        return;
    }
    var newFormItem = '<br /><div id="forWriting"><input type="text" name="Name" />';
    newFormItem += '<input type="number" name="PageCount" />';
    newFormItem += '<input type="text" name="Author" />';
    newFormItem += '<input type="text" name="ReceivingDate" /></div><br />';
    $('#results').append(newFormItem);
}

function sendSaveBookAjax(url, data) {
    $.ajax({
        url: url,
        type: 'POST',
        data: data,
        success: onAjaxSuccess,
        error: function (data) {
            alert('FAIL');
        }
    })
}

function sendGetListAjax(url) {
    $.ajax({
        url: url,
        type: 'GET',
        success: onAjaxSuccess,
        error: function (data) {
            alert('FAIL');
        }
    });
}