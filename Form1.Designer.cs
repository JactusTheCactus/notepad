namespace Notepad
	{
	partial class Form1
		{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
			{
			if (disposing && (components != null))
				{
				components.Dispose();
				}
			base.Dispose(disposing);
			}
		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
			{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.rtbEditor = new System.Windows.Forms.RichTextBox();
            this.formattingButton = new System.Windows.Forms.Button();
            this.ViewMode = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtbEditor
            // 
            this.rtbEditor.AcceptsTab = true;
            resources.ApplyResources(this.rtbEditor, "rtbEditor");
            this.rtbEditor.Name = "rtbEditor";
            // 
            // formattingButton
            // 
            resources.ApplyResources(this.formattingButton, "formattingButton");
            this.formattingButton.Name = "formattingButton";
            this.formattingButton.UseVisualStyleBackColor = true;
            this.formattingButton.Click += new System.EventHandler(this.formattingButton_Click);
            // 
            // ViewMode
            // 
            resources.ApplyResources(this.ViewMode, "ViewMode");
            this.ViewMode.Name = "ViewMode";
            this.ViewMode.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.formattingButton);
            this.panel1.Controls.Add(this.ViewMode);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rtbEditor);
            this.panel2.Controls.Add(this.panel1);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Name = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

			}

		#endregion

		private System.Windows.Forms.RichTextBox rtbEditor;
		private System.Windows.Forms.Button formattingButton;
		private System.Windows.Forms.RichTextBox ViewMode;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
	}
	}