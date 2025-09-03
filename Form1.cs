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
		String editingLabel = "Editing Mode";
		String formattingLabel = "Formatting Mode";
		string rawText = "";
		bool formatted = false; // your toggle
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
		private void formattingButton_Click(object sender, EventArgs e)
		{
			formatted = !formatted;

			if (formatted)
			{
				ViewMode.Text = formattingLabel;
				// Copy current text to rawText and apply formatting
				rawText = rtbEditor.Text;
				rtbEditor.Text = ApplyFormatting(rawText);

				// Prevent further input
				rtbEditor.ReadOnly = true;
			}
			else
			{
				ViewMode.Text = editingLabel;
				// Restore raw text for editing
				rtbEditor.Text = rawText;

				// Allow typing again
				rtbEditor.ReadOnly = false;
			}

			// Keep caret at the end
			rtbEditor.SelectionStart = rtbEditor.Text.Length;
			rtbEditor.ScrollToCaret();
		}
		private string ApplyFormatting(string input)
		{
			// Example formatting: uppercase
			return input.ToUpper();
		}
		private void Form1_Load(object sender, EventArgs e)
		{
			ViewMode.Text = editingLabel;
		}
	}
}