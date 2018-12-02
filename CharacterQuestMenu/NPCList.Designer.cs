namespace CharacterQuestMenu
{
    partial class NPCList
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
            this.NewNPC = new System.Windows.Forms.Button();
            this.Delete_NPC = new System.Windows.Forms.Button();
            this.Finish_Selection = new System.Windows.Forms.Button();
            this.PartyRoster = new System.Windows.Forms.ListView();
            this.Remove = new System.Windows.Forms.Button();
            this.NPCRoster = new System.Windows.Forms.ListView();
            this.Edit_character = new System.Windows.Forms.Button();
            this.Add_Character = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // NewNPC
            // 
            this.NewNPC.Location = new System.Drawing.Point(299, 45);
            this.NewNPC.Name = "NewNPC";
            this.NewNPC.Size = new System.Drawing.Size(84, 23);
            this.NewNPC.TabIndex = 15;
            this.NewNPC.Text = "New";
            this.NewNPC.UseVisualStyleBackColor = true;
            this.NewNPC.Click += new System.EventHandler(this.NewNPC_Click);
            // 
            // Delete_NPC
            // 
            this.Delete_NPC.Location = new System.Drawing.Point(299, 103);
            this.Delete_NPC.Name = "Delete_NPC";
            this.Delete_NPC.Size = new System.Drawing.Size(84, 23);
            this.Delete_NPC.TabIndex = 13;
            this.Delete_NPC.Text = "Delete";
            this.Delete_NPC.UseVisualStyleBackColor = true;
            this.Delete_NPC.Click += new System.EventHandler(this.Delete_NPC_Click);
            // 
            // Finish_Selection
            // 
            this.Finish_Selection.Location = new System.Drawing.Point(299, 390);
            this.Finish_Selection.Name = "Finish_Selection";
            this.Finish_Selection.Size = new System.Drawing.Size(84, 23);
            this.Finish_Selection.TabIndex = 12;
            this.Finish_Selection.Text = "Finish";
            this.Finish_Selection.UseVisualStyleBackColor = true;
            this.Finish_Selection.Click += new System.EventHandler(this.Finish_Selection_Click);
            // 
            // PartyRoster
            // 
            this.PartyRoster.Location = new System.Drawing.Point(12, 45);
            this.PartyRoster.MultiSelect = false;
            this.PartyRoster.Name = "PartyRoster";
            this.PartyRoster.Size = new System.Drawing.Size(244, 339);
            this.PartyRoster.TabIndex = 17;
            this.PartyRoster.UseCompatibleStateImageBehavior = false;
            // 
            // Remove
            // 
            this.Remove.Location = new System.Drawing.Point(60, 390);
            this.Remove.Name = "Remove";
            this.Remove.Size = new System.Drawing.Size(156, 23);
            this.Remove.TabIndex = 19;
            this.Remove.Text = "Remove From Party";
            this.Remove.UseVisualStyleBackColor = true;
            this.Remove.Click += new System.EventHandler(this.Remove_Click);
            // 
            // NPCRoster
            // 
            this.NPCRoster.Location = new System.Drawing.Point(423, 45);
            this.NPCRoster.MultiSelect = false;
            this.NPCRoster.Name = "NPCRoster";
            this.NPCRoster.Size = new System.Drawing.Size(243, 339);
            this.NPCRoster.TabIndex = 20;
            this.NPCRoster.UseCompatibleStateImageBehavior = false;
            // 
            // Edit_character
            // 
            this.Edit_character.Enabled = false;
            this.Edit_character.Location = new System.Drawing.Point(299, 74);
            this.Edit_character.Name = "Edit_character";
            this.Edit_character.Size = new System.Drawing.Size(84, 23);
            this.Edit_character.TabIndex = 21;
            this.Edit_character.Text = "Edit";
            this.Edit_character.UseVisualStyleBackColor = true;
            this.Edit_character.Click += new System.EventHandler(this.Edit_character_Click);
            // 
            // Add_Character
            // 
            this.Add_Character.Location = new System.Drawing.Point(473, 390);
            this.Add_Character.Name = "Add_Character";
            this.Add_Character.Size = new System.Drawing.Size(157, 23);
            this.Add_Character.TabIndex = 22;
            this.Add_Character.Text = "Add To Party";
            this.Add_Character.UseVisualStyleBackColor = true;
            this.Add_Character.Click += new System.EventHandler(this.Add_Character_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 431);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(653, 86);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(102, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(456, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Add NPCs to your party accordingly. Adding or removing them from active party ref" +
    "reshes them. ";
            // 
            // NPCList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 529);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Add_Character);
            this.Controls.Add(this.Edit_character);
            this.Controls.Add(this.NPCRoster);
            this.Controls.Add(this.Remove);
            this.Controls.Add(this.PartyRoster);
            this.Controls.Add(this.NewNPC);
            this.Controls.Add(this.Delete_NPC);
            this.Controls.Add(this.Finish_Selection);
            this.Name = "NPCList";
            this.Text = "NPCList";
            this.Load += new System.EventHandler(this.NPCList_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button NewNPC;
        private System.Windows.Forms.Button Delete_NPC;
        private System.Windows.Forms.Button Finish_Selection;
        private System.Windows.Forms.ListView PartyRoster;
        private System.Windows.Forms.Button Remove;
        private System.Windows.Forms.ListView NPCRoster;
        private System.Windows.Forms.Button Edit_character;
        private System.Windows.Forms.Button Add_Character;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
    }
}