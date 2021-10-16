namespace Gladiatoria
{
    partial class AddGladiator
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.picGladiator = new System.Windows.Forms.PictureBox();
            this.btnLoadPhoto = new System.Windows.Forms.Button();
            this.tbName = new System.Windows.Forms.TextBox();
            this.dtpBirfthday = new System.Windows.Forms.DateTimePicker();
            this.tbRating = new System.Windows.Forms.TextBox();
            this.tbCountry = new System.Windows.Forms.TextBox();
            this.tbLocation = new System.Windows.Forms.TextBox();
            this.tbClub = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tbFamyliName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbSecondName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cbSex = new System.Windows.Forms.ComboBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label10 = new System.Windows.Forms.Label();
            this.nBattles = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.nWins = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.nLosers = new System.Windows.Forms.NumericUpDown();
            this.nWP = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.nMH = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.picGladiator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nBattles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nWins)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nLosers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nWP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nMH)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ім\'я";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Дата народження";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 171);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Рейтинг майстерності";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 209);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Країна";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 237);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Населений пункт";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 263);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Клуб";
            // 
            // picGladiator
            // 
            this.picGladiator.Location = new System.Drawing.Point(443, 12);
            this.picGladiator.Name = "picGladiator";
            this.picGladiator.Size = new System.Drawing.Size(160, 216);
            this.picGladiator.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picGladiator.TabIndex = 6;
            this.picGladiator.TabStop = false;
            // 
            // btnLoadPhoto
            // 
            this.btnLoadPhoto.Location = new System.Drawing.Point(443, 250);
            this.btnLoadPhoto.Name = "btnLoadPhoto";
            this.btnLoadPhoto.Size = new System.Drawing.Size(160, 27);
            this.btnLoadPhoto.TabIndex = 9;
            this.btnLoadPhoto.Text = "Завантажити фото...";
            this.btnLoadPhoto.UseVisualStyleBackColor = true;
            this.btnLoadPhoto.Click += new System.EventHandler(this.btnLoadPhoto_Click);
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(87, 12);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(272, 20);
            this.tbName.TabIndex = 0;
            // 
            // dtpBirfthday
            // 
            this.dtpBirfthday.Location = new System.Drawing.Point(121, 141);
            this.dtpBirfthday.Name = "dtpBirfthday";
            this.dtpBirfthday.Size = new System.Drawing.Size(200, 20);
            this.dtpBirfthday.TabIndex = 4;
            // 
            // tbRating
            // 
            this.tbRating.Location = new System.Drawing.Point(142, 168);
            this.tbRating.Name = "tbRating";
            this.tbRating.Size = new System.Drawing.Size(82, 20);
            this.tbRating.TabIndex = 5;
            this.tbRating.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbCountry
            // 
            this.tbCountry.Enabled = false;
            this.tbCountry.Location = new System.Drawing.Point(118, 206);
            this.tbCountry.Name = "tbCountry";
            this.tbCountry.Size = new System.Drawing.Size(144, 20);
            this.tbCountry.TabIndex = 6;
            this.tbCountry.Text = "Україна";
            // 
            // tbLocation
            // 
            this.tbLocation.Location = new System.Drawing.Point(118, 234);
            this.tbLocation.Name = "tbLocation";
            this.tbLocation.Size = new System.Drawing.Size(144, 20);
            this.tbLocation.TabIndex = 7;
            // 
            // tbClub
            // 
            this.tbClub.Location = new System.Drawing.Point(118, 260);
            this.tbClub.Name = "tbClub";
            this.tbClub.Size = new System.Drawing.Size(144, 20);
            this.tbClub.TabIndex = 8;
            // 
            // btnSave
            // 
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(380, 353);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(103, 27);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Зберегти";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(500, 353);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(103, 27);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Відміна";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // tbFamyliName
            // 
            this.tbFamyliName.Location = new System.Drawing.Point(87, 38);
            this.tbFamyliName.Name = "tbFamyliName";
            this.tbFamyliName.Size = new System.Drawing.Size(272, 20);
            this.tbFamyliName.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 41);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Прізвище";
            // 
            // tbSecondName
            // 
            this.tbSecondName.Location = new System.Drawing.Point(87, 64);
            this.tbSecondName.Name = "tbSecondName";
            this.tbSecondName.Size = new System.Drawing.Size(272, 20);
            this.tbSecondName.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 67);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Побатькові";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(17, 101);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(36, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "Стать";
            // 
            // cbSex
            // 
            this.cbSex.FormattingEnabled = true;
            this.cbSex.Items.AddRange(new object[] {
            "Чоловіча",
            "Жіноча"});
            this.cbSex.Location = new System.Drawing.Point(87, 98);
            this.cbSex.Name = "cbSex";
            this.cbSex.Size = new System.Drawing.Size(101, 21);
            this.cbSex.TabIndex = 3;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(17, 322);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(110, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "Проведених двобоїв";
            // 
            // nBattles
            // 
            this.nBattles.Location = new System.Drawing.Point(133, 320);
            this.nBattles.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.nBattles.Name = "nBattles";
            this.nBattles.Size = new System.Drawing.Size(42, 20);
            this.nBattles.TabIndex = 23;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(200, 322);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(52, 13);
            this.label11.TabIndex = 24;
            this.label11.Text = "Перемог";
            // 
            // nWins
            // 
            this.nWins.Location = new System.Drawing.Point(258, 320);
            this.nWins.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.nWins.Name = "nWins";
            this.nWins.Size = new System.Drawing.Size(42, 20);
            this.nWins.TabIndex = 25;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(332, 322);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(51, 13);
            this.label12.TabIndex = 26;
            this.label12.Text = "Поразок";
            // 
            // nLosers
            // 
            this.nLosers.Location = new System.Drawing.Point(389, 320);
            this.nLosers.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.nLosers.Name = "nLosers";
            this.nLosers.Size = new System.Drawing.Size(42, 20);
            this.nLosers.TabIndex = 27;
            // 
            // nWP
            // 
            this.nWP.Location = new System.Drawing.Point(124, 351);
            this.nWP.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.nWP.Name = "nWP";
            this.nWP.Size = new System.Drawing.Size(42, 20);
            this.nWP.TabIndex = 29;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(17, 353);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(101, 13);
            this.label13.TabIndex = 28;
            this.label13.Text = "Переможних балів";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(188, 353);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(104, 13);
            this.label14.TabIndex = 30;
            this.label14.Text = "Пропущених ударів";
            // 
            // nMH
            // 
            this.nMH.Location = new System.Drawing.Point(298, 351);
            this.nMH.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.nMH.Name = "nMH";
            this.nMH.Size = new System.Drawing.Size(42, 20);
            this.nMH.TabIndex = 31;
            // 
            // AddGladiator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 392);
            this.Controls.Add(this.nMH);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.nWP);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.nLosers);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.nWins);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.nBattles);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cbSex);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tbSecondName);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tbFamyliName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tbClub);
            this.Controls.Add(this.tbLocation);
            this.Controls.Add(this.tbCountry);
            this.Controls.Add(this.tbRating);
            this.Controls.Add(this.dtpBirfthday);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.btnLoadPhoto);
            this.Controls.Add(this.picGladiator);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddGladiator";
            this.Text = "AddGladiator";
            ((System.ComponentModel.ISupportInitialize)(this.picGladiator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nBattles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nWins)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nLosers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nWP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nMH)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnLoadPhoto;
        public System.Windows.Forms.PictureBox picGladiator;
        public System.Windows.Forms.TextBox tbName;
        public System.Windows.Forms.DateTimePicker dtpBirfthday;
        public System.Windows.Forms.TextBox tbRating;
        public System.Windows.Forms.TextBox tbCountry;
        public System.Windows.Forms.TextBox tbLocation;
        public System.Windows.Forms.TextBox tbClub;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ImageList imageList1;
        public System.Windows.Forms.TextBox tbFamyliName;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.TextBox tbSecondName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbSex;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown nBattles;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown nWins;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown nLosers;
        private System.Windows.Forms.NumericUpDown nWP;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.NumericUpDown nMH;
    }
}