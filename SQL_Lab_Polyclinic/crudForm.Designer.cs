
namespace SQL_Lab_Polyclinic {
  partial class crudForm {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      this.listBox1 = new System.Windows.Forms.ListBox();
      this.btnFirst = new System.Windows.Forms.Button();
      this.btnLeft = new System.Windows.Forms.Button();
      this.btnView = new System.Windows.Forms.Button();
      this.btnRight = new System.Windows.Forms.Button();
      this.btnLast = new System.Windows.Forms.Button();
      this.cbDoctor = new System.Windows.Forms.ComboBox();
      this.cbPatient = new System.Windows.Forms.ComboBox();
      this.cbDiagnose = new System.Windows.Forms.ComboBox();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.dtpAppDate = new System.Windows.Forms.DateTimePicker();
      this.label4 = new System.Windows.Forms.Label();
      this.btnAdd = new System.Windows.Forms.Button();
      this.btnEdit = new System.Windows.Forms.Button();
      this.btnDelete = new System.Windows.Forms.Button();
      this.btnSave = new System.Windows.Forms.Button();
      this.btnCancel = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // listBox1
      // 
      this.listBox1.FormattingEnabled = true;
      this.listBox1.Location = new System.Drawing.Point(376, 12);
      this.listBox1.Name = "listBox1";
      this.listBox1.Size = new System.Drawing.Size(324, 329);
      this.listBox1.TabIndex = 0;
      this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
      // 
      // btnFirst
      // 
      this.btnFirst.Enabled = false;
      this.btnFirst.Location = new System.Drawing.Point(376, 359);
      this.btnFirst.Name = "btnFirst";
      this.btnFirst.Size = new System.Drawing.Size(60, 41);
      this.btnFirst.TabIndex = 1;
      this.btnFirst.Text = "<<";
      this.btnFirst.UseVisualStyleBackColor = true;
      this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
      // 
      // btnLeft
      // 
      this.btnLeft.Enabled = false;
      this.btnLeft.Location = new System.Drawing.Point(442, 359);
      this.btnLeft.Name = "btnLeft";
      this.btnLeft.Size = new System.Drawing.Size(60, 41);
      this.btnLeft.TabIndex = 2;
      this.btnLeft.Text = "<";
      this.btnLeft.UseVisualStyleBackColor = true;
      this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click);
      // 
      // btnView
      // 
      this.btnView.Location = new System.Drawing.Point(508, 359);
      this.btnView.Name = "btnView";
      this.btnView.Size = new System.Drawing.Size(60, 41);
      this.btnView.TabIndex = 3;
      this.btnView.Text = "00";
      this.btnView.UseVisualStyleBackColor = true;
      this.btnView.Click += new System.EventHandler(this.btnView_Click);
      // 
      // btnRight
      // 
      this.btnRight.Enabled = false;
      this.btnRight.Location = new System.Drawing.Point(574, 359);
      this.btnRight.Name = "btnRight";
      this.btnRight.Size = new System.Drawing.Size(60, 41);
      this.btnRight.TabIndex = 4;
      this.btnRight.Text = ">";
      this.btnRight.UseVisualStyleBackColor = true;
      this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
      // 
      // btnLast
      // 
      this.btnLast.Enabled = false;
      this.btnLast.Location = new System.Drawing.Point(640, 359);
      this.btnLast.Name = "btnLast";
      this.btnLast.Size = new System.Drawing.Size(60, 41);
      this.btnLast.TabIndex = 5;
      this.btnLast.Text = ">>";
      this.btnLast.UseVisualStyleBackColor = true;
      this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
      // 
      // cbDoctor
      // 
      this.cbDoctor.Enabled = false;
      this.cbDoctor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.cbDoctor.FormattingEnabled = true;
      this.cbDoctor.Location = new System.Drawing.Point(16, 43);
      this.cbDoctor.Name = "cbDoctor";
      this.cbDoctor.Size = new System.Drawing.Size(322, 28);
      this.cbDoctor.TabIndex = 6;
      // 
      // cbPatient
      // 
      this.cbPatient.Enabled = false;
      this.cbPatient.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.cbPatient.FormattingEnabled = true;
      this.cbPatient.Location = new System.Drawing.Point(16, 109);
      this.cbPatient.Name = "cbPatient";
      this.cbPatient.Size = new System.Drawing.Size(322, 28);
      this.cbPatient.TabIndex = 7;
      // 
      // cbDiagnose
      // 
      this.cbDiagnose.Enabled = false;
      this.cbDiagnose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.cbDiagnose.FormattingEnabled = true;
      this.cbDiagnose.Location = new System.Drawing.Point(16, 175);
      this.cbDiagnose.Name = "cbDiagnose";
      this.cbDiagnose.Size = new System.Drawing.Size(322, 28);
      this.cbDiagnose.TabIndex = 8;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.label1.Location = new System.Drawing.Point(12, 20);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(47, 20);
      this.label1.TabIndex = 9;
      this.label1.Text = "Врач";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.label2.Location = new System.Drawing.Point(12, 86);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(75, 20);
      this.label2.TabIndex = 10;
      this.label2.Text = "Пациент";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.label3.Location = new System.Drawing.Point(12, 152);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(72, 20);
      this.label3.TabIndex = 11;
      this.label3.Text = "Диагноз";
      // 
      // dtpAppDate
      // 
      this.dtpAppDate.Enabled = false;
      this.dtpAppDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.dtpAppDate.Location = new System.Drawing.Point(16, 243);
      this.dtpAppDate.Name = "dtpAppDate";
      this.dtpAppDate.Size = new System.Drawing.Size(322, 26);
      this.dtpAppDate.TabIndex = 12;
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.label4.Location = new System.Drawing.Point(12, 220);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(108, 20);
      this.label4.TabIndex = 13;
      this.label4.Text = "Дата приёма";
      // 
      // btnAdd
      // 
      this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.btnAdd.Location = new System.Drawing.Point(19, 308);
      this.btnAdd.Name = "btnAdd";
      this.btnAdd.Size = new System.Drawing.Size(104, 40);
      this.btnAdd.TabIndex = 14;
      this.btnAdd.Text = "Добавить";
      this.btnAdd.UseVisualStyleBackColor = true;
      this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
      // 
      // btnEdit
      // 
      this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.btnEdit.Location = new System.Drawing.Point(141, 308);
      this.btnEdit.Name = "btnEdit";
      this.btnEdit.Size = new System.Drawing.Size(104, 40);
      this.btnEdit.TabIndex = 15;
      this.btnEdit.Text = "Изменить";
      this.btnEdit.UseVisualStyleBackColor = true;
      this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
      // 
      // btnDelete
      // 
      this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.btnDelete.Location = new System.Drawing.Point(260, 308);
      this.btnDelete.Name = "btnDelete";
      this.btnDelete.Size = new System.Drawing.Size(90, 40);
      this.btnDelete.TabIndex = 16;
      this.btnDelete.Text = "Удалить";
      this.btnDelete.UseVisualStyleBackColor = true;
      this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
      // 
      // btnSave
      // 
      this.btnSave.Enabled = false;
      this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.btnSave.Location = new System.Drawing.Point(19, 360);
      this.btnSave.Name = "btnSave";
      this.btnSave.Size = new System.Drawing.Size(104, 40);
      this.btnSave.TabIndex = 17;
      this.btnSave.Text = "Сохранить";
      this.btnSave.UseVisualStyleBackColor = true;
      this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
      // 
      // btnCancel
      // 
      this.btnCancel.Enabled = false;
      this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.btnCancel.Location = new System.Drawing.Point(141, 360);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(104, 40);
      this.btnCancel.TabIndex = 18;
      this.btnCancel.Text = "Отменить";
      this.btnCancel.UseVisualStyleBackColor = true;
      this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
      // 
      // crudForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(712, 414);
      this.Controls.Add(this.btnCancel);
      this.Controls.Add(this.btnSave);
      this.Controls.Add(this.btnDelete);
      this.Controls.Add(this.btnEdit);
      this.Controls.Add(this.btnAdd);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.dtpAppDate);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.cbDiagnose);
      this.Controls.Add(this.cbPatient);
      this.Controls.Add(this.cbDoctor);
      this.Controls.Add(this.btnLast);
      this.Controls.Add(this.btnRight);
      this.Controls.Add(this.btnView);
      this.Controls.Add(this.btnLeft);
      this.Controls.Add(this.btnFirst);
      this.Controls.Add(this.listBox1);
      this.Name = "crudForm";
      this.Text = "crudForm";
      this.Load += new System.EventHandler(this.crudForm_Load);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.ListBox listBox1;
    private System.Windows.Forms.Button btnFirst;
    private System.Windows.Forms.Button btnLeft;
    private System.Windows.Forms.Button btnView;
    private System.Windows.Forms.Button btnRight;
    private System.Windows.Forms.Button btnLast;
    private System.Windows.Forms.ComboBox cbDoctor;
    private System.Windows.Forms.ComboBox cbPatient;
    private System.Windows.Forms.ComboBox cbDiagnose;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.DateTimePicker dtpAppDate;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Button btnAdd;
    private System.Windows.Forms.Button btnEdit;
    private System.Windows.Forms.Button btnDelete;
    private System.Windows.Forms.Button btnSave;
    private System.Windows.Forms.Button btnCancel;
  }
}