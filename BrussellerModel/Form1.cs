using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrussellerModel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            var Xmax = 1M;
            var Tmax = 1M;
            var difusionService = new DifusionService(Xmax, Tmax);
            FileService.WriteResult("result1.txt",difusionService.T, Xmax, Tmax);
            FileService.WriteResult("result2.txt",difusionService.P, Xmax, Tmax);
        }
    }
}
