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
  public partial class cascadeDeleteForm : Form {
    public cascadeDeleteForm() {
      InitializeComponent();
            connection = new SqlConnection(Properties.Resources.ConnectionString);
            connection.Open();
            
            trans = connection.BeginTransaction();
            trans.Save("point");

    }
    List<Specialization> _list;
        SqlConnection connection;
        SqlTransaction trans;

    void GetListBox() {
      listBox1.Items.Clear();
      _list = Specialization.GetSpecializations(connection,trans);
      foreach (var n in _list)
        listBox1.Items.Add(n.Name);
      if (listBox1.Items.Count > 0)
        listBox1.SelectedIndex = 0;
    }
    private void button1_Click(object sender, EventArgs e) {
      int index = listBox1.SelectedIndex;
      if (index == -1) {
        MessageBox.Show("Выберите запись для удаления");
        return;
      }
      DialogResult res = MessageBox.Show("Запись будет удалена?", "Каскадное удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
      if (res == DialogResult.Yes) {
        
          var cmd = connection.CreateCommand();
                cmd.Transaction = trans;
          cmd.CommandText = $@"delete from Appointments  
                              where Doctor in 
                              (select Id from doctors  
                              where Specialization=
                              {_list[index].Id})";
          cmd.ExecuteNonQuery();
          cmd.CommandText = $@"delete from Doctors where Specialization={_list[index].Id}";
          cmd.ExecuteNonQuery();
          cmd.CommandText = $"delete from specializations where Id={_list[index].Id}";
          cmd.ExecuteNonQuery();

        
        GetListBox();
        MessageBox.Show("Запись была удалена каскадно");
      }
    }

    private void btnLast_Click(object sender, EventArgs e) {
      listBox1.SelectedIndex = listBox1.Items.Count - 1;
    }

    private void btnRight_Click(object sender, EventArgs e) {
      listBox1.SelectedIndex++;

    }

    private void btnView_Click(object sender, EventArgs e) {

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

    private void cascadeDeleteForm_Load(object sender, EventArgs e) {
      GetListBox();
    }

        private void button2_Click(object sender, EventArgs e)
        {
            var diag = MessageBox.Show("Восстановить запись?", "Восстановление", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (diag == DialogResult.Yes)
            {

                trans.Rollback("point");

                trans.Save("point");

                GetListBox();
                MessageBox.Show("Записи были восстановлены");
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            var diag = MessageBox.Show("Закрыть форму? Восстановить удаленные записи будет невозможно", "Закрытие", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (diag == DialogResult.Yes) { trans.Commit();connection.Close();connection.Dispose(); this.Close(); }

        }
    }
}
