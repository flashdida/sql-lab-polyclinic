using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQL_Lab_Polyclinic {
  public partial class Form1 : Form {
    public Form1() {
      InitializeComponent();

    }
    void CreateIfNotExists() {

    }
    private void Form1_Load(object sender, EventArgs e) {
            if (Role == 2)
            {
                button1.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;

            }
        }
        public int Role { get; set; }
    private void button1_Click(object sender, EventArgs e) {
      var f = new crudForm();
      f.ShowDialog();
    }

    private void button3_Click(object sender, EventArgs e) {
      var f = new cascadeDeleteForm();
      f.ShowDialog();
    }

    private void button2_Click(object sender, EventArgs e) {
      var f = new viewForm();
      f.ShowDialog();
    }

    private void button4_Click(object sender, EventArgs e) {
      var f = new markDeleteForm();
      f.ShowDialog();

    }
  }
}
