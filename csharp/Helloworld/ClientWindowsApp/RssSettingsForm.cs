using RssClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientWindowsApp
{
    public partial class RssSettingsForm : Form
    {

        private ClientMain client;
        private String username = " ";
        private String authtoken;
        private List<String> sites;
        private List<String> tags;

        public ClientMain Client { get => client; set => client = value; }
        public string Username { get => username; private set => username = value; }
        public string Authtoken { get => authtoken; private set => authtoken = value; }
        public List<string> Sites2 { get => sites; }
        public List<string> Tags { get => tags; }

        public RssSettingsForm()
        {
            InitializeComponent();

            sites = new List<String>();
            tags = new List<String>();
            //PopulateDataGridView();
            //listSites.MultiSelect = false;
            //tags.Add("Some tag");
            listSites.MultiSelect = false;
            //listSites.DataSource = sites;
            //listTags.BindingContext =  tags.Cast<String>().Select(tag => new ListViewItem(tag));
            listTags.Items.Clear();
            if (tags.Count > 0) 
                listTags.Items.AddRange(tags.Cast<String>().Select(tag => new ListViewItem(tag)).ToArray());
            //listTags.Items.Add(tags[0]);
        }
        public RssSettingsForm(ClientMain client)
        {
            InitializeComponent();

            this.client = client;
            //загрузить настройки из бд
            sites = new List<String>();
            tags = new List<String>();
            listSites.MultiSelect = false;
            listSites.DataSource = sites;
            listTags.Items.Clear();
            if (tags.Count>0)
                listTags.Items.AddRange(tags.Cast<String>().Select(tag => new ListViewItem(tag)).ToArray());
        }


        private void butOk_Click(object sender, EventArgs e)
        {
            //sites = listSites.DataSource as List<String>;
            //sites = listSites.Rows as IEnumerable<String>; //.Cast<List<String>>();
            foreach (DataGridViewRow row in listSites.Rows)
            {
                if ((row.ToString() != null) && !row.IsNewRow)
                {
                    sites.Add(row.Cells[0].Value.ToString().Trim());
                }
            }
            //sites = listSites.Rows
            //                .Cast<DataGridViewRow>()
            //                .Select(x => x.Cells[1].Value.ToString().Trim())
            //                .ToList<String>();
            tags = listTags.Items.Cast<ListViewItem>().Select(listViewItem => listViewItem.Text).ToList();
        }
        private void PopulateDataGridView()
        {

            string[] row0 = { //"11/22/1968", "29", "Revolution 9", "Beatles", 
                "The Beatles [White Album]" };
            string[] row1 = { //"1960", "6", "Fools Rush In", "Frank Sinatra", 
                "Nice 'N' Easy" };
            //string[] row2 = { "11/11/1971", "1", "One of These Days",
            //"Pink Floyd", "Meddle" };
            //string[] row3 = { "1988", "7", "Where Is My Mind?",
            //"Pixies", "Surfer Rosa" };
            //string[] row4 = { "5/1981", "9", "Can't Find My Mind",
            //"Cramps", "Psychedelic Jungle" };
            //string[] row5 = { "6/10/2003", "13",
            //"Scatterbrain. (As Dead As Leaves.)",
            //"Radiohead", "Hail to the Thief" };
            //string[] row6 = { "6/30/1992", "3", "Dress", 
            //    "P J Harvey", "Dry" };

            listSites.Rows.Add(row0);
            listSites.Rows.Add(row1);
            //listSites.Rows.Add(row2);
            //listSites.Rows.Add(row3);
            //listSites.Rows.Add(row4);
            //listSites.Rows.Add(row5);
            //listSites.Rows.Add(row6);

            //listSites.Columns[0].DisplayIndex = 3;
            //listSites.Columns[1].DisplayIndex = 4;
            //listSites.Columns[2].DisplayIndex = 0;
            //listSites.Columns[3].DisplayIndex = 1;
            //listSites.Columns[4].DisplayIndex = 2;
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {

            if ((client != null) && client.loggedin)
            {
                sites = client.Sites;
                //tags = client.Sites;
            }
            //listSites.Rows.AddRange(sites.ToArray<DataGridViewRow>());

            //listSites.Rows.Clear();
            //PopulateDataGridView();

            //listSites.Rows.Add(sites.ToArray<string>());
            //string[] nstr = { sites[1] };
            //return new []{ myString };

            //listSites.DataSource = sites.Select(x => new string[] { x.ToString() }).ToArray();//.Cast<string[]>();//().Cast<string>().ToArray(); => x => { string[] nstr = { x }; };
            //listSites.Rows.Add(sites.Select(x => new string[] { x.ToString() }).ToArray());
            foreach (string site in sites)
            {
                listSites.Rows.Add(new string[] { site.ToString() });
            }
            //BindingSource binding = new BindingSource();
            //binding.DataSource = sites;
            //listTags.BindingContext =  tags.Cast<String>().Select(tag => new ListViewItem(tag));
            listTags.Items.AddRange(tags.Cast<String>().Select(tag => new ListViewItem(tag)).ToArray());
        }

        private void butAddSite_Click(object sender, EventArgs e)
        {
            if (tbSite.Text.Length > 1)
            {
                if (!sites.Contains(tbSite.Text))   //listTags.Items.ContainsKey(tbTag.Text)
                {
                    sites.Add(tbSite.Text);
                    listSites.Rows.Add(new string[] { tbSite.Text });
                    tbSite.Text = "";
                }
                else lblSiteExist.Text = "Site already added";
                // на textChanged label.Text = ""
                
            }
        }

        private void butAddTag_Click(object sender, EventArgs e)
        {
            if (tbTag.Text.Length > 1)
            {
                if(listTags.FindItemWithText(tbTag.Text)==null)   //listTags.Items.ContainsKey(tbTag.Text)
                {   
                    listTags.Items.Add(tbTag.Text);
                    tbTag.Text = "";
                }
                else lblTagExist.Text = "Tag already added";
            }
        }
        private void tbSite_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                if (tbTag.Text != "")
                    butAddSite_Click(sender, e);
        }

        private void tbSite_Click(object sender, EventArgs e)
        {
            lblSiteExist.Text = "";
        }

        private void tbTag_Click(object sender, EventArgs e)
        {
            lblTagExist.Text = "";
        }

        private void tbTag_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.)
            //    if (tbTag.Text != "")
            //        butAddSite_Click(sender, e);
        }



        //private void InitializeComponent()
        //{
        //    this.SuspendLayout();
        //    // 
        //    // SettingsForm
        //    // 
        //    this.ClientSize = new System.Drawing.Size(274, 229);
        //    this.Name = "SettingsForm";
        //    this.ResumeLayout(false);

        //}
    }
}
