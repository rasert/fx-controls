namespace WizardTest
{
    public partial class Form1 : Form
    {
        private readonly Dictionary<int, UserControl> _steps = new();
        private int _currentStep;

        public Form1()
        {
            InitializeComponent();

            _steps[0] = wizardStepControl1;
            _steps[1] = wizardStepControl2;
            _steps[2] = wizardStepControl3;
            _steps[3] = wizardStepControl4;
            _steps[4] = wizardStepControl5;
            _steps[5] = wizardStepControl6;

            _currentStep = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _steps[_currentStep].Visible = false;
            _currentStep++;
            _steps[_currentStep].Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _steps[_currentStep].Visible = false;
            _currentStep--;
            _steps[_currentStep].Visible = true;
        }
    }
}