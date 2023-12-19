var vocabularyTypesDatatable = $("#vocabularyTypesDatatable").DataTable({
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
        "url": "/vocabulary-types/get-paging-vocabulary-types",
        "type": "POST",
        "datatype": "json"
    },
    "columnDefs": [{
        orderable: false,
        className: 'select-checkbox',
        targets: 0,
    },
    {
        "orderable": false, "targets": 2
    },
    {
        targets: [1],
        className: 'wrap-text',
    },
    {
        className: "text-start",
        targets: [1]
    }
    ],
    "select": {
        style: 'multi',
        selector: 'td:first-child'
    },
    "order": [[2, 'desc']],
    "columns": [
        {
            "Width": "5%",
            "render": function (row, type, data) {
                return `<input type='checkbox' class='form-check-input bg-secondary ms' data-id='${data.vocabularyTypeID}' /> `;
            },
        },
        { "data": "vocabularyTypeName", "name": "VocabularyTypeName", "Width": "75%" },
        {
            "data": "dateCreated", "name": "DateCreated", "Width": "100px",
            "render": function (row, type, data) {
                return formatDateTimeToDDMMYYYYHHMM(data.dateCreated);
            }
        },
        {
            "Width": "10%",
            "render": function (row, type, data) {
                return `<div class="d-flex gap-2 justify-content-center">
                            <a href="javascript:void(0)" onclick="modalUpdate(${data.vocabularyTypeID})" class="btn btn-info link-edit" style="background: transparent; border: none; color: #004d5c; padding: 0px;" ><i class="fa-solid fa-pen-to-square"></i></a>
                            <a href="javascript:void(0)" class='btn btn-danger link-delete' onclick="modalDelete('${data.vocabularyTypeID}', '${data.vocabularyTypeName}')" style="background: transparent; border: none; color: #dc3545; padding: 0px;"><i class="fa-solid fa-trash"></i></a>
                        </div>`;
            },
        },
    ]
});

vocabularyTypesDatatable.on('user-select', function (e, dt, type, cell, originalEvent) {
    let row = dt.row(cell.index().row);
    if (row.data().isDeleted === true) {
        e.preventDefault();
    }
});

$('#vocabularyTypesDatatable').on('page.dt', function () {
    $("#btn-deletecheckall").attr('disabled', 'true');
    $("#checkbox-all").prop('checked', false);
});


//#region search, sort, check datatable
$(document).ready(function () {
    $("#search").keyup(function () {
        $("#vocabularyTypesDatatable").dataTable().fnFilter(this.value);
        $("#checkbox-all").prop('checked', false);
        $("#btn-deletecheckall").attr('disabled', 'true');
    });
});

$(document).ready(function () {
    $('#vocabularyTypesDatatable_wrapper').find('div').first().remove();
});

$("th.sorting").on("click", function () {
    $("#checkbox-all").prop('checked', false);
    $("#btn-deletecheckall").attr('disabled', 'true');
})

$('tbody').on('click', 'td', function () {
    var countRow = vocabularyTypesDatatable.data().count();
    var count = $('#vocabularyTypesDatatable tbody').find("input[type='checkbox']:checked").length;
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

//#region validation form create vocabulary type
function CheckEnableSaveChange(event) {
    if ($('#form-create-vocabulary-type').validate().checkForm()) {
        $("#submit-create-vocabulary-type").removeAttr("disabled");
        $("#submit-update-vocabulary-type").removeAttr("disabled");
    }
    else {
        $("#submit-create-vocabulary-type").attr("disabled", "disabled");
    }
    return true;
}

$(document).on('click', '#btn-create', function () {
    $("#submit-create-vocabulary-type").attr("disabled", "disabled");
    $(".form-group.create .is-invalid").remove();
    let today = new Date().toISOString().split('T')[0];
    $('#form-create-vocabulary-type').find("input[name='date-created']").val(today);
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

    var formValidateCreate = $("#form-create-vocabulary-type").validate({
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
            "vocabulary-type-name": {
                required: true,
                notFullSpaceName: true,
                minlength: 1,
                maxlength: 200,
            },
        },
        messages: {
            "vocabulary-type-name": {
                required: "Please enter Vocabulary Type Name.",
                notFullSpaceName: "Please enter Vocabulary Type Name.",
                minlength: "Vocabulary Type Name must be from 1 to 200 characters.",
                maxlength: "Vocabulary Type Name must be from 1 to 200 characters.",
            },
        },
        submitHandler: function (form, event) {
            event.preventDefault();

            let vocabularyTypeName = $(form).find('input[name="vocabulary-type-name"]').val();

            let createVocabularyType = {
                "VocabularyTypeName": vocabularyTypeName
            };

            $.ajax({
                method: "POST",
                url: `vocabulary-types/create-vocabulary-type`,
                data: JSON.stringify(createVocabularyType),
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
                        modal.hide();
                        ShowToastSuccess(response.message);

                        $('#form-create-vocabulary-type :input[type="text"]').val('');
                        $('#form-create-vocabulary-type :input[type="date"]').val('');
                        vocabularyTypesDatatable.ajax.reload();
                        $("#form-create-vocabulary-type").validate().resetForm();
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

    $(document).on('click', '#cancel-create-vocabulary-type', function () {
        const truck_modal = document.querySelector('#modal-create');
        const modal = bootstrap.Modal.getInstance(truck_modal);
        modal.hide();
        $('#form-create-vocabulary-type :input[type="text"]').val('');
        $('#form-create-vocabulary-type :input[type="date"]').val('');
        formValidateCreate.resetForm();
    });
});
//#endregion

//#region validation form edit vocabulary type
var vocabularyTypeIDUpdate = null;
function modalUpdate(vocabularyTypeID) {
    vocabularyTypeIDUpdate = vocabularyTypeID;
    $(".form-group.edit .is-invalid").remove();
    $('#submit-update-vocabulary-type').prop('disabled', 'disabled');

    var myModal = new bootstrap.Modal(document.getElementById('modal-edit'), {
        keyboard: false
    })

    $.ajax({
        method: "GET",
        url: `/vocabulary-types/get-vocabulary-type-by-vocabulary-type-id/${vocabularyTypeID}`,
    })
        .done(function (response) {
            if (response.isSuccessed === true) {
                let getModalUpdate = $("#modal-edit");

                getModalUpdate.find("input[name='vocabulary-type-name']").val(response.resultObj.vocabularyTypeName);
                getModalUpdate.find("input[name='date-created']").val(new Date(response.resultObj.dateCreated).toISOString().split('T')[0]);

                var $form = $('#form-edit-vocabulary-word'),
                    origForm = $form.serialize();
                $('form :input').on('change input', function () {
                    if ($form.serialize() !== origForm) {
                        $('#submit-update-vocabulary-type').prop('disabled', false);
                    }
                    else {
                        $('#submit-update-vocabulary-type').prop('disabled', true);
                    }
                    if ($("#form-update-vocabulary-type").valid() == false) {
                        $('#submit-update-vocabulary-type').prop('disabled', true);
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

    var formValidateEdit = $("#form-update-vocabulary-type").validate({
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
            "vocabulary-type-name": {
                required: true,
                notFullSpaceName: true,
                minlength: 1,
                maxlength: 200,
            },
        },
        messages: {
            "vocabulary-type-name": {
                required: "Please enter Vocabulary Type Name.",
                notFullSpaceName: "Please enter Vocabulary Type Name.",
                minlength: "Vocabulary Type Name must be from 1 to 200 characters.",
                maxlength: "Vocabulary Type Name must be from 1 to 200 characters.",
            },
        },
        submitHandler: function (form, event) {
            event.preventDefault();

            let vocabularyTypeName = $(form).find('input[name="vocabulary-type-name"]').val();

            let updateVocabularyType = {
                "VocabularyTypeName": vocabularyTypeName
            };

            if (vocabularyTypeIDUpdate !== null && vocabularyTypeIDUpdate !== undefined && vocabularyTypeIDUpdate > 0) {
                $.ajax({
                    method: "PUT",
                    url: `vocabulary-types/update-vocabulary-type/${vocabularyTypeIDUpdate}`,
                    data: JSON.stringify(updateVocabularyType),
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

                            $('#form-update-vocabulary-type :input[type="text"]').val('');
                            $('#form-update-vocabulary-type :input[type="date"]').val('');
                            vocabularyTypesDatatable.ajax.reload();
                            $("#form-update-vocabulary-type").validate().resetForm();
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
                ShowToastError("No vocabulary type selected for editing.");
            }
        }
    });

    $(document).on('click', '#cancel-update-vocabulary-type', function () {
        const truck_modal = document.querySelector('#modal-edit');
        const modal = bootstrap.Modal.getInstance(truck_modal);
        modal.hide();

        $('#form-update-vocabulary-type :input[type="text"]').val('');
        $('#form-update-vocabulary-type :input[type="date"]').val('');
        formValidateEdit.resetForm();
    });
});
//#endregion

//#region delete one vocabulary type
var vocabularyTypeIDDelete;
function modalDelete(vocabularyTypeID, vocabularyTypeName) {
    let modalDelete = new bootstrap.Modal(document.getElementById('modal-delete'), {
        keyboard: false
    })
    modalDelete.show();
    $("#vocabularyTypeIDDelete").html(`<b>${vocabularyTypeName}</b>`);
    vocabularyTypeIDDelete = vocabularyTypeID;
}

$("button#btn-delete").on("click", function (event) {
    event.preventDefault();
    const truck_modal = document.querySelector('#modal-delete');
    const modal = bootstrap.Modal.getInstance(truck_modal);

    $.ajax({
        method: "DELETE",
        url: `/vocabulary-types/delete-vocabulary-type/${vocabularyTypeIDDelete}`,
        headers: {
            "Content-Type": "application/json;",
        },
        datatype: 'json',
    })
        .done(function (response) {
            if (response.isSuccessed === true) {
                ShowToastSuccess(response.message);
                vocabularyTypesDatatable.ajax.reload();
            }
            else {
                ShowToastError(response.message);
            }

            vocabularyTypesDatatable.rows().deselect();
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



