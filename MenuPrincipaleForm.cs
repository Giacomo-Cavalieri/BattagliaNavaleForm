using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BattagliaNavale
{
    public partial class MenuPrincipaleForm : Form
    {
        public Button IniziaPartitaBtn { get; set; }
        public Button EsciDalGiocoBtn { get; set; }

        public MenuPrincipaleForm()
        {            
            InitializeComponent();
        }       
    }
}
