using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace procesos2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            
                // no hay parametros, unicamente el nombre del programa a ejecutar. chrome esta incluido en el path
                // en caso contrario no funciona
                ProcessStartInfo p = new ProcessStartInfo("chrome.exe");
                Process.Start(p);
            
        }

        private void Button2_Click(object sender, EventArgs e)
        {
                ProcessStartInfo p = new ProcessStartInfo("calc.exe");
                var tmp = Process.Start(p);              
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            ProcessStartInfo p = new ProcessStartInfo(@"..\..\..\parametros\bin\Release\netcoreapp2.1\publish\parametros.exe", textBox1.Text);
            var tmp = Process.Start(p);
        }

       
    }
}
