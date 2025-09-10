import QtQuick 2.15
import QtQuick.Controls 2.15
ApplicationWindow {title: "Notepad"
	visible: true
	property var pt: 100
	property var em: 20
	width: 16 * pt
	height: 9 * pt
	font.pointSize: em
	property var borderColour: "#888"
	property var borderWidth: em / 5
	Row {id: top
		function styleButton(inputStr) {
			console.log(inputStr);
		}
		width: parent.width
		height: parent.height * 0.1
		Button {id: top_b
			width: parent.width / 5
			height: parent.height
			font.bold: true
			text: "Bold"
			onClicked: {
				top.styleButton(text);
				main._();
			}
		}
		Button {id: top_i
			width: parent.width / 5
			height: parent.height
			font.italic: true
			text: "Italic"
			onClicked: {
				top.styleButton(text);
				main._();
			}
		}
		Button {id: top_m
			width: parent.width / 5
			height: parent.height
			font.family: "monospace"
			text: "Mono"
			onClicked: {
				top.styleButton(text);
				main._();
			}
		}
		Button {id: top_u
			width: parent.width / 5
			height: parent.height
			font.underline: true
			text: "Underline"
			onClicked: {
				top.styleButton(text);
				main._();
			}
		}
		Button {id: top_s
			width: parent.width / 5
			height: parent.height
			font.strikeout: true
			text: "Strikethrough"
			onClicked: {
				top.styleButton(text);
				main._();
			}
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
			"-": "s",
			"R": "R",
			"O": "O",
			"Y": "Y",
			"G": "G",
			"B": "B",
			"P": "P"
		}
		property var stylesheet: {
			"b": [
				["font-weight","bold"]
			],
			"i": [
				["font-style","italic"]
			],
			"m": [
				["font-family","monospace"]
			],
			"u": [
				["text-decoration","underline"]
			],
			"s": [
				["text-decoration","line-through"]
			],
			"R": [
				["color","#f00"],
				["background-color","#0f0"]
			],
			"O": [
				["color","#f80"],
				["background-color","#00f"]
			],
			"Y": [
				["color","#ff0"],
				["background-color","#80f"]
			],
			"G": [
				["color","#0f0"],
				["background-color","#f00"]
			],
			"B": [
				["color","#00f"],
				["background-color","#f80"]
			],
			"P": [
				["color","#80f"],
				["background-color","#ff0"]
			]
		}
		function cssStyle(c,r) {
			const s = r.map(([p,v]) => `${p}:${v};`);
			const f = `.${c}{${s.join("")}}`;
			return f
		}
		property var style: `<style>${Object.entries(main.stylesheet).map(i => cssStyle(i[0],i[1])).join("")}</style>`
		function _() {
			console.log(style)
		}
		function fmt(text) {
			let body = text;
			body = body
				.replace(/\{\{(.*?)\|/g, "([[$1[[)")
				.replace(/\|(.*?)\}\}/g, "(]]$1]])")
			Object.entries(syntax).forEach(([k,v]) => {
				body = body.replace(
					new RegExp(`\\{${k}\\|([\\s\\S]*?)\\|${k}\\}`,"g"),
					`<span class="${v}">$1</span>`
				);
			});
			body = body
				.replace(/\n/g,"<br>")
				.replace(/\(\[\[(.*?)\[\[\)/g,"{$1|")
				.replace(/\(\]\](.*?)\]\]\)/g,"|$1}");
			return body
		}
		function getTag(tag=".",text="") {
			return `{${tag}|${text}|${tag}}`
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
					main.getTag("=",top_b.text),
					main.getTag("*",top_i.text),
					main.getTag(".",top_m.text),
					main.getTag("_",top_u.text),
					main.getTag("-",top_s.text),
					main.getTag("R","Red"),
					main.getTag("O","Orange"),
					main.getTag("Y","Yellow"),
					main.getTag("G","Green"),
					main.getTag("B","Blue"),
					main.getTag("P","Purple")
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
				text: main.style + main.fmt(rawText.text)
				padding: em
			}
		}
	}
}