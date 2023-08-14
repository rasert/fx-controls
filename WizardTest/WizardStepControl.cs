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
    public partial class WizardStepControl : UserControl
    {
        [Description("Name of the step"), Category("Step Config")]
        public string StepName { get => label1.Text; set => label1.Text = value; }
        public WizardStepControl()
        {
            InitializeComponent();
        }
    }
}
