/*
* Handler.js - ����������� ������� ����������� � ������ �����������
*
* ���� ������ ���������� ������� ����������� � ������ �����������
* ������������ ������� Handler.add() � Handler.remove(). ��� �������
* ��������� ��� ���������:
*
* element: DOM-�������, �������� ��� ����, ���� �����������
* ��� ������ ��������� ���������� �������.
*
* eventType: ������, ������������ ��� �������, ��� ��������� ��������
* ���������� ����������. ������������ ����� ����� � ������������
* �� ���������� DOM, � ������� ����������� ������� "on".
* �������: "click", "load", "mouseover".
*
* handler: �������, ������� ���������� ��� ������������� ����������
* ������� � �������� ��������. ������ ������� ���������� ��� �����
* ��������, � ������� ��� ����������������, � �������� ����� "this"
* ����� ��������� �� ���� �������. �������-����������� � ��������
* ��������� ���������� ������ �������. ������ ������ ����� ����
* ����������� �������� Event, ���� ��������������� ��������.
* � ������ �������� ���������������� ������� �� ����� ��������
* ���������� ����������, ������������ �� ���������� DOM: type, target,
* currentTarget, relatedTarget, eventPhase, clientX, clientY, screenX,
* screenY, altKey, ctrlKey, shiftKey, charCode, stopPropagation()
* � preventDefault()
*
* ������� Handler.add() � Handler.remove() �� ����� ������������ ��������.
*
* Handler.add() ���������� ��������� ������� ���������������� ���� � ���
* �� ���������� ������� ��� ������ � ���� �� ���� ������� � ��������.
* Handler.remove() �� ��������� ������� ��������, ���� ����������
* ��� �������� ��������������������� �����������.
*
* ���������� � ����������:
*
* � ���������, �������������� ����������� ������� �����������
* addEventListener() � removeEventListener(), Handler.add()
* � Handler.remove() ������ �������� ��� �������, ��������� �������� false
* � ������� ��������� (��� ��������, ��� ����������� ������� �������
* �� ����� ���������������� ��� ��������������� ����������� �������).
*
* � ������� Internet Explorer, �������������� attachEvent(), �������
* Handler.add() � Handler.remove() ���������� ������ attachEvent()
* � detachEvent(). ��� ������ �������-������������ � ���������� ���������
* ��������� ����� this ������������ ���������.
* ��������� � Internet Explorer ��������� ����� ��������� � ������� ������,
* Handler.add() ������������� ������������ ���������� ������� onunload,
* � ������� ���������� ����������� ���� ������������ ��� �������� ��������.
* ��� �������� ���������� � ������������������ ������������ �������
* Handler.add() ������� � ������� Window �������� � ������ _allHandlers,
* � �� ���� ���������, ��� ������� �������������� �����������, ���������
* �������� � ������ _handlers.
*/
var Handler = {};
// � DOM-����������� ��������� ���� ������� �������� ������������
// ��������� ������ addEventListener() � removeEventListener().
if (document.addEventListener) {
	Handler.add = function(element, eventType, handler) {
		element.addEventListener(eventType, handler, false);
	};
	Handler.remove = function(element, eventType, handler) {
		element.removeEventListener(eventType, handler, false);
	};
}
// � IE 5 � ����� ������� ������� ������������ attachEvent() � detachEvent()
// � ����������� ��������� �������, �������� �� ������������
// � addEventListener � removeEventListener.
else if (document.attachEvent) {
	Handler.add = function(element, eventType, handler) {
		// �� ��������� ��������� ����������� �����������
		// _find() - ������� ��������������� ������� ���������� �����.
		if (Handler._find(element, eventType, handler) != -1) return;
		// ��� ��������� ������� ������������ ��� ����, ����� �����
		// ����������� ������� ������� ��� ����� ��������.
		// ��� �� ������� �������������� ������ ������������ ����������� �������.
		var wrappedHandler = function(e) {
			if (!e) e = window.event;
			// ������� ������������� ������ �������, �������
			// ����������� �� ���������� DOM.
			var event = {
				_event: e, // ���� ����������� ��������� ������ ������� IE
				type: e.type, // ��� �������
				target: e.srcElement, // ��� �������� �������
				currentTarget: element, // ��� ��������������
				relatedTarget: e.fromElement?e.fromElement:e.toElement,
				eventPhase: (e.srcElement==element)?2:3,
				// ���������� ��������� ����
				clientX: e.clientX, clientY: e.clientY,
				screenX: e.screenX, screenY: e.screenY,
				// ��������� ������
				altKey: e.altKey, ctrlKey: e.ctrlKey,
				shiftKey: e.shiftKey, charCode: e.keyCode,
				// ������� ���������� ���������
				stopPropagation: function(){this._event.cancelBubble = true;},
				preventDefault: function() {this._event.returnValue = false;}
			}
			// ������� �������-���������� ��� ����� ��������, ��������
			// ������������� ������ ������� ��� ������������ ��������.
			// ���� ������� Function.call() ���������� - ������������ ��,
			// ����� ��������� ��������� ����
			if (Function.prototype.call)
				handler.call(element, event);
			else {
				// ���� ������� Function.call �����������,
				// ������������ �� �����.
				element._currentHandler = handler;
				element._currentHandler(event);
				element._currentHandler = null;
			}
		};
		// ���������������� ��������� ������� ��� ���������� �������.
		element.attachEvent("on" + eventType, wrappedHandler);
		// ������ ���������� ��������� ���������� � ����������������
		// �������-����������� � ��������� �������, ������� �������� ����
		// ����������. �������� ��� ��� ����, ����� ����� ����
		// �������� ����������� ����������� ������� remove()
		// ��� ������������� ��� �������� ��������.
		// ��������� ��� ���������� �� ����������� � �������.
		var h = {
			element: element,
			eventType: eventType,
			handler: handler,
			wrappedHandler: wrappedHandler
		};
		// ���������� ��������, ������ �������� �������� ����������.
		// ���� ������� �� ����� �������� "document" - ��� �� ����
		// � �� ������� ���������, �������������, ��� ������ ����
		// ��� ������ document.
		var d = element.document || element;
		// ������ �������� ������ �� ������ window, ��������� � ���� ����������.
		var w = d.parentWindow;
		// ���������� ������� ���� ���������� � �����,
		// ����� ����� ���� ������� ��� ��� �������� ����.
		var id = Handler._uid(); // ������������� ���������� ��� ��������
		if (!w._allHandlers) w._allHandlers = {}; // ������� ������, ���� ����������
		w._allHandlers[id] = h; // ��������� ���������� � ���� �������
		// � ������� ������������� ���������� �� ����������� � ���� ���������.
		if (!element._handlers) element._handlers = [];
			element._handlers.push(id);
		// ���� ��������� � ����� ���������� ������� onunload
		// ��� �� ���������������, ���������������� ���.
		if (!w._onunloadHandlerRegistered) {
			w._onunloadHandlerRegistered = true;
			w.attachEvent("onunload", Handler._removeAllHandlers);
		}
	};
	
	Handler.remove = function(element, eventType, handler) {
		// �������� �������� ���������� � ������� element._handlers[].
		var i = Handler._find(element, eventType, handler);
		if (i == -1) return; // ���� ��� ������������������ ������������,
		// ������ �� ������
		// �������� ������ �� ���� ��� ������� ��������.
		var d = element.document || element;
		var w = d.parentWindow;
		// �������� ���������� ������������� �����������.
		var handlerId = element._handlers[i];
		// � ������������ ��� ��� ������ ���������� �� �����������.
		var h = w._allHandlers[handlerId];
		// ��������� ��� ����������, ��������� ���������� �� ��������.
		element.detachEvent("on" + eventType, h.wrappedHandler);
		// ������� ���� ������� �� ������� element._handlers.
		element._handlers.splice(i, 1);
		// � ������� ���������� �� ����������� �� ������� _allHandlers.
		delete w._allHandlers[handlerId];
	};
	// ��������������� ������� ������ ����������� � ������� element._handlers
	// ���������� ������ � ������� ��� -1, ���� ��������� ���������� �� ������
	Handler._find = function(element, eventType, handler) {
		var handlers = element._handlers;
		if (!handlers) return -1; // ���� ��� ������������������ ������������,
		// ������ �� ������
		// �������� ������ �� ���� ��� ������� ��������
		var d = element.document || element;
		var w = d.parentWindow;
		// ������ � ����� �����������, ��������� � ���� ���������, ��������
		// ���������� � ���������� ����� � ��������. ����� ���� � �������� �������,
		// ������ ��� ������ ����������� ������������, ������ �����,
		// ����� ����������� � �������, �������� �� �����������.
		for(var i = handlers.length-1; i >= 0; i--) {
			var handlerId = handlers[i]; // �������� ������������� �����������
			var h = w._allHandlers[handlerId]; // �������� ����������
			// ���� ��� ������� � ������� ���������, ������, ��������� ���������� ������.
			if (h.eventType == eventType && h.handler == handler)
				return i;
		}
		return -1; // ���������� �� �������
	};
	
	Handler._removeAllHandlers = function() {
		// ������ ������� �������������� ��� ���������� ������� onunload
		// � ������� attachEvent. ��� ��������, ��� �������� ����� this
		// ��������� �� ������ window, � ������� �������� ��� �������.
		var w = this;
		// ������ ��� ������������������ �����������
		for(id in w._allHandlers) {
			// �������� ���������� �� ����������� �� ��������������
			var h = w._allHandlers[id];
			// ������������ �� ��� ���������� �����������
			h.element.detachEvent("on" + h.eventType, h.wrappedHandler);
			// ������� ���������� �� ������� window
			delete w._allHandlers[id];
		}
	}
	// ������� ��������������� ������� ��� ��������� ����������
	// ��������������� ������������
	Handler._counter = 0;
	Handler._uid = function() { return "h" + Handler._counter++; };
}