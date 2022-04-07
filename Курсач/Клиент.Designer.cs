namespace Курсач
{
    partial class Клиент
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
            this.label2 = new System.Windows.Forms.Label();
            this.Адрес = new System.Windows.Forms.TextBox();
            this.Порт = new System.Windows.Forms.TextBox();
            this.Начать = new System.Windows.Forms.Button();
            this.Отключиться = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Ответы = new System.Windows.Forms.ListBox();
            this.Ответ = new System.Windows.Forms.TextBox();
            this.Отправить = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Адрес";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Порт";
            // 
            // Адрес
            // 
            this.Адрес.Location = new System.Drawing.Point(50, 18);
            this.Адрес.Name = "Адрес";
            this.Адрес.Size = new System.Drawing.Size(100, 20);
            this.Адрес.TabIndex = 3;
            this.Адрес.Text = "127.0.0.1";
            // 
            // Порт
            // 
            this.Порт.Location = new System.Drawing.Point(50, 44);
            this.Порт.Name = "Порт";
            this.Порт.Size = new System.Drawing.Size(100, 20);
            this.Порт.TabIndex = 4;
            this.Порт.Text = "3333";
            // 
            // Начать
            // 
            this.Начать.Location = new System.Drawing.Point(6, 96);
            this.Начать.Name = "Начать";
            this.Начать.Size = new System.Drawing.Size(144, 23);
            this.Начать.TabIndex = 6;
            this.Начать.Text = "Начать";
            this.Начать.UseVisualStyleBackColor = true;
            this.Начать.Click += new System.EventHandler(this.Начать_Click);
            // 
            // Отключиться
            // 
            this.Отключиться.Location = new System.Drawing.Point(6, 125);
            this.Отключиться.Name = "Отключиться";
            this.Отключиться.Size = new System.Drawing.Size(144, 23);
            this.Отключиться.TabIndex = 7;
            this.Отключиться.Text = "Отключиться";
            this.Отключиться.UseVisualStyleBackColor = true;
            this.Отключиться.Click += new System.EventHandler(this.Отключиться_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Начать);
            this.groupBox1.Controls.Add(this.Отключиться);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.Порт);
            this.groupBox1.Controls.Add(this.Адрес);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(158, 161);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Подключение";
            // 
            // Ответы
            // 
            this.Ответы.FormattingEnabled = true;
            this.Ответы.Location = new System.Drawing.Point(176, 12);
            this.Ответы.Name = "Ответы";
            this.Ответы.Size = new System.Drawing.Size(241, 160);
            this.Ответы.TabIndex = 9;
            // 
            // Ответ
            // 
            this.Ответ.Location = new System.Drawing.Point(62, 179);
            this.Ответ.Name = "Ответ";
            this.Ответ.Size = new System.Drawing.Size(274, 20);
            this.Ответ.TabIndex = 10;
            // 
            // Отправить
            // 
            this.Отправить.Enabled = false;
            this.Отправить.Location = new System.Drawing.Point(342, 178);
            this.Отправить.Name = "Отправить";
            this.Отправить.Size = new System.Drawing.Size(75, 21);
            this.Отправить.TabIndex = 11;
            this.Отправить.Text = "Отправить";
            this.Отправить.UseVisualStyleBackColor = true;
            this.Отправить.Click += new System.EventHandler(this.Отправить_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 186);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Ответ";
            // 
            // Клиент
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 210);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Отправить);
            this.Controls.Add(this.Ответ);
            this.Controls.Add(this.Ответы);
            this.Controls.Add(this.groupBox1);
            this.Name = "Клиент";
            this.Text = "Клиент";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Клиент_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Адрес;
        private System.Windows.Forms.TextBox Порт;
        private System.Windows.Forms.Button Начать;
        private System.Windows.Forms.Button Отключиться;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox Ответы;
        private System.Windows.Forms.TextBox Ответ;
        private System.Windows.Forms.Button Отправить;
        private System.Windows.Forms.Label label4;
    }
}

