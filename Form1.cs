using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
namespace Notepad
{
	public partial class Form1 : Form
	{
		string rawText = "";
		bool formatted = false; // your toggle
		public Form1()
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
				rtbEditor.SelectedText = ""; // safely remove tag
			}
		}
		private void SetStyle(String tag, FontStyle style)
		{
			String pattern = $@"(?<=<{tag}>)(.*?)(?=</{tag}>)";
			foreach (Match match in Regex.Matches(rtbEditor.Text, pattern))
			{
				rtbEditor.Select(match.Index, match.Length);
				rtbEditor.SelectionFont = new Font("Segoe UI", 20, style);
				rtbEditor.DeselectAll();
			}
			RemoveTags($@"</?{tag}>");
		}
		private void format()
		{
			if (formatted)
			{
				rtbEditor.Font = new Font("Arial", 20, FontStyle.Regular);
				ViewMode.Text = "Formatting Mode";
				rawText = rtbEditor.Text;
				SetStyle("i", FontStyle.Italic);
				SetStyle("b", FontStyle.Bold);
				Console.WriteLine(rtbEditor.Text);
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

			// Keep caret at the end
			rtbEditor.SelectionStart = rtbEditor.Text.Length;
			rtbEditor.ScrollToCaret();
		}
		private void Form1_Load(object sender, EventArgs e)
		{
			format();
		}
	}
}