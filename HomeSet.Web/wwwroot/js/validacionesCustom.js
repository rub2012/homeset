$.validator.addMethod("date", function (value, element) {
    var dateRegex = new RegExp('^(\\d{2}\/\\d{2}\/\\d{4})(\\s{1}\\d{2}:\\d{2}(:\\d{2})?)?$');
    return this.optional(element) || dateRegex.test(value);
}, "Fecha inválida");