﻿namespace NetCommP140
{
    partial class FMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FMain));
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.ddbSettings = new System.Windows.Forms.ToolStripDropDownButton();
            this.tssConnectionsSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.miConnectionsList = new System.Windows.Forms.ToolStripMenuItem();
            this.miModuleSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.AutoSize = false;
            this.toolStrip.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.toolStrip.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolStrip.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toolStrip.GripMargin = new System.Windows.Forms.Padding(0);
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ddbSettings});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Padding = new System.Windows.Forms.Padding(0);
            this.toolStrip.Size = new System.Drawing.Size(105, 288);
            this.toolStrip.TabIndex = 0;
            // 
            // ddbSettings
            // 
            this.ddbSettings.AutoSize = false;
            this.ddbSettings.BackColor = System.Drawing.SystemColors.Control;
            this.ddbSettings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ddbSettings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssConnectionsSeparator,
            this.miConnectionsList,
            this.miModuleSettings});
            this.ddbSettings.Image = ((System.Drawing.Image)(resources.GetObject("ddbSettings.Image")));
            this.ddbSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ddbSettings.Name = "ddbSettings";
            this.ddbSettings.Size = new System.Drawing.Size(42, 20);
            this.ddbSettings.ToolTipText = "Настройки";
            this.ddbSettings.DropDownOpening += new System.EventHandler(this.ddbSettings_DropDownOpening);
            // 
            // tssConnectionsSeparator
            // 
            this.tssConnectionsSeparator.Name = "tssConnectionsSeparator";
            this.tssConnectionsSeparator.Size = new System.Drawing.Size(218, 6);
            // 
            // miConnectionsList
            // 
            this.miConnectionsList.Name = "miConnectionsList";
            this.miConnectionsList.Size = new System.Drawing.Size(221, 22);
            this.miConnectionsList.Text = "Подключения";
            this.miConnectionsList.Click += new System.EventHandler(this.miConnectionsList_Click);
            // 
            // miModuleSettings
            // 
            this.miModuleSettings.Name = "miModuleSettings";
            this.miModuleSettings.Size = new System.Drawing.Size(221, 22);
            this.miModuleSettings.Text = "Настройки модуля";
            this.miModuleSettings.Click += new System.EventHandler(this.miModuleSettings_Click);
            // 
            // FMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(104, 288);
            this.Controls.Add(this.toolStrip);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FMain";
            this.Text = "P-140";
            this.Load += new System.EventHandler(this.FMain_Load);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripDropDownButton ddbSettings;
        private System.Windows.Forms.ToolStripMenuItem miConnectionsList;
        private System.Windows.Forms.ToolStripSeparator tssConnectionsSeparator;
        private System.Windows.Forms.ToolStripMenuItem miModuleSettings;
    }
}

