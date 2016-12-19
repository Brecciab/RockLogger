using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestBed
{
    public partial class DisplayError : Form
    {
        public ErrorItem ErrItem { get; set; }

        public DisplayError(ErrorItem errItem)
        {
            ErrItem = errItem;
            InitializeComponent();
        }

        private void DisplayError_Load(object sender, EventArgs e)
        {
            // Check to make sure that the form has an ErrorItem to display
            if (ErrItem != null)
            {
                lblErrorNumber.Text = ErrItem?.Number.ToString() ?? "Unable to find a number associated with this error";
                lblErrorMessage.Text = ErrItem?.DisplayMessage ?? "Unable to find a message associated with this error.";
                // set the title of the form
                Text = ErrItem?.Title ?? "Generic Error";

                //Only display the link if there is information.  
                if (!string.IsNullOrEmpty(ErrItem.HelpLink))
                {
                    lnkHelp.Visible = true;
                    lnkHelp.Links.Add(6, 4, ErrItem.HelpLink);
                }

                if (!string.IsNullOrEmpty(ErrItem.VideoLink))
                {
                    lnkVideo.Visible = true;
                    lnkVideo.Links.Add(6, 4, ErrItem.VideoLink);
                }
                //Future: may want to make the links dynamic rather than fixed
            }
        }

        private void lnkVideo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.Link.LinkData.ToString());
        }

        private void lnkHelp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.Link.LinkData.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //TODO: Add function to submit the ticket to the support site
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
