using System;
using System.Windows.Forms;


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
      client.NewsRecieved += new EventHandler<string>(OnNewsRecieved);
      //listNews.Columns.Clear();
      //listNews.Items.Clear();
      //listNews.View = View.Details;
      
      //listNews.Columns.Add("Latest News");
      //listNews.Columns[0].Width = listNews.Width - 2;
    }

    private void butLoad_Click(object sender, EventArgs e)
    {
      client.GetNews();
    }

    private void OnNewsRecieved(object sender, string e)
    {
      listNews.Items.Add(new ListViewItem(new string[] { "FIRST" }));
      webBrowser1.DocumentText = e;
    }

    private void listNews_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (listNews.SelectedItems.Count > 0)
      {
        ListViewItem item = listNews.SelectedItems[0];
        webBrowser1.DocumentText = item.Text;
      }
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
  }
}
