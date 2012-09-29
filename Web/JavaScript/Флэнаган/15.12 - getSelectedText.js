function getSelectedText() {
	if (window.getSelection) {
		// ���� �����, ������ �����, ����� ����������������.
		// getSelection() ���������� ������ Selection,
		// ������� � ���� ����� �� �����������.
		return window.getSelection().toString();
	}
	else if (document.getSelection) {
		// ��� ����� ������ ���������� �����, ������� ���������� ������
		return document.getSelection( );
	}
	else if (document.selection) {
		// ���� ����� ������������ � IE. � ���� ����� �� �����������
		// �� �������� selection, �� ������ TextRange, �������������� � IE.
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
	else return ""; // �� �������������� ������ ���������
}