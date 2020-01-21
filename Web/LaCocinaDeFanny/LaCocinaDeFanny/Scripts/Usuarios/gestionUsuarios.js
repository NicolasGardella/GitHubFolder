$(document).ready(function () {


    $.ajax({
        url: "/Usuarios/GetUsuarios",
        type: 'GET',
        dataType: 'json',
        processData: false,
        contentType: 'application/json; charset=utf-8',

        success: function (data) {
           
            tablaUsuarios(data);
        },
        error: function (data) {
        }
    });
    $("#list-tab").click();
});

function tablaUsuarios(data) {
    jQuery.each(data, function (index, item) {

        var strBoton = "";
        if (item.estado == 3) {
            strBoton = "<i  id='btnReciclar' onclick='editarUsuario(" + item.idAlumno + ")' data-toggle='tooltip' style='color:#208e2373!important' data-placement='top' title='crear usuario' class='icon solid fa-recycle'></i>";
        } else {
            strBoton = "<i onclick='borrarUsuario(" + item.idAlumno + ")' id='btnBorrar' data-toggle='tooltip' style='color:#ff00007a!important' data-placement='top' title='eliminar usuario' class='icon solid fa-fire'></i>";
        }
        var newRowContent = "<tr><td>" + item.idAlumno + "</td><td>" + item.nombre + "</td><td>" + item.apellido + "</td><td>" + item.telefono + "</td><td>" + item.mail + "</td><td align='center'><i  data-toggle='tooltip' data-placement='top' title='editar usuario' class='icon solid fa-edit' style='color:#0400ff7a!important'></i>&nbsp;&nbsp;" + strBoton + "</td></tr>";
        $("#userList tbody").append(newRowContent);
    });
}

function editarUsuario(id) {
    alert("editar:"+id);
}

function borrarUsuario(id) {
   
    $.ajax({
        url: "/Usuarios/BorrarUsuario",
        type: 'GET',
        dataType: 'json',
        data: {"id":id},
        contentType: 'application/json; charset=utf-8',

        success: function (data) {

            tablaUsuarios(data);
        },
        error: function (data) {
        }
    });
}