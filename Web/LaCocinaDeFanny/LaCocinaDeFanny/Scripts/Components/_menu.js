$(document).ready(function () {
    $("#menuIngreso").hover(function (e) {
        if ($("#menuIngreso").hasClass("ingVerde")) {
            $("#spanIngresar").text("Cerrar Sesion");
        } else {
            $("#spanIngresar").text("Ingresar");
        }
    });
    var x = window.scrollX;
    var y = window.scrollY;
  //  window.onscroll = function () { window.scrollTo(x, y); };
});