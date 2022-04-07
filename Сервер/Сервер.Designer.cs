namespace Сервер
{
    partial class Сервер
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
            this.label1 = new System.Windows.Forms.Label();
            this.КоличествоИгроков = new System.Windows.Forms.NumericUpDown();
            this.Запуск = new System.Windows.Forms.Button();
            this.Остановить = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Порт = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ИгрокиОнлайн = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.StartGame = new System.Windows.Forms.Button();
            this.StopGame = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.КоличествоИгроков)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Порт)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Максимум игроков:";
            // 
            // КоличествоИгроков
            // 
            this.КоличествоИгроков.Location = new System.Drawing.Point(117, 19);
            this.КоличествоИгроков.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.КоличествоИгроков.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.КоличествоИгроков.Name = "КоличествоИгроков";
            this.КоличествоИгроков.Size = new System.Drawing.Size(44, 20);
            this.КоличествоИгроков.TabIndex = 1;
            this.КоличествоИгроков.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // Запуск
            // 
            this.Запуск.Location = new System.Drawing.Point(6, 71);
            this.Запуск.Name = "Запуск";
            this.Запуск.Size = new System.Drawing.Size(155, 23);
            this.Запуск.TabIndex = 2;
            this.Запуск.Text = "Запуск";
            this.Запуск.UseVisualStyleBackColor = true;
            this.Запуск.Click += new System.EventHandler(this.Запуск_Click);
            // 
            // Остановить
            // 
            this.Остановить.Location = new System.Drawing.Point(6, 100);
            this.Остановить.Name = "Остановить";
            this.Остановить.Size = new System.Drawing.Size(155, 23);
            this.Остановить.TabIndex = 3;
            this.Остановить.Text = "Остановить";
            this.Остановить.UseVisualStyleBackColor = true;
            this.Остановить.Click += new System.EventHandler(this.Остановить_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Порт);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.Запуск);
            this.groupBox1.Controls.Add(this.Остановить);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.КоличествоИгроков);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(167, 132);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Параметры сервера";
            // 
            // Порт
            // 
            this.Порт.Location = new System.Drawing.Point(44, 45);
            this.Порт.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.Порт.Minimum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.Порт.Name = "Порт";
            this.Порт.Size = new System.Drawing.Size(117, 20);
            this.Порт.TabIndex = 5;
            this.Порт.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Порт.Value = new decimal(new int[] {
            3333,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Порт";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Игроков подключено";
            // 
            // ИгрокиОнлайн
            // 
            this.ИгрокиОнлайн.AutoSize = true;
            this.ИгрокиОнлайн.Location = new System.Drawing.Point(9, 160);
            this.ИгрокиОнлайн.Name = "ИгрокиОнлайн";
            this.ИгрокиОнлайн.Size = new System.Drawing.Size(13, 13);
            this.ИгрокиОнлайн.TabIndex = 6;
            this.ИгрокиОнлайн.Text = "0";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 176);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(161, 95);
            this.listBox1.TabIndex = 7;
            // 
            // StartGame
            // 
            this.StartGame.Location = new System.Drawing.Point(12, 277);
            this.StartGame.Name = "StartGame";
            this.StartGame.Size = new System.Drawing.Size(161, 23);
            this.StartGame.TabIndex = 8;
            this.StartGame.Text = "Начать";
            this.StartGame.UseVisualStyleBackColor = true;
            this.StartGame.Click += new System.EventHandler(this.StartGame_Click);
            // 
            // StopGame
            // 
            this.StopGame.Location = new System.Drawing.Point(12, 306);
            this.StopGame.Name = "StopGame";
            this.StopGame.Size = new System.Drawing.Size(161, 23);
            this.StopGame.TabIndex = 9;
            this.StopGame.Text = "Закончить";
            this.StopGame.UseVisualStyleBackColor = true;
            this.StopGame.Click += new System.EventHandler(this.StopGame_Click);
            // 
            // Сервер
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(192, 342);
            this.Controls.Add(this.StopGame);
            this.Controls.Add(this.StartGame);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.ИгрокиОнлайн);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Name = "Сервер";
            this.Text = "Сервер";
            ((System.ComponentModel.ISupportInitialize)(this.КоличествоИгроков)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Порт)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown КоличествоИгроков;
        private System.Windows.Forms.Button Запуск;
        private System.Windows.Forms.Button Остановить;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown Порт;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label ИгрокиОнлайн;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button StartGame;
        private System.Windows.Forms.Button StopGame;
    }
}

