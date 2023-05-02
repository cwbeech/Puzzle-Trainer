namespace Ksu.Cis300.PuzzleTrainer
{
    partial class UserInterface
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
            this.uxMenuStrip1 = new System.Windows.Forms.MenuStrip();
            this.uxPuzzleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uxUndoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uxRestartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uxNewPuzzleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uxToolStripTextBoxPlace = new System.Windows.Forms.ToolStripTextBox();
            this.uxToolStripTextBoxNum = new System.Windows.Forms.ToolStripTextBox();
            this.uxFlowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.uxMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // uxMenuStrip1
            // 
            this.uxMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.uxMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uxPuzzleToolStripMenuItem,
            this.uxToolStripTextBoxPlace,
            this.uxToolStripTextBoxNum});
            this.uxMenuStrip1.Location = new System.Drawing.Point(0, 0);
            this.uxMenuStrip1.Name = "uxMenuStrip1";
            this.uxMenuStrip1.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
            this.uxMenuStrip1.Size = new System.Drawing.Size(533, 25);
            this.uxMenuStrip1.TabIndex = 0;
            this.uxMenuStrip1.Text = "menuStrip1";
            // 
            // uxPuzzleToolStripMenuItem
            // 
            this.uxPuzzleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uxUndoToolStripMenuItem,
            this.uxRestartToolStripMenuItem,
            this.uxNewPuzzleToolStripMenuItem});
            this.uxPuzzleToolStripMenuItem.Name = "uxPuzzleToolStripMenuItem";
            this.uxPuzzleToolStripMenuItem.Size = new System.Drawing.Size(52, 23);
            this.uxPuzzleToolStripMenuItem.Text = "Puzzle";
            // 
            // uxUndoToolStripMenuItem
            // 
            this.uxUndoToolStripMenuItem.Enabled = false;
            this.uxUndoToolStripMenuItem.Name = "uxUndoToolStripMenuItem";
            this.uxUndoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.uxUndoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.uxUndoToolStripMenuItem.Text = "Undo";
            this.uxUndoToolStripMenuItem.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
            // 
            // uxRestartToolStripMenuItem
            // 
            this.uxRestartToolStripMenuItem.Enabled = false;
            this.uxRestartToolStripMenuItem.Name = "uxRestartToolStripMenuItem";
            this.uxRestartToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.uxRestartToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.uxRestartToolStripMenuItem.Text = "Restart";
            this.uxRestartToolStripMenuItem.Click += new System.EventHandler(this.uxRestartToolStripMenuItem_Click);
            // 
            // uxNewPuzzleToolStripMenuItem
            // 
            this.uxNewPuzzleToolStripMenuItem.Name = "uxNewPuzzleToolStripMenuItem";
            this.uxNewPuzzleToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.uxNewPuzzleToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.uxNewPuzzleToolStripMenuItem.Text = "New Puzzle";
            this.uxNewPuzzleToolStripMenuItem.Click += new System.EventHandler(this.newPuzzleToolStripMenuItem_Click);
            // 
            // uxToolStripTextBoxPlace
            // 
            this.uxToolStripTextBoxPlace.BackColor = System.Drawing.SystemColors.Control;
            this.uxToolStripTextBoxPlace.Name = "uxToolStripTextBoxPlace";
            this.uxToolStripTextBoxPlace.Size = new System.Drawing.Size(68, 23);
            this.uxToolStripTextBoxPlace.Text = "Place:";
            this.uxToolStripTextBoxPlace.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // uxToolStripTextBoxNum
            // 
            this.uxToolStripTextBoxNum.BackColor = System.Drawing.SystemColors.Control;
            this.uxToolStripTextBoxNum.Name = "uxToolStripTextBoxNum";
            this.uxToolStripTextBoxNum.Size = new System.Drawing.Size(68, 23);
            this.uxToolStripTextBoxNum.Text = "1";
            // 
            // uxFlowLayoutPanel1
            // 
            this.uxFlowLayoutPanel1.AutoSize = true;
            this.uxFlowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.uxFlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.uxFlowLayoutPanel1.Location = new System.Drawing.Point(25, 39);
            this.uxFlowLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.uxFlowLayoutPanel1.MinimumSize = new System.Drawing.Size(500, 300);
            this.uxFlowLayoutPanel1.Name = "uxFlowLayoutPanel1";
            this.uxFlowLayoutPanel1.Size = new System.Drawing.Size(500, 300);
            this.uxFlowLayoutPanel1.TabIndex = 1;
            this.uxFlowLayoutPanel1.WrapContents = false;
            // 
            // UserInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(533, 325);
            this.Controls.Add(this.uxFlowLayoutPanel1);
            this.Controls.Add(this.uxMenuStrip1);
            this.MainMenuStrip = this.uxMenuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "UserInterface";
            this.Text = "Puzzle Trainer";
            this.uxMenuStrip1.ResumeLayout(false);
            this.uxMenuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip uxMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem uxPuzzleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uxUndoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uxRestartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uxNewPuzzleToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox uxToolStripTextBoxPlace;
        private System.Windows.Forms.ToolStripTextBox uxToolStripTextBoxNum;
        private System.Windows.Forms.FlowLayoutPanel uxFlowLayoutPanel1;
    }
}

