using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace slowBrowser
{
    public partial class Form1 : Form
    {
        public String homeUrl = "https://google.com";
        public String searchEngine = "Google";
        public bool darkMode = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void tabControl_MouseDown(object sender, MouseEventArgs e)
        {
            //Pokud uživatel klikne na + (nový list)
            if (tabControl.SelectedIndex == tabControl.TabCount - 1)
            {
                tabControl.TabPages.Insert(tabControl.TabCount - 1, "Nová stránka");
                tabControl.SelectTab(tabControl.TabCount - 2);
                WebBrowser browser = new WebBrowser() { ScriptErrorsSuppressed = true };
                browser.Parent = tabControl.TabPages[tabControl.TabCount - 2];
                browser.Dock = DockStyle.Fill;
                browser.Navigate(homeUrl);
                browser.Navigating += Browser_Navigating;
                browser.DocumentCompleted += Browser_DocumentCompleted;
                backButton.Enabled = false;
                forwardButton.Enabled = false;
            }
            else {
                WebBrowser browser = tabControl.SelectedTab.Controls[0] as WebBrowser;
                urlBox.Text = browser.Url.ToString();
                isBookmarked();
                if (browser.CanGoBack)
                {
                    backButton.Enabled = true;
                }
                if (browser.CanGoForward)
                {
                    forwardButton.Enabled = true;
                }
            }
        }

        private void Browser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            WebBrowser browser = tabControl.SelectedTab.Controls[0] as WebBrowser;
            tabControl.SelectedTab.Text = browser.DocumentTitle;
            urlBox.Text = browser.Url.ToString();
            statusLabel.Text = "";
            isBookmarked();
            if (browser.CanGoBack)
            {
                backButton.Enabled = true;
            }
            if (browser.CanGoForward)
            {
                forwardButton.Enabled = true;
            }
        }

        private void Browser_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            statusLabel.Text = "Načítání " + e.Url.Host;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //vyvolání prvního listu automaticky
            tabControl_MouseDown(null, null);
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            WebBrowser browser = tabControl.SelectedTab.Controls[0] as WebBrowser;
            browser.Refresh();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            WebBrowser browser = tabControl.SelectedTab.Controls[0] as WebBrowser;
            if (browser.CanGoBack)
            {
                browser.GoBack();
                forwardButton.Enabled = true;
            }
            else {
                backButton.Enabled = false;
            }
        }

        private void forwardButton_Click(object sender, EventArgs e)
        {
            WebBrowser browser = tabControl.SelectedTab.Controls[0] as WebBrowser;
            if (browser.CanGoForward)
            {
                browser.GoForward();
                backButton.Enabled = true;
            }
            else {
                forwardButton.Enabled = false;
            }
        }

        private void homeButton_Click(object sender, EventArgs e)
        {
            WebBrowser browser = tabControl.SelectedTab.Controls[0] as WebBrowser;
            browser.Navigate(homeUrl);
        }

        private void urlBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) {
                if (String.IsNullOrEmpty(urlBox.Text)) return;
                if (urlBox.Text.Equals("about:blank")) return;
                if (urlBox.Text.Contains(".")){
                    WebBrowser browser = tabControl.SelectedTab.Controls[0] as WebBrowser;
                    browser.Navigate(urlBox.Text);
                }
                else {
                    search();
                }
            }
        }

        private void search() {
            WebBrowser browser = tabControl.SelectedTab.Controls[0] as WebBrowser;
            Uri searched = null;
            String search = urlBox.Text;
            if (search.Contains(" ")) {
                search = urlBox.Text.Replace(" ", "+");
            }
            switch (searchEngine) {
                case "Google":
                    searched = new Uri(string.Format("http://www.google.com/search?q={0}", search));
                    break;
                case "Yahoo":
                    searched = new Uri(string.Format("http://search.yahoo.com/search?p={0}", search));
                    break;
                case "Bing":
                    searched = new Uri(string.Format("http://www.bing.com/search?q={0}", search));
                    break;
                case "DuckDuckGo":
                    searched = new Uri(string.Format("https://duckduckgo.com/?q={0}", search));
                    break;
            }
            browser.Navigate(searched);
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {
            Form settings = new Form2(this, homeUrl, searchEngine, darkMode);
            settings.Show();
        }

        private void urlBox_Click(object sender, EventArgs e)
        {
            urlBox.SelectAll();
        }

        private void bookmarkButton_Click(object sender, EventArgs e)
        {
            WebBrowser browser = tabControl.SelectedTab.Controls[0] as WebBrowser;
            var newBookmark = new ToolStripMenuItem(browser.Url.ToString());
            bookmarks.DropDownItems.Add(newBookmark);
            if (darkMode == false)
            {
                bookmarkButton.Image = Properties.Resources.bookmarkFilled;
            }
            else
            {
                bookmarkButton.Image = Properties.Resources.bookmarkFilledL;
            }
            newBookmark.Click += NewBookmark_Click;
        }

        private void NewBookmark_Click(object sender, EventArgs e)
        {
            WebBrowser browser = tabControl.SelectedTab.Controls[0] as WebBrowser;
            browser.Navigate((sender as ToolStripMenuItem).Text);
        }

        private void isBookmarked()
        {
            WebBrowser browser = tabControl.SelectedTab.Controls[0] as WebBrowser;
            if (darkMode == false)
            {
                bookmarkButton.Image = Properties.Resources.bookmark;
            }
            else {
                bookmarkButton.Image = Properties.Resources.bookmarkL;
            }
            foreach (ToolStripMenuItem bookmark in bookmarks.DropDownItems)
            {
                if (bookmark.ToString() == browser.Url.ToString())
                {
                    if (darkMode == false)
                    {
                        bookmarkButton.Image = Properties.Resources.bookmarkFilled;
                    }
                    else {
                        bookmarkButton.Image = Properties.Resources.bookmarkFilledL;
                    }
                    break;
                }
            }
        }

        public void toggleDarkMode() {
            if (darkMode == false)
            {
                // -- TOOSTRIP --
                toolStrip.BackColor = Color.FromArgb(240, 240 ,240);
                backButton.Image = Properties.Resources.back;
                forwardButton.Image = Properties.Resources.forward;
                refreshButton.Image = Properties.Resources.refresh;
                homeButton.Image = Properties.Resources.home;
                urlBox.BackColor = Color.FromArgb(240, 240, 240);
                urlBox.ForeColor = Color.FromArgb(0, 0, 0);
                bookmarks.BackColor = Color.FromArgb(240, 240, 240);
                bookmarks.ForeColor = Color.FromArgb(0, 0, 0);
                bookmarks.DropDown.BackColor = Color.FromArgb(240, 240, 240);
                bookmarks.DropDown.ForeColor = Color.FromArgb(0, 0, 0);
                settingsButton.Image = Properties.Resources.settings;
                isBookmarked();
                //-- /TOOLSTRIP --
                // -- TABCONTROL --

                // -- /TABCONTROL --
                // -- STATUSSTRIP -- 
                statusStrip.BackColor = Color.FromArgb(240, 240, 240);
                statusStrip.ForeColor = Color.FromArgb(0, 0, 0);
                // -- /STATUSSTRIP -- 
            }
            else {
                // -- TOOSTRIP --
                toolStrip.BackColor = Color.FromArgb(52, 52, 52);
                backButton.Image = Properties.Resources.backL;
                forwardButton.Image = Properties.Resources.forwardL;
                refreshButton.Image = Properties.Resources.refreshL;
                homeButton.Image = Properties.Resources.homeL;
                urlBox.BackColor = Color.FromArgb(52, 52, 52);
                urlBox.ForeColor = Color.FromArgb(255, 255, 255);
                bookmarks.BackColor = Color.FromArgb(52, 52, 52);
                bookmarks.ForeColor = Color.FromArgb(255, 255, 255);
                bookmarks.DropDown.BackColor = Color.FromArgb(52, 52, 52);
                bookmarks.DropDown.ForeColor = Color.FromArgb(255, 255, 255);
                settingsButton.Image = Properties.Resources.settingsL;
                isBookmarked();
                // -- /TOOSTRIP --
                // -- TABCONTROL --

                // --/TABCONTROL -- 
                // -- STATUSSTRIP -- 
                statusStrip.BackColor = Color.FromArgb(52, 52, 52);
                statusStrip.ForeColor = Color.FromArgb(255, 255, 255);
                // -- /STATUSSTRIP -- 
            }
        }
    }
}
