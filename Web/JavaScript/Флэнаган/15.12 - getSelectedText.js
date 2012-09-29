function getSelectedText() {
	if (window.getSelection) {
		// Этот прием, скорее всего, будет стандартизирован.
		// getSelection() возвращает объект Selection,
		// который в этой книге не описывается.
		return window.getSelection().toString();
	}
	else if (document.getSelection) {
		// Это более старый простейший прием, который возвращает строку
		return document.getSelection( );
	}
	else if (document.selection) {
		// Этот прием используется в IE. В этой книге не описываются
		// ни свойство selection, ни объект TextRange, присутствующие в IE.
		return document.selection.createRange().text;
	}
}

//for FF
function getTextFieldSelection(e) {
	if (e.selectionStart != undefined && e.selectionEnd != undefined) {
		var start = e.selectionStart;
		var end = e.selectionEnd;
		return e.value.substring(start, end);
	}
	else return ""; // Не поддерживается данным броузером
}