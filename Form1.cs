using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
namespace Notepad
{
	public partial class App : Form
	{
		Dictionary<string, string> formatDict = new Dictionary<string, string>();
		string rawText;
		bool formatted = false;
		public App()
		{
			InitializeComponent();
			formatDict.Add("bold", "=");
			formatDict.Add("italic", "*");
			formatDict.Add("bold-italic", $"{formatDict["bold"]}{formatDict["italic"]}");
			formatDict.Add("mono", ".");
			formatDict.Add("underline", "_");
			formatDict.Add("strikethrough", "~");
			rawText = $@"{FmtString("bold", "Bold")}
{FmtString("italic", "Italic")}
{FmtString("bold-italic", "Bold+Italic")}
{FmtString("mono", "Monospace")}
{FmtString("underline", "Underline")}
{FmtString("strikethrough", "Strikethrough")}";
		}
		private string[] SyntaxFormat(string input)
		{
			return new string[] { $@"{{{formatDict[input]}|", $@"|{formatDict[input]}}}" };
		}
		private string FmtString(string tag, string input)
		{
			return $"{SyntaxFormat(tag)[0]}{input}{SyntaxFormat(tag)[1]}";
		}
		private void RemoveTags(string pattern)
		{
			var matches = Regex.Matches(RTBEditor.Text, pattern);
			for (int i = matches.Count - 1; i >= 0; i--)
			{
				var match = matches[i];
				RTBEditor.Select(match.Index, match.Length);
				RTBEditor.SelectedText = "";
			}
		}
		private Font SetFont(
			string family = "Arial",
			int size = 20,
			string style = "Regular"
		)
		{
			FontStyle fontStyle = (FontStyle)Enum.Parse(typeof(FontStyle), style.Replace(" ", ""), true);
			return new Font(family, size, fontStyle);
		}
		private void SetStyle(Action<RichTextBox> formatter, string openTag, string closeTag)
		{
			openTag = Regex.Escape(openTag);
			closeTag = Regex.Escape(closeTag);
			string pattern = $@"(?<={openTag})(.*?)(?={closeTag})";
			foreach (Match match in Regex.Matches(RTBEditor.Text, pattern))
			{
				RTBEditor.Select(match.Index, match.Length);
				formatter(RTBEditor);
				RTBEditor.DeselectAll();
			}
			RemoveTags($@"{openTag}|{closeTag}");
		}
		private void StyleFormat(
			string[] tags,
			string family = "Arial",
			int size = 20,
			string style = "Regular"
			)
		{
			SetStyle(box => box.SelectionFont = SetFont(
				family: family,
				size: size,
				style: style
			), tags[0], tags[1]);
		}
		private void Format()
		{
			if (formatted)
			{
				RTBEditor.Font = new Font("Arial", 20, FontStyle.Regular);
				ViewMode.Text = "Formatting Mode";
				rawText = RTBEditor.Text;
				StyleFormat(SyntaxFormat("italic"),
					style: "Italic"
				);
				StyleFormat(SyntaxFormat("bold"),
					style: "Bold"
				);
				StyleFormat(SyntaxFormat("bold-italic"),
					style: "Bold, Italic"
				);
				StyleFormat(SyntaxFormat("underline"),
					style: "Underline"
				);
				StyleFormat(SyntaxFormat("strikethrough"),
					style: "Strikeout"
				);
				StyleFormat(SyntaxFormat("mono"),
					family: "Consolas"
				);
				RTBEditor.ReadOnly = true;
			}
			else
			{
				ViewMode.Text = "Editing Mode";
				RTBEditor.Text = rawText;
				RTBEditor.Font = new Font("Consolas", 20, FontStyle.Regular);
				RTBEditor.ReadOnly = false;
			}
		}
		private void FormattingButton_Click(object sender, EventArgs e)
		{
			formatted = !formatted;
			Format();
			RTBEditor.SelectionStart = RTBEditor.Text.Length;
			RTBEditor.ScrollToCaret();
		}
		private void Form1_Load(object sender, EventArgs e)
		{
			Format();
		}
	}
}