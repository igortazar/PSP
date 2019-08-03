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
        private Process p1 = null;
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

        private void Button4_Click(object sender, EventArgs e)
        {
            if(p1==null)
            {
                //iniciar pipes
                ProcessStartInfo info = new ProcessStartInfo(@"..\..\..\pipe\bin\Release\netcoreapp2.1\win-x64\pipe.exe");
                // su valor por defecto el false, si se establece a true no se "crea" ventana
                info.CreateNoWindow = false;
                info.WindowStyle = ProcessWindowStyle.Normal;
                // indica si se utiliza el cmd para lanzar el proceso
                info.UseShellExecute = true;
                p1 = Process.Start(info);
            }
            
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            //parar pipes
            if(p1!=null && !p1.HasExited)
            {
                p1.Kill();
                p1 = null;
            }
        }
    }
}
