import re
import sass
from PyQt5.QtWidgets import (
	QApplication,
	QWidget,
	QTextEdit,
	QHBoxLayout
)
syntax = {
	"=": "bold",
	"*": "italic",
	".": "mono",
	"_": "underline",
	"~": "strikethrough"
}
inputCSS = """
	QTextEdit {
		font: 20pt monospace;
	}
""".strip()
with open("style.scss","r",encoding="utf8") as f:
	outputSCSS = f.read()
def formatRaw(self):
	self.input.setFontFamily("monospace")
class MarkupEditor(QWidget):
	def __init__(self):
		super().__init__()
		self.input = QTextEdit()
		self.input.setStyleSheet(inputCSS)
		self.preview = QTextEdit()
		formatRaw(self)
		self.preview.setReadOnly(True)
		layout = QHBoxLayout()
		layout.addWidget(self.input)
		layout.addWidget(self.preview)
		self.setLayout(layout)
		self.input.textChanged.connect(self.update_preview)
	def update_preview(self):
		text = self.input.toPlainText()
		formatRaw(self)
		for k,v in syntax.items():
			k = re.escape(k)
			print(k,v)
			text = re.sub(
				f"\\{{{k}\\|(.*?)\\|{k}\\}}",
				f"<span class=\"{v}\">\\1</span>",
				text
			)
		text = re.sub("\n","<br>",text)
		outputCSS = sass.compile(string=outputSCSS,output_style="compressed").strip()
		text = f"<style>{outputCSS}</style><body>{text}</body>"
		print(re.sub(r"\t"," "*4,text))
		self.preview.setHtml(text)
if __name__ == "__main__":
	app = QApplication([])
	w = MarkupEditor()
	w.setWindowTitle("Notepad")
	w.resize(800, 400)
	w.show()
	app.exec_()