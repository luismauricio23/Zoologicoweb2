$(function () {
    $("#btnSumar").click(function () {
        let num2 = parseInt($("#txtNumero2").val())
        $("#total").val(sumar(num2))
    })
    $("#btnRestar").click(function () {
        let num2 = parseInt($("#txtNumero2").val())
        $("#total").val(restar(num2))
    })
    $("#btnMultiplicar").click(function () {
        let num2 = parseInt($("#txtNumero2").val())
        $("#total").val(multiplicar(num2))
    })

    function sumar(b) {
        return (20000 * b)
    }

    function restar(b) {
        return (15000 * b)
    }

    function multiplicar(b) {
        return (10000 * b)
    }
})