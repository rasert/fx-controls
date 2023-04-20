using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace WizardTest
{
    public partial class StepIndicatorControl : UserControl
    {
        private System.Windows.Forms.Timer _timer;
        private int _currentStep = 1;
        private string[] _steps;
        private bool?[] _stepStatus;

        private float _widthPercent = 0.1f;

        public StepIndicatorControl()
        {
            _steps = new string[0];
            _stepStatus = new bool?[0];

            InitializeComponent();

            _timer = new System.Windows.Forms.Timer
            {
                Interval = 50,
                Enabled = false
            };
            _timer.Tick += Timer_Tick;

            DoubleBuffered = true;
            ResizeRedraw = true;
        }

        [Description("Steps"), Category("Step Config")]
        public string[] Steps
        {
            get => _steps;
            set
            {
                _steps = value;
                _stepStatus = new bool?[_steps.Length];
                Array.Fill(_stepStatus, value: null);
                Invalidate();
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Invalidate();
            if (_widthPercent < 1)
            {
                _widthPercent += 0.1f;
            }
            else
            {
                _timer.Enabled = false;
            }
        }

        public void NextStep(bool? currentStepStatus = null)
        {
            if (currentStepStatus.HasValue)
                _stepStatus[_currentStep - 1] = currentStepStatus;

            _currentStep++;
            _widthPercent = 0.1f;
            Invalidate();
        }

        public void PreviousStep()
        {
            _currentStep--;
            Invalidate();
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

                // Draw current step outline
                if (i == _currentStep -1)
                {
                    Pen greenPen = new Pen(Color.LawnGreen, 2);
                    e.Graphics.DrawEllipse(greenPen, x, y, radiusBig, radiusBig);
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

            x = margin;
            for (int i = 0; i < _steps.Length; i++)
            {
                if (!_stepStatus[i].HasValue)
                    continue;

                var lightBrush = _stepStatus[i].Value
                        ? new LinearGradientBrush(ClientRectangle, Color.LawnGreen, Color.Gold, LinearGradientMode.Vertical)
                        : new LinearGradientBrush(ClientRectangle, Color.MediumVioletRed, Color.OrangeRed, LinearGradientMode.Vertical);
                var darkBrush = _stepStatus[i].Value
                    ? new LinearGradientBrush(ClientRectangle, Color.YellowGreen, Color.ForestGreen, LinearGradientMode.Vertical)
                    : new LinearGradientBrush(ClientRectangle, Color.DarkRed, Color.Red, LinearGradientMode.Vertical);

                float stepCenterX = x + innerOffset;
                float stepCenterY = y + innerOffset;
                float height = 4;
                float lineY = y + radiusBig / 2 - height / 2;
                float lineX = stepCenterX + 1;
                float width = radiusBig + stepSpacing;

                if (i == _currentStep - 2)
                {
                    width -= innerOffset;
                    width *= _widthPercent;
                    _timer.Enabled = true;
                }

                // Draw the red or green line connecting the completed steps
                var brushRectangle = Rectangle.FromLTRB((int)lineX, (int)lineY, (int)(lineX + width), (int)(lineY + height));
                if (i < _steps.Length - 1)
                    e.Graphics.FillRectangle(GetInnerLineBrush(i, brushRectangle), lineX, lineY, width, height);

                // Draw the inner circle for completed steps
                e.Graphics.FillEllipse(darkBrush, stepCenterX, stepCenterY - 1, radiusSmall, radiusSmall);
                e.Graphics.FillEllipse(lightBrush, stepCenterX, stepCenterY, radiusSmall, radiusSmall);

                // Move the drawing position to the right for the next step
                x += radiusBig + stepSpacing;
            }
        }

        private LinearGradientBrush GetInnerLineBrush(int stepIndex, Rectangle brushRectangle)
        {
            int leftIndex = stepIndex;
            int rightIndex = stepIndex < _stepStatus.Length -1 ? stepIndex + 1 : stepIndex;

            Color leftColor = _stepStatus[leftIndex].Value ? Color.LawnGreen : Color.Crimson;

            Color rightColor = Color.LawnGreen;
            if (_stepStatus[rightIndex].HasValue)
                rightColor = _stepStatus[rightIndex].Value ? Color.LawnGreen : Color.Crimson;

            return new LinearGradientBrush(brushRectangle, leftColor, rightColor, LinearGradientMode.Horizontal);
        }
    }
}
