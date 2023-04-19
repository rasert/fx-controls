using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace WizardTest
{
    public partial class StepIndicatorControl : UserControl
    {
        private int _stepCount = 5;
        private int _currentStep = 1;

        [Description("Quantity of Steps"), Category("Step Config")]
        public int StepCount
        { 
            get => _stepCount;
            set
            {
                _stepCount = value;
                Parent?.Refresh();
            }
        }
        [Description("Current Step"), Category("Step Config")]
        public int CurrentStep
        { 
            get => _currentStep;
            set
            {
                _currentStep = value;
                Parent?.Refresh();
            }
        }

        public StepIndicatorControl()
        {
            InitializeComponent();
        }

        private void StepIndicatorControl_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            float margin = 3;
            float radiusBig = Height * 0.8f;
            float radiusSmall = radiusBig * 0.75f;
            float innerOffset = radiusSmall * 0.17f;
            float stepSpacing = (Width - (StepCount * radiusBig)) / (StepCount - 1) - margin;
            float x = margin;
            float y = margin;

            var lightGrayBrush = new LinearGradientBrush(ClientRectangle, Color.FromArgb(224, 227, 214), Color.LightGray, LinearGradientMode.Vertical);
            var darkGrayBrush = new LinearGradientBrush(ClientRectangle, Color.DarkGray, Color.Gray, LinearGradientMode.Vertical);
            var lightGreenBrush = new LinearGradientBrush(ClientRectangle, Color.FromArgb(206, 217, 79), Color.FromArgb(191, 201, 82), LinearGradientMode.Vertical);
            var darkGreenBrush = new LinearGradientBrush(ClientRectangle, Color.YellowGreen, Color.ForestGreen, LinearGradientMode.Vertical);

            // Draw the gray lines connecting the steps
            for (int i = 0; i < StepCount - 1; i++)
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
            for (int i = 0; i < StepCount; i++)
            {
                // Draw the outer circle
                e.Graphics.FillEllipse(darkGrayBrush, x, y -1, radiusBig, radiusBig); // drop shadow
                e.Graphics.FillEllipse(lightGrayBrush, x, y, radiusBig, radiusBig);

                if (i == CurrentStep -1)
                {
                    Pen greenPen = new Pen(Color.FromArgb(206, 217, 79), 2);
                    e.Graphics.DrawEllipse(greenPen, x, y, radiusBig, radiusBig);
                }

                if (i < CurrentStep -1)
                {
                    float width = radiusBig + stepSpacing * 1.5f;
                    float height = 4;
                    float lineX = x - stepSpacing / 2;
                    float lineY = y + radiusBig / 2 - height / 2;

                    if (i == 0)
                        lineX = x + innerOffset;
                    if (i == StepCount - 1)
                        width = width / 2 - (radiusBig - radiusSmall);

                    // Draw the green line connecting the completed steps
                    e.Graphics.FillRectangle(lightGreenBrush, lineX, lineY, width, height);

                    // Draw the inner circle for completed steps
                    float innerX = x + innerOffset;
                    float innerY = y + innerOffset;
                    e.Graphics.FillEllipse(darkGreenBrush, innerX, innerY -1, radiusSmall, radiusSmall);
                    e.Graphics.FillEllipse(lightGreenBrush, innerX, innerY, radiusSmall, radiusSmall);
                }

                // Move the drawing position to the right for the next step
                x += radiusBig + stepSpacing;
            }
        }
    }
}
