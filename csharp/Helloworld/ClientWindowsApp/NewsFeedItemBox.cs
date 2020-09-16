using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Helloworld;

namespace ClientWindowsApp
{
    public partial class NewsFeedItemBox : UserControl
    {
        public NewsFeedItemBox()
        {
            InitializeComponent();
        }
        public NewsFeedItemBox(NewsReply item)
        {
            InitializeComponent();
            newsItem = item;
            lblSubject.Text = newsItem.Subject;
            lblSummary.Text = newsItem.Summary;
            lblPublished.Text = newsItem.Date;
        }
    }
}
