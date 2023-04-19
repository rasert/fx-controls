using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WizardTest
{
    public partial class StepIndicatorControl : UserControl
    {
        [Description("Quantity of Steps"), Category("Step Config")]
        public int StepCount { get; set; } = 5;
        [Description("Current Step"), Category("Step Config")]
        public int CurrentStep { get; set; } = 3;

        public StepIndicatorControl()
        {
            InitializeComponent();
        }

        private void StepIndicatorControl_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            float radiusBig = 30; // TODO: should be a proportion of the control Height
            float radiusSmall = radiusBig * 0.75f;
            float innerOffset = radiusSmall * 0.17f;
            float stepSpacing = 10; // TODO: should be a proportion of the control Width
            float x = 0;
            float y = 0;

            var lightGrayBrush = new LinearGradientBrush(ClientRectangle, Color.FromArgb(224, 227, 214), Color.LightGray, LinearGradientMode.Vertical);
            var darkGrayBrush = new LinearGradientBrush(ClientRectangle, Color.DarkGray, Color.Gray, LinearGradientMode.Vertical);
            var lightGreenBrush = new LinearGradientBrush(ClientRectangle, Color.FromArgb(206, 217, 79), Color.FromArgb(191, 201, 82), LinearGradientMode.Vertical);
            var darkGreenBrush = new LinearGradientBrush(ClientRectangle, Color.YellowGreen, Color.ForestGreen, LinearGradientMode.Vertical);

            // Draw the gray lines connecting the steps
            for (int i = 0; i < StepCount - 1; i++)
            {
                float width = y + radiusBig + stepSpacing;
                float height = 10;
                float lineX1 = x + radiusBig;
                float lineY = y + radiusBig / 2 - height / 2;
                e.Graphics.FillRectangle(darkGrayBrush, lineX1, lineY - 1, width, height); // drop shadow
                e.Graphics.FillRectangle(lightGrayBrush, lineX1, lineY, width, height);

                x += radiusBig + stepSpacing;
            }

            // Reset the drawing position for the steps and draw them
            x = 0;
            for (int i = 0; i < StepCount; i++)
            {
                // Draw the outer circle
                e.Graphics.FillEllipse(darkGrayBrush, x, y -1, radiusBig, radiusBig); // drop shadow
                e.Graphics.FillEllipse(lightGrayBrush, x, y, radiusBig, radiusBig);

                if (i < CurrentStep)
                {
                    float width = radiusBig + stepSpacing * 1.5f;
                    float height = 4;
                    float lineX = x - stepSpacing / 2;
                    float lineY = y + radiusBig / 2 - height / 2;

                    if (i == 0)
                        lineX = x + innerOffset;

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
