/**
* Stylesheet.js: вспомогательные методы для работы с таблицами CSSстилей.
*
* Этот модуль объявляет класс Stylesheet, который представляет собой просто
* обертку для массива document.styleSheets[]. Он определяет удобные
* межплатформенные методы чтения и изменения таблиц стилей.
**/
// Создает новый объект Stylesheet, который служит оберткой
// для заданного объекта CSSStylesheet.
// Если аргумент ss  это число, найти таблицу стилей в массиве styleSheet[].
function Stylesheet(ss) {
	if (typeof ss == "number") ss = document.styleSheets[ss];
	this.ss = ss;
}
// Возвращает массив правил для заданной таблицы стилей.
Stylesheet.prototype.getRules = function() {
	// Если определено W3Cсвойство, использовать его,
	// в противном случае использовать IEсвойство
	return this.ss.cssRules?this.ss.cssRules:this.ss.rules;
}
// Возвращает правило из таблицы стилей. Если s  это число, возвращается
// правило с этим индексом. Иначе предположить, что s  это селектор,
// тогда следует отыскать правило, соответствующее этому селектору.
Stylesheet.prototype.getRule = function(s) {
	var rules = this.getRules();
	if (!rules) return null;
	if (typeof s == "number") return rules[s];
	// Предположить, что s  это селектор
	// Обойти правила в обратном порядке, чтобы в случае нескольких
	// правил с одинаковым селектором мы получили правило с наивысшим приоритетом.
	s = s.toLowerCase();
	for(var i = rules.length - 1; i >= 0; --i) {
		if (rules[i].selectorText.toLowerCase() == s) return rules[i];
	}
	return null;
};
// Возвращает объект CSS2Properties для заданного правила.
// Правило может задаваться номером или селектором.
Stylesheet.prototype.getStyles = function(s) {
	var rule = this.getRule(s);
	if (rule && rule.style) return rule.style;
	else return null;
};
// Возвращает текст стиля для заданного правила.
Stylesheet.prototype.getStyleText = function(s) {
	var rule = this.getRule(s);
	if (rule && rule.style && rule.style.cssText) return rule.style.cssText;
	else return "";
};
// Вставляет правило в таблицу стилей.
// Правило состоит из заданного селектора и строк стилей.
// Вставляется под индексом n. Если аргумент n опущен, правило
// добавляется в конец таблицы.
Stylesheet.prototype.insertRule = function(selector, styles, n) {
	if (n == undefined) {
		var rules = this.getRules();
		n = rules.length;
	}
	if (this.ss.insertRule) // Сначала попробовать использовать W3C API
		this.ss.insertRule(selector + "{" + styles + "}", n);
	else if (this.ss.addRule) // Иначе использовать IE API
		this.ss.addRule(selector, styles, n);
};
// Удаляет правило из таблицы стилей.
// Если s  это число, удаляет правило с этим номером.
// Если s  это строка, удаляет правило с этим селектором.
// Если аргумент s не задан, удаляет последнее правило в таблице стилей.
Stylesheet.prototype.deleteRule = function(s) {
	// Если значение s не определено, превратить его в индекс
	// последнего правила
	if (s == undefined) {
		var rules = this.getRules();
		s = rules.length - 1;
	}
	// Если s  не число, отыскать соответствующее правило
	// и получить его индекс.
	if (typeof s != "number") {
		s = s.toLowerCase( ); // Преобразовать в нижний регистр
		var rules = this.getRules();
		for(var i = rules.length - 1; i >= 0; i) {
			if (rules[i].selectorText.toLowerCase() == s) {
				s = i; // Запомнить индекс удаляемого правила
				break; // и прекратить дальнейший поиск
			}
		}
		// Если правило не было найдено, просто ничего не делать.
		if (i == 1) return;
	}
	// В этой точке s содержит число.
	// Сначала попробовать использовать W3C API, а затем – IE API
	if (this.ss.deleteRule) this.ss.deleteRule(s);
	else if (this.ss.removeRule) this.ss.removeRule(s);
};