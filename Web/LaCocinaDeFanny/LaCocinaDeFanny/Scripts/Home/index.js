var usr = {};    
var startApp = function () {
    $(document.body).css({ 'cursor': 'wait' });
   
    gapi.load('auth2', function () {
        // Retrieve the singleton for the GoogleAuth library and set up the client.
        auth2 = gapi.auth2.init({
            client_id: '460338197016-7mh7rqm0uufpotjvo7r5oh95h4g07spv.apps.googleusercontent.com',
            cookiepolicy: 'single_host_origin',
            // Request scopes in addition to 'profile' and 'email'
            //scope: 'additional_scope'
        });
        attachSignin(document.getElementById('customBtn'));
        auth2.isSignedIn.listen(signinChanged);
        auth2.currentUser.listen(userChanged);
    });
    setTimeout(
        function () {
            init();
            $(document.body).css({ 'cursor': 'default' });
        }, 1000);
    
};
function init() {
    $("#customBtn").click();

}
var signinChanged = function (val) {
    console.log('Signin state changed to ', val);
};
var userChanged = function (user) {
    if (user.getId()) {
        console.log('User changed.');
    }
};
function signOut() {
    gapi.auth2.signOut().then(function () {
        console.log('User signed out.');
    });
}
function cerrarSesion() {
    gapi.auth2.init().then(function () {
        var auth2 = gapi.auth2.getAuthInstance();
        auth2.signOut().then(function () {
            $("#menuIngreso").removeClass("ingVerde");
            window.location = "";
        });
    });
}
function attachSignin(element) {
   
    auth2.attachClickHandler(element, {},
        function (googleUser) {
            onSignIn(googleUser);            
        }, function (error) {
            alert(JSON.stringify(error, undefined, 2));
        });
}
function onSignIn(googleUser) {
    //event.preventDefault();
    // Useful data for your client-side scripts:
    console.log(googleUser);
    var profile = googleUser.getBasicProfile();   
    var alumno = {
        nombre: profile.getGivenName(),
        apellido: profile.getFamilyName(),
        mail: profile.getEmail(),
        comentarios: profile.getImageUrl()

    }
    $.ajax({
        url: "/Usuarios/LogIn",
        type: 'POST',
        data: JSON.stringify(alumno),
        dataType: 'json',
        processData: false,
        contentType: 'application/json; charset=utf-8',

        success: function (data) {
            debugger;
            $("#menuIngreso").addClass("ingVerde");
            $(location).attr('href', 'Home/Agenda')
        },
        error: function (data) {

        }
    });
    // The ID token you need to pass to your backend:
    //var id_token = googleUser.getAuthResponse().id_token;
    //console.log("ID Token: " + id_token);

}
$(document).ready(function () {



});