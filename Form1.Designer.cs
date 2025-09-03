namespace Notepad
	{
	partial class App
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(App));
            this.rtbEditor = new System.Windows.Forms.RichTextBox();
            this.formattingButton = new System.Windows.Forms.Button();
            this.ViewMode = new System.Windows.Forms.RichTextBox();
            this.TopBar = new System.Windows.Forms.Panel();
            this.Window = new System.Windows.Forms.Panel();
            this.TopBar.SuspendLayout();
            this.Window.SuspendLayout();
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
            // TopBar
            // 
            this.TopBar.Controls.Add(this.formattingButton);
            this.TopBar.Controls.Add(this.ViewMode);
            resources.ApplyResources(this.TopBar, "TopBar");
            this.TopBar.Name = "TopBar";
            // 
            // Window
            // 
            this.Window.Controls.Add(this.rtbEditor);
            this.Window.Controls.Add(this.TopBar);
            resources.ApplyResources(this.Window, "Window");
            this.Window.Name = "Window";
            // 
            // App
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Window);
            this.Name = "App";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.TopBar.ResumeLayout(false);
            this.TopBar.PerformLayout();
            this.Window.ResumeLayout(false);
            this.ResumeLayout(false);

			}

		#endregion

		private System.Windows.Forms.RichTextBox rtbEditor;
		private System.Windows.Forms.Button formattingButton;
		private System.Windows.Forms.RichTextBox ViewMode;
		private System.Windows.Forms.Panel TopBar;
		private System.Windows.Forms.Panel Window;
	}
	}