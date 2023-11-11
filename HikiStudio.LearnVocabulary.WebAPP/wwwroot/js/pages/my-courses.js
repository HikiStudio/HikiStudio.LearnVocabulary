
function changeFavouriteCourse(courseID) {
    $.ajax({
        method: "GET",
        url: `my-courses/change-favourite-course/${courseID}`,
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
                if (response.resultObj === true) {
                    $(`#course-favourite-${courseID}`).css('background', 'brown');
                    $(`#course-favourite-icon-${courseID}`).css('color', '#fff700');
                }
                else {
                    $(`#course-favourite-${courseID}`).css('background', '#c8c0c0');
                    $(`#course-favourite-icon-${courseID}`).css('color', 'white');
                }
                ShowToastSuccess(response.message);
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