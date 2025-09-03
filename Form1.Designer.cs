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
            this.SuspendLayout();
            // 
            // rtbEditor
            // 
            resources.ApplyResources(this.rtbEditor, "rtbEditor");
            this.rtbEditor.Name = "rtbEditor";
            this.rtbEditor.TextChanged += new System.EventHandler(this.rtbEditor_TextChanged);
            // 
            // formattingButton
            // 
            resources.ApplyResources(this.formattingButton, "formattingButton");
            this.formattingButton.Name = "formattingButton";
            this.formattingButton.UseVisualStyleBackColor = true;
            this.formattingButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.formattingButton);
            this.Controls.Add(this.rtbEditor);
            this.Name = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

			}

		#endregion

		private System.Windows.Forms.RichTextBox rtbEditor;
		private System.Windows.Forms.Button formattingButton;
		}
	}