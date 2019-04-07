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
    public partial class Form2 : Form
    {

        public Form2()
        {
            InitializeComponent();
        }

        private Form1 mainform;
        public Form2(Form browserForm, String homeUrl, String searchEngine, bool darkModeState)
        {
            mainform = browserForm as Form1;
            InitializeComponent();
            homeUrlTextBox.Text = homeUrl;
            searchEngineBox.Text = searchEngine;
            darkModeCheckBox.Checked = darkModeState;
        }

        private void commitButton_Click(object sender, EventArgs e)
        {
            this.mainform.homeUrl = homeUrlTextBox.Text;
            this.mainform.searchEngine = searchEngineBox.Text;
            this.mainform.darkMode = darkModeCheckBox.Checked;
            this.mainform.toggleDarkMode();
            this.Close();
        }
    }
}
