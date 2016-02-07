function onAjaxSuccess(data) {
    $('#results').html(data);
    $('#booksGridHeader').dblclick(addBookForm);
    $('table').dblclick(addBookForm);
    removeFillBookInfoFields();
}

function onAddFormSubmit() {
    var form = $('#saveBookForm');
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
    var enterNameInput = '<div id="forWriting"><span><label for="enterName">Book Name</label>' +
        '<input id="enterName" type="text" name="Name" /></span>';
    var enterPageCountInput = '<span><label for="enterCount">Pages Count</label>' +
        '<input id="enterCount" type="number" name="PageCount" min="1" value="1" /></span>';
    var enterAuthorNameInput = '<span><label for="enterAuthor">Author</label>' +
        '<input id="enterAuthor" type="text" name="Author" /></span>';
    var enterDateInput = '<span><label for="enterDate">Receiving Date</label>' +
        '<input id="enterDate" type="text" name="ReceivingDate" /></span>\n\n';
    var submitInput = '<br /><br /><input type="submit" class="btn" value="Save Book" />\n';
    var cancelInput = '<input type="button" class="btn" value="Cancel" onclick="removeFillBookInfoFields()" /></div>'

    var newFormItem = enterNameInput;
    newFormItem += enterAuthorNameInput;
    newFormItem += enterPageCountInput;
    newFormItem += enterDateInput;
    newFormItem += submitInput;
    newFormItem += cancelInput;
    $('#saveBookForm').append(newFormItem);
    $('span').css("margin", "1em");
}

function sendAjax(url, data) {
    $.ajax({
        url: url,
        type: 'POST',
        data: data,
        success: onAjaxSuccess,
        error: function (data) {
            alert('FAIL');
            removeFillBookInfoFields();
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
            removeFillBookInfoFields();
        }
    });
}

function removeFillBookInfoFields() {
    var forWriting = $('#forWriting');
    if (forWriting) {
        $('#forWriting').remove();
    }
}