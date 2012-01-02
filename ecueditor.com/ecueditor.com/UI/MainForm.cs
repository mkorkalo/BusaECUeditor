using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ecueditor.com.UI
{
    public partial class MainForm : Form
    {
        #region Constructors

        public MainForm()
        {
            InitializeComponent();
        }

        #endregion

        #region Control Event Handlers

        private void btnFuelMaps_Click(object sender, EventArgs e)
        {
            FuelMap fuelMap = new FuelMap();
            fuelMap.Show();
        }

        #endregion

    }
}
