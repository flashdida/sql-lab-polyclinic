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
  public partial class markDeleteForm : Form {

    public markDeleteForm() {
      InitializeComponent();
    }
    List<Specialization> _list;
    void GetListBox() {
      listBox1.Items.Clear();
      _list = Specialization.GetSpecializations();
      foreach (var n in _list)
        listBox1.Items.Add(n.Name);
      if (listBox1.Items.Count > 0)
        listBox1.SelectedIndex = 0;
    }
    private void markDeleteForm_Load(object sender, EventArgs e) {
      GetListBox();
    }

    private void button2_Click(object sender, EventArgs e) {
      var f = new Form2();
      f.ShowDialog();
      GetListBox();
    }

    private void button1_Click(object sender, EventArgs e) {
      int index = listBox1.SelectedIndex;
      if (index == -1) {
        MessageBox.Show("Выберите запись для удаления");
        return;
      }
      DialogResult res = MessageBox.Show("Запись будет удалена?", "Удаление с меткой", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
      if (res == DialogResult.Yes) {
        using (var conn = new SqlConnection(Properties.Resources.ConnectionString)) {
          conn.Open();
          var cmd = conn.CreateCommand();
          cmd.CommandText = $@"update Specializations set IsDeleted=1 where Id=  {_list[index].Id}";
          cmd.ExecuteNonQuery();
        }
        GetListBox();
        MessageBox.Show("Запись была удалена с меткой");
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
  }
}
