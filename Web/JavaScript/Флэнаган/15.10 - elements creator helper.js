/**
* make(tagname, attributes, children):
* создает HTML-элемент с заданным именем тега tagname, атрибутами
* и дочерними элементами.
*
* Аргумент attributes – это JavaScript-объект: имена и значения его свойств - это имена
* и значения атрибутов. Если атрибуты отсутствуют, а аргумент children
* представляет собой массив или строку, тогда аргумент attributes
* можно просто опустить, а значение аргумента children передавать во втором аргументе.
*
* Как правило, аргумент children представляет собой массив дочерних
* элементов, добавляемых к создаваемому элементу. Если элемент не имеет
* потомков, аргумент children может быть опущен.
* Если дочерний элемент единственный, его можно передавать непосредственно,
* не заключая его в массив. (Но если дочерний элемент не является строкой
* и атрибуты отсутствуют, тогда массив должен использоваться обязательно.)
*
* Пример: make("p", ["Это ", make("b", "жирный"), " шрифт."]);
*
* var table = make("table", {border:1}, make("tr", [make("th", "Имя"),
* 													make("th", "Тип"),
* 													make("th", "Значение")]));
*
* Идея взята из библиотеки MochiKit (http://mochikit.com),
* автор библиотеки – Боб Ипполито (Bob Ippolito)
*/
function make(tagname, attributes, children) {
	// Если было передано два аргумента и аргумент attributes представляет
	// собой массив или строку, значит, на самом деле это аргумент children.
	if (arguments.length == 2 &&
		(attributes instanceof Array || typeof attributes == "string")) {
		children = attributes;
		attributes = null;
	}
	// Создать элемент
	var e = document.createElement(tagname);
	// Установить атрибуты
	if (attributes) {
		for(var name in attributes) e.setAttribute(name, attributes[name]);
	}
	// Добавить дочерний узел, если таковой был определен.
	if (children != null) {
		if (children instanceof Array) { // Если это массив
			for(var i = 0; i < children.length; i++) { // обойти все элементы
				var child = children[i];
				if (typeof child == "string") // Текстовый узел
					child = document.createTextNode(child);
				e.appendChild(child); // Все остальное – это Node
			}
		}
		else if (typeof children == "string") // Единственный узел-потомок Text
			e.appendChild(document.createTextNode(children));
		else e.appendChild(children); // Единственный узел-потомок другого типа
	}
	// Вернуть элемент
	return e;
}
/**
* maker(tagname): Возвращает функцию, которая вызывает make() для заданного тега.
* Пример: var table = maker("table"), tr = maker("tr"), td = maker("td");
* и потом:
* var mytable = table({border:1}, tr([th("Имя"), th("Тип"), th("Значение")]));
*/
function maker(tag) {
	return function(attrs, kids) {
		if (arguments.length == 1) return make(tag, attrs);
		else return make(tag, attrs, kids);
	}
}