namespace WizardTest
{
    public partial class Form1 : Form
    {
        private System.Windows.Forms.Timer _timer;
        private readonly Dictionary<int, UserControl> _steps = new();
        private int _currentStep;
        private int _direction = -1;

        public Form1()
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

        private void Timer_Tick(object sender, EventArgs e)
        {
            Invalidate();

            // TODO: create separate functions for each direction

            int otherStep = _currentStep - _direction;
            int offset = 50 * _direction;
            int threshold = Width * _direction;

            if (otherStep >= 0 && otherStep < _steps.Count)
            {
                _steps[_currentStep].Left = _direction < 0
                    ? Math.Max(_steps[_currentStep].Left + offset, threshold)
                    : Math.Min(_steps[_currentStep].Left + offset, threshold);
                _steps[otherStep].Left = _direction < 0
                    ? Math.Max(_steps[otherStep].Left + offset, 0)
                    : Math.Min(_steps[otherStep].Left + offset, 0);

                if (_steps[_currentStep].Left == threshold)
                {
                    _steps[otherStep].Show();

                    if (_direction < 0)
                    {
                        _currentStep++;
                    }
                    else
                    {
                        _currentStep--;
                    }

                    _timer.Enabled = false;
                }
            }
            else
            {
                if (_direction < 0)
                {
                    _timer.Enabled = false;
                    _currentStep++;
                }
                else
                {
                    _timer.Enabled = false;
                    _currentStep--;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_currentStep == _steps.Count -1)
                return;

            if (_currentStep < _steps.Count -1)
            {
                _steps[_currentStep].Hide();
                _steps[_currentStep + 1].Show();
            }

            stepIndicatorControl1.NextStep(DateTime.Now.Millisecond % 2 == 0);
            _direction = -1;
            _timer.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (_currentStep == 0)
                return;

            stepIndicatorControl1.PreviousStep();
            _direction = 1;
            _timer.Enabled = true;
        }
    }
}