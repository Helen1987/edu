/**
* Tooltip.js: ���������� ����������� ���������, ������������� ����.
*
* ���� ������ ���������� ����� Tooltip. ������� ������ Tooltip ���������
* � ������� ������������ Tooltip(). ����� ����� ��������� ����� �������
* ������� ������� ������ show(). ����� ������ ���������, �������
* ������� ����� hide().
*
* �������� ��������: ��� ����������� ����������� ��������� � ��������������
* ����� ������ ���������� �������� ��������������� ����������� CSS�������
* ��������:
*
* .tooltipShadow {
* background: url(shadow.png); /* �������������� ���� * /
* }
*
* .tooltipContent {
* left: 4px; top: 4px; /* �������� ������������ ���� * /
* backgroundcolor: #ff0; /* ������ ��� * /
* border: solid black 1px; /* ������ ����� ������� ����� * /
* padding: 5px; /* ������� ����� ������� � ������ * /
* font: bold 10pt sansserif; /* ��������� ������ ����� * /
* }
*
* � ���������, �������������� ����������� ����������� ��������������
* ����������� ������� PNG, ����� ������������ ����������� ��������������
* ����. � ��������� ��������� �������� ������������ ��� ���� �������� ����
* ��� ����������� ���������������� � ������� ����������� ������� GIF.
*/
function Tooltip( ) { // ������������������ ������ Tooltip
	this.tooltip = document.createElement("div"); // ������� div ��� ����
	this.tooltip.style.position = "absolute"; // ���������� ����������������
	this.tooltip.style.visibility = "hidden"; // ���������� ��������� ������
	this.tooltip.className = "tooltipShadow"; // ���������� ��� �����
	this.content = document.createElement("div"); // ������� div � ����������
	this.content.style.position = "relative"; // ������������� ����������������
	this.content.className = "tooltipContent"; // ���������� ��� �����
	this.tooltip.appendChild(this.content); // �������� ���������� � ����
}
// ���������� ����������, ���������� ������� ���� � ���������� � ���������� ��
Tooltip.prototype.show = function(text, x, y) {
	this.content.innerHTML = text; // �������� ����� ���������.
	this.tooltip.style.left = x + "px"; // ���������� ���������.
	this.tooltip.style.top = y + "px";
	this.tooltip.style.visibility = "visible"; // ������� �������.
	// �������� ��������� � ��������, ���� ��� ��� �� �������
	if (this.tooltip.parentNode != document.body)
		document.body.appendChild(this.tooltip);
};
// ������ ���������
Tooltip.prototype.hide = function() {
	this.tooltip.style.visibility = "hidden"; // ������� ���������.
};