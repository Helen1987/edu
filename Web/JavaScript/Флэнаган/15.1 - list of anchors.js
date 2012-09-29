/*
* listanchors.js: ������� ������� ���������� � ������� document.anchors[].
*
* ������� listanchors() �������� �������� � �������� ��������� � ���������
* ����� ����, ������� ��������� � ���� "���� ���������" �� ����� ���������.
* ����� ���� ���������� ������ ���� ������� ��������� ���������.
* ������ �� ����� ������ �� ������ �������� ��������� ���������
* � ������� ��������� �������� ��������.
*/
function listanchors(d) {
	// ������� ����� ����
	var newwin = window.open("", "navwin",
		"menubar=yes,scrollbars=yes,resizable=yes," +
		"width=500,height=300");
	// ���������� ���������
	newwin.document.write("<h1>���� ���������: " + d.title + "</h1>");
	// ����������� ��� ������� ��������
	for(var i = 0; i < d.anchors.length; i++) {
		// ��� ������� �������� �������� ����� �������� ����� ��� �����������
		// � ������. � ������ ������� ���� ���������� �������� �����, �������������
		// ����� ������ <a> � </a>, � ������� ��������, ���������� �� ���� ��������.
		// ���� ����� �����������, ����� ������������ �������� �������� name.
		var a = d.anchors[i];
		var text = null;
		if (a.text) text = a.text; // Netscape 4
		else if (a.innerText) text = a.innerText; // IE 4+
		if ((text == null) || (text == '')) text = a.name; // �� ���������
		// ������ ������� ���� ����� � ���� ������. �������� href ���� ������
		// �������������� �� �����: ��� ������ ��������� ���������� �������
		// onclick, �� ������������� �������� location.hash �������������
		// ����, ��� �������� ��������� ���� �� ��������� �������� ��������.
		// ��. �������� ������� Window.opener, Window.location,
		// Location.hash � Link.onclick.
		newwin.document.write('<a href="#' + a.name + '"' +
			' onclick="opener.location.hash=\'' + a.name +
			'\'; return false;">');
		newwin.document.write(text);
		newwin.document.write('</a><br>');
	}
	newwin.document.close( ); // ������� �� ��������� ��������� ��������!
}