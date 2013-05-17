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
    public partial class Lineaire : Form
    {
        double[,] simplex;
        double[] quotient;
        TextBox[,] variableSimplex;
        int nombreValeur;
        int nombreEquation;

        public Lineaire(int nombreValeur, int nombreEquation)
        {
            InitializeComponent();
            this.nombreValeur = nombreValeur;
            this.nombreEquation = nombreEquation;
            InitialiserTextBox();
        }

        private void buttonCalculer_Click(object sender, EventArgs e)
        {
            InitialiserSimplex();

            Maximiser();
        }
        private void Maximiser()
        {
            while (!Verification())
            {
                int entrante = CalculVariableEntrante();
                CalculQuotient(entrante);
                int lignePivot = TrouverLignePivot();
                DefenirPivot(entrante, lignePivot);
                Gauss(entrante, lignePivot);
            }
            MessageBox.Show(simplex[simplex.GetUpperBound(0), simplex.GetUpperBound(1)].ToString());
        }

        #region Initialisation

        private void InitialiserSimplex()
        {

            int simplexI = nombreValeur + nombreEquation + 2;
            int simplexJ = nombreEquation + 1;
            simplex = new double[simplexI, simplexJ];
            for (int j = variableSimplex.GetLowerBound(1); j <= variableSimplex.GetUpperBound(1); j++)
            {
                for (int i = variableSimplex.GetLowerBound(0); i <= variableSimplex.GetUpperBound(0); i++)
                {
                    simplex[i, j] = double.Parse(variableSimplex[i, j].Text);
                    if (j == variableSimplex.GetUpperBound(1))
                    {
                        simplex[i, j] *= -1;
                    }
                }
                simplex[simplex.GetUpperBound(0), j] = double.Parse(variableSimplex[variableSimplex.GetUpperBound(0), j].Text);
            }



            InitialiserVariableEcart();
        }
        /// <summary>
        /// Initialise les variables d'écarts
        /// </summary>
        private void InitialiserVariableEcart()
        {
            for (int i = nombreValeur; i <= simplex.GetUpperBound(0); i++)
            {
                for (int j = simplex.GetLowerBound(1); j <= simplex.GetUpperBound(1); j++)
                {
                    if ((i - 2) == j)
                    {
                        simplex[i, j] = 1;
                    }
                }
            }
        }
        /// <summary>
        /// Crée les textbox dynamiquement sur la form
        /// </summary>
        private void InitialiserTextBox()
        {
            variableSimplex = new TextBox[nombreValeur + 1, nombreEquation + 1];
            int x = 10;
            int y = 10;


            for (int j = variableSimplex.GetLowerBound(1); j <= variableSimplex.GetUpperBound(1); j++)
            {
                for (int i = variableSimplex.GetLowerBound(0); i <= variableSimplex.GetUpperBound(0); i++)
                {
                    variableSimplex[i, j] = new TextBox();
                    variableSimplex[i, j].Location = new Point(x, y);
                    variableSimplex[i, j].Size = new Size(46, 20);
                    this.Controls.Add(variableSimplex[i, j]);
                    x += 60;
                }
                x = 10;
                y += 30;
            }
            buttonCalculer.Location = new Point(x, y);

            if (this.Size.Height <= y || this.Size.Width <= x)
            {
                this.Size = new Size(1000,1000);
            }
        }
        #endregion

        #region Calcul
        private int CalculVariableEntrante()
        {
            double valeurPlusPetite = 0;
            int entrante = 0;
            int z = simplex.GetUpperBound(1);
            for (int i = simplex.GetLowerBound(0); i <= simplex.GetUpperBound(0); i++)
            {
                if (simplex[i, z] < valeurPlusPetite)
                {
                    entrante = i;
                    valeurPlusPetite = simplex[i, z];
                }
            }
            return entrante;
        }

        private void CalculQuotient(int entrante)
        {
            quotient = new double[nombreEquation];
            //Le quotient est égal a la valeur divisé par la variable entrante
            for (int j = simplex.GetLowerBound(1); j <= simplex.GetUpperBound(1) - 1; j++)
            {

                quotient[j] = (simplex[simplex.GetUpperBound(0), j] / simplex[entrante, j]);
                if (quotient[j] < 0 || quotient[j] == double.PositiveInfinity)
                {
                    quotient[j] = 0;
                }
            }
        }

        private int TrouverLignePivot()
        {
            double valeurPlusPetite = double.MaxValue;
            int lignePivot = 0;
            for (int i = quotient.GetLowerBound(0); i <= quotient.GetUpperBound(0); i++)
            {
                if (quotient[i] < valeurPlusPetite && quotient[i] != 0)
                {
                    valeurPlusPetite = quotient[i];
                    lignePivot = i;
                }
            }
            return lignePivot;
        }

        private void DefenirPivot(int entrante, int lignePivot)
        {
            double pivot = simplex[entrante, lignePivot];

            for (int i = simplex.GetLowerBound(0); i <= simplex.GetUpperBound(0); i++)
            {
                simplex[i, lignePivot] /= pivot;
            }
        }

        private void Gauss(int entrante, int lignePivot)
        {
            double diviseur;
            double premiereLigne;
            double derniereLigne;

            for (int j = simplex.GetLowerBound(1); j <= simplex.GetUpperBound(1); j++)
            {
                if (j != lignePivot)
                {
                    diviseur = simplex[entrante, j] * -1;
                    for (int i = simplex.GetLowerBound(0); i <= simplex.GetUpperBound(0); i++)
                    {
                        premiereLigne = simplex[i, j];
                        derniereLigne = (simplex[i, lignePivot] * diviseur);
                        simplex[i, j] = premiereLigne + derniereLigne;
                    }
                }
            }
        }

        private bool Verification()
        {
            for (int i = simplex.GetLowerBound(0); i <= simplex.GetUpperBound(0); i++)
            {
                if (simplex[i, simplex.GetUpperBound(1)] < 0)
                {
                    return false;
                }
            }
            return true;
        }
        #endregion
    }
}
