let datatable

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    datatable = $('#tblDatos').DataTable({
        "ajax": {
            "url": "/Administrator/Campanign/GetAll"
        },
        "columns": [
            { "data": "name" },
            { "data": "description" },
            { "data": "country" },
            { "data": "city" },
            { "data": "address" },
            { "data": "phone" },
            {
                "data": "createdBy",
                "render": function (data) {
                    if (data == null) {
                        return "Unassigned";
                    }
                    else {
                        return data;
                    }
                }, "width": "20%"
            },
            { "data": "creationDate" },
            {
                "data": "updatedBy",
                "render": function (data) {
                    if (data == null) {
                        return "Unassigned";
                    }
                    else {
                        return data;
                    }
                }, "width": "20%"
            },
            { "data": "dateUpdate" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                        <div class="text-center">
                           <a href="/Administrator/Campanign/Upsert/${data}" class="btn btn-success text-white" style="cursor:pointer">
                              <i class="bi bi-pencil-square"></i>  
                           </a>
                           <a onclick=Delete("/Administrator/Campanign/Delete/${data}") class="btn btn-danger text-white" style="cursor:pointer">
                                <i class="bi bi-trash3-fill"></i>
                           </a> 
                        </div>
                    `;
                }, "width": "20%"
            }
        ]

    });
}

function Delete(url) {

    swal({
        title: "Are you sure about Delete the Campaign?",
        text: "This record cannot be recovered",
        icon: "warning",
        buttons: true,
        dangerMode: true
    }).then((borrar) => {
        if (borrar) {
            $.ajax({
                type: "DELETE",
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        datatable.ajax.reload();
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    });
}