/**
* Geometry.js: ����������� ������� ����������� ��������� ���� � ���������
*
* ���� ������ ���������� ������� ��������� �������������� �������������
* ���� � ���������
*
* getWindowX/Y() : ���������� ��������� ���� �� ������
* getViewportWidth/Height() : ���������� ������� ���������� ������� ����
* getDocumentWidth/Height() : ���������� ������� ���������
* getHorizontalScroll() : ���������� �������� �� �����������
* getVerticalScroll() : ���������� �������� �� ���������
*
* �������� ��������: �� ���������� ������������ ������� ���������� �����
* ������� ���� ��������, ������� ����������� ������� getWindowWidth/Height()
*
* �����: ���� ������ ������ ���������� � ��� <body> ���������, � �� � ��� <head>
*/
var Geometry = {};
if (window.screenLeft === undefined) { // ��� IE � ������
    Geometry.getWindowX = function() { return window.screenLeft; };
    Geometry.getWindowY = function() { return window.screenTop; };
}
else if (window.screenX) { // ��� Firefox � ������
    Geometry.getWindowX = function() { return window.screenX; };
    Geometry.getWindowY = function() { return window.screenY; };
}
if (window.innerWidth) { // ��� ��������, ����� IE
    Geometry.getViewportWidth = function() { return window.innerWidth; };
    Geometry.getViewportHeight = function() { return window.innerHeight; };
    Geometry.getHorizontalScroll = function() { return window.pageXOffset; };
    Geometry.getVerticalScroll = function() { return window.pageYOffset; };
}
else if (document.documentElement && document.documentElement.clientWidth) {
    // ��� ������� ������������� ��� IE 6 � ���������� � ����������� DOCTYPE
    Geometry.getViewportWidth = function() { return document.documentElement.clientWidth; };
    Geometry.getViewportHeight = function() { return document.documentElement.clientHeight; };
    Geometry.getHorizontalScroll = function() { return document.documentElement.scrollLeft; };
    Geometry.getVerticalScroll = function() { return document.documentElement.scrollTop; };
}
else if (document.body.clientWidth) {
    // ��� ������� ������������� ��� IE4, IE5 � IE6 ��� ���������� DOCTYPE
    Geometry.getViewportWidth = function() { return document.body.clientWidth; };
    Geometry.getViewportHeight = function() { return document.body.clientHeight; };
    Geometry.getHorizontalScroll = function() { return document.body.scrollLeft; };
    Geometry.getVerticalScroll = function() { return document.body.scrollTop; };
}
// ��������� ������� ���������� ������� ���������.
// ��� �� ����� ��������� � ����, �� ������ ������ ����� ��.
if (document.documentElement && document.documentElement.scrollWidth) {
    Geometry.getDocumentWidth = function() { return document.documentElement.scrollWidth; };
    Geometry.getDocumentHeight = function() { return document.documentElement.scrollHeight; };
}
else if (document.body.scrollWidth) {
    Geometry.getDocumentWidth = function() { return document.body.scrollWidth; };
    Geometry.getDocumentHeight = function() { return document.body.scrollHeight; };
}