using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientWindowsApp
{
    public partial class NewsFeedPanel : UserControl
    {
        public NewsFeedPanel()
        {
            InitializeComponent();
        }
        public NewsFeedPanel(System.ServiceModel.Syndication.SyndicationItem item)
        {
            InitializeComponent();
            newsItem = item;

        }

        //private void lblPublished_Paint(object sender, PaintEventArgs e)
        //{
        //    flListItemTemplate.SendToBack();//BringToFront();
        //    lblSubject.BringToFront();
        //    lblSummary.BringToFront();
        //    lblPublished.BringToFront();
        //}
    }
}
