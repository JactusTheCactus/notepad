import QtQuick 2.15
import QtQuick.Controls 2.15

ApplicationWindow {
	visible: true
	property var mult: 100
	width: mult * 16
	height: mult * 9
	title: "QML Notepad"
	font.pointSize: 20
	Row {
		id: top
		width: parent.width
		height: parent.height * 0.1
		Button {
			width: parent.width / 5
			height: parent.height
			font.bold: true
			text: "Bold"
		}
		Button {
			width: parent.width / 5
			height: parent.height
			font.italic: true
			text: "Italic"
		}
		Button {
			width: parent.width / 5
			height: parent.height
			font.family: "monospace"
			text: "Mono"
		}
		Button {
			width: parent.width / 5
			height: parent.height
			font.underline: true
			text: "Underline"
		}
		Button {
			width: parent.width / 5
			height: parent.height
			font.strikeout: true
			text: "Strikethrough"
		}
	}
	Item {
		id: main
		anchors.top: top.bottom
		width: parent.width
		height: parent.height * 0.9
		property var syntax: {
			"=": "b",
			"\\*": "i",
			"\\.": "m",
			"_": "u",
			"-": "s"
		}
		function cssStyle(c, [p, v]) {
			return `.${c} {${p}: ${v}}`
		}
		function fmt(text) {
			const css = `<style>${[
				cssStyle("b",[
					"font-weight",
					"bold"
				]),
				cssStyle("i",[
					"font-style",
					"italic"
				]),
				cssStyle("m",[
					"font-family",
					"monospace"
				]),
				cssStyle("u",[
					"text-decoration",
					"underline"
				]),
				cssStyle("s",[
					"text-decoration",
					"line-through"
				])
			].join("\n")}</style>`;
			let body = text;
			Object.entries(syntax).forEach(([k, v]) => {
				body = body.replace(
					new RegExp(`\\{${k}\\|([\\s\\S]*?)\\|${k}\\}`, "g"),
					`<span class="${v}">$1</span>`
				)
			});
			body = body.replace(/\n/g, "<br>");
			const output = css + body;
			return output
		}
		TextEdit {
			id: raw
			anchors.left: main.left
			width: main.width / 2
			height: main.height
			font.pointSize: 20
			text: [
				"{=|Bold|=}",
				"{*|Italic|*}",
				"{.|Mono|.}",
				"{_|Underline|_}",
				"{-|Strikethrough|-}"
			].join("\n")
		}
		Text {
			id: formatted
			anchors.right: parent.right
			width: parent.width / 2
			height: main.height
			font.pointSize: 20
			textFormat: Text.RichText
			text: main.fmt(raw.text)
		}
	}
}