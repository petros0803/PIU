namespace WF
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
            this.textBoxNume = new System.Windows.Forms.TextBox();
            this.labelNume = new System.Windows.Forms.Label();
            this.labelPrenume = new System.Windows.Forms.Label();
            this.textBoxPrenume = new System.Windows.Forms.TextBox();
            this.labelNote = new System.Windows.Forms.Label();
            this.textBoxNote = new System.Windows.Forms.TextBox();
            this.buttonAdauga = new System.Windows.Forms.Button();
            this.labelAdaugaStudent = new System.Windows.Forms.Label();
            this.comboBoxSpecializare = new System.Windows.Forms.ComboBox();
            this.labelSpecializare = new System.Windows.Forms.Label();
            this.labelLimbajeProgramare = new System.Windows.Forms.Label();
            this.listboxLimbajeDeProgramare = new System.Windows.Forms.ListBox();
            this.labelAnStudiu = new System.Windows.Forms.Label();
            this.textBoxAnStudiu = new System.Windows.Forms.TextBox();
            this.buttonCauta = new System.Windows.Forms.Button();
            this.labelFoundStudent = new System.Windows.Forms.Label();
            this.buttonModifica = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxNume
            // 
            this.textBoxNume.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxNume.Location = new System.Drawing.Point(99, 32);
            this.textBoxNume.Name = "textBoxNume";
            this.textBoxNume.Size = new System.Drawing.Size(116, 22);
            this.textBoxNume.TabIndex = 0;
            // 
            // labelNume
            // 
            this.labelNume.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelNume.AutoSize = true;
            this.labelNume.Location = new System.Drawing.Point(22, 35);
            this.labelNume.Name = "labelNume";
            this.labelNume.Size = new System.Drawing.Size(38, 15);
            this.labelNume.TabIndex = 1;
            this.labelNume.Text = "Nume";
            // 
            // labelPrenume
            // 
            this.labelPrenume.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelPrenume.AutoSize = true;
            this.labelPrenume.Location = new System.Drawing.Point(22, 63);
            this.labelPrenume.Name = "labelPrenume";
            this.labelPrenume.Size = new System.Drawing.Size(53, 15);
            this.labelPrenume.TabIndex = 3;
            this.labelPrenume.Text = "Prenume";
            // 
            // textBoxPrenume
            // 
            this.textBoxPrenume.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxPrenume.Location = new System.Drawing.Point(99, 60);
            this.textBoxPrenume.Name = "textBoxPrenume";
            this.textBoxPrenume.Size = new System.Drawing.Size(116, 22);
            this.textBoxPrenume.TabIndex = 2;
            // 
            // labelNote
            // 
            this.labelNote.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelNote.AutoSize = true;
            this.labelNote.Location = new System.Drawing.Point(22, 121);
            this.labelNote.Name = "labelNote";
            this.labelNote.Size = new System.Drawing.Size(33, 15);
            this.labelNote.TabIndex = 5;
            this.labelNote.Text = "Note";
            // 
            // textBoxNote
            // 
            this.textBoxNote.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxNote.Location = new System.Drawing.Point(99, 118);
            this.textBoxNote.Name = "textBoxNote";
            this.textBoxNote.Size = new System.Drawing.Size(116, 22);
            this.textBoxNote.TabIndex = 4;
            // 
            // buttonAdauga
            // 
            this.buttonAdauga.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonAdauga.Location = new System.Drawing.Point(25, 276);
            this.buttonAdauga.Name = "buttonAdauga";
            this.buttonAdauga.Size = new System.Drawing.Size(84, 27);
            this.buttonAdauga.TabIndex = 6;
            this.buttonAdauga.Text = "Adauga";
            this.buttonAdauga.UseVisualStyleBackColor = true;
            this.buttonAdauga.Click += new System.EventHandler(this.buttonAdauga_Click);
            // 
            // labelAdaugaStudent
            // 
            this.labelAdaugaStudent.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelAdaugaStudent.AutoSize = true;
            this.labelAdaugaStudent.Location = new System.Drawing.Point(22, 349);
            this.labelAdaugaStudent.Name = "labelAdaugaStudent";
            this.labelAdaugaStudent.Size = new System.Drawing.Size(0, 15);
            this.labelAdaugaStudent.TabIndex = 7;
            // 
            // comboBoxSpecializare
            // 
            this.comboBoxSpecializare.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBoxSpecializare.FormattingEnabled = true;
            this.comboBoxSpecializare.Location = new System.Drawing.Point(99, 147);
            this.comboBoxSpecializare.Name = "comboBoxSpecializare";
            this.comboBoxSpecializare.Size = new System.Drawing.Size(116, 23);
            this.comboBoxSpecializare.TabIndex = 8;
            this.comboBoxSpecializare.SelectedIndexChanged += new System.EventHandler(this.comboBoxSpecializare_SelectedIndexChanged);
            // 
            // labelSpecializare
            // 
            this.labelSpecializare.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelSpecializare.AutoSize = true;
            this.labelSpecializare.Location = new System.Drawing.Point(22, 150);
            this.labelSpecializare.Name = "labelSpecializare";
            this.labelSpecializare.Size = new System.Drawing.Size(69, 15);
            this.labelSpecializare.TabIndex = 10;
            this.labelSpecializare.Text = "Specializare";
            // 
            // labelLimbajeProgramare
            // 
            this.labelLimbajeProgramare.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelLimbajeProgramare.AutoSize = true;
            this.labelLimbajeProgramare.Location = new System.Drawing.Point(22, 180);
            this.labelLimbajeProgramare.Name = "labelLimbajeProgramare";
            this.labelLimbajeProgramare.Size = new System.Drawing.Size(48, 15);
            this.labelLimbajeProgramare.TabIndex = 11;
            this.labelLimbajeProgramare.Text = "Limbaje";
            // 
            // listboxLimbajeDeProgramare
            // 
            this.listboxLimbajeDeProgramare.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listboxLimbajeDeProgramare.FormattingEnabled = true;
            this.listboxLimbajeDeProgramare.ItemHeight = 15;
            this.listboxLimbajeDeProgramare.Location = new System.Drawing.Point(99, 176);
            this.listboxLimbajeDeProgramare.Name = "listboxLimbajeDeProgramare";
            this.listboxLimbajeDeProgramare.Size = new System.Drawing.Size(116, 94);
            this.listboxLimbajeDeProgramare.TabIndex = 12;
            this.listboxLimbajeDeProgramare.SelectedIndexChanged += new System.EventHandler(this.listboxLimbajeDeProgramare_SelectedIndexChanged);
            // 
            // labelAnStudiu
            // 
            this.labelAnStudiu.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelAnStudiu.AutoSize = true;
            this.labelAnStudiu.Location = new System.Drawing.Point(22, 92);
            this.labelAnStudiu.Name = "labelAnStudiu";
            this.labelAnStudiu.Size = new System.Drawing.Size(61, 15);
            this.labelAnStudiu.TabIndex = 14;
            this.labelAnStudiu.Text = "An studiu";
            // 
            // textBoxAnStudiu
            // 
            this.textBoxAnStudiu.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxAnStudiu.Location = new System.Drawing.Point(99, 89);
            this.textBoxAnStudiu.Name = "textBoxAnStudiu";
            this.textBoxAnStudiu.Size = new System.Drawing.Size(116, 22);
            this.textBoxAnStudiu.TabIndex = 13;
            // 
            // buttonCauta
            // 
            this.buttonCauta.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonCauta.Location = new System.Drawing.Point(131, 276);
            this.buttonCauta.Name = "buttonCauta";
            this.buttonCauta.Size = new System.Drawing.Size(84, 27);
            this.buttonCauta.TabIndex = 15;
            this.buttonCauta.Text = "Cauta";
            this.buttonCauta.UseVisualStyleBackColor = true;
            this.buttonCauta.Click += new System.EventHandler(this.buttonCauta_Click);
            // 
            // labelFoundStudent
            // 
            this.labelFoundStudent.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelFoundStudent.AutoSize = true;
            this.labelFoundStudent.Location = new System.Drawing.Point(369, 35);
            this.labelFoundStudent.Name = "labelFoundStudent";
            this.labelFoundStudent.Size = new System.Drawing.Size(0, 15);
            this.labelFoundStudent.TabIndex = 16;
            // 
            // buttonModifica
            // 
            this.buttonModifica.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonModifica.Location = new System.Drawing.Point(131, 276);
            this.buttonModifica.Name = "buttonModifica";
            this.buttonModifica.Size = new System.Drawing.Size(84, 27);
            this.buttonModifica.TabIndex = 17;
            this.buttonModifica.Text = "Modifica";
            this.buttonModifica.UseVisualStyleBackColor = true;
            this.buttonModifica.Click += new System.EventHandler(this.buttonModifica_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.buttonModifica);
            this.Controls.Add(this.labelFoundStudent);
            this.Controls.Add(this.buttonCauta);
            this.Controls.Add(this.labelAnStudiu);
            this.Controls.Add(this.textBoxAnStudiu);
            this.Controls.Add(this.listboxLimbajeDeProgramare);
            this.Controls.Add(this.labelLimbajeProgramare);
            this.Controls.Add(this.labelSpecializare);
            this.Controls.Add(this.comboBoxSpecializare);
            this.Controls.Add(this.labelAdaugaStudent);
            this.Controls.Add(this.buttonAdauga);
            this.Controls.Add(this.labelNote);
            this.Controls.Add(this.textBoxNote);
            this.Controls.Add(this.labelPrenume);
            this.Controls.Add(this.textBoxPrenume);
            this.Controls.Add(this.labelNume);
            this.Controls.Add(this.textBoxNume);
            this.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxNume;
        private System.Windows.Forms.Label labelNume;
        private System.Windows.Forms.Label labelPrenume;
        private System.Windows.Forms.TextBox textBoxPrenume;
        private System.Windows.Forms.Label labelNote;
        private System.Windows.Forms.TextBox textBoxNote;
        private System.Windows.Forms.Button buttonAdauga;
        private System.Windows.Forms.Label labelAdaugaStudent;
        private System.Windows.Forms.ComboBox comboBoxSpecializare;
        private System.Windows.Forms.Label labelSpecializare;
        private System.Windows.Forms.Label labelLimbajeProgramare;
        private System.Windows.Forms.ListBox listboxLimbajeDeProgramare;
        private System.Windows.Forms.Label labelAnStudiu;
        private System.Windows.Forms.TextBox textBoxAnStudiu;
        private System.Windows.Forms.Button buttonCauta;
        private System.Windows.Forms.Label labelFoundStudent;
        private System.Windows.Forms.Button buttonModifica;
    }
}

