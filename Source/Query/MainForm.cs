using HappyWords.Data.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Query
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void _btnQueryDistinctProns_Click(object sender, EventArgs e)
        {
            var words = WordRepository.Get();
            var prons = words.Where(w => !string.IsNullOrWhiteSpace(w.USPron))
                             .SelectMany(w => w.USPron.ToCharArray())
                             .Distinct()
                             .ToList();
            _output.Text = "[" + string.Join(", ", prons.Select(p => string.Format("\"{0}\"", p))) + "]";
        }
    }
}
