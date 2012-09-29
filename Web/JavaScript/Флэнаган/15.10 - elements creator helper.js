/**
* make(tagname, attributes, children):
* ������� HTML-������� � �������� ������ ���� tagname, ����������
* � ��������� ����������.
*
* �������� attributes � ��� JavaScript-������: ����� � �������� ��� ������� - ��� �����
* � �������� ���������. ���� �������� �����������, � �������� children
* ������������ ����� ������ ��� ������, ����� �������� attributes
* ����� ������ ��������, � �������� ��������� children ���������� �� ������ ���������.
*
* ��� �������, �������� children ������������ ����� ������ ��������
* ���������, ����������� � ������������ ��������. ���� ������� �� �����
* ��������, �������� children ����� ���� ������.
* ���� �������� ������� ������������, ��� ����� ���������� ���������������,
* �� �������� ��� � ������. (�� ���� �������� ������� �� �������� �������
* � �������� �����������, ����� ������ ������ �������������� �����������.)
*
* ������: make("p", ["��� ", make("b", "������"), " �����."]);
*
* var table = make("table", {border:1}, make("tr", [make("th", "���"),
* 													make("th", "���"),
* 													make("th", "��������")]));
*
* ���� ����� �� ���������� MochiKit (http://mochikit.com),
* ����� ���������� � ��� �������� (Bob Ippolito)
*/
function make(tagname, attributes, children) {
	// ���� ���� �������� ��� ��������� � �������� attributes ������������
	// ����� ������ ��� ������, ������, �� ����� ���� ��� �������� children.
	if (arguments.length == 2 &&
		(attributes instanceof Array || typeof attributes == "string")) {
		children = attributes;
		attributes = null;
	}
	// ������� �������
	var e = document.createElement(tagname);
	// ���������� ��������
	if (attributes) {
		for(var name in attributes) e.setAttribute(name, attributes[name]);
	}
	// �������� �������� ����, ���� ������� ��� ���������.
	if (children != null) {
		if (children instanceof Array) { // ���� ��� ������
			for(var i = 0; i < children.length; i++) { // ������ ��� ��������
				var child = children[i];
				if (typeof child == "string") // ��������� ����
					child = document.createTextNode(child);
				e.appendChild(child); // ��� ��������� � ��� Node
			}
		}
		else if (typeof children == "string") // ������������ ����-������� Text
			e.appendChild(document.createTextNode(children));
		else e.appendChild(children); // ������������ ����-������� ������� ����
	}
	// ������� �������
	return e;
}
/**
* maker(tagname): ���������� �������, ������� �������� make() ��� ��������� ����.
* ������: var table = maker("table"), tr = maker("tr"), td = maker("td");
* � �����:
* var mytable = table({border:1}, tr([th("���"), th("���"), th("��������")]));
*/
function maker(tag) {
	return function(attrs, kids) {
		if (arguments.length == 1) return make(tag, attrs);
		else return make(tag, attrs, kids);
	}
}