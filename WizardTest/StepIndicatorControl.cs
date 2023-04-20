using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace WizardTest
{
    public partial class StepIndicatorControl : UserControl
    {
        private int _currentStep = 1;
        private string[] _steps;
        private bool?[] _stepStatus;

        [Description("Steps"), Category("Step Config")]
        public string[] Steps
        {
            get => _steps;
            set
            {
                _steps = value;
                _stepStatus = new bool?[_steps.Length];
                Array.Fill(_stepStatus, value: null);
                Parent?.Refresh();
            }
        }

        public StepIndicatorControl()
        {
            InitializeComponent();

            _steps = new string[0];
            _stepStatus = new bool?[0];
        }

        public void NextStep(bool? currentStepStatus = null)
        {
            if (currentStepStatus.HasValue)
                _stepStatus[_currentStep - 1] = currentStepStatus;

            _currentStep++;
            Parent?.Refresh();
        }

        public void PreviousStep()
        {
            _currentStep--;
            Parent?.Refresh();
        }

        private void StepIndicatorControl_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            float margin = 3;
            float radiusBig = Height * 0.5f;
            float radiusSmall = radiusBig * 0.75f;
            float innerOffset = radiusSmall * 0.17f;
            float stepSpacing = (Width - (_steps.Length * radiusBig)) / (_steps.Length - 1) - margin;
            float x = margin;
            float y = margin;

            var lightGrayBrush = new LinearGradientBrush(ClientRectangle, Color.FromArgb(224, 227, 214), Color.LightGray, LinearGradientMode.Vertical);
            var darkGrayBrush = new LinearGradientBrush(ClientRectangle, Color.DarkGray, Color.Gray, LinearGradientMode.Vertical);

            // Draw the gray lines connecting the steps
            for (int i = 0; i < _steps.Length - 1; i++)
            {
                float width = y + radiusBig + stepSpacing - margin;
                float height = 10;
                float lineX1 = x + radiusBig;
                float lineY = y + radiusBig / 2 - height / 2;
                e.Graphics.FillRectangle(darkGrayBrush, lineX1, lineY - 1, width, height); // drop shadow
                e.Graphics.FillRectangle(lightGrayBrush, lineX1, lineY, width, height);

                x += radiusBig + stepSpacing;
            }

            // Reset the drawing position for the steps and draw them
            x = margin;
            for (int i = 0; i < _steps.Length; i++)
            {
                // Draw the outer circle
                e.Graphics.FillEllipse(darkGrayBrush, x, y -1, radiusBig, radiusBig); // drop shadow
                e.Graphics.FillEllipse(lightGrayBrush, x, y, radiusBig, radiusBig);

                if (i == _currentStep -1)
                {
                    Pen greenPen = new Pen(Color.FromArgb(206, 217, 79), 2);
                    e.Graphics.DrawEllipse(greenPen, x, y, radiusBig, radiusBig);
                }

                if (i < _currentStep -1 && _stepStatus[i].HasValue)
                {
                    var lightBrush = _stepStatus[i].Value
                        ? new LinearGradientBrush(ClientRectangle, Color.FromArgb(206, 217, 79), Color.FromArgb(191, 201, 82), LinearGradientMode.Vertical)
                        : new LinearGradientBrush(ClientRectangle, Color.MediumVioletRed, Color.OrangeRed, LinearGradientMode.Vertical);
                    var darkBrush = _stepStatus[i].Value
                        ? new LinearGradientBrush(ClientRectangle, Color.YellowGreen, Color.ForestGreen, LinearGradientMode.Vertical)
                        : new LinearGradientBrush(ClientRectangle, Color.DarkRed, Color.Red, LinearGradientMode.Vertical);

                    float width = radiusBig + stepSpacing * 1.5f;
                    float height = 4;
                    float lineX = x - stepSpacing / 2;
                    float lineY = y + radiusBig / 2 - height / 2;

                    if (i == 0)
                    {
                        lineX = x + innerOffset;
                        width -= stepSpacing * 0.5f;
                    }
                    if (i == _steps.Length - 1)
                        width = width / 2 - (radiusBig - radiusSmall);

                    // Draw the green line connecting the completed steps
                    e.Graphics.FillRectangle(lightBrush, lineX, lineY, width, height);

                    // Draw the inner circle for completed steps
                    float innerX = x + innerOffset;
                    float innerY = y + innerOffset;
                    e.Graphics.FillEllipse(darkBrush, innerX, innerY -1, radiusSmall, radiusSmall);
                    e.Graphics.FillEllipse(lightBrush, innerX, innerY, radiusSmall, radiusSmall);
                }

                // Draw the label text under the step circle
                string labelText = _steps[i];
                Font labelFont = new Font("Arial", 10);
                Brush labelBrush = Brushes.Black;
                PointF labelLocation = new PointF(x + radiusBig / 2 + margin, y + radiusBig + 5 + margin);
                StringFormat stringFormat = new StringFormat();
                if (i == 0)
                {
                    stringFormat.Alignment = StringAlignment.Near;
                    labelLocation.X = x;
                }
                else if (i == _steps.Length - 1)
                {
                    stringFormat.Alignment = StringAlignment.Far;
                    labelLocation.X = x + radiusBig;
                }
                else
                    stringFormat.Alignment = StringAlignment.Center;
                e.Graphics.DrawString(labelText, labelFont, labelBrush, labelLocation, stringFormat);

                // Move the drawing position to the right for the next step
                x += radiusBig + stepSpacing;
            }
        }
    }
}
