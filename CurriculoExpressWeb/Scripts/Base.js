$(document).ready(function () {
    $("#cpf").mask("999.999.999-99");
    $("#cpf-registro").mask("999.999.999-99");
    $("#cpf-curriculo").mask("999.999.999-99");
    $("#identidade").mask("99.999.999-9");
});

window.onload = function () {
    new dgCidadesEstados(
            document.getElementById('estado'),
            document.getElementById('cidade'),
            true
        );
}