using NivelStocareDate;
using LibrarieModele;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ProiectPIU;




namespace InterfataUtilizator
{
    public partial class Form1: Form
    {
        AdministrareJucatori_FisierText adminJucatori;

        private Label lblNume;
        private Label lblPrenume;
        private Label lblInaltime;

        private Label[] lblsNume;
        private Label[] lblsPrenume;
        private Label[] lblsInaltime;

        private const int latime_control = 100;
        private const int dim_pas_y = 30;
        private const int dim_pas_x = 120;

        

        public Form1()
        {
            InitializeComponent();
            string numeFisier = ConfigurationManager.AppSettings["NumeFisier"];
            string locatieFisierSolutie = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;

            string caleCompletaFisier = locatieFisierSolutie + "\\" + numeFisier;

            AdministrareJucatori_FisierText adminJucatori = new AdministrareJucatori_FisierText(caleCompletaFisier);

            // setam proprietatile
            this.Size = new Size(500, 200);
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(100, 100);
            this.Font = new Font("Arial", 9, FontStyle.Bold);
            this.ForeColor = Color.LimeGreen;
            this.Text = "Informatii jucatori";

            lblNume = new Label();
            lblNume.Width = latime_control;
            lblNume.Text = "Nume";
            lblNume.Left = dim_pas_x;
            lblNume.ForeColor = Color.DarkGreen;
            this.Controls.Add(lblNume);

            //adaugare control de tip Label pentru 'Prenume';
            lblPrenume = new Label();
            lblPrenume.Width = latime_control;
            lblPrenume.Text = "Prenume";
            lblPrenume.Left = 2 * dim_pas_x;
            lblPrenume.ForeColor = Color.DarkGreen;
            this.Controls.Add(lblPrenume);

            //adaugare control de tip Label pentru 'Note';
            lblInaltime = new Label();
            lblInaltime.Width = latime_control;
            lblInaltime.Text = "Inaltime:";
            lblInaltime.Left = 3 * dim_pas_x;
            lblInaltime.ForeColor = Color.DarkGreen;
            this.Controls.Add(lblInaltime);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AfiseazaJucatori();
        }

        private void AfiseazaJucatori()
        {
            Jucator[] jucatori = adminJucatori.GetJucatori(out int nrJucatori);

            lblsNume = new Label[nrJucatori];
            lblsPrenume = new Label[nrJucatori];
            lblsInaltime = new Label[nrJucatori];

            int i = 0;
            foreach (Jucator jucator in jucatori)
            {
                lblsNume[i] = new Label();
                lblsNume[i].Width = latime_control;
                lblsNume[i].Text = jucator.numeJucator;
                lblsNume[i].Left = dim_pas_x;
                lblsNume[i].Top = (i + 1) * dim_pas_y;
                this.Controls.Add(lblsNume[i]);

                //adaugare control de tip Label pentru prenumele studentilor
                lblsPrenume[i] = new Label();
                lblsPrenume[i].Width = latime_control;
                lblsPrenume[i].Text = jucator.prenumeJucator;
                lblsPrenume[i].Left = 2 * dim_pas_x;
                lblsPrenume[i].Top = (i + 1) * dim_pas_y;
                this.Controls.Add(lblsPrenume[i]);

                //adaugare control de tip Label pentru notele studentilor
                lblsInaltime[i] = new Label();
                lblsInaltime[i].Width = latime_control;
                lblsInaltime[i].Text = jucator.inaltimeJucator.ToString();
                lblsInaltime[i].Left = 2 * dim_pas_x;
                lblsInaltime[i].Top = (i * 1) * dim_pas_y;
                this.Controls.Add(lblsInaltime[i]);
                i++;

            }

        }
    }
}
