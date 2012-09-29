/**
* Stylesheet.js: ��������������� ������ ��� ������ � ��������� CSS������.
*
* ���� ������ ��������� ����� Stylesheet, ������� ������������ ����� ������
* ������� ��� ������� document.styleSheets[]. �� ���������� �������
* ���������������� ������ ������ � ��������� ������ ������.
**/
// ������� ����� ������ Stylesheet, ������� ������ ��������
// ��� ��������� ������� CSSStylesheet.
// ���� �������� ss  ��� �����, ����� ������� ������ � ������� styleSheet[].
function Stylesheet(ss) {
	if (typeof ss == "number") ss = document.styleSheets[ss];
	this.ss = ss;
}
// ���������� ������ ������ ��� �������� ������� ������.
Stylesheet.prototype.getRules = function() {
	// ���� ���������� W3C��������, ������������ ���,
	// � ��������� ������ ������������ IE��������
	return this.ss.cssRules?this.ss.cssRules:this.ss.rules;
}
// ���������� ������� �� ������� ������. ���� s  ��� �����, ������������
// ������� � ���� ��������. ����� ������������, ��� s  ��� ��������,
// ����� ������� �������� �������, ��������������� ����� ���������.
Stylesheet.prototype.getRule = function(s) {
	var rules = this.getRules();
	if (!rules) return null;
	if (typeof s == "number") return rules[s];
	// ������������, ��� s  ��� ��������
	// ������ ������� � �������� �������, ����� � ������ ����������
	// ������ � ���������� ���������� �� �������� ������� � ��������� �����������.
	s = s.toLowerCase();
	for(var i = rules.length - 1; i >= 0; --i) {
		if (rules[i].selectorText.toLowerCase() == s) return rules[i];
	}
	return null;
};
// ���������� ������ CSS2Properties ��� ��������� �������.
// ������� ����� ���������� ������� ��� ����������.
Stylesheet.prototype.getStyles = function(s) {
	var rule = this.getRule(s);
	if (rule && rule.style) return rule.style;
	else return null;
};
// ���������� ����� ����� ��� ��������� �������.
Stylesheet.prototype.getStyleText = function(s) {
	var rule = this.getRule(s);
	if (rule && rule.style && rule.style.cssText) return rule.style.cssText;
	else return "";
};
// ��������� ������� � ������� ������.
// ������� ������� �� ��������� ��������� � ����� ������.
// ����������� ��� �������� n. ���� �������� n ������, �������
// ����������� � ����� �������.
Stylesheet.prototype.insertRule = function(selector, styles, n) {
	if (n == undefined) {
		var rules = this.getRules();
		n = rules.length;
	}
	if (this.ss.insertRule) // ������� ����������� ������������ W3C API
		this.ss.insertRule(selector + "{" + styles + "}", n);
	else if (this.ss.addRule) // ����� ������������ IE API
		this.ss.addRule(selector, styles, n);
};
// ������� ������� �� ������� ������.
// ���� s  ��� �����, ������� ������� � ���� �������.
// ���� s  ��� ������, ������� ������� � ���� ����������.
// ���� �������� s �� �����, ������� ��������� ������� � ������� ������.
Stylesheet.prototype.deleteRule = function(s) {
	// ���� �������� s �� ����������, ���������� ��� � ������
	// ���������� �������
	if (s == undefined) {
		var rules = this.getRules();
		s = rules.length - 1;
	}
	// ���� s  �� �����, �������� ��������������� �������
	// � �������� ��� ������.
	if (typeof s != "number") {
		s = s.toLowerCase( ); // ������������� � ������ �������
		var rules = this.getRules();
		for(var i = rules.length - 1; i >= 0; i) {
			if (rules[i].selectorText.toLowerCase() == s) {
				s = i; // ��������� ������ ���������� �������
				break; // � ���������� ���������� �����
			}
		}
		// ���� ������� �� ���� �������, ������ ������ �� ������.
		if (i == 1) return;
	}
	// � ���� ����� s �������� �����.
	// ������� ����������� ������������ W3C API, � ����� � IE API
	if (this.ss.deleteRule) this.ss.deleteRule(s);
	else if (this.ss.removeRule) this.ss.removeRule(s);
};