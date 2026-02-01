using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Elective
{
    public partial class POS2Print : Form
    {
        public POS2Print()
        {
            InitializeComponent();
        }

        public POS2Print(ListBox.ObjectCollection items)
        {
            InitializeComponent();

            // the data will display here from the form1
            printdisplayListbox.Items.AddRange(items);
        }
    }
}
