using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProgrammationLineaire
{
    public partial class Base : Form
    {
        public Base()
        {
            InitializeComponent();
        }

        private void buttonCalculer_Click(object sender, EventArgs e)
        {
            int nombreValeur = int.Parse(textBoxNombreValeur.Text);
            int nombreEquation = int.Parse(textBoxNombreEquation.Text);
            Lineaire lineraire = new Lineaire(nombreValeur, nombreEquation);
            this.Hide();
            lineraire.ShowDialog();
            this.Close();
        }
    }
}
