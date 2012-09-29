/**
* Tooltip.js: простейшие всплывающие подсказки, отбрасывающие тень.
*
* Этот модуль определяет класс Tooltip. Объекты класса Tooltip создаются
* с помощью конструктора Tooltip(). После этого подсказку можно сделать
* видимой вызовом метода show(). Чтобы скрыть подсказку, следует
* вызвать метод hide().
*
* Обратите внимание: для корректного отображения подсказок с использованием
* этого модуля необходимо добавить соответствующие определения CSSклассов
* Например:
*
* .tooltipShadow {
* background: url(shadow.png); /* полупрозрачная тень * /
* }
*
* .tooltipContent {
* left: 4px; top: 4px; /* смещение относительно тени * /
* backgroundcolor: #ff0; /* желтый фон * /
* border: solid black 1px; /* тонкая рамка черного цвета * /
* padding: 5px; /* отступы между текстом и рамкой * /
* font: bold 10pt sansserif; /* небольшой жирный шрифт * /
* }
*
* В броузерах, поддерживающих возможность отображения полупрозрачных
* изображений формата PNG, можно организовать отображение полупрозрачной
* тени. В остальных броузерах придется использовать для тени сплошной цвет
* или эмулировать полупрозрачность с помощью изображения формата GIF.
*/
function Tooltip( ) { // Функцияконструктор класса Tooltip
	this.tooltip = document.createElement("div"); // Создать div для тени
	this.tooltip.style.position = "absolute"; // Абсолютное позиционирование
	this.tooltip.style.visibility = "hidden"; // Изначально подсказка скрыта
	this.tooltip.className = "tooltipShadow"; // Определить его стиль
	this.content = document.createElement("div"); // Создать div с содержимым
	this.content.style.position = "relative"; // Относительное позиционирование
	this.content.className = "tooltipContent"; // Определить его стиль
	this.tooltip.appendChild(this.content); // Добавить содержимое к тени
}
// Определить содержимое, установить позицию окна с подсказкой и отобразить ее
Tooltip.prototype.show = function(text, x, y) {
	this.content.innerHTML = text; // Записать текст подсказки.
	this.tooltip.style.left = x + "px"; // Определить положение.
	this.tooltip.style.top = y + "px";
	this.tooltip.style.visibility = "visible"; // Сделать видимой.
	// Добавить подсказку в документ, если это еще не сделано
	if (this.tooltip.parentNode != document.body)
		document.body.appendChild(this.tooltip);
};
// Скрыть подсказку
Tooltip.prototype.hide = function() {
	this.tooltip.style.visibility = "hidden"; // Сделать невидимой.
};