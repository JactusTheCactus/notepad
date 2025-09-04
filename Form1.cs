using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
namespace Notepad
{
	public partial class App : Form
	{
		Dictionary<string, string> formatDict = new Dictionary<string, string>
		{
			{ "bold", "b" },
			{"italic","*" },
			{"bold-italic","b*" },
			{"mono","m" },
			{"underline","_" },
			{"strikethrough","~" }
		};
		string rawText;
		private string[] SyntaxFormat(string input)
		{
			return new string[] { $@"{{{input}|", $@"|{input}}}" };
		}
		private string FmtString(string tag, string input)
		{
			return $"{SyntaxFormat(formatDict[tag])[0]}{input}{SyntaxFormat(formatDict[tag])[1]}";
		}
		bool formatted = false;
		public App()
		{
			InitializeComponent();
			rawText = $@"
	{FmtString("mono", "  ")}{FmtString("bold", "Bold")}
	{FmtString("mono", "+ ")}{FmtString("italic", "Italic")}
	{FmtString("mono", "= ")}{FmtString("bold-italic", "Both")}

	{FmtString("underline", "Underline")}
	{FmtString("strikethrough", "Strikethrough")}";
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
				StyleFormat(SyntaxFormat("*"),
					style: "Italic"
				);
				StyleFormat(SyntaxFormat("b"),
					style: "Bold"
				);
				StyleFormat(SyntaxFormat("b*"),
					style: "Bold, Italic"
				);
				StyleFormat(SyntaxFormat("_"),
					style: "Underline"
				);
				StyleFormat(SyntaxFormat("~"),
					style: "Strikeout"
				);
				StyleFormat(SyntaxFormat("m"),
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