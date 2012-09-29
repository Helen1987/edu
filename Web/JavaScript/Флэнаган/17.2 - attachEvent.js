/*
* Handler.js - Переносимые функции регистрации и отмены регистрации
*
* Этот модуль определяет функции регистрации и отмены регистрации
* обработчиков событий Handler.add() и Handler.remove(). Обе функции
* принимают три аргумента:
*
* element: DOM-элемент, документ или окно, куда добавляется
* или откуда удаляется обработчик события.
*
* eventType: строка, определяющая тип события, для обработки которого
* вызывается обработчик. Используются имена типов в соответствии
* со стандартом DOM, в которых отсутствует префикс "on".
* Примеры: "click", "load", "mouseover".
*
* handler: Функция, которая вызывается при возникновении указанного
* события в заданном элементе. Данная функция вызывается как метод
* элемента, в котором она зарегистрирована, и ключевое слово "this"
* будет ссылаться на этот элемент. Функции-обработчику в качестве
* аргумента передается объект события. Данный объект будет либо
* стандартным объектом Event, либо смоделированным объектом.
* В случае передачи смоделированного объекта он будет обладать
* следующими свойствами, совместимыми со стандартом DOM: type, target,
* currentTarget, relatedTarget, eventPhase, clientX, clientY, screenX,
* screenY, altKey, ctrlKey, shiftKey, charCode, stopPropagation()
* и preventDefault()
*
* Функции Handler.add() и Handler.remove() не имеют возвращаемых значений.
*
* Handler.add() игнорирует повторные попытки зарегистрировать один и тот
* же обработчик события для одного и того же типа события и элемента.
* Handler.remove() не выполняет никаких действий, если вызывается
* для удаления незарегистрированного обработчика.
*
* Примечания к реализации:
*
* В броузерах, поддерживающих стандартные функции регистрации
* addEventListener() и removeEventListener(), Handler.add()
* и Handler.remove() просто вызывают эти функции, передавая значение false
* в третьем аргументе (это означает, что обработчики событий никогда
* не будут зарегистрированы как перехватывающие обработчики событий).
*
* В версиях Internet Explorer, поддерживающих attachEvent(), функции
* Handler.add() и Handler.remove() используют методы attachEvent()
* и detachEvent(). Для вызова функций-обработчиков с корректным значением
* ключевого слова this используются замыкания.
* Поскольку в Internet Explorer замыкания могут приводить к утечкам памяти,
* Handler.add() автоматически регистрирует обработчик события onunload,
* в котором отменяется регистрация всех обработчиков при выгрузке страницы.
* Для хранения информации о зарегистрированных обработчиках функция
* Handler.add() создает в объекте Window свойство с именем _allHandlers,
* а во всех элементах, для которых регистрируются обработчики, создается
* свойство с именем _handlers.
*/
var Handler = {};
// В DOM-совместимых броузерах наши функции являются тривиальными
// обертками вокруг addEventListener() и removeEventListener().
if (document.addEventListener) {
	Handler.add = function(element, eventType, handler) {
		element.addEventListener(eventType, handler, false);
	};
	Handler.remove = function(element, eventType, handler) {
		element.removeEventListener(eventType, handler, false);
	};
}
// В IE 5 и более поздних версиях используются attachEvent() и detachEvent()
// с применением некоторых приемов, делающих их совместимыми
// с addEventListener и removeEventListener.
else if (document.attachEvent) {
	Handler.add = function(element, eventType, handler) {
		// Не допускать повторную регистрацию обработчика
		// _find() - частная вспомогательная функция определена далее.
		if (Handler._find(element, eventType, handler) != -1) return;
		// Эта вложенная функция определяется для того, чтобы иметь
		// возможность вызвать функцию как метод элемента.
		// Эта же функция регистрируется вместо фактического обработчика событий.
		var wrappedHandler = function(e) {
			if (!e) e = window.event;
			// Создать искусственный объект события, отчасти
			// совместимый со стандартом DOM.
			var event = {
				_event: e, // Если потребуется настоящий объект события IE
				type: e.type, // Тип события
				target: e.srcElement, // Где возникло событие
				currentTarget: element, // Где обрабатывается
				relatedTarget: e.fromElement?e.fromElement:e.toElement,
				eventPhase: (e.srcElement==element)?2:3,
				// Координаты указателя мыши
				clientX: e.clientX, clientY: e.clientY,
				screenX: e.screenX, screenY: e.screenY,
				// Состояние клавиш
				altKey: e.altKey, ctrlKey: e.ctrlKey,
				shiftKey: e.shiftKey, charCode: e.keyCode,
				// Функции управления событиями
				stopPropagation: function(){this._event.cancelBubble = true;},
				preventDefault: function() {this._event.returnValue = false;}
			}
			// Вызвать функцию-обработчик как метод элемента, передать
			// искусственный объект события как единственный аргумент.
			// Если функция Function.call() определена - использовать ее,
			// иначе применить маленький трюк
			if (Function.prototype.call)
				handler.call(element, event);
			else {
				// Если функция Function.call отсутствует,
				// симулировать ее вызов.
				element._currentHandler = handler;
				element._currentHandler(event);
				element._currentHandler = null;
			}
		};
		// Зарегистрировать вложенную функцию как обработчик события.
		element.attachEvent("on" + eventType, wrappedHandler);
		// Теперь необходимо сохранить информацию о пользовательской
		// функции-обработчике и вложенной функции, которая вызывает этот
		// обработчик. Делается это для того, чтобы можно было
		// отменить регистрацию обработчика методом remove()
		// или автоматически при выгрузке страницы.
		// Сохранить всю информацию об обработчике в объекте.
		var h = {
			element: element,
			eventType: eventType,
			handler: handler,
			wrappedHandler: wrappedHandler
		};
		// Определить документ, частью которого является обработчик.
		// Если элемент не имеет свойства "document" - это не окно
		// и не элемент документа, следовательно, это должен быть
		// сам объект document.
		var d = element.document || element;
		// Теперь получить ссылку на объект window, связанный с этим документом.
		var w = d.parentWindow;
		// Необходимо связать этот обработчик с окном,
		// чтобы можно было удалить его при выгрузке окна.
		var id = Handler._uid(); // Сгенерировать уникальное имя свойства
		if (!w._allHandlers) w._allHandlers = {}; // Создать объект, если необходимо
		w._allHandlers[id] = h; // Сохранить обработчик в этом объекте
		// И связать идентификатор информации об обработчике с этим элементом.
		if (!element._handlers) element._handlers = [];
			element._handlers.push(id);
		// Если связанный с окном обработчик события onunload
		// еще не зарегистрирован, зарегистрировать его.
		if (!w._onunloadHandlerRegistered) {
			w._onunloadHandlerRegistered = true;
			w.attachEvent("onunload", Handler._removeAllHandlers);
		}
	};
	
	Handler.remove = function(element, eventType, handler) {
		// Отыскать заданный обработчик в массиве element._handlers[].
		var i = Handler._find(element, eventType, handler);
		if (i == -1) return; // Если нет зарегистрированных обработчиков,
		// ничего не делать
		// Получить ссылку на окно для данного элемента.
		var d = element.document || element;
		var w = d.parentWindow;
		// Отыскать уникальный идентификатор обработчика.
		var handlerId = element._handlers[i];
		// И использовать его для поиска информации об обработчике.
		var h = w._allHandlers[handlerId];
		// Используя эту информацию, отключить обработчик от элемента.
		element.detachEvent("on" + eventType, h.wrappedHandler);
		// Удалить один элемент из массива element._handlers.
		element._handlers.splice(i, 1);
		// И удалить информацию об обработчике из объекта _allHandlers.
		delete w._allHandlers[handlerId];
	};
	// Вспомогательная функция поиска обработчика в массиве element._handlers
	// Возвращает индекс в массиве или -1, если требуемый обработчик не найден
	Handler._find = function(element, eventType, handler) {
		var handlers = element._handlers;
		if (!handlers) return -1; // Если нет зарегистрированных обработчиков,
		// ничего не делать
		// Получить ссылку на окно для данного элемента
		var d = element.document || element;
		var w = d.parentWindow;
		// Обойти в цикле обработчики, связанные с этим элементом, отыскать
		// обработчик с требуемыми типом и функцией. Обход идет в обратном порядке,
		// потому что отмена регистрации обработчиков, скорее всего,
		// будет выполняться в порядке, обратном их регистрации.
		for(var i = handlers.length-1; i >= 0; i--) {
			var handlerId = handlers[i]; // Получить идентификатор обработчика
			var h = w._allHandlers[handlerId]; // Получить информацию
			// Если тип события и функция совпадают, значит, требуемый обработчик найден.
			if (h.eventType == eventType && h.handler == handler)
				return i;
		}
		return -1; // Совпадений не найдено
	};
	
	Handler._removeAllHandlers = function() {
		// Данная функция регистрируется как обработчик события onunload
		// с помощью attachEvent. Это означает, что ключевое слово this
		// ссылается на объект window, в котором возникло это событие.
		var w = this;
		// Обойти все зарегистрированные обработчики
		for(id in w._allHandlers) {
			// Получить информацию об обработчике по идентификатору
			var h = w._allHandlers[id];
			// Использовать ее для отключения обработчика
			h.element.detachEvent("on" + h.eventType, h.wrappedHandler);
			// Удалить информацию из объекта window
			delete w._allHandlers[id];
		}
	}
	// Частная вспомогательная функция для генерации уникальных
	// идентификаторов обработчиков
	Handler._counter = 0;
	Handler._uid = function() { return "h" + Handler._counter++; };
}