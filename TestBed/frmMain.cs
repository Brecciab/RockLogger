using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static RockLogger.LogManager;
using System.Reflection;

namespace TestBed
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            LogWriterEF rLog = new LogWriterEF();

            WriteDebugEvent(rLog, MethodBase.GetCurrentMethod(), "This is only a test.");

            TestClass tc = new TestClass();

            tc.CheckCompanyFacts();

            tc.CompanyName = "Test case";
            tc.CompanyId = 14;

            WriteLogEvent(EventLevel.Debug, rLog, MethodBase.GetCurrentMethod(), "This is only a second test.", tc);

            txtResults.Text += Environment.NewLine + $"{ Environment.NewLine} The values in Test Case are now: {Newtonsoft.Json.JsonConvert.SerializeObject(tc)}";
            txtResults.Text += $"{ Environment.NewLine}";
            txtResults.Text += $"The values in rLog are now: { Newtonsoft.Json.JsonConvert.SerializeObject(rLog)}";

            try
            {
                // Now generate an error on purpose
            }
            catch (Exception exp)
            {
                WriteLogEvent(EventLevel.CriticalError, rLog, MethodBase.GetCurrentMethod(),"Critical Error");
            }

        }
    }
}
