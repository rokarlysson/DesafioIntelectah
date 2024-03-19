$(document).ready(function () {
	$('.dateTimePicker').datetimepicker({
		lang: 'pt-BR',
		dateFormat: 'dd/mm/yy',
		dayNames: ['Domingo', 'Segunda', 'Terça', 'Quarta', 'Quinta', 'Sexta', 'Sábado'],
		dayNamesMin: ['D', 'S', 'T', 'Q', 'Q', 'S', 'S', 'D'],
		dayNamesShort: ['Dom', 'Seg', 'Ter', 'Qua', 'Qui', 'Sex', 'Sáb', 'Dom'],
		monthNames: ['Janeiro', 'Fevereiro', 'Março', 'Abril', 'Maio', 'Junho', 'Julho', 'Agosto', 'Setembro', 'Outubro', 'Novembro', 'Dezembro'],
		monthNamesShort: ['Jan', 'Fev', 'Mar', 'Abr', 'Mai', 'Jun', 'Jul', 'Ago', 'Set', 'Out', 'Nov', 'Dez'],
		nextText: 'Próximo',
		prevText: 'Anterior',
		format: 'd/m/Y H:i',
		mask: '99/99/9999 99:99',
		minDate: 0,
		onClose: function () {
			try {
				$(this).valid();
			}
			catch (e) {
			}
		}
	});
	$.validator.methods["date"] = function (value, element) {
		return true;
	}
});