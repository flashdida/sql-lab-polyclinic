
namespace SQL_Lab_Polyclinic {
  partial class Form2 {
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
      this.button2 = new System.Windows.Forms.Button();
      this.btnLast = new System.Windows.Forms.Button();
      this.btnRight = new System.Windows.Forms.Button();
      this.btnLeft = new System.Windows.Forms.Button();
      this.btnFirst = new System.Windows.Forms.Button();
      this.listBox1 = new System.Windows.Forms.ListBox();
      this.SuspendLayout();
      // 
      // button2
      // 
      this.button2.Location = new System.Drawing.Point(25, 28);
      this.button2.Name = "button2";
      this.button2.Size = new System.Drawing.Size(118, 43);
      this.button2.TabIndex = 26;
      this.button2.Text = "Восстановить с помощью метки";
      this.button2.UseVisualStyleBackColor = true;
      this.button2.Click += new System.EventHandler(this.button2_Click);
      // 
      // btnLast
      // 
      this.btnLast.Enabled = false;
      this.btnLast.Location = new System.Drawing.Point(441, 306);
      this.btnLast.Name = "btnLast";
      this.btnLast.Size = new System.Drawing.Size(60, 41);
      this.btnLast.TabIndex = 25;
      this.btnLast.Text = ">>";
      this.btnLast.UseVisualStyleBackColor = true;
      this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
      // 
      // btnRight
      // 
      this.btnRight.Enabled = false;
      this.btnRight.Location = new System.Drawing.Point(375, 306);
      this.btnRight.Name = "btnRight";
      this.btnRight.Size = new System.Drawing.Size(60, 41);
      this.btnRight.TabIndex = 24;
      this.btnRight.Text = ">";
      this.btnRight.UseVisualStyleBackColor = true;
      this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
      // 
      // btnLeft
      // 
      this.btnLeft.Enabled = false;
      this.btnLeft.Location = new System.Drawing.Point(288, 306);
      this.btnLeft.Name = "btnLeft";
      this.btnLeft.Size = new System.Drawing.Size(60, 41);
      this.btnLeft.TabIndex = 22;
      this.btnLeft.Text = "<";
      this.btnLeft.UseVisualStyleBackColor = true;
      this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click);
      // 
      // btnFirst
      // 
      this.btnFirst.Enabled = false;
      this.btnFirst.Location = new System.Drawing.Point(222, 306);
      this.btnFirst.Name = "btnFirst";
      this.btnFirst.Size = new System.Drawing.Size(60, 41);
      this.btnFirst.TabIndex = 21;
      this.btnFirst.Text = "<<";
      this.btnFirst.UseVisualStyleBackColor = true;
      this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
      // 
      // listBox1
      // 
      this.listBox1.FormattingEnabled = true;
      this.listBox1.Location = new System.Drawing.Point(215, 19);
      this.listBox1.Name = "listBox1";
      this.listBox1.Size = new System.Drawing.Size(309, 264);
      this.listBox1.TabIndex = 19;
      this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
      // 
      // Form2
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(557, 368);
      this.Controls.Add(this.button2);
      this.Controls.Add(this.btnLast);
      this.Controls.Add(this.btnRight);
      this.Controls.Add(this.btnLeft);
      this.Controls.Add(this.btnFirst);
      this.Controls.Add(this.listBox1);
      this.Name = "Form2";
      this.Text = "Form2";
      this.Load += new System.EventHandler(this.Form2_Load);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.Button btnLast;
    private System.Windows.Forms.Button btnRight;
    private System.Windows.Forms.Button btnLeft;
    private System.Windows.Forms.Button btnFirst;
    private System.Windows.Forms.ListBox listBox1;
  }
}