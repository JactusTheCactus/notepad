import QtQuick 2.15
import QtQuick.Controls 2.15
ApplicationWindow {title: "QML Notepad"
	visible: true
	property var pt: 100
	property var em: 20
	width: 16 * pt
	height: 9 * pt
	font.pointSize: em
	property var borderColour: "#888"
	property var borderWidth: em / 5
	Row {id: top
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
	Row {id: main
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
		function cssStyle(c,[p,v]) {
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
			].join("\n")}</style>`
			let body = text;
			Object.entries(syntax).forEach(([k,v]) => {
				body = body.replace(
					new RegExp(`\\{${k}\\|([\\s\\S]*?)\\|${k}\\}`,"g"),
					`<span class="${v}">$1</span>`
				)
			});
			body = body.replace(/\n/g,"<br>");
			const output = css + body;
			return output
		}
		Rectangle {id: raw
			width: main.width / 2
			height: main.height
			border {
				color: borderColour
				width: borderWidth
			}
			TextEdit {id: rawText
				font.family: "monospace"
				font.pointSize: em
				text: [
					"{=|Bold|=}",
					"{*|Italic|*}",
					"{.|Mono|.}",
					"{_|Underline|_}",
					"{-|Strikethrough|-}"
				].join("\n")
				padding: em
			}
		}
		Rectangle {id: formatted
			width: parent.width / 2
			height: main.height
			border {
				color: borderColour
				width: borderWidth
			}
			Text {id: formattedText
				font.pointSize: em
				textFormat: Text.RichText
				text: main.fmt(rawText.text)
				padding: em
			}
		}
	}
}