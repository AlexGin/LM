namespace LM
{
    partial class KeyFilterForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBoxCompany = new System.Windows.Forms.CheckBox();
            this.comboBoxCompany = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBoxDevice = new System.Windows.Forms.CheckBox();
            this.comboBoxDevice = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radioButtonAnyKey = new System.Windows.Forms.RadioButton();
            this.radioButtonLicKey = new System.Windows.Forms.RadioButton();
            this.radioButtonTestKey = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.checkBoxOwner = new System.Windows.Forms.CheckBox();
            this.comboBoxOwner = new System.Windows.Forms.ComboBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.checkBoxParent = new System.Windows.Forms.CheckBox();
            this.comboBoxParent = new System.Windows.Forms.ComboBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.radioButtonAllKeys = new System.Windows.Forms.RadioButton();
            this.radioButtonInvalid = new System.Windows.Forms.RadioButton();
            this.radioButtonValid = new System.Windows.Forms.RadioButton();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBoxCompany);
            this.groupBox1.Controls.Add(this.comboBoxCompany);
            this.groupBox1.Location = new System.Drawing.Point(15, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(388, 67);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Организация ";
            // 
            // checkBoxCompany
            // 
            this.checkBoxCompany.AutoSize = true;
            this.checkBoxCompany.Location = new System.Drawing.Point(25, 46);
            this.checkBoxCompany.Name = "checkBoxCompany";
            this.checkBoxCompany.Size = new System.Drawing.Size(15, 14);
            this.checkBoxCompany.TabIndex = 1;
            this.checkBoxCompany.UseVisualStyleBackColor = true;
            this.checkBoxCompany.CheckedChanged += new System.EventHandler(this.OnCheckedChangedCompany);
            // 
            // comboBoxCompany
            // 
            this.comboBoxCompany.FormattingEnabled = true;
            this.comboBoxCompany.Location = new System.Drawing.Point(25, 19);
            this.comboBoxCompany.Name = "comboBoxCompany";
            this.comboBoxCompany.Size = new System.Drawing.Size(345, 21);
            this.comboBoxCompany.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBoxDevice);
            this.groupBox2.Controls.Add(this.comboBoxDevice);
            this.groupBox2.Location = new System.Drawing.Point(15, 81);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(387, 73);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Устройство ";
            // 
            // checkBoxDevice
            // 
            this.checkBoxDevice.AutoSize = true;
            this.checkBoxDevice.Location = new System.Drawing.Point(25, 48);
            this.checkBoxDevice.Name = "checkBoxDevice";
            this.checkBoxDevice.Size = new System.Drawing.Size(15, 14);
            this.checkBoxDevice.TabIndex = 1;
            this.checkBoxDevice.UseVisualStyleBackColor = true;
            this.checkBoxDevice.CheckedChanged += new System.EventHandler(this.OnCheckedChangedDevice);
            // 
            // comboBoxDevice
            // 
            this.comboBoxDevice.FormattingEnabled = true;
            this.comboBoxDevice.Location = new System.Drawing.Point(25, 20);
            this.comboBoxDevice.Name = "comboBoxDevice";
            this.comboBoxDevice.Size = new System.Drawing.Size(345, 21);
            this.comboBoxDevice.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radioButtonAnyKey);
            this.groupBox3.Controls.Add(this.radioButtonLicKey);
            this.groupBox3.Controls.Add(this.radioButtonTestKey);
            this.groupBox3.Location = new System.Drawing.Point(16, 164);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(384, 88);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Флаг Тестового ключа ";
            // 
            // radioButtonAnyKey
            // 
            this.radioButtonAnyKey.AutoSize = true;
            this.radioButtonAnyKey.Location = new System.Drawing.Point(23, 64);
            this.radioButtonAnyKey.Name = "radioButtonAnyKey";
            this.radioButtonAnyKey.Size = new System.Drawing.Size(95, 17);
            this.radioButtonAnyKey.TabIndex = 2;
            this.radioButtonAnyKey.TabStop = true;
            this.radioButtonAnyKey.Text = "Любые ключи";
            this.radioButtonAnyKey.UseVisualStyleBackColor = true;
            // 
            // radioButtonLicKey
            // 
            this.radioButtonLicKey.AutoSize = true;
            this.radioButtonLicKey.Location = new System.Drawing.Point(23, 42);
            this.radioButtonLicKey.Name = "radioButtonLicKey";
            this.radioButtonLicKey.Size = new System.Drawing.Size(247, 17);
            this.radioButtonLicKey.TabIndex = 1;
            this.radioButtonLicKey.TabStop = true;
            this.radioButtonLicKey.Text = "Только Лицензионные (не тестовые) ключи";
            this.radioButtonLicKey.UseVisualStyleBackColor = true;
            // 
            // radioButtonTestKey
            // 
            this.radioButtonTestKey.AutoSize = true;
            this.radioButtonTestKey.Location = new System.Drawing.Point(23, 20);
            this.radioButtonTestKey.Name = "radioButtonTestKey";
            this.radioButtonTestKey.Size = new System.Drawing.Size(149, 17);
            this.radioButtonTestKey.TabIndex = 0;
            this.radioButtonTestKey.TabStop = true;
            this.radioButtonTestKey.Text = "Только Тестовые ключи";
            this.radioButtonTestKey.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.checkBoxOwner);
            this.groupBox4.Controls.Add(this.comboBoxOwner);
            this.groupBox4.Location = new System.Drawing.Point(412, 8);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(388, 67);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Владелец ";
            // 
            // checkBoxOwner
            // 
            this.checkBoxOwner.AutoSize = true;
            this.checkBoxOwner.Location = new System.Drawing.Point(24, 48);
            this.checkBoxOwner.Name = "checkBoxOwner";
            this.checkBoxOwner.Size = new System.Drawing.Size(15, 14);
            this.checkBoxOwner.TabIndex = 1;
            this.checkBoxOwner.UseVisualStyleBackColor = true;
            this.checkBoxOwner.CheckedChanged += new System.EventHandler(this.OnCheckedChangedOwner);
            // 
            // comboBoxOwner
            // 
            this.comboBoxOwner.FormattingEnabled = true;
            this.comboBoxOwner.Location = new System.Drawing.Point(24, 20);
            this.comboBoxOwner.Name = "comboBoxOwner";
            this.comboBoxOwner.Size = new System.Drawing.Size(345, 21);
            this.comboBoxOwner.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.checkBoxParent);
            this.groupBox5.Controls.Add(this.comboBoxParent);
            this.groupBox5.Location = new System.Drawing.Point(412, 81);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(387, 73);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Выпущенные взамен утративших силу  ";
            // 
            // checkBoxParent
            // 
            this.checkBoxParent.AutoSize = true;
            this.checkBoxParent.Location = new System.Drawing.Point(21, 44);
            this.checkBoxParent.Name = "checkBoxParent";
            this.checkBoxParent.Size = new System.Drawing.Size(15, 14);
            this.checkBoxParent.TabIndex = 1;
            this.checkBoxParent.UseVisualStyleBackColor = true;
            this.checkBoxParent.CheckedChanged += new System.EventHandler(this.OnCheckedChangedParent);
            // 
            // comboBoxParent
            // 
            this.comboBoxParent.FormattingEnabled = true;
            this.comboBoxParent.Location = new System.Drawing.Point(21, 20);
            this.comboBoxParent.Name = "comboBoxParent";
            this.comboBoxParent.Size = new System.Drawing.Size(345, 21);
            this.comboBoxParent.TabIndex = 0;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.radioButtonAllKeys);
            this.groupBox6.Controls.Add(this.radioButtonInvalid);
            this.groupBox6.Controls.Add(this.radioButtonValid);
            this.groupBox6.Location = new System.Drawing.Point(411, 164);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(384, 88);
            this.groupBox6.TabIndex = 5;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Факт действительности ключа (по сроку действия)";
            // 
            // radioButtonAllKeys
            // 
            this.radioButtonAllKeys.AutoSize = true;
            this.radioButtonAllKeys.Location = new System.Drawing.Point(22, 60);
            this.radioButtonAllKeys.Name = "radioButtonAllKeys";
            this.radioButtonAllKeys.Size = new System.Drawing.Size(243, 17);
            this.radioButtonAllKeys.TabIndex = 2;
            this.radioButtonAllKeys.TabStop = true;
            this.radioButtonAllKeys.Text = "Все ключи, независимо от срока действия";
            this.radioButtonAllKeys.UseVisualStyleBackColor = true;
            // 
            // radioButtonInvalid
            // 
            this.radioButtonInvalid.AutoSize = true;
            this.radioButtonInvalid.Location = new System.Drawing.Point(22, 39);
            this.radioButtonInvalid.Name = "radioButtonInvalid";
            this.radioButtonInvalid.Size = new System.Drawing.Size(198, 17);
            this.radioButtonInvalid.TabIndex = 1;
            this.radioButtonInvalid.TabStop = true;
            this.radioButtonInvalid.Text = "Только не действительные ключи";
            this.radioButtonInvalid.UseVisualStyleBackColor = true;
            // 
            // radioButtonValid
            // 
            this.radioButtonValid.AutoSize = true;
            this.radioButtonValid.Location = new System.Drawing.Point(22, 18);
            this.radioButtonValid.Name = "radioButtonValid";
            this.radioButtonValid.Size = new System.Drawing.Size(183, 17);
            this.radioButtonValid.TabIndex = 0;
            this.radioButtonValid.TabStop = true;
            this.radioButtonValid.Text = "Только действительные ключи";
            this.radioButtonValid.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(323, 262);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.OnClickOK);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(412, 262);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.OnClickCancel);
            // 
            // KeyFilterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 295);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KeyFilterForm";
            this.Text = "Поиск ключа по фильтру";
            this.Load += new System.EventHandler(this.OnFilterLoad);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBoxCompany;
        private System.Windows.Forms.CheckBox checkBoxCompany;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox checkBoxDevice;
        private System.Windows.Forms.ComboBox comboBoxDevice;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton radioButtonTestKey;
        private System.Windows.Forms.RadioButton radioButtonLicKey;
        private System.Windows.Forms.RadioButton radioButtonAnyKey;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox comboBoxOwner;
        private System.Windows.Forms.CheckBox checkBoxOwner;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ComboBox comboBoxParent;
        private System.Windows.Forms.CheckBox checkBoxParent;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.RadioButton radioButtonValid;
        private System.Windows.Forms.RadioButton radioButtonInvalid;
        private System.Windows.Forms.RadioButton radioButtonAllKeys;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
    }
}