using Helloworld;
using System;
using System.Windows.Forms;

//using LoginForm;

namespace ClientWindowsApp
{
    public partial class RssClientForm : Form
    {
        RssClient.ClientMain client;
        private bool Resizing = false;
        public RssClientForm()
        {
            InitializeComponent();
            client = new RssClient.ClientMain();
            client.NewsRecieved += new EventHandler<NewsReply>(OnNewsRecieved);  //new EventHandler<string>(OnNewsRecieved);
            //listNews.Columns.Clear();
            //listNews.Items.Clear();
            //listNews.View = View.Details;

            //listNews.Columns.Add("Latest News");
            //listNews.Columns[0].Width = listNews.Width - 2;

            //listNews.Items.Add(new ListViewItem(new string[] { " " }));
            //listNews.Items.Clear();
        }

        private void butLoad_Click(object sender, EventArgs e)
        {
            client.GetNews();
        }
        private void OnNewsRecieved(object sender, string e)
        {
            //html format
            //String.Format(e);
            listNews.Items.Add(new ListViewItem(new string[] { String.Format(e) }));
            webBrowser1.DocumentText = e;
            //webBrowser1.Navigate();
        }
        private void OnNewsRecieved(object sender, NewsReply e)
        {
            //html format
            //String.Format(e);
            //listNews.Items.Add(new ListViewItem(new string[] { String.Format(e) }));
            Label lblTemp = new Label();
            lblTemp.Text = e.Subject;
            Label lblTempS = new Label();
            lblTemp.Text = e.Summary;
            LinkLabel lblTempL = new LinkLabel();
            lblTemp.Text = e.Url;
            FlowLayoutPanel flTmp = new FlowLayoutPanel();
            flTmp.FlowDirection = FlowDirection.TopDown;
            flTmp.Controls.Add(lblTemp);
            flTmp.Controls.Add(lblTempS);
            flTmp.Controls.Add(lblTempL);
            listNews.Controls.Add(flTmp);
            ///webBrowser1.DocumentText = e;
            webBrowser1.Navigate(e.Url);
        }

        private void listNews_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (listNews.SelectedItems.Count > 0)
      {
        ListViewItem item = listNews.SelectedItems[0];
        webBrowser1.DocumentText = item.Text;
      }
    }
        private void listNews_Add(object sender, EventArgs e)
        {
            //create label
            //create linklabel
            //create label/text field unchangable
            //add to listview
        }



        private void ListView_SizeChanged(object sender, EventArgs e)
    {
      // Don't allow overlapping of SizeChanged calls
      if (!Resizing)
      {
        // Set the resizing flag
        Resizing = true;

        ListView listView = sender as ListView;
        if (listView != null)
        {
          float totalColumnWidth = 0;

          // Get the sum of all column tags
          for (int i = 0; i < listView.Columns.Count; i++)
            totalColumnWidth += Convert.ToInt32(listView.Columns[i].Tag);

          // Calculate the percentage of space each column should 
          // occupy in reference to the other columns and then set the 
          // width of the column to that percentage of the visible space.
          for (int i = 0; i < listView.Columns.Count; i++)
          {
            float colPercentage = (Convert.ToInt32(listView.Columns[i].Tag) / totalColumnWidth);
            listView.Columns[i].Width = (int)(colPercentage * listView.ClientRectangle.Width);
          }
        }
      }

      // Clear the resizing flag
      Resizing = false;
    }

        private void butLogin_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Client = this.client;
            loginForm.ShowDialog();
            if (loginForm.DialogResult == DialogResult.OK)
            {
                lblUsername.Text = loginForm.Username;
                //load settings
                //load rss feed
            }
        }
    }
}
