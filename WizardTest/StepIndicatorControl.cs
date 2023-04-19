using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WizardTest
{
    public partial class StepIndicatorControl : UserControl
    {
        public StepIndicatorControl()
        {
            InitializeComponent();
        }

        private void StepIndicatorControl_Paint(object sender, PaintEventArgs e)
        {
            int stepCount = 5;
            int currentStep = 3;
            float stepSize = 30;
            float innerStepSize = stepSize / 2;
            float stepSpacing = 10;
            float x = 0;
            float y = 0;

            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // Draw the gray lines connecting the steps
            Pen grayPen = new Pen(Color.LightGray, 6);
            for (int i = 0; i < stepCount - 1; i++)
            {
                float lineX1 = x + stepSize;
                float lineX2 = x + stepSize + stepSpacing;
                float lineY = y + stepSize / 2;
                e.Graphics.DrawLine(grayPen, lineX1, lineY, lineX2, lineY);

                x += stepSize + stepSpacing;
            }

            // Reset the drawing position for the steps and draw them
            x = 0;
            for (int i = 0; i < stepCount; i++)
            {
                // Determine the color for the step based on its index
                Brush brush = Brushes.LightGray;
                Brush innerBrush = Brushes.Transparent;
                Pen greenPen = new Pen(Color.Green, 2);

                // Draw the outer circle
                e.Graphics.FillEllipse(brush, x, y, stepSize, stepSize);

                // Draw the green line connecting the completed steps
                if (i < currentStep)
                {
                    innerBrush = Brushes.Green;

                    float lineX1 = x - stepSpacing / 2;
                    float lineX2 = x + stepSize + stepSpacing / 2;
                    float lineY = y + stepSize / 2;

                    if (i == 0)
                        lineX1 = x + innerStepSize / 2;

                    e.Graphics.DrawLine(greenPen, lineX1, lineY, lineX2, lineY);
                }

                // Draw the inner circle for completed steps
                float innerX = x + innerStepSize / 2;
                float innerY = y + innerStepSize / 2;
                e.Graphics.FillEllipse(innerBrush, innerX, innerY, innerStepSize, innerStepSize);

                // Move the drawing position to the right for the next step
                x += stepSize + stepSpacing;
            }
        }
    }
}
