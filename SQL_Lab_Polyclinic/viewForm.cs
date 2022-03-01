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
  public partial class viewForm : Form {
    DateTime minDate;
    DateTime maxDate;
    public viewForm() {
      InitializeComponent();
    }

    private void button2_Click(object sender, EventArgs e) {
      using (var conn = new SqlConnection(Properties.Resources.ConnectionString)) {
        conn.Open();
        var cmd = conn.CreateCommand();
        cmd.CommandText = "select min([Date]) from appointments";
        var reader = cmd.ExecuteReader();
        if (reader.Read())
          minDate = reader.IsDBNull(0) ? DateTime.Today : reader.GetDateTime(0);
        reader.Close();
        cmd.CommandText = "select max([Date]) from appointments";
        reader = cmd.ExecuteReader();
        if (reader.Read())
          maxDate = reader.IsDBNull(0) ? DateTime.Today : reader.GetDateTime(0);
      }
      comboBox1.SelectedIndex = -1;
      comboBox2.SelectedIndex = -1;
      comboBox3.SelectedIndex = -1;
      comboBox4.SelectedIndex = -1;
      radioButton1.Checked = false;
      radioButton2.Checked = false;
      radioButton3.Checked = false;
      dateTimePicker1.Value = minDate;
      dateTimePicker2.Value = maxDate;
    }
    void GetDoctors() {
      string sql = "select Id, [FullName] from Doctors where Specialization not in (select Id from Specializations where isDeleted=1)";
      if (comboBox3.SelectedIndex != -1)
        sql += $"and Specialization = {comboBox3.SelectedValue}";
      var dt = new dbManager().GetData(sql);
      comboBox4.DataSource = dt;
      comboBox4.ValueMember = "Id";
      comboBox4.DisplayMember = "FullName";
      comboBox4.SelectedIndex = -1;
    }
    void GetDiseases() {
      string sql = "select Id, [Name] from diseases ";
      if (comboBox1.SelectedIndex != -1)
        sql += $"where Class = {comboBox1.SelectedValue}";
      var dt = new dbManager().GetData(sql);
      comboBox2.DataSource = dt;
      comboBox2.ValueMember = "Id";
      comboBox2.DisplayMember = "Name";
      comboBox2.SelectedIndex = -1;
    }
    private void viewForm_Load(object sender, EventArgs e) {
      using (var conn = new SqlConnection(Properties.Resources.ConnectionString)) {
        conn.Open();
        var cmd = new SqlCommand("select Id,[Name] from Specializations where IsDeleted!=1", conn);
        var dt = new DataTable();
        var adapter = new SqlDataAdapter(cmd);
        adapter.Fill(dt);
        comboBox3.DataSource = dt;
        comboBox3.ValueMember = "Id";
        comboBox3.DisplayMember = "Name";
        cmd.CommandText = "select Id, [Name] from DiseaseClassifications";
        dt = new DataTable();
        adapter = new SqlDataAdapter(cmd);
        adapter.Fill(dt);
        comboBox1.DataSource = dt;
        comboBox1.ValueMember = "Id";
        comboBox1.DisplayMember = "Name";
      }
      comboBox1.SelectedIndexChanged += delegate (object o, EventArgs ea) {
        GetDiseases();
      };
      comboBox3.SelectedIndexChanged += delegate (object o, EventArgs ea) {
        GetDoctors();
      };
      button2_Click(null, null);
      button1_Click(null, null);
    }
    private void button1_Click(object sender, EventArgs e) {
      string sql = $@"select d.Fullname as [Врач], s.[Name] as [Специализация врача], p.Fullname as [Пациент],dc.[Name] as [Тип диагноза],di.[Name] as [Диагноз], a.[Date] as 'Дата приёма' from appointments a join doctors d on d.Id=a.Doctor join patients p on p.Id=a.Patient join Diseases di on di.Id=a.Disease join Specializations s on s.Id=d.Specialization join DiseaseClassifications dc on dc.Id=di.Class where a.[Date] between '{dateTimePicker1.Value}' and '{dateTimePicker2.Value}' and s.IsDeleted<>1 ";
      sql += comboBox1.SelectedIndex == -1 ? "" : $" and dc.Id={comboBox1.SelectedValue} ";
      sql += comboBox2.SelectedIndex == -1 ? "" : $" and di.Id={comboBox2.SelectedValue} ";
      sql += comboBox3.SelectedIndex == -1 ? "" : $" and s.Id={comboBox3.SelectedValue} ";
      sql += comboBox4.SelectedIndex == -1 ? "" : $" and d.Id={comboBox4.SelectedValue} ";
      sql += radioButton1.Checked ? " order by p.Fullname " : radioButton2.Checked ? " order by d.Fullname " : radioButton3.Checked ? " order by di.[Name] " : "";
      var dt = new dbManager().GetData(sql);
      var dt1 = new DataTable();
      dt1.Columns.Add("#");
      for (int i = 0; i < dt.Columns.Count; ++i)
        dt1.Columns.Add(dt.Columns[i].ColumnName);
      int k = 0;
      foreach (DataRow dataRow in dt.Rows) {
        DataRow newRow = dt1.NewRow();
        newRow["#"] = ++k;
        foreach (DataColumn column in dt.Columns) {
          newRow[column.ColumnName] = dataRow[column.ColumnName].ToString();
        }
        dt1.Rows.Add(newRow);
      }
      dataGridView1.DataSource = dt1;
    }

    private void groupBox1_Enter(object sender, EventArgs e) {

    }

        private void button3_Click(object sender, EventArgs e)
        {
            var app = new Microsoft.Office.Interop.Excel.Application
            {
                DisplayAlerts = false
            };
            string path = "template.xlsx";
            var workbook = app.Workbooks.Open(System.IO.Path.
              Combine(Application.StartupPath, path));
            var worksheet = workbook.ActiveSheet as Microsoft.Office.
              Interop.Excel.Worksheet;
            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; ++j)
                {
                    worksheet.Cells[i + 2, j + 1] = dataGridView1[j, i].Value.ToString();
                }
            }
            app.Visible = true;


        }
    }
}
