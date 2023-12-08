let V1V2V3Equals = []
let V1V2Equals = []
let V2V3Equals = []
let V1V3Equals = []
let V1V2V3Differents = []

commonRegularVerbs.forEach((item) => {
    if (item.OriginalV1.join(",") == item.PastV2.join(",") && item.PastV2.join(",") == item.PastParticipleV3.join(",")) {
        item.TypeID = 1;
        V1V2V3Equals.push(item);
    }
    else if (item.OriginalV1.join(",") == item.PastV2.join(",")) {
        item.TypeID = 2;
        V1V2Equals.push(item);
    }
    else if (item.PastV2.join(",") == item.PastParticipleV3.join(",")) {
        item.TypeID = 3;
        V2V3Equals.push(item);
    }
    else if (item.OriginalV1.join(",") == item.PastV2.join(",") && item.PastV2.join(",") == item.PastParticipleV3.join(",")) {
        item.TypeID = 4;
        V1V3Equals.push(item);
    }
    else {
        item.TypeID = 5;
        V1V2V3Differents.push(item);
    }
})

let regularVerbs = [...V1V2V3Equals, ...V1V2Equals, ...V2V3Equals, ...V1V3Equals, ...V1V2V3Differents];

console.log(regularVerbs)

var vocabularyWordsDatatable = $("#vocabularyWordsDatatable").DataTable({
    "lengthChange": false,
    "processing": true,
    "filter": true,
    "responsive": true,
    "data": regularVerbs,
    'language': {
        'loadingRecords': '&nbsp;',
        'processing': `<div class="spinner-border" style="width: 3rem; height: 3rem" role="status">
                        <span class="visually-hidden">Loading...</span>
                      </div>`
    },
    "paging": false,
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
        targets: [5]
    }],
    "select": {
        style: 'multi',
        selector: 'td:first-child'
    },
    "columns": [
        {
            "render": function (row, type, data) {
                return `<input type='checkbox' class='form-check-input bg-secondary ms' data-id='${data.CommonRegularVerbID}' /> `;
            },
        },
        { "data": "CommonRegularVerbID", "name": "CommonRegularVerbID", "Width": "50px" },
        {
            "name": "OriginalV1",
            "render": function (row, type, data) {
                return `${data.OriginalV1.join("<br>")}`;
            }
        },
        {
            "name": "PastV2",
            "render": function (row, type, data) {
                return `${data.PastV2.join("<br>")}`;
            }
        },
        {
            "name": "PastParticipleV3",
            "render": function (row, type, data) {
                return `${data.PastParticipleV3.join("<br>")}`;
            }
        },
        { 
            "name": "Definition",
            "render": function (row, type, data) {
                return `<span style="text-algin: left">${data.Definition}</span>`;
            }
        }
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

//#endregion