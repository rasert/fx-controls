namespace WizardTest
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            stepIndicatorControl1 = new StepIndicatorControl();
            button2 = new Button();
            button1 = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            wizardStepControl1 = new WizardStepControl();
            wizardStepControl2 = new WizardStepControl();
            wizardStepControl3 = new WizardStepControl();
            wizardStepControl4 = new WizardStepControl();
            wizardStepControl5 = new WizardStepControl();
            wizardStepControl6 = new WizardStepControl();
            panel1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(stepIndicatorControl1);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(flowLayoutPanel1);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(776, 426);
            panel1.TabIndex = 0;
            // 
            // stepIndicatorControl1
            // 
            stepIndicatorControl1.CurrentStep = 1;
            stepIndicatorControl1.Location = new Point(107, 3);
            stepIndicatorControl1.Name = "stepIndicatorControl1";
            stepIndicatorControl1.Size = new Size(585, 62);
            stepIndicatorControl1.StepCount = 6;
            stepIndicatorControl1.TabIndex = 3;
            // 
            // button2
            // 
            button2.Location = new Point(617, 400);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 2;
            button2.Text = "Anterior";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(698, 400);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 1;
            button1.Text = "Próximo";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Controls.Add(wizardStepControl1);
            flowLayoutPanel1.Controls.Add(wizardStepControl2);
            flowLayoutPanel1.Controls.Add(wizardStepControl3);
            flowLayoutPanel1.Controls.Add(wizardStepControl4);
            flowLayoutPanel1.Controls.Add(wizardStepControl5);
            flowLayoutPanel1.Controls.Add(wizardStepControl6);
            flowLayoutPanel1.Location = new Point(3, 86);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(770, 308);
            flowLayoutPanel1.TabIndex = 0;
            flowLayoutPanel1.WrapContents = false;
            // 
            // wizardStepControl1
            // 
            wizardStepControl1.Location = new Point(3, 3);
            wizardStepControl1.Name = "wizardStepControl1";
            wizardStepControl1.Size = new Size(234, 150);
            wizardStepControl1.StepName = "Etapa 1";
            wizardStepControl1.TabIndex = 0;
            // 
            // wizardStepControl2
            // 
            wizardStepControl2.Location = new Point(243, 3);
            wizardStepControl2.Name = "wizardStepControl2";
            wizardStepControl2.Size = new Size(234, 150);
            wizardStepControl2.StepName = "Etapa 2";
            wizardStepControl2.TabIndex = 1;
            wizardStepControl2.Visible = false;
            // 
            // wizardStepControl3
            // 
            wizardStepControl3.Location = new Point(483, 3);
            wizardStepControl3.Name = "wizardStepControl3";
            wizardStepControl3.Size = new Size(234, 150);
            wizardStepControl3.StepName = "Etapa 3";
            wizardStepControl3.TabIndex = 2;
            wizardStepControl3.Visible = false;
            // 
            // wizardStepControl4
            // 
            wizardStepControl4.Location = new Point(723, 3);
            wizardStepControl4.Name = "wizardStepControl4";
            wizardStepControl4.Size = new Size(234, 150);
            wizardStepControl4.StepName = "Etapa 4";
            wizardStepControl4.TabIndex = 3;
            wizardStepControl4.Visible = false;
            // 
            // wizardStepControl5
            // 
            wizardStepControl5.Location = new Point(963, 3);
            wizardStepControl5.Name = "wizardStepControl5";
            wizardStepControl5.Size = new Size(234, 150);
            wizardStepControl5.StepName = "Etapa 5";
            wizardStepControl5.TabIndex = 4;
            wizardStepControl5.Visible = false;
            // 
            // wizardStepControl6
            // 
            wizardStepControl6.Location = new Point(1203, 3);
            wizardStepControl6.Name = "wizardStepControl6";
            wizardStepControl6.Size = new Size(234, 150);
            wizardStepControl6.StepName = "Etapa 6";
            wizardStepControl6.TabIndex = 5;
            wizardStepControl6.Visible = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "Form1";
            panel1.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private FlowLayoutPanel flowLayoutPanel1;
        private WizardStepControl wizardStepControl1;
        private WizardStepControl wizardStepControl2;
        private WizardStepControl wizardStepControl3;
        private WizardStepControl wizardStepControl4;
        private WizardStepControl wizardStepControl5;
        private WizardStepControl wizardStepControl6;
        private Button button2;
        private Button button1;
        private StepIndicatorControl stepIndicatorControl1;
    }
}