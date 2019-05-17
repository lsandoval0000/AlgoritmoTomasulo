using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlgoritmoTomasulo
{
    public partial class InfoAyuda : Form
    {
        public InfoAyuda()
        {
            InitializeComponent();
        }

        private void InfoAyuda_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
    }
}
