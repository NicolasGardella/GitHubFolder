$(document).ready(function () {

    $("#list-tab").click(function () {
        $.ajax({
            url: "/Usuarios/GetUsuarios",
            type: 'GET',
            dataType: 'json',
            processData: false,
            contentType: 'application/json; charset=utf-8',

            success: function (data) {
                debugger;
                //data.each(function (i) {
                jQuery.each(data, function (index, item) {
                    debugger;
                    var newRowContent = "<tr><td>" + item.idAlumno + "</td><td>" + item.nombre + "</td><td>" + item.apellido + "</td><td>" + item.telefono + "</td><td>" + item.mail + "</td></tr>";
                    $("#userList tbody").append(newRowContent);
                }); 
            },
            error: function (data) {
            }
        });
    });
});