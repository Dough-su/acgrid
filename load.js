$(document).ready(function() {
    Cookies.get('name'); // => 'value'
    var xx = Cookies.get('name') + ".jpg";
    $('#image').attr('src', xx);
})