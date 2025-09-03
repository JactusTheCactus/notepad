using System;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
namespace Notepad
{
	public partial class App : Form
	{
		string rawText = @"
	`  `<b>Bold</b>
	`+ `<i>Italic</i>
	`= `<b,i>Both</b,i>

	_Underline_";
		bool formatted = false;
		public App()
		{
			InitializeComponent();
		}
		private void RemoveTags(string pattern)
		{
			var matches = Regex.Matches(rtbEditor.Text, pattern);
			for (int i = matches.Count - 1; i >= 0; i--)
			{
				var match = matches[i];
				rtbEditor.Select(match.Index, match.Length);
				rtbEditor.SelectedText = "";
			}
		}
		private Font SetFont(
			String family = "Arial",
			Int32 size = 20,
			String style = "Regular"
			)
		{
			FontStyle fontStyle = (FontStyle)Enum.Parse(typeof(FontStyle), style.Replace(" ", ""), true);
			return new Font(family, size, fontStyle);
		}
		private void SetStyle(Action<RichTextBox> formatter, String openTag, String closeTag)
		{
			openTag = Regex.Escape(openTag);
			closeTag = Regex.Escape(closeTag);
			String pattern = $@"(?<={openTag})(.*?)(?={closeTag})";
			foreach (Match match in Regex.Matches(rtbEditor.Text, pattern))
			{
				rtbEditor.Select(match.Index, match.Length);
				formatter(rtbEditor);
				rtbEditor.DeselectAll();
			}
			RemoveTags($@"{openTag}|{closeTag}");
		}
		private void StyleFormat(
			String[] tags,
			String family = "Arial",
			Int32 size = 20,
			String style = "Regular"
			)
		{
			SetStyle(box => box.SelectionFont = SetFont(
				family: family,
				size: size,
				style: style
			), tags[0], tags[1]);
		}
		private String[] HTML(String tag)
		{
			return new String[] { $"<{tag}>", $"</{tag}>" };
		}
		private T[] ListDuplicates<T>(T input, Int32 n)
		{
			return Enumerable.Repeat(input, n).ToArray();
		}
		private void format()
		{
			if (formatted)
			{
				rtbEditor.Font = new Font("Arial", 20, FontStyle.Regular);
				ViewMode.Text = "Formatting Mode";
				rawText = rtbEditor.Text;
				StyleFormat(HTML("i"),
					style: "Italic"
				);
				StyleFormat(HTML("b"),
					style: "Bold"
				);
				StyleFormat(HTML("b,i"),
					style: "Bold, Italic"
				);
				StyleFormat(ListDuplicates("_", 2),
					style: "Underline"
				);
				StyleFormat(ListDuplicates("`", 2),
					family: "Consolas"
				);
				rtbEditor.ReadOnly = true;
			}
			else
			{
				ViewMode.Text = "Editing Mode";
				rtbEditor.Text = rawText;
				rtbEditor.Font = new Font("Consolas", 20, FontStyle.Regular);
				rtbEditor.ReadOnly = false;
			}
		}
		private void formattingButton_Click(object sender, EventArgs e)
		{
			formatted = !formatted;
			format();
			rtbEditor.SelectionStart = rtbEditor.Text.Length;
			rtbEditor.ScrollToCaret();
		}
		private void Form1_Load(object sender, EventArgs e)
		{
			format();
		}
	}
}