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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            LogWriterEF rLog = new LogWriterEF();

            WriteDebugEvent(rLog, MethodBase.GetCurrentMethod(), "This is only a test.");

            TestClass tc = new TestClass();

            tc.SetCompanyFacts();

            tc.CompanyName = "Test case";
            tc.CompanyId = 14;

            WriteLogEvent(EventLevel.Debug, rLog, MethodBase.GetCurrentMethod(), "This is only a second test.", tc);

            txtResults.Text += Environment.NewLine + $"{ Environment.NewLine} The values in Test Case are now: {Newtonsoft.Json.JsonConvert.SerializeObject(tc)}";
            txtResults.Text += $"{ Environment.NewLine}";
            txtResults.Text += $"The values in rLog are now: { Newtonsoft.Json.JsonConvert.SerializeObject(rLog)}";

            DataAccess.EventSampleEntities context = new DataAccess.EventSampleEntities();

            var events = 
            (from o in context.EventActivities
             select o).Count();

            txtResults.Text += string.Format( $"{ Environment.NewLine}The row count is now: {events.ToString()}");

            try
            {
                // Now generate an error on purpose
            }
            catch (Exception exp)
            {
                WriteLogEvent(EventLevel.CriticalError, rLog, MethodBase.GetCurrentMethod(),"Critical Error");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            LogWriterEF rLog = new LogWriterEF();

            OtherTestClass otc = new OtherTestClass();
            
            otc.ErrorId = 14;

            RockLogger.Settings settings = RockLogger.Settings.Instance;

            settings.CurrentLoggingLevel = RockLogger.LogManager.EventLevel.Debug;

            WriteDebugEvent(rLog, MethodBase.GetCurrentMethod(), "This is a test after changing the default logging level", otc, this);
            txtResults.Text += $"{ Environment.NewLine}Check the record count.";

            DataAccess.EventSampleEntities context = new DataAccess.EventSampleEntities();

            var events =
            (from o in context.EventActivities
             select o).Count();


            txtResults.Text += string.Format($"{ Environment.NewLine}The row count is now: {events.ToString()}");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ErrorItem it = new TestBed.ErrorItem();

            it.Title = "Test Error Display";
            it.DisplayMessage = "We would have a friendly message here for display.";
            it.HelpLink = "https://msdn.microsoft.com/en-us/library/aa288420(v=vs.71).aspx";
            it.Number = 503;

            DisplayError frmErr = new DisplayError(it);
            frmErr.ShowDialog(); // showing dialog so that it has to be dealt with
        }
    }
}
