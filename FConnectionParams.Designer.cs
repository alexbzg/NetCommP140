namespace EncRotator
{
    partial class fConnectionParams
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fConnectionParams));
            this.bOK = new System.Windows.Forms.Button();
            this.bCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbPort = new System.Windows.Forms.TextBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.tbHost = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.lUSARTPort = new System.Windows.Forms.Label();
            this.tbUSARTPort = new System.Windows.Forms.TextBox();
            this.nudSlowInt = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.cbDeviceType = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.chbSoft = new System.Windows.Forms.CheckBox();
            this.pIcon = new System.Windows.Forms.Panel();
            this.bIconPrev = new System.Windows.Forms.Button();
            this.bIconNext = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudSlowInt)).BeginInit();
            this.SuspendLayout();
            // 
            // bOK
            // 
            this.bOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bOK.Location = new System.Drawing.Point(124, 297);
            this.bOK.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bOK.Name = "bOK";
            this.bOK.Size = new System.Drawing.Size(112, 37);
            this.bOK.TabIndex = 0;
            this.bOK.Text = "OK";
            this.bOK.UseVisualStyleBackColor = true;
            // 
            // bCancel
            // 
            this.bCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bCancel.Location = new System.Drawing.Point(246, 297);
            this.bCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(112, 37);
            this.bCancel.TabIndex = 1;
            this.bCancel.Text = "Отмена";
            this.bCancel.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(14, 202);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Порт";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(14, 165);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Пароль";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(14, 125);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Адрес";
            // 
            // tbPort
            // 
            this.tbPort.Location = new System.Drawing.Point(86, 196);
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(266, 26);
            this.tbPort.TabIndex = 5;
            this.tbPort.Validated += new System.EventHandler(this.tbPort_Validated);
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(86, 159);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(266, 26);
            this.tbPassword.TabIndex = 6;
            this.tbPassword.Validated += new System.EventHandler(this.tbPassword_Validated);
            // 
            // tbHost
            // 
            this.tbHost.Location = new System.Drawing.Point(86, 122);
            this.tbHost.Name = "tbHost";
            this.tbHost.Size = new System.Drawing.Size(266, 26);
            this.tbHost.TabIndex = 7;
            this.tbHost.Validated += new System.EventHandler(this.tbHost_Validated);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(90, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Название";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(179, 22);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(173, 26);
            this.tbName.TabIndex = 9;
            this.tbName.Validated += new System.EventHandler(this.tbName_Validated);
            // 
            // lUSARTPort
            // 
            this.lUSARTPort.AutoSize = true;
            this.lUSARTPort.Location = new System.Drawing.Point(14, 234);
            this.lUSARTPort.Name = "lUSARTPort";
            this.lUSARTPort.Size = new System.Drawing.Size(64, 20);
            this.lUSARTPort.TabIndex = 12;
            this.lUSARTPort.Text = "USART";
            // 
            // tbUSARTPort
            // 
            this.tbUSARTPort.Location = new System.Drawing.Point(86, 228);
            this.tbUSARTPort.Name = "tbUSARTPort";
            this.tbUSARTPort.Size = new System.Drawing.Size(266, 26);
            this.tbUSARTPort.TabIndex = 13;
            this.tbUSARTPort.Validated += new System.EventHandler(this.tbUSARTPort_Validated);
            // 
            // nudSlowInt
            // 
            this.nudSlowInt.Location = new System.Drawing.Point(282, 260);
            this.nudSlowInt.Name = "nudSlowInt";
            this.nudSlowInt.Size = new System.Drawing.Size(70, 26);
            this.nudSlowInt.TabIndex = 14;
            this.nudSlowInt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudSlowInt.ThousandsSeparator = true;
            this.nudSlowInt.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudSlowInt.Validating += new System.ComponentModel.CancelEventHandler(this.nudSlowInt_Validating);
            this.nudSlowInt.Validated += new System.EventHandler(this.nudSlowInt_Validated);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(99, 266);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(182, 20);
            this.label5.TabIndex = 15;
            this.label5.Text = "Интервал торможения";
            // 
            // cbDeviceType
            // 
            this.cbDeviceType.FormattingEnabled = true;
            this.cbDeviceType.Items.AddRange(new object[] {
            "Энкодер",
            "Yaesu"});
            this.cbDeviceType.Location = new System.Drawing.Point(179, 54);
            this.cbDeviceType.Name = "cbDeviceType";
            this.cbDeviceType.Size = new System.Drawing.Size(173, 28);
            this.cbDeviceType.TabIndex = 16;
            this.cbDeviceType.SelectedIndexChanged += new System.EventHandler(this.cbDeviceType_SelectedIndexChanged);
            this.cbDeviceType.Validated += new System.EventHandler(this.cbDeviceType_Validated);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(137, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 20);
            this.label6.TabIndex = 17;
            this.label6.Text = "Тип";
            // 
            // chbSoft
            // 
            this.chbSoft.AutoSize = true;
            this.chbSoft.Location = new System.Drawing.Point(146, 88);
            this.chbSoft.Name = "chbSoft";
            this.chbSoft.Size = new System.Drawing.Size(133, 24);
            this.chbSoft.TabIndex = 18;
            this.chbSoft.Text = "Плавный пуск";
            this.chbSoft.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.chbSoft.UseVisualStyleBackColor = true;
            this.chbSoft.Validated += new System.EventHandler(this.chbSoft_Validated);
            // 
            // pIcon
            // 
            this.pIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pIcon.Location = new System.Drawing.Point(12, 12);
            this.pIcon.Name = "pIcon";
            this.pIcon.Size = new System.Drawing.Size(66, 78);
            this.pIcon.TabIndex = 19;
            // 
            // bIconPrev
            // 
            this.bIconPrev.Location = new System.Drawing.Point(12, 89);
            this.bIconPrev.Name = "bIconPrev";
            this.bIconPrev.Size = new System.Drawing.Size(30, 30);
            this.bIconPrev.TabIndex = 0;
            this.bIconPrev.Text = "<";
            this.bIconPrev.UseVisualStyleBackColor = true;
            this.bIconPrev.Click += new System.EventHandler(this.bIconPrev_Click);
            // 
            // bIconNext
            // 
            this.bIconNext.Location = new System.Drawing.Point(45, 89);
            this.bIconNext.Name = "bIconNext";
            this.bIconNext.Size = new System.Drawing.Size(30, 30);
            this.bIconNext.TabIndex = 1;
            this.bIconNext.Text = ">";
            this.bIconNext.UseVisualStyleBackColor = true;
            this.bIconNext.Click += new System.EventHandler(this.bIconNext_Click);
            // 
            // fConnectionParams
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 343);
            this.Controls.Add(this.bIconPrev);
            this.Controls.Add(this.bIconNext);
            this.Controls.Add(this.pIcon);
            this.Controls.Add(this.chbSoft);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbDeviceType);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.nudSlowInt);
            this.Controls.Add(this.tbUSARTPort);
            this.Controls.Add(this.lUSARTPort);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbHost);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.tbPort);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.bOK);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "fConnectionParams";
            this.Text = "Параметры подключения";
            ((System.ComponentModel.ISupportInitialize)(this.nudSlowInt)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bOK;
        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbPort;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.TextBox tbHost;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label lUSARTPort;
        private System.Windows.Forms.TextBox tbUSARTPort;
        private System.Windows.Forms.NumericUpDown nudSlowInt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbDeviceType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chbSoft;
        private System.Windows.Forms.Panel pIcon;
        private System.Windows.Forms.Button bIconPrev;
        private System.Windows.Forms.Button bIconNext;
    }
}