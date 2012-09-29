/*
* Log.js: Cредства ненавязчивого протоколирования
*
* Данный модуль определяет единственный глобальный символ – функцию log().
* Протоколирование сообщений производится вызовом этой функции
* с двумя или тремя аргументами:
*
* category: тип сообщения. Это необходимо, чтобы можно было разрешать или
* запрещать вывод сообщений различных типов, а также для того, чтобы иметь
* возможность оформлять их разными стилями независимо друг от друга.
* Подробности далее.
*
* message: текст сообщения. Может быть пустой строкой, если функции передается объект
*
* object: записываемый в журнал объект. Это необязательный аргумент.
* Если он определен, свойства объекта выводятся в форме таблицы.
* Любое свойство, значением которого является объект, протоколируется рекурсивно.
*
* Вспомогательные функции:
*
* Функции log.debug() и log.warn() – это сервисные функции, которые просто
* вызывают функцию log() с жестко предопределенными типами "debug"
* и "warning". Довольно просто можно определить функцию, которая подменит
* метод alert() и будет вызывать функцию log().
*
* Включение режима протоколирования
*
* Протоколируемые сообщения по умолчанию *не* отображаются. Разрешить
* отображение сообщений того или иного типа можно одним из двух способов.
* Первый – создать элемент <div> или другой контейнерный элемент
* со значением атрибута id равным "<category>_log". Для вывода сообщений
* c категорией "debug" можно вставить в документ следующую строку:
*
* <div id="debug_log"></div>
*
* В этом случае все сообщения данного типа будут добавляться в элемент-
* контейнер, для которого могут быть определены свои стили отображения.
*
* Второй способ активировать вывод сообщений определенной категории -
* установить значение соответствующего свойства. Например, чтобы разрешить
* вывод сообщений категории "debug", следует установить свойство
* log.options.debugEnabled = true. После этого создается элемент
* <div class="log">, куда и будут добавляться сообщения.
* Чтобы запретить отображение протоколируемых сообщений даже
* при наличии контейнерного элемента с соответствующим значением
* атрибута id следует установить значение свойства:
* log.options.debugDisabled=true. Чтобы опять разрешить вывод
* сообщений в свойство, соответствующее заданной категории,
* следует записать значение false.
*
* Оформление сообщений
*
* В дополнение к возможности оформления самого контейнера для сообщений
* можно использовать CSS-стили, чтобы оформлять вывод отдельных
* сообщений. Каждое сообщение помещается в тег <div> с CSS-классом
* <category>_message. Например, сообщения из категории "debug" будут
* иметь класс "debug_message"
*
* Свойства объекта Log
*
* Порядок протоколирования можно изменять установкой свойств
* объекта log.options, как, например, те, которые были описаны ранее
* и использовались для разрешения/запрета вывода сообщений отдельных
* категорий. Далее приводится перечень доступных свойств:
*
* log.options.timestamp: Если в это свойство записано значение true,
* к каждому сообщению будут добавлены дата и время.
*
* log.options.maxRecursion: Целое число, определяющее глубину вложения
* таблиц при отображении сведений об объектах. Если внутри таблиц не должно
* быть вложенных таблиц, в это свойство следует записать значение 0
*
* log.options.filter: Функция, используемая для определения, какие свойства
* объектов должны отображаться. Функция-фильтр должна принимать имя
* и значение свойства и возвращать true, если свойство должно отображаться
* в таблице с объектом, и false – в противном случае
*/
function log(category, message, object) {
	// Если заданная категория явно запрещена, ничего не делать
	if (log.options[category + "Disabled"]) return;
	// Отыскать элемент-контейнер
	var id = category + "_log";
	var c = document.getElementById(id);
	// Если контейнер не найден и вывод сообщений этой категории разрешен,
	// создать новый контейнерный элемент.
	if (!c && log.options[category + "Enabled"]) {
		c = document.createElement("div");
		c.id = id;
		c.className = "log";
		document.body.appendChild(c);
	}
	// Если контейнер по-прежнему отсутствует – игнорировать сообщение
	if (!c) return;
	// Если вывод информации о дате/времени разрешен, добавить ее
	if (log.options.timestamp)
		message = new Date() + ": " + (message?message:"");
	// Создать элемент <div>, в который будет записано сообщение
	var entry = document.createElement("div");
	entry.className = category + "_message";
	if (message) {
		// Добавить сообщение в элемент
		entry.appendChild(document.createTextNode(message));
	}
	if (object && typeof object == "object") {
		entry.appendChild(log.makeTable(object, 0));
	}
	// В заключение добавить запись в контейнер
	c.appendChild(entry);
}
// Создает таблицу для отображения свойств заданного объекта
log.makeTable = function(object, level) {
	// Если достигнуто значение, ограничивающее рекурсию, вернуть узел Text.
	if (level > log.options.maxRecursion)
		return document.createTextNode(object.toString());
	// Создать таблицу, которая будет возвращена
	var table = document.createElement("table");
	table.border = 1;
	// Добавить в таблицу заголовки столбцов Имя|Тип|Значение
	var header = document.createElement("tr");
	var headerName = document.createElement("th");
	var headerType = document.createElement("th");
	var headerValue = document.createElement("th");
	headerName.appendChild(document.createTextNode("Имя"));
	headerType.appendChild(document.createTextNode("Тип"));
	headerValue.appendChild(document.createTextNode("Значение"));
	header.appendChild(headerName);
	header.appendChild(headerType);
	header.appendChild(headerValue);
	table.appendChild(header);
	// Получить имена свойств объекта и отсортировать их в алфавитном порядке
	var names = [];
	for(var name in object) names.push(name);
	names.sort();
	// Теперь обойти эти свойства
	for(var i = 0; i < names.length; i++) {
		var name, value, type;
		name = names[i];
		try {
			value = object[name];
			type = typeof value;
		}
		catch(e) { // Этого не должно происходить, но случается в Firefox
			value = "<неизвестное значение>";
			type = "не известен";
		};
		// Пропустить свойство, если оно отвергается функцией-фильтром
		if (log.options.filter && !log.options.filter(name, value)) continue;
		// Никогда не отображать исходные тексты функций – это может
		// потребовать слишком много места
		if (type == "function") value = "{/*исходные тексты не выводятся*/}";
		// Создать строку таблицы для отображения имени свойства, типа и значения
		var row = document.createElement("tr");
		row.vAlign = "top";
		var rowName = document.createElement("td");
		var rowType = document.createElement("td");
		var rowValue = document.createElement("td");
		rowName.appendChild(document.createTextNode(name));
		rowType.appendChild(document.createTextNode(type));
		// В случае объекта произвести рекурсивный вызов, чтобы вывести вложенные объекты
		if (type == "object")
			rowValue.appendChild(log.makeTable(value, level+1));
		else
			rowValue.appendChild(document.createTextNode(value));
		// Добавить ячейки в строку, затем строку добавить к таблице
		row.appendChild(rowName);
		row.appendChild(rowType);
		row.appendChild(rowValue);
		table.appendChild(row);
	}
	// Вернуть таблицу.
	return table;
}
// Создать пустой объект options
log.options = {};
// Вспомогательные функции для вывода сообщений предопределенных типов
log.debug = function(message, object) { log("debug", message, object); };
log.warn = function(message, object) { log("warning", message, object); };
// Раскомментируйте следующую строку, чтобы подменить функцию alert()
// одноименной функцией, использующей функцию log()
// function alert(msg) { log("alert", msg); }