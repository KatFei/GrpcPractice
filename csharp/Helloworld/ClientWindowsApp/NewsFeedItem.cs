using System;
using System.Collections.Generic;
using System.ComponentModel;

using System.Drawing;
using System.Drawing.Text;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Helloworld;
using System.Text.RegularExpressions;

namespace ClientWindowsApp
{
    public partial class NewsFeedItem : UserControl
    {
        [Browsable(true)]
        [Category("Action")]
        [Description("Invoked when user clicks news feed item")]
        public event EventHandler<NewsReply> ItemClicked;
        public NewsFeedItem()
        {
            InitializeComponent();
        }
        public NewsFeedItem(NewsReply item)
        {
            InitializeComponent();
            newsItem = item;
            lblSubject.Text = newsItem.Subject;
            string noHTML = Regex.Replace(newsItem.Summary, @"<[^>]+>|&nbsp;", "").Trim();
            string noHTMLNormalised = Regex.Replace(noHTML, @"\s{2,}", " ");

            lblSummary.Text = noHTMLNormalised;
            lblPublished.Text = newsItem.Date;
        }

        private void NewsFeedItem_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
            //TextRenderer.DrawText(e.Graphics, "Hi There", new Font(this.Font.FontFamily, 32f), new Point(100, 50), Color.Black);
            base.OnPaint(e);
        }

        private void NewsFeedItem_MouseClick(object sender, MouseEventArgs e)
        {
            //передаем newsItem.Summary в событии
            //можно передавать только Summary
            ItemClicked?.Invoke(this, newsItem);
        }
    }
}
