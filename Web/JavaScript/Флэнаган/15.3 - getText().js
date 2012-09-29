/**
* getText(n): ���������� ��� ���� Text, ��������� � ���� n.
* ���������� � ���������� � ���������� ��������� � ���� ������.
*/
function getText(n) {
	// �������� ����������� ����� ����� �����������, ������ �������
	// ���������� ��������� ����� ���������� � ������, ����� �����������
	// �������� ������������ ��������� ������� � ���� ������.
	var strings = [];
	getStrings(n, strings);
	return strings.join("");
	// ��� ����������� ������� ���������� ��� ��������� ����
	// � ��������� �� ���������� � ����� �������.
	function getStrings(n, strings) {
		if (n.nodeType == 3 /* Node.TEXT_NODE */)
			strings.push(n.data);
		else if (n.nodeType == 1 /* Node.ELEMENT_NODE */) {
			// �������� ��������, ����� �����������
			// � �������������� firstChild/nextSibling
			for(var m = n.firstChild; m != null; m = m.nextSibling) {
			getStrings(m, strings);
			}
		}
	}
}