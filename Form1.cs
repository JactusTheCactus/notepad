using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Notepad
	{
	public partial class Form1 : Form
		{
		public Form1()
			{
			InitializeComponent();
			}
		private void SetStyle(String RegExp, FontStyle style)
			{
			foreach (Match match in Regex.Matches(rtbEditor.Text, RegExp))
				{
				rtbEditor.Select(match.Index, match.Length);
				rtbEditor.SelectionFont = new Font("Segoe UI", 20, style);
				rtbEditor.DeselectAll();
				}
			}
		bool formatted = false;
		private void ApplyMarkup(string pattern, FontStyle style)
			{
			foreach (Match match in Regex.Matches(rtbEditor.Text, pattern))
				{
				string innerText = match.Groups[1].Value;

				// Apply style to inner text (not the tags)
				int start = match.Index + match.Value.IndexOf(innerText);
				rtbEditor.Select(start, innerText.Length);
				rtbEditor.SelectionFont = new Font("Segoe UI", 20, style);
				}
			}
		private void HideTags(string tagPattern)
			{
			foreach (Match match in Regex.Matches(rtbEditor.Text, tagPattern))
				{
				rtbEditor.Select(match.Index, match.Length);
				rtbEditor.Text = Regex.Replace(rtbEditor.Text, @"</?\w+>", "");
				//rtbEditor.SelectionColor = rtbEditor.BackColor; // invisible
				}
			}
		private void ApplyFormatting()
			{
			int cursorPos = rtbEditor.SelectionStart;

			// Reset formatting
			rtbEditor.SelectAll();
			rtbEditor.SelectionFont = new Font("Segoe UI", 20, FontStyle.Regular);
			rtbEditor.SelectionColor = Color.Black;
			rtbEditor.DeselectAll();

			// Apply bold
			ApplyMarkup(@"<b>(.*?)</b>", FontStyle.Bold);

			// Apply italic
			ApplyMarkup(@"<i>(.*?)</i>", FontStyle.Italic);

			// Hide tags
			HideTags(@"</?b>");
			HideTags(@"</?i>");

			rtbEditor.SelectionStart = cursorPos;
			}
		private void rtbEditor_TextChanged(object sender, EventArgs e)
			{
			if (formatted)
				{
				ApplyFormatting();
				}
			}
		private void button1_Click(object sender, EventArgs e)
			{
			formatted = !formatted;
			if (formatted)
				{
				ApplyFormatting();
				}
			else
				{
				string plainText = rtbEditor.Text;
				rtbEditor.SelectAll();
				rtbEditor.SelectionFont = new Font("Segoe UI", 20, FontStyle.Regular);
				rtbEditor.SelectionColor = Color.Black;
				rtbEditor.DeselectAll();
				}
			}
		}
	}