namespace WizardTest
{
    partial class SupportWizardForm
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
            metroButton1 = new MetroFramework.Controls.MetroButton();
            metroButton2 = new MetroFramework.Controls.MetroButton();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Location = new Point(12, 146);
            panel1.Name = "panel1";
            panel1.Size = new Size(776, 263);
            panel1.TabIndex = 0;
            // 
            // stepIndicatorControl1
            // 
            stepIndicatorControl1.Location = new Point(12, 63);
            stepIndicatorControl1.Name = "stepIndicatorControl1";
            stepIndicatorControl1.Size = new Size(776, 77);
            stepIndicatorControl1.Steps = (new string[] { "Instalação", "Execução", "Saúde", "Sincronismo", "Teste Básico", "Conclusão" });
            stepIndicatorControl1.TabIndex = 5;
            // 
            // metroButton1
            // 
            metroButton1.Highlight = false;
            metroButton1.Location = new Point(713, 415);
            metroButton1.Name = "metroButton1";
            metroButton1.Size = new Size(75, 23);
            metroButton1.Style = MetroFramework.MetroColorStyle.Blue;
            metroButton1.StyleManager = null;
            metroButton1.TabIndex = 6;
            metroButton1.Text = "Próximo";
            metroButton1.Theme = MetroFramework.MetroThemeStyle.Light;
            metroButton1.Click += button1_Click;
            // 
            // metroButton2
            // 
            metroButton2.Highlight = false;
            metroButton2.Location = new Point(632, 415);
            metroButton2.Name = "metroButton2";
            metroButton2.Size = new Size(75, 23);
            metroButton2.Style = MetroFramework.MetroColorStyle.Blue;
            metroButton2.StyleManager = null;
            metroButton2.TabIndex = 7;
            metroButton2.Text = "Anterior";
            metroButton2.Theme = MetroFramework.MetroThemeStyle.Light;
            metroButton2.Click += button2_Click;
            // 
            // SupportWizardForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(metroButton2);
            Controls.Add(metroButton1);
            Controls.Add(stepIndicatorControl1);
            Controls.Add(panel1);
            Location = new Point(0, 0);
            Name = "SupportWizardForm";
            Text = "Support Wizard";
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private StepIndicatorControl stepIndicatorControl1;
        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroButton metroButton2;
    }
}