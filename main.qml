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
			"red": "red",
			"orange": "orange",
			"yellow": "yellow",
			"green": "green",
			"blue": "blue",
			"purple": "purple"
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
			"red": [
				["color","#f00"]
			],
			"orange": [
				["color","#f80"]
			],
			"yellow": [
				["color","#ff0"]
			],
			"green": [
				["color","#0f0"]
			],
			"blue": [
				["color","#00f"]
			],
			"purple": [
				["color","#80f"]
			]
		}
		function cssStyle(c,r) {
			return `${c}{${r
				.map(([p,v]) => {
					return `${p}:${v};`
				})
				.join("")
			}}`
		}
		property var style: `<style>${[
			//"body{}"
		].join("")}${Object
			.entries(main.stylesheet)
			.map(i => {
				return cssStyle(`${i[0]}-style`,i[1])
			})
			.join("")
		}</style>`
		function _() {
			console.log(style);
			console.log(formattedText.fmtText)
		}
		function fmt(text) {
			let body = text;
			body = body
				.replace(/\{\{(.*?)\|/g, "([[$1[[)")
				.replace(/\|(.*?)\}\}/g, "(]]$1]])")
				.replace(/\n{4,}/g,["<br>","<br>"].join("=".repeat(25)))
				.replace(/\n{3,}/g,["<br>","<br>"].join("-".repeat(25)))
				.replace(/\n{2,}/g,["<br>","<br>"].join("\u00b7".repeat(25)))
				.replace(/\n/g,"<br>")
			let match;
			while ((match = /\{\S*? \S*?\||\|\S*? \S*?\}/g.exec(body))) {
				body = body
					.replace(/\{(\S*?) (\S*?)\|/g,"{$1|{$2|")
					.replace(/\|(\S*?) (\S*?)\}/g,"|$1}|$2}")
			}
			Object.entries(syntax).forEach(([k,v]) => {
				body = body.replace(
					new RegExp(`\\{${k}\\|(.*?)\\|${k}\\}`,"g"),
					`<${v}-style>$1</${v}-style>`
				);
			});
			body = body
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
				width: parent.width
				height: parent.height
				font.family: "monospace"
				font.pointSize: em
				wrapMode: TextEdit.Wrap
				text: [
					main.getTag("=",top_b.text),
					main.getTag("*",top_i.text),
					main.getTag(".",top_m.text),
					main.getTag("_",top_u.text),
					main.getTag("-",top_s.text),
					"",
					main.getTag("red","Red"),
					main.getTag("orange","Orange"),
					main.getTag("yellow","Yellow"),
					main.getTag("green","Green"),
					main.getTag("blue","Blue"),
					main.getTag("purple","Purple")
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
				width: parent.width
				height: parent.height
				font.pointSize: em
				textFormat: Text.RichText
				property var fmtText: main.fmt(rawText.text)
				text: main.style + fmtText
				padding: em
				wrapMode: Text.Wrap
			}
		}
	}
}