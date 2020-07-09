using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace testApp
{
    public partial class Boleto : Form
    {
        //Variables
        bool negrita = false;


        //Funciones
        public Boleto()
        {
            InitializeComponent();
        }
        /*********************************************************************************/
        private void textBoleto_TextChanged(object sender, EventArgs e)
        {
            labelBoleto.Text = "Bytes: " + textBoleto.Text.Length;
        }
        /*********************************************************************************/
        private void buttonNegrita_Click(object sender, EventArgs e)
        {
            negrita = !negrita;
            if (negrita)
            {
                //textBoleto.Text += "<CMD:NEG1>";
                textBoleto.Text = textBoleto.Text.Insert(textBoleto.SelectionStart,"<CMD:NEG1>");
                buttonNegrita.Text = "No negrita";
            }
            else {
                textBoleto.Text = textBoleto.Text.Insert(textBoleto.SelectionStart, "<CMD:NEG0>");
                buttonNegrita.Text = "Negrita";
            }    
        }
        /*********************************************************************************/
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (justificacion.Text == "Izquierda")
                textBoleto.Text = textBoleto.Text.Insert(textBoleto.SelectionStart,"<CMD:JUSTL>");
            else if (justificacion.Text == "Centrada")
                textBoleto.Text = textBoleto.Text.Insert(textBoleto.SelectionStart, "<CMD:JUSTC>");
            else if (justificacion.Text == "Derecha")
                textBoleto.Text = textBoleto.Text.Insert(textBoleto.SelectionStart, "<CMD:JUSTR>");
        }
        /*********************************************************************************/
        private void variables_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (variables.Text == "Folio")
                textBoleto.Text = textBoleto.Text.Insert(textBoleto.SelectionStart,"<CMD:VARFOL>");
            else if (variables.Text == "Fecha")
                textBoleto.Text = textBoleto.Text.Insert(textBoleto.SelectionStart,"<CMD:VARFCH>");
            else if (variables.Text == "CodigoBar1")
                textBoleto.Text = textBoleto.Text.Insert(textBoleto.SelectionStart,"<CMD:VARCB1>");
            else if (variables.Text == "CodigoBar2")
                textBoleto.Text = textBoleto.Text.Insert(textBoleto.SelectionStart, "<CMD:VARCB2>");
        }
        /*********************************************************************************/
        private void button1_Click(object sender, EventArgs e)
        {
            textBoleto.Text = textBoleto.Text.Insert(textBoleto.SelectionStart,  "<CMD:SIZE" + sizeAlto.Text + sizeAncho.Text + ">");
        }
        /*********************************************************************************/
        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog svb = new SaveFileDialog();
            svb.Filter = "Archivos txt(*.txt)|*.txt";
            svb.Title = "Guardar";
            if (svb.ShowDialog() == DialogResult.OK)
            {
                //byte[] datos = new byte[3200];
                //datos = Encoding.ASCII.GetBytes(textBoleto.Text);
                //Encoding.ASCII.GetString(datos)

                System.IO.File.WriteAllText(svb.FileName, textBoleto.Text);
                MessageBox.Show("Guardado Correctamente", "SAVE FILE",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
            }
        }
        /*********************************************************************************/
        private void buttonLoad_Click(object sender, EventArgs e)
        {
            int cont = 0;
            string line;

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Archivos txt (*.txt)|*.txt";
            ofd.Title = "Abrir";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                System.IO.StreamReader file =
                new System.IO.StreamReader(ofd.FileName);
                // Read the file and display it line by line.  
                textBoleto.Text = "";
                while ((line = file.ReadLine()) != null)
                {
                    textBoleto.Text += line + "\r\n";
                    //textBoleto.AppendText(line);
                    cont++;
                }
                file.Close();
                //MessageBox.Show("Cargado Correctamente", "OPEN FILE",
                //MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoleto.Text = "";
        }

        private void Boleto_Load(object sender, EventArgs e)
        {
            
        }
    }
}
