using MetroFramework.Forms;

namespace WizardTest
{
    public partial class SupportWizardForm : MetroForm
    {
        private System.Windows.Forms.Timer _timer;
        private readonly Dictionary<int, UserControl> _steps = new();
        private int _currentStep;
        private bool _forward = true;

        public SupportWizardForm()
        {
            InitializeComponent();

            _timer = new System.Windows.Forms.Timer
            {
                Interval = 10,
                Enabled = false
            };
            _timer.Tick += Timer_Tick;

            for (int i = 0; i < 6; i++)
            {
                _steps[i] = new WizardStepControl()
                {
                    StepName = $"Etapa {i + 1}",
                    Left = Width
                };
                _steps[i].Hide();
                panel1.Controls.Add(_steps[i]);
            }

            _currentStep = 0;
            _steps[_currentStep].Left = 0;
            _steps[_currentStep].Show();
        }

        private void AnimateNextStep()
        {
            int otherStep = _currentStep + 1;
            int offset = -50;
            int threshold = -Width;

            if (otherStep < _steps.Count)
            {
                _steps[_currentStep].Left = Math.Max(_steps[_currentStep].Left + offset, threshold);
                _steps[otherStep].Left = Math.Max(_steps[otherStep].Left + offset, 0);

                if (_steps[_currentStep].Left == threshold)
                {
                    _currentStep++;
                    _timer.Enabled = false;
                }
            }
            else
            {
                _currentStep++;
                _timer.Enabled = false;
            }
        }

        private void AnimatePreviousStep()
        {
            int otherStep = _currentStep - 1;
            int offset = 50;
            int threshold = Width;
            bool shouldAnimate = otherStep >= 0;

            if (shouldAnimate)
            {
                _steps[_currentStep].Left = Math.Min(_steps[_currentStep].Left + offset, threshold);
                _steps[otherStep].Left = Math.Min(_steps[otherStep].Left + offset, 0);

                if (_steps[_currentStep].Left == threshold)
                {
                    _steps[otherStep].Show();

                    _currentStep--;
                    _timer.Enabled = false;
                }
            }
            else
            {
                _currentStep--;
                _timer.Enabled = false;
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Invalidate();

            if (_forward)
                AnimateNextStep();
            else
                AnimatePreviousStep();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_currentStep == _steps.Count - 1)
                return;

            if (_currentStep < _steps.Count - 1)
            {
                _steps[_currentStep].Hide();
                _steps[_currentStep + 1].Show();
            }

            stepIndicatorControl1.NextStep(DateTime.Now.Millisecond % 2 == 0);
            _forward = true;
            _timer.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (_currentStep == 0)
                return;

            stepIndicatorControl1.PreviousStep();
            _forward = false;
            _timer.Enabled = true;
        }
    }
}