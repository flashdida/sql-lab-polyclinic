using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQL_Lab_Polyclinic {
  public partial class Form2 : Form {
    List<Specialization> _list;
    public Form2() {
      InitializeComponent();
    }

    private void button2_Click(object sender, EventArgs e) {
      int index = listBox1.SelectedIndex;
      if (index == -1) {
        MessageBox.Show("Выберите запись для восстановления");
        return;
      }
      DialogResult res = MessageBox.Show("Запись будет восстановлена?", "Восстановление с меткой", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
      if (res == DialogResult.Yes) {
        using (var conn = new SqlConnection(Properties.Resources.ConnectionString)) {
          conn.Open();
          var cmd = conn.CreateCommand();
          cmd.CommandText =
            $@"update Specializations set IsDeleted=0
              where Id=  {_list[index].Id}";
          cmd.ExecuteNonQuery();
        }
        GetListBox();
        MessageBox.Show("Запись была восстановлена с меткой");
      }
    }

    private void btnLast_Click(object sender, EventArgs e) {
      listBox1.SelectedIndex = listBox1.Items.Count - 1;
    }

    private void btnRight_Click(object sender, EventArgs e) {
      listBox1.SelectedIndex++;

    }

    private void btnLeft_Click(object sender, EventArgs e) {
      listBox1.SelectedIndex--;

    }

    private void btnFirst_Click(object sender, EventArgs e) {
      listBox1.SelectedIndex = 0;

    }

    private void listBox1_SelectedIndexChanged(object sender, EventArgs e) {
      int index = listBox1.SelectedIndex;
      if (index != -1) {
        if (listBox1.Items.Count > 1) {

          if (index == 0) {
            btnFirst.Enabled = false;
            btnLeft.Enabled = false;
            btnRight.Enabled = true;
            btnLast.Enabled = true;
          } else if (index == listBox1.Items.Count - 1) {
            btnFirst.Enabled = true;
            btnLeft.Enabled = true;
            btnRight.Enabled = false;
            btnLast.Enabled = false;
          } else {
            btnFirst.Enabled = true;
            btnLeft.Enabled = true;
            btnRight.Enabled = true;
            btnLast.Enabled = true;
          }
        } else {
          btnFirst.Enabled = false;
          btnLeft.Enabled = false;
          btnRight.Enabled = false;
          btnLast.Enabled = false;
        }
      } else {
        btnFirst.Enabled = false;
        btnLeft.Enabled = false;
        btnRight.Enabled = false;
        btnLast.Enabled = false;
      }
    }
    void GetListBox() {
      listBox1.Items.Clear();
      _list = Specialization.GetDeletedSpecializations();
      foreach (var n in _list)
        listBox1.Items.Add(n.Name);
      if (listBox1.Items.Count > 0)
        listBox1.SelectedIndex = 0;
    }

    private void Form2_Load(object sender, EventArgs e) {
      GetListBox();
    }
  }
}
