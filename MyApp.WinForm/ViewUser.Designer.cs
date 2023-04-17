namespace MyApp.WinForm
{
    partial class ViewUser
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
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            lblForename = new System.Windows.Forms.Label();
            lblSurname = new System.Windows.Forms.Label();
            lblIsActive = new System.Windows.Forms.Label();
            btnBack = new System.Windows.Forms.Button();
            label5 = new System.Windows.Forms.Label();
            lblDOB = new System.Windows.Forms.Label();
            listView1 = new System.Windows.Forms.ListView();
            Action = new System.Windows.Forms.ColumnHeader();
            Date_Time = new System.Windows.Forms.ColumnHeader();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label1.Location = new System.Drawing.Point(153, 9);
            label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(101, 25);
            label1.TabIndex = 0;
            label1.Text = "View User";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(26, 71);
            label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(63, 15);
            label2.TabIndex = 1;
            label2.Text = "Forename:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(26, 97);
            label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(57, 15);
            label3.TabIndex = 2;
            label3.Text = "Surname:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(29, 125);
            label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(54, 15);
            label4.TabIndex = 3;
            label4.Text = "Is Active:";
            // 
            // lblForename
            // 
            lblForename.AutoSize = true;
            lblForename.Location = new System.Drawing.Point(113, 71);
            lblForename.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            lblForename.Name = "lblForename";
            lblForename.Size = new System.Drawing.Size(77, 15);
            lblForename.TabIndex = 4;
            lblForename.Text = "[FORENAME]";
            // 
            // lblSurname
            // 
            lblSurname.AutoSize = true;
            lblSurname.Location = new System.Drawing.Point(113, 97);
            lblSurname.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            lblSurname.Name = "lblSurname";
            lblSurname.Size = new System.Drawing.Size(70, 15);
            lblSurname.TabIndex = 5;
            lblSurname.Text = "[SURNAME]";
            // 
            // lblIsActive
            // 
            lblIsActive.AutoSize = true;
            lblIsActive.Location = new System.Drawing.Point(113, 125);
            lblIsActive.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            lblIsActive.Name = "lblIsActive";
            lblIsActive.Size = new System.Drawing.Size(62, 15);
            lblIsActive.TabIndex = 6;
            lblIsActive.Text = "[ISACTIVE]";
            // 
            // btnBack
            // 
            btnBack.Location = new System.Drawing.Point(362, 305);
            btnBack.Margin = new System.Windows.Forms.Padding(2);
            btnBack.Name = "btnBack";
            btnBack.Size = new System.Drawing.Size(93, 40);
            btnBack.TabIndex = 7;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(29, 153);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(76, 15);
            label5.TabIndex = 8;
            label5.Text = "Date of Birth:";
            // 
            // lblDOB
            // 
            lblDOB.AutoSize = true;
            lblDOB.Location = new System.Drawing.Point(113, 153);
            lblDOB.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            lblDOB.Name = "lblDOB";
            lblDOB.Size = new System.Drawing.Size(80, 15);
            lblDOB.TabIndex = 9;
            lblDOB.Text = "DATEOFBIRTH";
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { Action, Date_Time });
            listView1.Location = new System.Drawing.Point(29, 186);
            listView1.Name = "listView1";
            listView1.Size = new System.Drawing.Size(316, 158);
            listView1.TabIndex = 10;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = System.Windows.Forms.View.Details;
            listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;
            // 
            // Action
            // 
            Action.Text = "Action";
            Action.Width = 105;
            // 
            // Date_Time
            // 
            Date_Time.Text = "Date of Action";
            Date_Time.Width = 200;
            // 
            // ViewUser
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(466, 356);
            Controls.Add(listView1);
            Controls.Add(lblDOB);
            Controls.Add(label5);
            Controls.Add(btnBack);
            Controls.Add(lblIsActive);
            Controls.Add(lblSurname);
            Controls.Add(lblForename);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new System.Windows.Forms.Padding(2);
            Name = "ViewUser";
            Text = "ViewUser";
            Load += ViewUser_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblForename;
        private System.Windows.Forms.Label lblSurname;
        private System.Windows.Forms.Label lblIsActive;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblDOB;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader Action;
        private System.Windows.Forms.ColumnHeader Date_Time;
    }
}