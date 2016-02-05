function onAjaxSuccess(data) {
    $('#results').html(data);
    $('table').dblclick(addBookForm);
}

function setValidators() {
    $('#enterName').change(function (nameField) {
        nameField.valueOf();
    })
}

function isNameValid() {
    var nameValue = $('#enterName').val();
    return nameValue != null && nameValue != '';
}

function isAuthorNameValid() {

}

function addBookForm() {
    if ($('#forWriting').length) {
        alert('Already added');
        return;
    }
    var enterNameInput = '<span><label for="enterName">Book Name</label>' +
        '<input id="enterName" type="text" name="Name" /></span>';
    var enterPageCountInput = '<span><label for="enterCount">Pages Count</label>' +
        '<input id="enterCount" type="number" name="PageCount" min="1" value="1" /></span>';
    var enterAuthorNameInput = '<span><label for="enterAuthor">Author</label>' +
        '<input id="enterAuthor" type="text" name="Author" /></span>';
    var enterDateInput = '<span><label for="enterDate">Receiving Date</label>' +
        '<input id="enterDate" type="text" name="ReceivingDate" /></span>';

    var newFormItem = '<br /><div id="forWriting">' + enterNameInput;
    newFormItem += enterAuthorNameInput;
    newFormItem += enterPageCountInput;
    newFormItem += (enterDateInput + '\n</div><br />');
    $('#results').append(newFormItem);
    $('span').css("margin", "1em");
    $('forWriting').css('overflow', 'scroll');
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