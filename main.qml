import QtQuick 2.15
import QtQuick.Controls 2.15

ApplicationWindow {
	visible: true
	width: 400
	height: 300
	title: "QML Notepad"
	font.pointSize: 20
	Row {
		id: topBar
		width: parent.width
		Button {
			width: parent.width / 5
			text: "Bold"
		}
		Button {
			width: parent.width / 5
			text: "Italic"
		}
		Button {
			width: parent.width / 5
			text: "Mono"
		}
		Button {
			width: parent.width / 5
			text: "Underline"
		}
		Button {
			width: parent.width / 5
			text: "Strikethrough"
		}
	}
	Row {
		id: main
		width: parent.width
		anchors.top: topBar.bottom
		TextEdit {
			id: raw
			anchors.left: parent.left
			width: parent.width / 2
			height: parent.height
			font.pointSize: 20
			text: "Raw"
		}
		Rectangle {
			id: formatted
			anchors.right: parent.right
			width: parent.width / 2
			height: parent.height
			Text {
				font.pointSize: 20
				text: raw.text
			}
		}
	}
}