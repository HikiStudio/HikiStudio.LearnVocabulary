
//#region render table history learn vocabulary learing log
var vocabularyLearningLogDatatable = $("#vocabularyLearningLogDatatable").DataTable({
    "lengthChange": false,
    "processing": true,
    "serverSide": true,
    "filter": false,
    "responsive": true,
    'language': {
        'loadingRecords': '&nbsp;',
        'processing': `<div class="spinner-border" style="width: 3rem; height: 3rem" role="status">
                        <span class="visually-hidden">Loading...</span>
                      </div>`
    },
    "pagingType": 'full_numbers',
    "ajax": {
        "url": "/get-paging-vocabulary-learning-logs",
        "type": "POST",
        "datatype": "json"
    },
    "columnDefs": [{
        orderable: false,
        className: 'select-checkbox',
        targets: 0,
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
    "order": [[1, 'desc']],
    "columns": [
        {
            "render": function (data, type, row, meta) {
                return meta.row + 1;
            },
        },
        {
            "data": "dateCreated", "name": "DateCreated", "Width": "30%",
            "render": function (row, type, data) {
                return formatDateTimeToDDMMYYYY(data.dateCreated);
            }
        },
        { "data": "duration", "name": "Duration", "Width": "30%" },
        { "data": "notes", "name": "Notes", "Width": "10%" },
        { "data": "deviceInfo", "name": "Device", "Width": "10%" },
    ]
});
//#endregion

function getStatisticsVocabularyLearning() {
    let result;
    $.ajax({
        method: "GET",
        async: false,
        url: `/get-statistics-vocabulary-learning/14`,
    })
        .done(function (response) {
            if (response.isSuccessed === true) {
                result = response.resultObj;
            }
            else {
                ShowToastError(response.message);
            }
        })
        .fail(function (jqXHR, textStatus, errorThrown) {
            ShowToastError(jqXHR.responseJSON.message);
        });
    return result;
}

$(document).ready(function () {
    const apiResponse = getStatisticsVocabularyLearning();

    const combinedDataInMinutes = apiResponse.days.map((day, index) => {
        const [hour, minute, second] = apiResponse.dateTimes[index].split(':');

        const totalMinutes = (parseInt(hour) * 60) + parseInt(minute);
        return totalMinutes;
    });

    const chartData = {
        labels: apiResponse.days.reverse(), // Use days as labels
        datasets: [{
            label: 'language learning time every day',
            data: combinedDataInMinutes.reverse(), // Use the combinedData array
            borderColor: 'rgba(54, 162, 235, 1)',
            backgroundColor: 'rgba(54, 162, 235, 0.2)',
            pointBackgroundColor: 'rgba(255, 99, 132, 1)',
            pointBorderColor: 'rgba(255, 99, 132, 1)',
            pointRadius: 5,
            pointHoverRadius: 7,
            borderWidth: 1
        }]
    };

    // Create Chart
    const ctx = document.getElementById('myChart').getContext('2d');
    const myChart = new Chart(ctx, {
        type: 'line',
        data: chartData,
        options: {

            responsive: true,
            maintainAspectRatio: false,
            theme: 'dark', // Set the theme to dark
        }
    });
})
