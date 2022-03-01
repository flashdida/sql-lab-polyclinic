
namespace SQL_Lab_Polyclinic {
  partial class markDeleteForm {
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
      this.btnLast = new System.Windows.Forms.Button();
      this.btnRight = new System.Windows.Forms.Button();
      this.btnLeft = new System.Windows.Forms.Button();
      this.btnFirst = new System.Windows.Forms.Button();
      this.button1 = new System.Windows.Forms.Button();
      this.listBox1 = new System.Windows.Forms.ListBox();
      this.button2 = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // btnLast
      // 
      this.btnLast.Enabled = false;
      this.btnLast.Location = new System.Drawing.Point(476, 301);
      this.btnLast.Name = "btnLast";
      this.btnLast.Size = new System.Drawing.Size(60, 41);
      this.btnLast.TabIndex = 17;
      this.btnLast.Text = ">>";
      this.btnLast.UseVisualStyleBackColor = true;
      this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
      // 
      // btnRight
      // 
      this.btnRight.Enabled = false;
      this.btnRight.Location = new System.Drawing.Point(395, 301);
      this.btnRight.Name = "btnRight";
      this.btnRight.Size = new System.Drawing.Size(60, 41);
      this.btnRight.TabIndex = 16;
      this.btnRight.Text = ">";
      this.btnRight.UseVisualStyleBackColor = true;
      this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
      // 
      // btnLeft
      // 
      this.btnLeft.Enabled = false;
      this.btnLeft.Location = new System.Drawing.Point(307, 301);
      this.btnLeft.Name = "btnLeft";
      this.btnLeft.Size = new System.Drawing.Size(60, 41);
      this.btnLeft.TabIndex = 14;
      this.btnLeft.Text = "<";
      this.btnLeft.UseVisualStyleBackColor = true;
      this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click);
      // 
      // btnFirst
      // 
      this.btnFirst.Enabled = false;
      this.btnFirst.Location = new System.Drawing.Point(222, 301);
      this.btnFirst.Name = "btnFirst";
      this.btnFirst.Size = new System.Drawing.Size(60, 41);
      this.btnFirst.TabIndex = 13;
      this.btnFirst.Text = "<<";
      this.btnFirst.UseVisualStyleBackColor = true;
      this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(23, 29);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(118, 43);
      this.button1.TabIndex = 12;
      this.button1.Text = "Удалить с помощью метки";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // listBox1
      // 
      this.listBox1.FormattingEnabled = true;
      this.listBox1.Location = new System.Drawing.Point(215, 14);
      this.listBox1.Name = "listBox1";
      this.listBox1.Size = new System.Drawing.Size(331, 264);
      this.listBox1.TabIndex = 11;
      this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
      // 
      // button2
      // 
      this.button2.Location = new System.Drawing.Point(23, 180);
      this.button2.Name = "button2";
      this.button2.Size = new System.Drawing.Size(95, 83);
      this.button2.TabIndex = 18;
      this.button2.Text = "Удаленные специализации(Восстановление с меткой)";
      this.button2.UseVisualStyleBackColor = true;
      this.button2.Click += new System.EventHandler(this.button2_Click);
      // 
      // markDeleteForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(568, 361);
      this.Controls.Add(this.button2);
      this.Controls.Add(this.btnLast);
      this.Controls.Add(this.btnRight);
      this.Controls.Add(this.btnLeft);
      this.Controls.Add(this.btnFirst);
      this.Controls.Add(this.button1);
      this.Controls.Add(this.listBox1);
      this.Name = "markDeleteForm";
      this.Text = "markDeleteForm";
      this.Load += new System.EventHandler(this.markDeleteForm_Load);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button btnLast;
    private System.Windows.Forms.Button btnRight;
    private System.Windows.Forms.Button btnLeft;
    private System.Windows.Forms.Button btnFirst;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.ListBox listBox1;
    private System.Windows.Forms.Button button2;
  }
}