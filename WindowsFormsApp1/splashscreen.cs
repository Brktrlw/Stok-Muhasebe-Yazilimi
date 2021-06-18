using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroSet_UI.Forms;
using System.Threading;
namespace WindowsFormsApp1
{
    public partial class splashscreen : MetroSetForm
    {
        public splashscreen()
        {
            InitializeComponent();
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int i = 0;
            int deger = 0;
            while (i < 100)
            {
                
                deger +=1;
                progressbar.Value = deger;
                i++;
            }

        }
    }
}
