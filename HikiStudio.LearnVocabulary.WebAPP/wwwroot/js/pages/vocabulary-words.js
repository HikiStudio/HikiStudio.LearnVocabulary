var vocabularyWordsDatatable = $("#vocabularyWordsDatatable").DataTable({
    "lengthChange": false,
    "processing": true,
    "serverSide": true,
    "filter": true,
    "responsive": true,
    'language': {
        'loadingRecords': '&nbsp;',
        'processing': `<div class="spinner-border" style="width: 3rem; height: 3rem" role="status">
                        <span class="visually-hidden">Loading...</span>
                      </div>`
    },
    "pagingType": 'full_numbers',
    "ajax": {
        "url": "/vocabulary-words/get-paging-vocabulary-words/0",
        "type": "POST",
        "datatype": "json"
    },
    "columnDefs": [{
        orderable: false,
        className: 'select-checkbox',
        targets: 0,
    },
    {
        "orderable": false, "targets": 5
    },
    {
        targets: [1, 2, 3],
        className: 'wrap-text',
    },
    {
        className: "text-start",
        targets: [1, 2, 4]
    }
    ],
    "select": {
        style: 'multi',
        selector: 'td:first-child'
    },
    "order": [[5, 'desc']],
    "columns": [
        {
            "render": function (row, type, data) {
                return `<input type='checkbox' class='form-check-input bg-secondary ms' data-id='${data.vocabularyWordID}' /> `;
            },
        },
        { "data": "word", "name": "Word", "Width": "15%" },
        { "data": "definition", "name": "Definition", "Width": "25%" },
        { "data": "pronunciation", "name": "Pronunciation", "Width": "20%" },
        { "data": "exampleSentence", "name": "Example Sentence", "Width": "20%" },
        {
            "data": "dateCreated", "name": "DateCreated", "Width": "10%",
            "render": function (row, type, data) {
                return formatDateTimeToDDMMYYYYHHMM(data.dateCreated);
            }
        },
        {
            "name": "AudioClips", "Width": "10%",
            "render": function (row, type, data) {
                let html = "";

                if (data.audioClips.length > 0) {
                    data.audioClips.forEach((item) => {
                        html += `<a href="javascript:void(0)" onclick="playAudio(${item.audioClipID})" class="btn btn-info link-edit" style="background: transparent; border: none; color: #004d5c; padding: 0px;" ><i class="fa-solid fa-volume" style="color: #646462;"></i></a>`
                    })    
                }

                return `<div class="d-flex gap-2 justify-content-center">
                            ${html}
                        </div>`;
            }
        },
        {
            "render": function (row, type, data) {
                return `<div class="d-flex gap-2 justify-content-center">
                            <a href="javascript:void(0)" onclick="modalEdit(${data.vocabularyWordID})" class="btn btn-info link-edit" style="background: transparent; border: none; color: #004d5c; padding: 0px;" ><i class="fa-solid fa-pen-to-square"></i></a>
                            <a href="javascript:void(0)" class='btn btn-danger link-delete' onclick="modalDelete('${data.vocabularyWordID}', '${data.word}')" style="background: transparent; border: none; color: #dc3545; padding: 0px;"><i class="fa-solid fa-trash"></i></a>
                        </div>`;
            },
        },
    ]
});

vocabularyWordsDatatable.on('user-select', function (e, dt, type, cell, originalEvent) {
    let row = dt.row(cell.index().row);
    if (row.data().isDeleted === true) {
        e.preventDefault();
    }
});

$('#vocabularyWordsDatatable').on('page.dt', function () {
    $("#btn-deletecheckall").attr('disabled', 'true');
    $("#checkbox-all").prop('checked', false);
});


//#region search, sort, check datatable
$(document).ready(function () {
    $("#search").keyup(function () {
        $("#vocabularyWordsDatatable").dataTable().fnFilter(this.value);
        $("#checkbox-all").prop('checked', false);
        $("#btn-deletecheckall").attr('disabled', 'true');
    });
});

$(document).ready(function () {
    $('#vocabularyWordsDatatable_wrapper').find('div').first().remove();
});

$("th.sorting").on("click", function () {
    $("#checkbox-all").prop('checked', false);
    $("#btn-deletecheckall").attr('disabled', 'true');
})

$('tbody').on('click', 'td', function () {
    var countRow = vocabularyWordsDatatable.data().count();
    var count = $('#vocabularyWordsDatatable tbody').find("input[type='checkbox']:checked").length;
    if ($(this).hasClass("select-checkbox")) {
        if ($(this).parent().hasClass("selected")) {
            //uncheck
            $(this).find("input[type='checkbox']").prop('checked', false);
            count--;
        } else {
            //check
            let fieldCheckBox = $(this).find("input[type='checkbox']");
            if (fieldCheckBox.prop('disabled') !== true) {
                fieldCheckBox.prop('checked', true);
                count++;
            }
        }
    }

    if (count > 0) {
        $("#btn-deletecheckall").removeAttr('disabled');
    } else {
        $("#btn-deletecheckall").attr('disabled', 'true');
    }

    if (count == countRow) {
        $("#checkbox-all").prop('checked', true);
    }
    else {
        $("#checkbox-all").prop('checked', false);
    }
});
//#endregion

//#region validation form create vocabulary word
function CheckEnableSaveChange(event) {
    if ($('#form-create-vocabulary-word').validate().checkForm()) {
        $("#submit-create-vocabulary-word").removeAttr("disabled");
    }
    else {
        $("#submit-create-vocabulary-word").attr("disabled", "disabled");
    }
    return true;
}

$(document).on('click', '#btn-create', function () {
    $("#submit-create-vocabulary-word").attr("disabled", "disabled");
    $(".form-group.create .is-invalid").remove();
    let today = new Date().toISOString().split('T')[0];
    $('#form-create-vocabulary-word').find("input[name='CreateDate']").val(today);
});

$(document).ready(function () {
    $.validator.addMethod("validateName", function (value, element) {
        return this.optional(element) || /^\s*[a-zA-Z\s]+\s*$/.test(value);
    }, 'Numeric and Special characters are not allowed.');

    $.validator.addMethod("notFullSpaceName", function (value, element, param) {
        let matchValue = value.trim();
        return this.optional(element) || matchValue.length !== 0;
    }, "Please enter Name.");

    $('input').on('blur keyup', function (event) {
        CheckEnableSaveChange(event);
    })

    var formValidateCreate = $("#form-create-vocabulary-word").validate({
        errorClass: "is-invalid",
        validClass: "",
        highlight: function (element, errorClass, validClass) {
            $(element).addClass(errorClass).removeClass(validClass);
        },
        unhighlight: function (element, errorClass, validClass) {
            $(element).removeClass(errorClass).addClass(validClass);
        },
        onfocusout: function (element) { $(element).valid(); },
        onclick: function (element) { $(element).valid(); },
        rules: {
            "word": {
                required: true,
                notFullSpaceName: true,
                minlength: 1,
                maxlength: 200,
                validateName: true,
            },
            "definition": {
                required: true,
                notFullSpaceName: true,
                minlength: 1,
                maxlength: 500,
            },
            "pronunciation": {
                required: true,
                notFullSpaceName: true,
                minlength: 1,
                maxlength: 500,
            },
            "example-sentence": {
                notFullSpaceName: true,
                minlength: 1,
                maxlength: 1000,
            },
            "example-sentence-meaning": {
                notFullSpaceName: true,
                minlength: 1,
                maxlength: 1000,
            },
            "synonyms": {
                notFullSpaceName: true,
                minlength: 1,
                maxlength: 1000,
            },
            "antonyms": {
                notFullSpaceName: true,
                minlength: 1,
                maxlength: 1000,
            },
        },
        messages: {
            "word": {
                required: "Please enter Word.",
                notFullSpaceName: "Please enter Word.",
                minlength: "Word must be from 1 to 200 characters.",
                maxlength: "Word must be from 1 to 200 characters.",
                validateName: "Numeric and Special characters are not allowed.",
            },
            "definition": {
                required: "Please enter Definition.",
                notFullSpaceName: "Please enter Definition.",
                minlength: "Definition must be from 1 to 500 characters.",
                maxlength: "Definition must be from 1 to 500 characters.",
            },
            "pronunciation": {
                required: "Please enter Pronunciation.",
                notFullSpaceName: "Please enter Pronunciation.",
                minlength: "Pronunciation must be from 1 to 500 characters.",
                maxlength: "Pronunciation must be from 1 to 500 characters.",
            },
            "example-sentence": {
                notFullSpaceName: "Please enter Example Sentence.",
                minlength: "Example Sentence must be from 1 to 1000 characters.",
                maxlength: "Example Sentence must be from 1 to 1000 characters.",
            },
            "example-sentence-meaning": {
                notFullSpaceName: "Please enter Example Sentence Meaning.",
                minlength: "Example Sentence Meaning must be from 1 to 1000 characters.",
                maxlength: "Example Sentence Meaning must be from 1 to 1000 characters.",
            },
            "synonyms": {
                notFullSpaceName: "Please enter Synonyms.",
                minlength: "Synonyms must be from 1 to 1000 characters.",
                maxlength: "Synonyms must be from 1 to 1000 characters.",
            },
            "antonyms": {
                notFullSpaceName: "Please enter Antonyms.",
                minlength: "Antonyms must be from 1 to 1000 characters.",
                maxlength: "Antonyms must be from 1 to 1000 characters.",
            },
        },
        submitHandler: function (form, event) {
            event.preventDefault();

            let word = $(form).find('input[name="word"]').val();
            let vocabularyTypeID = $('#vocabulary-types-create').find(":selected").val();
            let definition = $(form).find('input[name="definition"]').val();
            let pronunciation = $(form).find('input[name="pronunciation"]').val();
            let exampleSentence = $(form).find('input[name="example-sentence"]').val();
            let exampleSentenceMeaning = $(form).find('input[name="example-sentence-meaning"]').val();
            let synonyms = $(form).find('input[name="synonyms"]').val();
            let antonyms = $(form).find('input[name="antonyms"]').val();

            let createVocabularyTypeRequest = {
                word: word,
                vocabularyTypeID: vocabularyTypeID,
                definition: definition,
                pronunciation: pronunciation,
                exampleSentence: exampleSentence,
                exampleSentenceMeaning: exampleSentenceMeaning,
                synonyms: synonyms,
                antonyms: antonyms,
            };

            $.ajax({
                method: "POST",
                url: `vocabulary-words/create-vocabulary-word`,
                data: JSON.stringify(createVocabularyTypeRequest),
                headers: {
                    "Content-Type": "application/json;",
                },
                processData: false,
                contentType: false,
                datatype: 'json',
                beforeSend: function () {
                    showLoadingOverlay();
                },
                complete: function () {
                    hideLoadingOverlay();
                }
            })
                .done(function (response) {
                    if (response.isSuccessed === true) {
                        const truck_modal = document.querySelector('#modal-create');
                        const modal = bootstrap.Modal.getInstance(truck_modal);
                        //modal.hide();
                        ShowToastSuccess(response.message);

                        $('#form-create-vocabulary-word :input[type="text"]').val('');
                        $('#form-create-vocabulary-word :input[type="date"]').val('');
                        vocabularyWordsDatatable.ajax.reload();
                        $("#form-create-vocabulary-word").validate().resetForm();
                        return;
                    }
                    else {
                        ShowToastError(response.message);
                    }

                })
                .fail(function (jqXHR, textStatus, errorThrown) {
                    ShowToastError(jqXHR.responseJSON.message);
                });
        }
    });

    $(document).on('click', '#cancel-create-vocabulary-word', function () {
        const truck_modal = document.querySelector('#modal-create');
        const modal = bootstrap.Modal.getInstance(truck_modal);
        modal.hide();
        $('#form-create-vocabulary-word :input[type="text"]').val('');
        $('#form-create-vocabulary-word :input[type="date"]').val('');
        formValidateCreate.resetForm();
    });
});
//#endregion

//#region validation form edit vocabulary word
var vocabularyWordIDEdit = null;
function modalEdit(vocabularyWordID) {
    vocabularyWordIDEdit = vocabularyWordID;
    $(".form-group.edit .is-invalid").remove();
    $('#submit-edit-vocabulary-word').prop('disabled', 'disabled');

    var myModal = new bootstrap.Modal(document.getElementById('modal-edit'), {
        keyboard: false
    })

    $.ajax({
        method: "GET",
        url: `/vocabulary-words/get-vocabulary-word-by-vocabulary-word-id/${vocabularyWordID}`,
    })
        .done(function (response) {
            if (response.isSuccessed === true) {
                let getModalEdit = $("#modal-edit");

                getModalEdit.find("input[name='word']").val(response.resultObj.word);
                getModalEdit.find("select[name='vocabulary-types-update']").val(response.resultObj.vocabularyTypeID);
                getModalEdit.find("input[name='definition']").val(response.resultObj.definition);
                getModalEdit.find("input[name='pronunciation']").val(response.resultObj.pronunciation);
                getModalEdit.find("input[name='example-sentence']").val(response.resultObj.exampleSentence);
                getModalEdit.find("input[name='example-sentence-meaning']").val(response.resultObj.exampleSentenceMeaning);
                getModalEdit.find("input[name='synonyms']").val(response.resultObj.synonyms);
                getModalEdit.find("input[name='antonyms']").val(response.resultObj.antonyms);
                getModalEdit.find("input[name='date-created']").val(new Date(response.resultObj.dateCreated).toISOString().split('T')[0]);

                var $form = $('#form-edit-vocabulary-word'),
                    origForm = $form.serialize();
                $('form :input').on('change input', function () {
                    if ($form.serialize() !== origForm) {
                        $('#submit-edit-vocabulary-word').prop('disabled', false);
                    }
                    else {
                        $('#submit-edit-vocabulary-word').prop('disabled', true);
                    }
                    if ($("#form-edit-vocabulary-word").valid() == false) {
                        $('#submit-edit-vocabulary-word').prop('disabled', true);
                    }
                });

                myModal.show();
            }
            else {
                ShowToastError(response.message);
            }
        })
        .fail(function (jqXHR, textStatus, errorThrown) {
            ShowToastError(jqXHR.responseJSON.message);
        });
    return;
}

$(document).ready(function () {
    $.validator.addMethod("validateName", function (value, element) {
        return this.optional(element) || /^\s*[a-zA-Z\s]+\s*$/.test(value);
    }, 'Numeric and Special characters are not allowed.');

    $.validator.addMethod("notFullSpaceName", function (value, element, param) {
        let matchValue = value.trim();
        return this.optional(element) || matchValue.length !== 0;
    }, "Please enter Name.");

    var formValidateEdit = $("#form-edit-vocabulary-word").validate({
        errorClass: "is-invalid",
        validClass: "",
        highlight: function (element, errorClass, validClass) {
            $(element).addClass(errorClass).removeClass(validClass);
        },
        unhighlight: function (element, errorClass, validClass) {
            $(element).removeClass(errorClass).addClass(validClass);
        },
        onfocusout: function (element) { $(element).valid(); },
        onclick: function (element) { $(element).valid(); },
        rules: {
            "word": {
                required: true,
                notFullSpaceName: true,
                minlength: 1,
                maxlength: 200,
                validateName: true,
            },
            "definition": {
                required: true,
                notFullSpaceName: true,
                minlength: 1,
                maxlength: 500,
            },
            "pronunciation": {
                required: true,
                notFullSpaceName: true,
                minlength: 1,
                maxlength: 500,
            },
            "example-sentence": {
                notFullSpaceName: true,
                minlength: 1,
                maxlength: 1000,
            },
            "example-sentence-meaning": {
                notFullSpaceName: true,
                minlength: 1,
                maxlength: 1000,
            },
            "synonyms": {
                notFullSpaceName: true,
                minlength: 1,
                maxlength: 1000,
            },
            "antonyms": {
                notFullSpaceName: true,
                minlength: 1,
                maxlength: 1000,
            },
        },
        messages: {
            "word": {
                required: "Please enter Word.",
                notFullSpaceName: "Please enter Word.",
                minlength: "Word must be from 1 to 200 characters.",
                maxlength: "Word must be from 1 to 200 characters.",
                validateName: "Numeric and Special characters are not allowed.",
            },
            "definition": {
                required: "Please enter Definition.",
                notFullSpaceName: "Please enter Definition.",
                minlength: "Definition must be from 1 to 500 characters.",
                maxlength: "Definition must be from 1 to 500 characters.",
            },
            "pronunciation": {
                required: "Please enter Pronunciation.",
                notFullSpaceName: "Please enter Pronunciation.",
                minlength: "Pronunciation must be from 1 to 500 characters.",
                maxlength: "Pronunciation must be from 1 to 500 characters.",
            },
            "example-sentence": {
                notFullSpaceName: "Please enter Example Sentence.",
                minlength: "Example Sentence must be from 1 to 1000 characters.",
                maxlength: "Example Sentence must be from 1 to 1000 characters.",
            },
            "example-sentence-meaning": {
                notFullSpaceName: "Please enter Example Sentence Meaning.",
                minlength: "Example Sentence Meaning must be from 1 to 1000 characters.",
                maxlength: "Example Sentence Meaning must be from 1 to 1000 characters.",
            },
            "synonyms": {
                notFullSpaceName: "Please enter Synonyms.",
                minlength: "Synonyms must be from 1 to 1000 characters.",
                maxlength: "Synonyms must be from 1 to 1000 characters.",
            },
            "antonyms": {
                notFullSpaceName: "Please enter Antonyms.",
                minlength: "Antonyms must be from 1 to 1000 characters.",
                maxlength: "Antonyms must be from 1 to 1000 characters.",
            },
        },
        submitHandler: function (form, event) {
            event.preventDefault();

            let word = $(form).find('input[name="word"]').val();
            let vocabularyTypeID = $('#vocabulary-types-update').find(":selected").val();
            let definition = $(form).find('input[name="definition"]').val();
            let pronunciation = $(form).find('input[name="pronunciation"]').val();
            let exampleSentence = $(form).find('input[name="example-sentence"]').val();
            let exampleSentenceMeaning = $(form).find('input[name="example-sentence-meaning"]').val();
            let synonyms = $(form).find('input[name="synonyms"]').val();
            let antonyms = $(form).find('input[name="antonyms"]').val();

            let updateVocabularyTypeRequest = {
                word: word,
                vocabularyTypeID: vocabularyTypeID,
                definition: definition,
                pronunciation: pronunciation,
                exampleSentence: exampleSentence,
                exampleSentenceMeaning: exampleSentenceMeaning,
                synonyms: synonyms,
                antonyms: antonyms,
            };

            if (vocabularyWordIDEdit !== null && vocabularyWordIDEdit !== undefined && vocabularyWordIDEdit > 0) {
                $.ajax({
                    method: "PUT",
                    url: `vocabulary-words/update-vocabulary-word/${vocabularyWordIDEdit}`,
                    data: JSON.stringify(updateVocabularyTypeRequest),
                    headers: {
                        "Content-Type": "application/json;",
                    },
                    processData: false,
                    contentType: false,
                    datatype: 'json',
                    beforeSend: function () {
                        showLoadingOverlay();
                    },
                    complete: function () {
                        hideLoadingOverlay();
                    }
                })
                    .done(function (response) {
                        vocabularyWordIDEdit = null;
                        if (response.isSuccessed === true) {
                            const truck_modal = document.querySelector('#modal-edit');
                            const modal = bootstrap.Modal.getInstance(truck_modal);
                            modal.hide();
                            ShowToastSuccess(response.message);

                            $('#form-edit-vocabulary-word :input[type="text"]').val('');
                            $('#form-edit-vocabulary-word :input[type="date"]').val('');
                            vocabularyWordsDatatable.ajax.reload();
                            $("#form-edit-vocabulary-word").validate().resetForm();
                            return;
                        }
                        else {
                            ShowToastError(response.message);
                        }

                    })
                    .fail(function (jqXHR, textStatus, errorThrown) {
                        ShowToastError(jqXHR.responseJSON.message);
                    });
            }
            else {
                ShowToastError("No vocabulary word selected for editing.");
            }
        }
    });

    $(document).on('click', '#cancel-edit-vocabulary-word', function () {
        const truck_modal = document.querySelector('#modal-edit');
        const modal = bootstrap.Modal.getInstance(truck_modal);
        modal.hide();

        $('#form-edit-vocabulary-word :input[type="text"]').val('');
        $('#form-edit-vocabulary-word :input[type="date"]').val('');
        formValidateEdit.resetForm();
    });
});
//#endregion

//#region delete one vocabulary word
var vocabularyWordIDDelete;
function modalDelete(vocabularyWordID, word) {
    let modalDelete = new bootstrap.Modal(document.getElementById('modal-delete'), {
        keyboard: false
    })
    modalDelete.show();
    $("#vocabularyWordIDDelete").html(`<b>${word}</b>`);
    vocabularyWordIDDelete = vocabularyWordID;
}

$("button#btn-delete").on("click", function (event) {
    event.preventDefault();
    const truck_modal = document.querySelector('#modal-delete');
    const modal = bootstrap.Modal.getInstance(truck_modal);

    $.ajax({
        method: "DELETE",
        url: `/vocabulary-words/delete-vocabulary-word/${vocabularyWordIDDelete}`,
        headers: {
            "Content-Type": "application/json;",
        },
        datatype: 'json',
    })
        .done(function (response) {
            if (response.isSuccessed === true) {
                ShowToastSuccess(response.message);
                vocabularyWordsDatatable.ajax.reload();
            }
            else {
                ShowToastError(response.message);
            }

            vocabularyWordsDatatable.rows().deselect();
            $("#btn-deletecheckall").attr('disabled', 'true');
            $('input[type="checkbox"]').prop('checked', false);
            modal.hide();
            return;
        })
        .fail(function (jqXHR, textStatus, errorThrown) {
            ShowToastError(jqXHR.responseJSON.message);
        });
});
//#endregion

function playAudio(audioClipID) {
    fetch(`${URLServer}/api/mp3/open/${audioClipID}`)
        .then(response => {
            if (response.ok) {
                return response.blob();
            }
            ShowToastError("Không thể tải âm thanh.");
        })
        .then(blob => {
            const audioURL = URL.createObjectURL(blob);
            audioPlayer.src = audioURL;
            audioPlayer.play();
        })
        .catch(error => {
            console.error(error);
        });

}

