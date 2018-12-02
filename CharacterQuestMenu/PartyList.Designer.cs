namespace CharacterQuestMenu
{
    partial class PartyList
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
            this.PartyScrollList = new System.Windows.Forms.ListView();
            this.Delete_Party = new System.Windows.Forms.Button();
            this.Finish_Selection = new System.Windows.Forms.Button();
            this.NewParty = new System.Windows.Forms.Button();
            this.SelectParty = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PartyScrollList
            // 
            this.PartyScrollList.Location = new System.Drawing.Point(109, 12);
            this.PartyScrollList.Name = "PartyScrollList";
            this.PartyScrollList.Size = new System.Drawing.Size(552, 423);
            this.PartyScrollList.TabIndex = 9;
            this.PartyScrollList.UseCompatibleStateImageBehavior = false;
            this.PartyScrollList.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PartyScrollList_KeyPress);
            // 
            // Delete_Party
            // 
            this.Delete_Party.Enabled = false;
            this.Delete_Party.Location = new System.Drawing.Point(12, 41);
            this.Delete_Party.Name = "Delete_Party";
            this.Delete_Party.Size = new System.Drawing.Size(75, 23);
            this.Delete_Party.TabIndex = 7;
            this.Delete_Party.Text = "Delete";
            this.Delete_Party.UseVisualStyleBackColor = true;
            this.Delete_Party.Click += new System.EventHandler(this.Delete_Party_Click);
            // 
            // Finish_Selection
            // 
            this.Finish_Selection.Location = new System.Drawing.Point(12, 412);
            this.Finish_Selection.Name = "Finish_Selection";
            this.Finish_Selection.Size = new System.Drawing.Size(75, 23);
            this.Finish_Selection.TabIndex = 6;
            this.Finish_Selection.Text = "Done";
            this.Finish_Selection.UseVisualStyleBackColor = true;
            // 
            // NewParty
            // 
            this.NewParty.Location = new System.Drawing.Point(12, 12);
            this.NewParty.Name = "NewParty";
            this.NewParty.Size = new System.Drawing.Size(75, 23);
            this.NewParty.TabIndex = 10;
            this.NewParty.Text = "New";
            this.NewParty.UseVisualStyleBackColor = true;
            this.NewParty.Click += new System.EventHandler(this.NewParty_Click);
            // 
            // SelectParty
            // 
            this.SelectParty.Location = new System.Drawing.Point(13, 380);
            this.SelectParty.Name = "SelectParty";
            this.SelectParty.Size = new System.Drawing.Size(75, 23);
            this.SelectParty.TabIndex = 11;
            this.SelectParty.Text = "Open";
            this.SelectParty.UseVisualStyleBackColor = true;
            this.SelectParty.Click += new System.EventHandler(this.SelectParty_Click);
            // 
            // PartyList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 446);
            this.Controls.Add(this.SelectParty);
            this.Controls.Add(this.NewParty);
            this.Controls.Add(this.PartyScrollList);
            this.Controls.Add(this.Delete_Party);
            this.Controls.Add(this.Finish_Selection);
            this.Name = "PartyList";
            this.Text = "PartyList";
            this.Load += new System.EventHandler(this.PartyList_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView PartyScrollList;
        private System.Windows.Forms.Button Delete_Party;
        private System.Windows.Forms.Button Finish_Selection;
        private System.Windows.Forms.Button NewParty;
        private System.Windows.Forms.Button SelectParty;
    }
}