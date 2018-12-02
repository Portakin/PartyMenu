namespace CharacterQuestMenu
{
    partial class CharacterList
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
            this.Finish_Selection = new System.Windows.Forms.Button();
            this.Delete_Character = new System.Windows.Forms.Button();
            this.Edit_Character = new System.Windows.Forms.Button();
            this.NewCharacter = new System.Windows.Forms.Button();
            this.CharacterScrollList = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // Finish_Selection
            // 
            this.Finish_Selection.Location = new System.Drawing.Point(12, 410);
            this.Finish_Selection.Name = "Finish_Selection";
            this.Finish_Selection.Size = new System.Drawing.Size(75, 23);
            this.Finish_Selection.TabIndex = 0;
            this.Finish_Selection.Text = "Done";
            this.Finish_Selection.UseVisualStyleBackColor = true;
            this.Finish_Selection.Click += new System.EventHandler(this.Finish_Selection_Click);
            // 
            // Delete_Character
            // 
            this.Delete_Character.Enabled = false;
            this.Delete_Character.Location = new System.Drawing.Point(12, 88);
            this.Delete_Character.Name = "Delete_Character";
            this.Delete_Character.Size = new System.Drawing.Size(75, 23);
            this.Delete_Character.TabIndex = 2;
            this.Delete_Character.Text = "Delete";
            this.Delete_Character.UseVisualStyleBackColor = true;
            this.Delete_Character.Click += new System.EventHandler(this.Delete_Character_Click);
            // 
            // Edit_Character
            // 
            this.Edit_Character.Location = new System.Drawing.Point(12, 50);
            this.Edit_Character.Name = "Edit_Character";
            this.Edit_Character.Size = new System.Drawing.Size(75, 23);
            this.Edit_Character.TabIndex = 3;
            this.Edit_Character.Text = "Edit";
            this.Edit_Character.UseVisualStyleBackColor = true;
            this.Edit_Character.Click += new System.EventHandler(this.Edit_Character_Click);
            // 
            // NewCharacter
            // 
            this.NewCharacter.Location = new System.Drawing.Point(12, 12);
            this.NewCharacter.Name = "NewCharacter";
            this.NewCharacter.Size = new System.Drawing.Size(75, 23);
            this.NewCharacter.TabIndex = 4;
            this.NewCharacter.Text = "New";
            this.NewCharacter.UseVisualStyleBackColor = true;
            this.NewCharacter.Click += new System.EventHandler(this.NewCharacter_Click_1);
            // 
            // CharacterScrollList
            // 
            this.CharacterScrollList.Location = new System.Drawing.Point(109, 12);
            this.CharacterScrollList.MultiSelect = false;
            this.CharacterScrollList.Name = "CharacterScrollList";
            this.CharacterScrollList.Size = new System.Drawing.Size(425, 423);
            this.CharacterScrollList.TabIndex = 5;
            this.CharacterScrollList.UseCompatibleStateImageBehavior = false;
            // 
            // CharacterList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 446);
            this.Controls.Add(this.CharacterScrollList);
            this.Controls.Add(this.NewCharacter);
            this.Controls.Add(this.Edit_Character);
            this.Controls.Add(this.Delete_Character);
            this.Controls.Add(this.Finish_Selection);
            this.Name = "CharacterList";
            this.Text = " ";
            this.Load += new System.EventHandler(this.CharacterList_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Finish_Selection;
        private System.Windows.Forms.Button Delete_Character;
        private System.Windows.Forms.Button Edit_Character;
        private System.Windows.Forms.Button NewCharacter;
        private System.Windows.Forms.ListView CharacterScrollList;
    }
}