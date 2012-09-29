/**
* getText(n): Отыскивает все узлы Text, вложенные в узел n.
* Объединяет х содержимое и возвращает результат в виде строки.
*/
function getText(n) {
	// Операция объединения строк очень ресурсоемка, потому сначала
	// содержимое текстовых узлов помещается в массив, затем выполняется
	// операция конкатенации элементов массива в одну строку.
	var strings = [];
	getStrings(n, strings);
	return strings.join("");
	// Эта рекурсивная функция отыскивает все текстовые узлы
	// и добавляет их содержимое в конец массива.
	function getStrings(n, strings) {
		if (n.nodeType == 3 /* Node.TEXT_NODE */)
			strings.push(n.data);
		else if (n.nodeType == 1 /* Node.ELEMENT_NODE */) {
			// Обратите внимание, обход выполняется
			// с использованием firstChild/nextSibling
			for(var m = n.firstChild; m != null; m = m.nextSibling) {
			getStrings(m, strings);
			}
		}
	}
}