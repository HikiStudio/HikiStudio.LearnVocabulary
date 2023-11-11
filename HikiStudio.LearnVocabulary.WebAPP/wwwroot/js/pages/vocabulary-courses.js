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
        "url": "/vocabulary-courses/get-paging-courses",
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
        targets: [1, 2, 3]
    }
    ],
    "select": {
        style: 'multi',
        selector: 'td:first-child'
    },
    "order": [[4, 'desc']],
    "columns": [
        {
            "render": function (row, type, data) {
                return `<input type='checkbox' class='form-check-input bg-secondary ms' data-id='${data.vocabularyWordID}' /> `;
            },
        },
        { "data": "courseName", "name": "CourseName", "Width": "15%" },
        { "data": "courseCode", "name": "CourseCode", "Width": "15%" },
        { "data": "description", "name": "Description", "Width": "25%" },
        {
            "data": "dateCreated", "name": "DateCreated", "Width": "10%",
            "render": function (row, type, data) {
                return formatDateTimeToDDMMYYYYHHMM(data.dateCreated);
            }
        },
        {
            "render": function (row, type, data) {
                return `<div class="d-flex gap-2 justify-content-center">
                            <a href="javascript:void(0)" onclick="modalEdit(${data.courseID})" class="btn btn-info link-edit" style="background: transparent; border: none; color: #004d5c; padding: 0px;" ><i class="fa-solid fa-pen-to-square"></i></a>
                            <a href="javascript:void(0)" class='btn btn-danger link-delete' onclick="modalDelete('${data.courseID}', '${data.courseName}')" style="background: transparent; border: none; color: #dc3545; padding: 0px;"><i class="fa-solid fa-trash"></i></a>
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
    if ($('#form-create-course').validate().checkForm() && selectGenres.getValue().length != 0) {
        $("#submit-create-course").removeAttr("disabled");
    }
    else {
        $("#submit-create-course").attr("disabled", "disabled");
    }
    return true;
}

$(document).on('click', '#btn-create', function () {
    $("#submit-create-course").attr("disabled", "disabled");
    $(".form-group.create .is-invalid").remove();
    let today = new Date().toISOString().split('T')[0];
    $('#form-create-course').find("input[name='CreateDate']").val(today);
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

    var formValidateCreate = $("#form-create-course").validate({
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
            "course-name": {
                required: true,
                notFullSpaceName: true,
                minlength: 1,
                maxlength: 200,
                validateName: true,
            },
            "description": {
                notFullSpaceName: true,
                minlength: 1,
                maxlength: 500,
            },
        },
        messages: {
            "course-name": {
                required: "Please enter Course Name.",
                notFullSpaceName: "Please enter Course Name.",
                minlength: "Course Name must be from 1 to 200 characters.",
                maxlength: "Course Name must be from 1 to 200 characters.",
                validateName: "Numeric and Special characters are not allowed.",
            },
            "description": {
                notFullSpaceName: "Please enter Description.",
                minlength: "Description must be from 1 to 500 characters.",
                maxlength: "Description must be from 1 to 500 characters.",
            },
        },
        submitHandler: function (form, event) {
            event.preventDefault();

            let courseName = $(form).find('input[name="course-name"]').val();
            let description = $(form).find('input[name="description"]').val();
            let courseType = $('#course-type').find(":selected").val();

            let vocabularyWordIDs = [];
            $('#select-genre option:selected').each(function (i, selectedelement) {
                vocabularyWordIDs[i] = $(selectedelement).val() * 1;
            })

            let createCourse = {
                courseName: courseName,
                description: description,
                vocabularyWordIDs: vocabularyWordIDs,
                courseType: courseType * 1
            };

            $.ajax({
                method: "POST",
                url: `vocabulary-courses/create-course`,
                data: JSON.stringify(createCourse),
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

                        $('#form-create-course :input[type="text"]').val('');
                        $('#form-create-course :input[type="date"]').val('');
                        vocabularyWordsDatatable.ajax.reload();
                        $("#form-create-course").validate().resetForm();
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

    $(document).on('click', '#cancel-create-course', function () {
        const truck_modal = document.querySelector('#modal-create');
        const modal = bootstrap.Modal.getInstance(truck_modal);
        modal.hide();
        $('#form-create-course :input[type="text"]').val('');
        $('#form-create-course :input[type="date"]').val('');
        formValidateCreate.resetForm();
    });
});
//#endregion

//#region validation form edit vocabulary word
var courseIDUpdate = null;
function modalEdit(courseID) {
    courseIDUpdate = courseID;
    $(".form-group.edit .is-invalid").remove();
    $('#submit-edit-course').prop('disabled', 'disabled');

    var myModal = new bootstrap.Modal(document.getElementById('modal-edit'), {
        keyboard: false
    })

    $.ajax({
        method: "GET",
        url: `/vocabulary-courses/get-course-by-course-id/${courseIDUpdate}`,
    })
        .done(function (response) {
            if (response.isSuccessed === true) {
                let getModalEdit = $("#modal-edit");

                getModalEdit.find("input[name='course-name']").val(response.resultObj.courseName);
                getModalEdit.find("select[name='course-type']").val(response.resultObj.courseType);
                getModalEdit.find("input[name='description']").val(response.resultObj.description);
                getModalEdit.find("input[name='date-created']").val(new Date(response.resultObj.dateCreated).toISOString().split('T')[0]);
                let vocabularyWordOfCourseID = []
                for (var i = 0; i < response.resultObj.vocabularyWords.length; i++) {
                    vocabularyWordOfCourseID.push(response.resultObj.vocabularyWords[i].vocabularyWordID + "");
                }
                selectVocabularyWordsUpdate.removeActiveItems();
                selectVocabularyWordsUpdate.setChoiceByValue(vocabularyWordOfCourseID);
                var $form = $('#form-edit-course'),
                    origForm = $form.serialize();
                $('form :input').on('change input', function () {
                    if ($form.serialize() !== origForm) {
                        $('#submit-edit-course').prop('disabled', false);
                    }
                    else {
                        $('#submit-edit-course').prop('disabled', true);
                    }
                    if ($("#form-edit-course").valid() == false) {
                        $('#submit-edit-course').prop('disabled', true);
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

    var formValidateEdit = $("#form-edit-course").validate({
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
            "course-name": {
                required: true,
                notFullSpaceName: true,
                minlength: 1,
                maxlength: 200,
                validateName: true,
            },
            "description": {
                notFullSpaceName: true,
                minlength: 1,
                maxlength: 500,
            },
        },
        messages: {
            "course-name": {
                required: "Please enter Course Name.",
                notFullSpaceName: "Please enter Course Name.",
                minlength: "Course Name must be from 1 to 200 characters.",
                maxlength: "Course Name must be from 1 to 200 characters.",
                validateName: "Numeric and Special characters are not allowed.",
            },
            "description": {
                notFullSpaceName: "Please enter Description.",
                minlength: "Description must be from 1 to 500 characters.",
                maxlength: "Description must be from 1 to 500 characters.",
            },
        },
        submitHandler: function (form, event) {
            event.preventDefault();

            let courseName = $(form).find('input[name="course-name"]').val();
            let description = $(form).find('input[name="description"]').val();
            let courseType = $('#course-type').find(":selected").val();

            let vocabularyWordIDs = [];
            $('#select-vocabulary-word-update option:selected').each(function (i, selectedelement) {
                vocabularyWordIDs[i] = $(selectedelement).val() * 1;
            })

            let updateCourse = {
                courseName: courseName,
                description: description,
                vocabularyWordIDs: vocabularyWordIDs,
                courseType: courseType * 1
            };

            if (courseIDUpdate !== null && courseIDUpdate !== undefined && courseIDUpdate > 0) {
                $.ajax({
                    method: "PUT",
                    url: `vocabulary-courses/update-course/${courseIDUpdate}`,
                    data: JSON.stringify(updateCourse),
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

                            $('#form-edit-course :input[type="text"]').val('');
                            $('#form-edit-course :input[type="date"]').val('');
                            vocabularyWordsDatatable.ajax.reload();
                            $("#form-edit-course").validate().resetForm();
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
                ShowToastError("No course selected for editing.");
            }
        }
    });

    $(document).on('click', '#cancel-edit-course', function () {
        const truck_modal = document.querySelector('#modal-edit');
        const modal = bootstrap.Modal.getInstance(truck_modal);
        modal.hide();

        $('#form-edit-course :input[type="text"]').val('');
        $('#form-edit-course :input[type="date"]').val('');
        formValidateEdit.resetForm();
    });
});
//#endregion

//#region delete one vocabulary word
var courseIDDelete;
function modalDelete(courseID, courseName) {
    let modalDelete = new bootstrap.Modal(document.getElementById('modal-delete'), {
        keyboard: false
    })
    modalDelete.show();
    $("#courseIDDelete").html(`<b>${courseName}</b>`);
    courseIDDelete = courseID;
}

$("button#btn-delete").on("click", function (event) {
    event.preventDefault();
    const truck_modal = document.querySelector('#modal-delete');
    const modal = bootstrap.Modal.getInstance(truck_modal);

    $.ajax({
        method: "DELETE",
        url: `/vocabulary-courses/delete-course/${courseIDDelete}`,
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


//#region choices vocabulary words - create course
const selectGenres = new Choices('#select-genre', {
    removeItemButton: true,
    duplicateItemsAllowed: true,
});

$("#div-select-genre .choices__input")
    .focusout(function () {
        const elementCreate = $(".set-genre-for-comic .choices__inner");
        if ((selectGenres.getValue().length === 0)) {
            $("#select-genre").parent().parent().next("#lable-error-select-genre").remove()
            $("#select-genre").parent().parent().after("<div id='lable-error-select-genre' class='is-invalid' style='margin-top: 2px; position: absolute;'>Please select Vocabulary Word(s).</div>");
            if (!elementCreate.hasClass("error-genre")) {
                elementCreate.addClass("error-genre")
                $("#submit-create-course").attr("disabled", "disabled");
            }
        }
        else {
            CheckEnableSaveChange();

            elementCreate.removeClass("error-genre");
            $("#lable-error-select-genre").remove();
        }
    })

$('#div-select-genre').change(function () {
    const elementCreate = $(".set-genre-for-comic .choices__inner");
    if ((selectGenres.getValue().length === 0)) {
        $("#select-genre").parent().parent().next("#lable-error-select-genre").remove()
        $("#select-genre").parent().parent().after("<div id='lable-error-select-genre' class='is-invalid' style='margin-top: 2px; position: absolute;'>Please select Vocabulary Word(s).</div>");
        if (!elementCreate.hasClass("error-genre")) {
            elementCreate.addClass("error-genre")
            $("#submit-create-course").attr("disabled", "disabled");
        }
    }
    else {
        CheckEnableSaveChange();

        elementCreate.removeClass("error-genre");
        $("#lable-error-select-genre").remove();
    }
})
//#endregion

//#region handle choices vocabulary words - create course
Array.prototype.diff = function (a) {
    return this.filter(function (i) { return a.indexOf(i) < 0; });
};

$('#select-genre').on('change', function () {
    let listChoices = selectGenres.config.choices;
    let defaultValue = [];
    let defaultLabel = [];

    for (let p = 0; p < listChoices.length; p++) {
        let value = selectGenres.config.choices[p].value;
        let label = selectGenres.config.choices[p].label;
        defaultValue.push(value);
        defaultLabel.push(label);
    }

    let SeletedValue = [];
    let SeletedLabel = [];

    $('#select-genre option:selected').each(function (i, selectedelement) {
        SeletedValue[i] = $(selectedelement).val();
        SeletedLabel[i] = $(selectedelement).text();
    });
});
//#endregion

//#region choices vocabulary words - update course
const selectVocabularyWordsUpdate = new Choices('#select-vocabulary-word-update', {
    removeItemButton: true,
    duplicateItemsAllowed: true,
});

$("#div-select-vocabulary-word-update .choices__input")
    .focusout(function () {
        const elementCreate = $(".set-genre-for-comic .choices__inner");
        if ((selectVocabularyWordsUpdate.getValue().length === 0)) {
            $("#select-vocabulary-word-update").parent().parent().next("#lable-error-select-genre").remove()
            $("#select-vocabulary-word-update").parent().parent().after("<div id='lable-error-select-genre' class='is-invalid' style='margin-top: 2px; position: absolute;'>Please select Vocabulary Word(s).</div>");
            if (!elementCreate.hasClass("error-genre")) {
                elementCreate.addClass("error-genre")
                $("#submit-create-course").attr("disabled", "disabled");
            }
        }
        else {
            CheckEnableSaveChange();

            elementCreate.removeClass("error-genre");
            $("#lable-error-select-genre").remove();
        }
    })

$('#div-select-vocabulary-word-update').change(function () {
    const elementCreate = $(".set-genre-for-comic .choices__inner");
    if ((selectVocabularyWordsUpdate.getValue().length === 0)) {
        $("#select-vocabulary-word-update").parent().parent().next("#lable-error-select-genre").remove()
        $("#select-vocabulary-word-update").parent().parent().after("<div id='lable-error-select-genre' class='is-invalid' style='margin-top: 2px; position: absolute;'>Please select Vocabulary Word(s).</div>");
        if (!elementCreate.hasClass("error-genre")) {
            elementCreate.addClass("error-genre")
            $("#submit-create-course").attr("disabled", "disabled");
        }
    }
    else {
        CheckEnableSaveChange();

        elementCreate.removeClass("error-genre");
        $("#lable-error-select-genre").remove();
    }
})
//#endregion

//#region handle choices vocabulary words - update course
Array.prototype.diff = function (a) {
    return this.filter(function (i) { return a.indexOf(i) < 0; });
};

$('#select-vocabulary-word-update').on('change', function () {
    let listChoices = selectVocabularyWordsUpdate.config.choices;
    let defaultValue = [];
    let defaultLabel = [];

    for (let p = 0; p < listChoices.length; p++) {
        let value = selectVocabularyWordsUpdate.config.choices[p].value;
        let label = selectVocabularyWordsUpdate.config.choices[p].label;
        defaultValue.push(value);
        defaultLabel.push(label);
    }

    let SeletedValue = [];
    let SeletedLabel = [];

    $('#select-vocabulary-word-update option:selected').each(function (i, selectedelement) {
        SeletedValue[i] = $(selectedelement).val();
        SeletedLabel[i] = $(selectedelement).text();
    });
});
//#endregion
