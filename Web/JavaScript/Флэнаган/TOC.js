/**
* TOC.js: ������� ���������� ���������.
*
* � ���� ������ ������������ ������������ ������� maketoc(), ����� ��
* ������������ ���������� ������� onload, ��������� ���� �������
* ����������� ������������� ����� �� ����� �������� ���������
* ����� ������� ������� maketoc() ������� ������������� �������� � �������
* �������� �� ��������� �������� id="toc". ���� ����� ������� � ���������
* �����������, maketoc() ������ �� ������. ���� ����� ������� ��������������,
* maketoc() ������� ��������, ���������� ��� ���� �� <h1> �� <h6>
* � ������� ����������, ������� ����� ����������� � ������� "toc".
* ������� maketoc() ��������� ������ �������� � ������� ��������� �������
* ������� � ��������� ����� ������ ���������� �������� ������ �� ����������
* ������ � ������� �������� � �������, ������������� � �������� "TOC",
* ��������� �������� maketoc(), �.�. ������� ��������
* ������������� ������� �������� � ����� HTML-����������.
*
* ������ ������ ������� ���������� ����� ������������� � ������� CSS.
* ��� ������ ����������� � ������ "TOCEntry". ����� ����, ������ �����
* ����������� ������, ��� �������� ������������� ������ ��������� �������.
* ��� ����� <h1> ������������ ������ � ������� "TOCLevel1",
* ��� ����� <h2> � ������ � ������� "TOCLevel2", � �.�.
* ������ �������� ����������� � ���������, ������������� ������ "TOCSectNum",
* � �������� ������ �� ���������� ������������ ��� ����������,
* ������������� ������ "TOCBackLink".
*
* �� ��������� ��������������� �������� ������ �������� ����� "Contents".
* ����� �������� ���� ����� (��������, � ����� �������������������),
* ������� �������� ��� � �������� maketoc.backlinkText.
**/
function maketoc() {
	// ����� ���������. � ������ ���������� �������� ������ ��������� ������.
	var container = document.getElementById('toc');
	if (!container) return;
	// ������ ��������, �������� � ������ ��� ���� <h1>...<h6>
	var sections = [];
	findSections(document, sections);
	// �������� ������� ������� ����� ����������, ����� ����� ����
	// ��������� �������� ������ �� ����
	var anchor = document.createElement("a"); // ������� ���� <a>
	anchor.name = "TOCtop"; // ���������� ��������
	anchor.id = "TOCtop"; // name � id (��� IE)
	container.parentNode.insertBefore(anchor, container); // �������� ����� �����������
	// ���������������� ������ ��� ������������ ������� ��������
	var sectionNumbers = [0,0,0,0,0,0];
	// ������ � ����� ��� ��������� ��������� ��������
	for(var s = 0; s < sections.length; s++) {
		var section = sections[s];
		// ���������� ������� ���������
		var level = parseInt(section.tagName.charAt(1));
		if (isNaN(level) || level < 1 || level > 6) continue;
		// ��������� ����� ������� ��� ������� ������
		// � �������� � ���� ������ ���� ����������� ����������
		sectionNumbers[level-1]++;
		for(var i = level; i < 6; i++) sectionNumbers[i] = 0;
		// ������� ����� ������� ��� ������� ������,
		// ����� ������� ����� �����, ���, ��������, 2.3.1
		var sectionNumber = "";
		for(i = 0; i < level; i++) {
			sectionNumber += sectionNumbers[i];
			if (i < level-1) sectionNumber += ".";
		}
		// �������� ����� � ������ � ���������.
		// ����� ���������� � ��� <span>, ����� ����� ���� ������ �� ������ ������.
		var frag = document.createDocumentFragment(); // ��� �������� ������ � �������
		var span = document.createElement("span"); // ���� span ������ �������
		span.className = "TOCSectNum"; // ��������� ��� ��������������
		span.appendChild(document.createTextNode(sectionNumber)); // �������� �����
		frag.appendChild(span); // �������� ��� � ������� �� ��������
		frag.appendChild(document.createTextNode(" ")); // �������� ������
		section.insertBefore(frag, section.firstChild); // �������� ��� � ���������
		// ������� ������� �������, ������� ����� �������� ������ �������.
		var anchor = document.createElement("a");
		anchor.name = "TOC"+sectionNumber; // ��� ��������, �� ������� ����� ������
		anchor.id = "TOC"+sectionNumber; // � IE ��� ��������� ������
		// ���������� ���������� ������� id
		// �������� ������� ��������� �������� ������ �� ����������
		var link = document.createElement("a");
		link.href = "#TOCtop";
		link.className = "TOCBackLink";
		link.appendChild(document.createTextNode(maketoc.backlinkText));
		anchor.appendChild(link);
		// �������� ������� ������� � ������ ��������������� ����� ���������� �������
		section.parentNode.insertBefore(anchor, section);
		// ������� ������ �� ���� ������.
		var link = document.createElement("a");
		link.href = "#TOC" + sectionNumber; // ���������� ����� ������
		link.innerHTML = section.innerHTML; // �������� ����� ��������� � ����� ������
		// ��������� ������ � ������� div, ����� �������� ����������� ������
		// �� ������ ����������� �� ������ ������ ���������
		var entry = document.createElement("div");
		entry.className = "TOCEntry TOCLevel" + level; // ��� CSS
		entry.appendChild(link);
		// � �������� ������� div � ��������� � �����������
		container.appendChild(entry);
	}
	// ���� ����� ������� ������ ��������� � ������ � �������� n,
	// ���������� ���� � <h1> �� <h6> � ��������� �� � ������ ��������.
	function findSections(n, sects) {
		// ������ ��� �������� ���� �������� n
		for(var m = n.firstChild; m != null; m = m.nextSibling) {
			// ���������� ����, ������� �� �������� ����������.
			if (m.nodeType != 1 /* Node.Element_NODE */) continue;
			// ���������� ������������ �������, ��������� �� ����� ����� ���� ���������
			if (m == container) continue;
			// � ����� ����������� ���������� ���� <p>, ���������
			// ��������������, ��� ��������� �� ����� ���������� ������
			// �������. (����� ����, ����� ���� �� ���������� ������,
			// ���� <pre> � ������, �� ��� <p> - ����� ����������������.)
			if (m.tagName == "P") continue; // �����������
			// ���� �� ��� �������� - ���������, �� �������� �� �� ����������.
			// ���� ��� ���������, �������� ��� � ������. ����� �����������
			// ���������� ���������� ����.
			// �������� ��������: ������ DOM �������� �� �����������,
			// � �� �� �������, ������ ������ ��������� ��������
			// �� �������������� (m instanceof HTMLHeadingElement).
			if (m.tagName.length==2 && m.tagName.charAt(0)=="H")
				sects.push(m);
			else
				findSections(m, sects);
		}
	}
}
// ��� ����� �� ��������� ��� �������� ������ �� ����������
maketoc.backlinkText = "Contents";
// ���������������� ������� maketoc() ��� ���������� ������� onload
if (window.addEventListener) window.addEventListener("load", maketoc, false);
else if (window.attachEvent) window.attachEvent("onload", maketoc);