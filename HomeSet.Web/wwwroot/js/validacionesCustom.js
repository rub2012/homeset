$.validator.addMethod("date", function (value, element) {
    var dateRegex = new RegExp('^(\\d{1,2}\/\\d{1,2}\/\\d{2,4})(\\s{1}\\d{1,2}:\\d{1,2}(:\\d{1,2})?)?$');
    return this.optional(element) || dateRegex.test(value);
}, "Fecha inválida");