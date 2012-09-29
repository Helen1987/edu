/**
* Geometry.js: переносимые функции определения геометрии окна и документа
*
* Этот модуль определяет функции получения геометрических характеристик
* окна и документа
*
* getWindowX/Y() : возвращают положение окна на экране
* getViewportWidth/Height() : возвращают размеры клиентской области окна
* getDocumentWidth/Height() : возвращают размеры документа
* getHorizontalScroll() : возвращает смещение по горизонтали
* getVerticalScroll() : возвращает смещение по вертикали
*
* Обратите внимание: не существует переносимого способа определить общие
* размеры окна броузера, поэтому отсутствуют функции getWindowWidth/Height()
*
* ВАЖНО: Этот модуль должен включаться в тег <body> документа, а не в тег <head>
*/
var Geometry = {};
if (window.screenLeft === undefined) { // Для IE и других
    Geometry.getWindowX = function() { return window.screenLeft; };
    Geometry.getWindowY = function() { return window.screenTop; };
}
else if (window.screenX) { // Для Firefox и других
    Geometry.getWindowX = function() { return window.screenX; };
    Geometry.getWindowY = function() { return window.screenY; };
}
if (window.innerWidth) { // Все броузеры, кроме IE
    Geometry.getViewportWidth = function() { return window.innerWidth; };
    Geometry.getViewportHeight = function() { return window.innerHeight; };
    Geometry.getHorizontalScroll = function() { return window.pageXOffset; };
    Geometry.getVerticalScroll = function() { return window.pageYOffset; };
}
else if (document.documentElement && document.documentElement.clientWidth) {
    // Эти функции предназначены для IE 6 и документов с объявлением DOCTYPE
    Geometry.getViewportWidth = function() { return document.documentElement.clientWidth; };
    Geometry.getViewportHeight = function() { return document.documentElement.clientHeight; };
    Geometry.getHorizontalScroll = function() { return document.documentElement.scrollLeft; };
    Geometry.getVerticalScroll = function() { return document.documentElement.scrollTop; };
}
else if (document.body.clientWidth) {
    // Эти функции предназначены для IE4, IE5 и IE6 без объявления DOCTYPE
    Geometry.getViewportWidth = function() { return document.body.clientWidth; };
    Geometry.getViewportHeight = function() { return document.body.clientHeight; };
    Geometry.getHorizontalScroll = function() { return document.body.scrollLeft; };
    Geometry.getVerticalScroll = function() { return document.body.scrollTop; };
}
// Следующие функции возвращают размеры документа.
// Они не имеют отношения к окну, но бывает удобно иметь их.
if (document.documentElement && document.documentElement.scrollWidth) {
    Geometry.getDocumentWidth = function() { return document.documentElement.scrollWidth; };
    Geometry.getDocumentHeight = function() { return document.documentElement.scrollHeight; };
}
else if (document.body.scrollWidth) {
    Geometry.getDocumentWidth = function() { return document.body.scrollWidth; };
    Geometry.getDocumentHeight = function() { return document.body.scrollHeight; };
}