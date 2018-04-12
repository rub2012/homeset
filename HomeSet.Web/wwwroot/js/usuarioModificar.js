$(document).ready(function () {
    $("#userInput").attr('readonly', 'readonly');
    $("#passwordInput").rules('remove', 'required');
    $("#passwordConfirmInput").rules('remove', 'required');
    $("#passwordConfirmInput").removeAttr('data-rule-equalTo');
});

//# sourceURL=usuarioModificar.js