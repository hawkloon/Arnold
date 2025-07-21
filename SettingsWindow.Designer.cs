namespace VoiceRecognition
{
    partial class SettingsWindow
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
            label1 = new Label();
            applyButton = new Button();
            label3 = new Label();
            ConfidenceInput = new NumericUpDown();
            assistantNameBox = new TextBox();
            label4 = new Label();
            openFileDialog1 = new OpenFileDialog();
            openFileDialog2 = new OpenFileDialog();
            button1 = new Button();
            progressBar1 = new ProgressBar();
            ((System.ComponentModel.ISupportInitialize)ConfidenceInput).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 25F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(141, 46);
            label1.TabIndex = 0;
            label1.Text = "Settings";
            // 
            // applyButton
            // 
            applyButton.Location = new Point(225, 393);
            applyButton.Name = "applyButton";
            applyButton.Size = new Size(150, 45);
            applyButton.TabIndex = 3;
            applyButton.Text = "Apply";
            applyButton.UseVisualStyleBackColor = true;
            applyButton.Click += applyButton_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(12, 68);
            label3.Name = "label3";
            label3.Size = new Size(182, 25);
            label3.TabIndex = 5;
            label3.Text = "Minimum Confidence";
            // 
            // ConfidenceInput
            // 
            ConfidenceInput.Location = new Point(255, 72);
            ConfidenceInput.Name = "ConfidenceInput";
            ConfidenceInput.Size = new Size(120, 23);
            ConfidenceInput.TabIndex = 6;
            ConfidenceInput.Value = new decimal(new int[] { 85, 0, 0, 0 });
            ConfidenceInput.ValueChanged += ConfidenceInput_ValueChanged;
            // 
            // assistantNameBox
            // 
            assistantNameBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            assistantNameBox.Location = new Point(255, 110);
            assistantNameBox.Name = "assistantNameBox";
            assistantNameBox.Size = new Size(120, 29);
            assistantNameBox.TabIndex = 7;
            assistantNameBox.Text = "Arnold";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(12, 112);
            label4.Name = "label4";
            label4.Size = new Size(135, 25);
            label4.TabIndex = 8;
            label4.Text = "Assistant Name";
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // openFileDialog2
            // 
            openFileDialog2.FileName = "openFileDialog2";
            // 
            // button1
            // 
            button1.Location = new Point(225, 354);
            button1.Name = "button1";
            button1.Size = new Size(150, 23);
            button1.TabIndex = 9;
            button1.Text = "Add App To Recognition";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(12, 314);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(363, 23);
            progressBar1.TabIndex = 10;
            progressBar1.Click += progressBar1_Click;
            // 
            // SettingsWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(387, 450);
            Controls.Add(progressBar1);
            Controls.Add(button1);
            Controls.Add(label4);
            Controls.Add(assistantNameBox);
            Controls.Add(ConfidenceInput);
            Controls.Add(label3);
            Controls.Add(applyButton);
            Controls.Add(label1);
            Name = "SettingsWindow";
            RightToLeftLayout = true;
            Text = "Hawkloon's Uber Cool Voice Recognition";
            ((System.ComponentModel.ISupportInitialize)ConfidenceInput).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private ComboBox inputDeviceBox;
        private Button applyButton;
        private Label label3;
        private NumericUpDown ConfidenceInput;
        private Label label4;
        private OpenFileDialog openFileDialog1;
        private OpenFileDialog openFileDialog2;
        private Button button1;
        private ProgressBar progressBar1;
        public TextBox assistantNameBox;
    }
}