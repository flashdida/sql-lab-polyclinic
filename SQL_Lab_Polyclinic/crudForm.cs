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
  public partial class crudForm : Form {
    bool _add, _edit;
    dbManager _dbManager;
    List<Appointment> _list;
    public crudForm() {
      InitializeComponent();
      _dbManager = new dbManager();
    }

    void FillListBox() {
      listBox1.Items.Clear();
      _list = dbManager.GetAppointments();
      int count = _list.Count;
      foreach (var n in _list)
        listBox1.Items.Add(n.Representation);
      if (count > 0)
        listBox1.SelectedIndex = 0;
    }
    private void crudForm_Load(object sender, EventArgs e) {
      fillComboBox();
      FillListBox();
    }
    void fillComboBox() {
      var dt = _dbManager.GetData("select Id, FullName from Doctors where Specialization not in (select Id from specializations where IsDeleted=1)");
      cbDoctor.DataSource = dt;
      cbDoctor.ValueMember = "Id";
      cbDoctor.DisplayMember = "FullName";
      dt = _dbManager.GetData("select Id, [Name] from diseases");
      cbDiagnose.DataSource = dt;
      cbDiagnose.ValueMember = "Id";
      cbDiagnose.DisplayMember = "Name";
      dt = _dbManager.GetData("select Id, FullName from Patients");
      cbPatient.DataSource = dt;
      cbPatient.ValueMember = "Id";
      cbPatient.DisplayMember = "FullName";
    }

    private void btnSave_Click(object sender, EventArgs e) {
      Appointment app = new Appointment() {
        Doctor = Convert.ToInt32(cbDoctor.SelectedValue),
        Patient = Convert.ToInt32(cbPatient.SelectedValue),
        Disease = Convert.ToInt32(cbDiagnose.SelectedValue),
        Date = dtpAppDate.Value
      };
      if (cbDoctor.SelectedIndex == -1 || cbPatient.SelectedIndex == -1 || cbDiagnose.SelectedIndex == -1) {
        MessageBox.Show("Заполните все поля");
        return;
      }
      int index = listBox1.SelectedIndex;
      bool res = false;
      string result = "";
      if (_add) {
        res = _dbManager.InsertAppointment(app, out result);
      } else if (_edit) {
        app.Id = _list[index].Id;
        res = _dbManager.UpdateAppointment(app, out result);
      }
      if (!res) {
        MessageBox.Show(result);
        return;
      }
      btnAdd.Enabled = true;
      btnEdit.Enabled = true;
      btnDelete.Enabled = true;
      btnFirst.Enabled = true;
      btnLeft.Enabled = true;
      btnView.Enabled = true;
      btnRight.Enabled = true;
      btnLast.Enabled = true;
      listBox1.Enabled = true;
      btnSave.Enabled = false;
      btnCancel.Enabled = false;
      cbDoctor.Enabled = false;
      cbPatient.Enabled = false;
      cbDiagnose.Enabled = false;
      dtpAppDate.Enabled = false;
      FillListBox();
      //if (_edit)
      //  listBox1.SelectedIndex = index;
      _add = false;
      _edit = false;
      MessageBox.Show(result);
    }
    void resetCbox() {
      cbDoctor.SelectedIndex = -1;
      cbDiagnose.SelectedIndex = -1;
      cbPatient.SelectedIndex = -1;
    }
    private void btnDelete_Click(object sender, EventArgs e) {
      int index = listBox1.SelectedIndex;
      if (index == -1) {
        MessageBox.Show("Ошибка. Выберите запись для удаления");
        return;
      }
      string res = "";
      var diag = MessageBox.Show("Вы точно хотите удалить запись?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
      if (diag == DialogResult.Yes) {
        bool result = _dbManager.DeleteAppointment(_list[index].Id, out res);
        FillListBox();
        MessageBox.Show(res);
      }
    }

    private void btnAdd_Click(object sender, EventArgs e) {
      _add = true;
      resetCbox();
      btnAdd.Enabled = false;
      btnEdit.Enabled = false;
      btnDelete.Enabled = false;
      btnFirst.Enabled = false;
      btnLeft.Enabled = false;
      btnView.Enabled = false;
      btnRight.Enabled = false;
      btnLast.Enabled = false;
      listBox1.Enabled = false;
      btnSave.Enabled = true;
      btnCancel.Enabled = true;
      cbDoctor.Enabled = true;
      cbPatient.Enabled = true;
      cbDiagnose.Enabled = true;
      dtpAppDate.Enabled = true;
    }
    private void btnEdit_Click(object sender, EventArgs e) {
      if (listBox1.SelectedIndex == -1) {
        MessageBox.Show("Выберите запись для изменения");
        return;
      }
      _edit = true;
      btnAdd.Enabled = false;
      btnEdit.Enabled = false;
      btnDelete.Enabled = false;
      btnFirst.Enabled = false;
      btnLeft.Enabled = false;
      btnView.Enabled = false;
      btnRight.Enabled = false;
      btnLast.Enabled = false;
      listBox1.Enabled = false;
      btnSave.Enabled = true;
      btnCancel.Enabled = true;
      cbDoctor.Enabled = true;
      cbPatient.Enabled = true;
      cbDiagnose.Enabled = true;
      dtpAppDate.Enabled = true;
    }

    private void btnCancel_Click(object sender, EventArgs e) {
      _add = false;
      _edit = false;
      int index = listBox1.SelectedIndex;
      btnAdd.Enabled = true;
      btnEdit.Enabled = true;
      btnDelete.Enabled = true;
      btnFirst.Enabled = true;
      btnLeft.Enabled = true;
      btnView.Enabled = true;
      btnRight.Enabled = true;
      btnLast.Enabled = true;
      listBox1.Enabled = true;
      btnSave.Enabled = false;
      btnCancel.Enabled = false;
      cbDoctor.Enabled = false;
      cbPatient.Enabled = false;
      cbDiagnose.Enabled = false;
      dtpAppDate.Enabled = false;
      FillListBox();
      listBox1.SelectedIndex = index;
    }

    private void btnLast_Click(object sender, EventArgs e) {
      listBox1.SelectedIndex = listBox1.Items.Count - 1;
    }

    private void btnRight_Click(object sender, EventArgs e) {
      listBox1.SelectedIndex++;
    }

    private void btnView_Click(object sender, EventArgs e) {
      var f = new viewForm();
      f.ShowDialog();
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
        cbDoctor.SelectedValue = _list[index].Doctor;
        cbPatient.SelectedValue = _list[index].Patient;
        cbDiagnose.SelectedValue = _list[index].Disease;
        dtpAppDate.Value = _list[index].Date;
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
