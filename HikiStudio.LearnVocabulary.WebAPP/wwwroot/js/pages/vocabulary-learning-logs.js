
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
