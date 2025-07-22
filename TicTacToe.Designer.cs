namespace KrestikiNolikiKursovaya
{
    partial class TicTacToeMenu
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblName = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnFastVsComp = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnFastVsFriend = new System.Windows.Forms.Button();
            this.lblFastGame = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnOcupVsFriend = new System.Windows.Forms.Button();
            this.lblOcup = new System.Windows.Forms.Label();
            this.btnAboutTheGame = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Better VCR", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(124, 22);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(374, 32);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Крестики-Нолики";
            // 
            // btnExit
            // 
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Better VCR", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnExit.Location = new System.Drawing.Point(211, 262);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(226, 42);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "Выйти";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnFastVsComp
            // 
            this.btnFastVsComp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFastVsComp.Font = new System.Drawing.Font("Better VCR", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnFastVsComp.Location = new System.Drawing.Point(361, 3);
            this.btnFastVsComp.Name = "btnFastVsComp";
            this.btnFastVsComp.Size = new System.Drawing.Size(236, 32);
            this.btnFastVsComp.TabIndex = 1;
            this.btnFastVsComp.Text = "Против бота";
            this.btnFastVsComp.UseVisualStyleBackColor = true;
            this.btnFastVsComp.Click += new System.EventHandler(this.btnFastVsComp_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnFastVsFriend);
            this.panel1.Controls.Add(this.btnFastVsComp);
            this.panel1.Controls.Add(this.lblFastGame);
            this.panel1.Location = new System.Drawing.Point(12, 75);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(607, 78);
            this.panel1.TabIndex = 2;
            // 
            // btnFastVsFriend
            // 
            this.btnFastVsFriend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFastVsFriend.Font = new System.Drawing.Font("Better VCR", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnFastVsFriend.Location = new System.Drawing.Point(361, 41);
            this.btnFastVsFriend.Name = "btnFastVsFriend";
            this.btnFastVsFriend.Size = new System.Drawing.Size(236, 34);
            this.btnFastVsFriend.TabIndex = 1;
            this.btnFastVsFriend.Text = "Против друга";
            this.btnFastVsFriend.UseVisualStyleBackColor = true;
            this.btnFastVsFriend.Click += new System.EventHandler(this.btnFastVsFriend_Click);
            // 
            // lblFastGame
            // 
            this.lblFastGame.AutoSize = true;
            this.lblFastGame.Font = new System.Drawing.Font("Better VCR", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblFastGame.Location = new System.Drawing.Point(3, 26);
            this.lblFastGame.Name = "lblFastGame";
            this.lblFastGame.Size = new System.Drawing.Size(262, 24);
            this.lblFastGame.TabIndex = 0;
            this.lblFastGame.Text = "\"Быстрая игра\"";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnOcupVsFriend);
            this.panel2.Controls.Add(this.lblOcup);
            this.panel2.Location = new System.Drawing.Point(12, 168);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(607, 78);
            this.panel2.TabIndex = 3;
            // 
            // btnOcupVsFriend
            // 
            this.btnOcupVsFriend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOcupVsFriend.Font = new System.Drawing.Font("Better VCR", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnOcupVsFriend.Location = new System.Drawing.Point(361, 23);
            this.btnOcupVsFriend.Name = "btnOcupVsFriend";
            this.btnOcupVsFriend.Size = new System.Drawing.Size(236, 34);
            this.btnOcupVsFriend.TabIndex = 1;
            this.btnOcupVsFriend.Text = "Против друга";
            this.btnOcupVsFriend.UseVisualStyleBackColor = true;
            this.btnOcupVsFriend.Click += new System.EventHandler(this.btnOcupVsFriend_Click);
            // 
            // lblOcup
            // 
            this.lblOcup.AutoSize = true;
            this.lblOcup.Font = new System.Drawing.Font("Better VCR", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblOcup.Location = new System.Drawing.Point(3, 26);
            this.lblOcup.Name = "lblOcup";
            this.lblOcup.Size = new System.Drawing.Size(352, 24);
            this.lblOcup.TabIndex = 0;
            this.lblOcup.Text = "\"Захват территорий\"";
            // 
            // btnAboutTheGame
            // 
            this.btnAboutTheGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAboutTheGame.Font = new System.Drawing.Font("Better VCR", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAboutTheGame.Location = new System.Drawing.Point(12, 262);
            this.btnAboutTheGame.Name = "btnAboutTheGame";
            this.btnAboutTheGame.Size = new System.Drawing.Size(128, 42);
            this.btnAboutTheGame.TabIndex = 1;
            this.btnAboutTheGame.Text = "Об игре";
            this.btnAboutTheGame.UseVisualStyleBackColor = true;
            this.btnAboutTheGame.Click += new System.EventHandler(this.btnAboutTheGame_Click);
            // 
            // TicTacToeMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Khaki;
            this.ClientSize = new System.Drawing.Size(631, 316);
            this.Controls.Add(this.btnAboutTheGame);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lblName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TicTacToeMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Крестики-Нолики";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnFastVsComp;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnFastVsFriend;
        private System.Windows.Forms.Label lblFastGame;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnOcupVsFriend;
        private System.Windows.Forms.Label lblOcup;
        private System.Windows.Forms.Button btnAboutTheGame;
    }
}

