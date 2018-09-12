using AMCDatabase;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;

namespace UpdateHistoryTestFlags
{
	public class HistoryTestFlagsFixForm : Form
	{
		private HistoryTable _histTable;

		private IContainer components;

		private TextBox partlNumberTB;

		private Button getHistBtn;

		private Button updateBtn;

		private CheckBox ictreqChk;

		private CheckBox regtestChk;

		private CheckBox regburnChk;

		private CheckBox mantestChk;

		private CheckBox manburnChk;

		private CheckBox m_manburnChk;

		private CheckBox m_regtestChk;

		private CheckBox m_mantestChk;

		private CheckBox m_regburnChk;

		private TextBox m_testprogTB;

		private TextBox testprogTB;

		private Label label2;

		private Label label7;

		private Label label8;

		private GroupBox groupBox4;

		private Label label3;

		private Label label4;

		private GroupBox groupBox5;

		private Label label5;

		private GroupBox groupBox1;

		private Label label6;

		private GroupBox groupBox2;

		private MaskedTextBox workCodeMTB;

		private NumericUpDown versionUD;

		private RadioButton wcRB;

		private RadioButton pnRB;

		public HistoryTestFlagsFixForm()
		{
			this.InitializeComponent();
		}

		private void BindControls()
		{
			this.ictreqChk.DataBindings.Add("Checked", this._histTable.GetDataTable(), "ictreq");
			this.regtestChk.DataBindings.Add("Checked", this._histTable.GetDataTable(), "regtest");
			this.regburnChk.DataBindings.Add("Checked", this._histTable.GetDataTable(), "regburn");
			this.mantestChk.DataBindings.Add("Checked", this._histTable.GetDataTable(), "mantest");
			this.manburnChk.DataBindings.Add("Checked", this._histTable.GetDataTable(), "manburn");
			this.m_regtestChk.DataBindings.Add("Checked", this._histTable.GetDataTable(), "m_regtest");
			this.m_regburnChk.DataBindings.Add("Checked", this._histTable.GetDataTable(), "m_regburn");
			this.m_mantestChk.DataBindings.Add("Checked", this._histTable.GetDataTable(), "m_mantest");
			this.m_manburnChk.DataBindings.Add("Checked", this._histTable.GetDataTable(), "m_manburn");
			this.testprogTB.DataBindings.Add("Text", this._histTable.GetDataTable(), "testprog");
			this.m_testprogTB.DataBindings.Add("Text", this._histTable.GetDataTable(), "m_testprog");
		}

		private void ClearBindings()
		{
			foreach (Control control in base.Controls)
			{
				if (control.Name == "partlNumberTB" || control.Name == "versionUD")
				{
					continue;
				}
				if (control is CheckBox)
				{
					((CheckBox)control).Checked = false;
				}
				if (control is TextBox)
				{
					control.Text = "";
				}
				control.DataBindings.Clear();
			}
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			this.ToggleEabledStates(false);
			this.workCodeMTB.Mask = "#####";
			this.wcRB.Checked = true;
		}

		private void getHistBtn_Click(object sender, EventArgs e)
		{
			this.workCodeMTB.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
			bool length = this.workCodeMTB.Text.Length == 0;
			this.workCodeMTB.TextMaskFormat = MaskFormat.IncludeLiterals;
			if (!length)
			{
				Workcode workcode = new Workcode(this.workCodeMTB.Text, false);
				if (workcode.KeyFound())
				{
					this.partlNumberTB.Text = workcode.GetValue(workcode.MODELLCODE);
					string value = workcode.GetValue(workcode.AMPVERSION);
					this.versionUD.Value = Convert.ToDecimal(value);
					this.versionUD.Show();
				}
			}
			this.ClearBindings();
			this.ToggleEabledStates(false);
			string str = this.partlNumberTB.Text.Trim();
			string str1 = this.versionUD.Value.ToString();
			this._histTable = new HistoryTable(str, str1, false);
			if (this._histTable.KeyFound())
			{
				this.BindControls();
				this.ToggleEabledStates(true);
				return;
			}
			string[] strArrays = new string[] { "Partnumber: ", str, " Version: ", str1, " Could not be found in History!" };
			MessageBox.Show(string.Concat(strArrays));
		}

		private void InitializeComponent()
		{
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(HistoryTestFlagsFixForm));
			this.partlNumberTB = new TextBox();
			this.getHistBtn = new Button();
			this.updateBtn = new Button();
			this.ictreqChk = new CheckBox();
			this.regtestChk = new CheckBox();
			this.regburnChk = new CheckBox();
			this.mantestChk = new CheckBox();
			this.manburnChk = new CheckBox();
			this.m_manburnChk = new CheckBox();
			this.m_regtestChk = new CheckBox();
			this.m_mantestChk = new CheckBox();
			this.m_regburnChk = new CheckBox();
			this.m_testprogTB = new TextBox();
			this.testprogTB = new TextBox();
			this.label2 = new Label();
			this.label7 = new Label();
			this.label8 = new Label();
			this.groupBox4 = new GroupBox();
			this.label3 = new Label();
			this.label4 = new Label();
			this.groupBox5 = new GroupBox();
			this.label5 = new Label();
			this.groupBox1 = new GroupBox();
			this.label6 = new Label();
			this.groupBox2 = new GroupBox();
			this.workCodeMTB = new MaskedTextBox();
			this.versionUD = new NumericUpDown();
			this.wcRB = new RadioButton();
			this.pnRB = new RadioButton();
			((ISupportInitialize)this.versionUD).BeginInit();
			base.SuspendLayout();
			this.partlNumberTB.Location = new Point(197, 36);
			this.partlNumberTB.Name = "partlNumberTB";
			this.partlNumberTB.Size = new System.Drawing.Size(129, 20);
			this.partlNumberTB.TabIndex = 1;
			this.getHistBtn.Location = new Point(428, 27);
			this.getHistBtn.Name = "getHistBtn";
			this.getHistBtn.Size = new System.Drawing.Size(75, 23);
			this.getHistBtn.TabIndex = 2;
			this.getHistBtn.Text = "Get";
			this.getHistBtn.UseVisualStyleBackColor = true;
			this.getHistBtn.Click += new EventHandler(this.getHistBtn_Click);
			this.updateBtn.Location = new Point(428, 56);
			this.updateBtn.Name = "updateBtn";
			this.updateBtn.Size = new System.Drawing.Size(75, 23);
			this.updateBtn.TabIndex = 3;
			this.updateBtn.Text = "Update";
			this.updateBtn.UseVisualStyleBackColor = true;
			this.updateBtn.Click += new EventHandler(this.updateBtn_Click);
			this.ictreqChk.AutoSize = true;
			this.ictreqChk.Location = new Point(16, 91);
			this.ictreqChk.Name = "ictreqChk";
			this.ictreqChk.Size = new System.Drawing.Size(88, 17);
			this.ictreqChk.TabIndex = 4;
			this.ictreqChk.Text = "Requires ICT";
			this.ictreqChk.UseVisualStyleBackColor = true;
			this.regtestChk.AutoSize = true;
			this.regtestChk.Location = new Point(12, 139);
			this.regtestChk.Name = "regtestChk";
			this.regtestChk.Size = new System.Drawing.Size(47, 17);
			this.regtestChk.TabIndex = 5;
			this.regtestChk.Text = "Test";
			this.regtestChk.UseVisualStyleBackColor = true;
			this.regburnChk.AutoSize = true;
			this.regburnChk.Location = new Point(204, 139);
			this.regburnChk.Name = "regburnChk";
			this.regburnChk.Size = new System.Drawing.Size(48, 17);
			this.regburnChk.TabIndex = 6;
			this.regburnChk.Text = "Burn";
			this.regburnChk.UseVisualStyleBackColor = true;
			this.mantestChk.AutoSize = true;
			this.mantestChk.Location = new Point(89, 139);
			this.mantestChk.Name = "mantestChk";
			this.mantestChk.Size = new System.Drawing.Size(85, 17);
			this.mantestChk.TabIndex = 7;
			this.mantestChk.Text = "Manual Test";
			this.mantestChk.UseVisualStyleBackColor = true;
			this.manburnChk.AutoSize = true;
			this.manburnChk.Location = new Point(285, 139);
			this.manburnChk.Name = "manburnChk";
			this.manburnChk.Size = new System.Drawing.Size(86, 17);
			this.manburnChk.TabIndex = 8;
			this.manburnChk.Text = "Manual Burn";
			this.manburnChk.UseVisualStyleBackColor = true;
			this.m_manburnChk.AutoSize = true;
			this.m_manburnChk.Location = new Point(285, 219);
			this.m_manburnChk.Name = "m_manburnChk";
			this.m_manburnChk.Size = new System.Drawing.Size(110, 17);
			this.m_manburnChk.TabIndex = 11;
			this.m_manburnChk.Text = "Mod Manual Burn";
			this.m_manburnChk.UseVisualStyleBackColor = true;
			this.m_regtestChk.AutoSize = true;
			this.m_regtestChk.Location = new Point(15, 219);
			this.m_regtestChk.Name = "m_regtestChk";
			this.m_regtestChk.Size = new System.Drawing.Size(71, 17);
			this.m_regtestChk.TabIndex = 12;
			this.m_regtestChk.Text = "Mod Test";
			this.m_regtestChk.UseVisualStyleBackColor = true;
			this.m_mantestChk.AutoSize = true;
			this.m_mantestChk.Location = new Point(89, 219);
			this.m_mantestChk.Name = "m_mantestChk";
			this.m_mantestChk.Size = new System.Drawing.Size(109, 17);
			this.m_mantestChk.TabIndex = 13;
			this.m_mantestChk.Text = "Mod Manual Test";
			this.m_mantestChk.UseVisualStyleBackColor = true;
			this.m_regburnChk.AutoSize = true;
			this.m_regburnChk.Location = new Point(207, 219);
			this.m_regburnChk.Name = "m_regburnChk";
			this.m_regburnChk.Size = new System.Drawing.Size(72, 17);
			this.m_regburnChk.TabIndex = 14;
			this.m_regburnChk.Text = "Mod Burn";
			this.m_regburnChk.UseVisualStyleBackColor = true;
			this.m_testprogTB.Location = new Point(89, 245);
			this.m_testprogTB.Name = "m_testprogTB";
			this.m_testprogTB.Size = new System.Drawing.Size(169, 20);
			this.m_testprogTB.TabIndex = 15;
			this.testprogTB.Location = new Point(89, 164);
			this.testprogTB.Name = "testprogTB";
			this.testprogTB.Size = new System.Drawing.Size(169, 20);
			this.testprogTB.TabIndex = 20;
			this.label2.AutoSize = true;
			this.label2.Location = new Point(10, 168);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(49, 13);
			this.label2.TabIndex = 21;
			this.label2.Text = "Program:";
			this.label7.AutoSize = true;
			this.label7.Location = new Point(17, 249);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(49, 13);
			this.label7.TabIndex = 26;
			this.label7.Text = "Program:";
			this.label8.AutoSize = true;
			this.label8.Location = new Point(332, 40);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(26, 13);
			this.label8.TabIndex = 27;
			this.label8.Text = "Ver:";
			this.groupBox4.Location = new Point(12, 27);
			this.groupBox4.Margin = new System.Windows.Forms.Padding(2);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(400, 2);
			this.groupBox4.TabIndex = 32;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "groupBox4";
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label3.Location = new Point(12, 9);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(56, 13);
			this.label3.TabIndex = 33;
			this.label3.Text = "Part Info";
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label4.Location = new Point(9, 114);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(58, 13);
			this.label4.TabIndex = 35;
			this.label4.Text = "Standard";
			this.groupBox5.Location = new Point(9, 132);
			this.groupBox5.Margin = new System.Windows.Forms.Padding(2);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(400, 2);
			this.groupBox5.TabIndex = 34;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "groupBox5";
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label5.Location = new Point(13, 192);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(82, 13);
			this.label5.TabIndex = 37;
			this.label5.Text = "Modifications";
			this.groupBox1.Location = new Point(13, 210);
			this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(400, 2);
			this.groupBox1.TabIndex = 36;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "groupBox1";
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label6.Location = new Point(13, 66);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(27, 13);
			this.label6.TabIndex = 39;
			this.label6.Text = "ICT";
			this.groupBox2.Location = new Point(13, 84);
			this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(400, 2);
			this.groupBox2.TabIndex = 38;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "groupBox2";
			this.workCodeMTB.Location = new Point(61, 36);
			this.workCodeMTB.Name = "workCodeMTB";
			this.workCodeMTB.Size = new System.Drawing.Size(57, 20);
			this.workCodeMTB.TabIndex = 41;
			this.versionUD.DecimalPlaces = 2;
			NumericUpDown num = this.versionUD;
			int[] numArray = new int[] { 1, 0, 0, 131072 };
			num.Increment = new decimal(numArray);
			this.versionUD.Location = new Point(365, 36);
			NumericUpDown numericUpDown = this.versionUD;
			int[] numArray1 = new int[] { 990, 0, 0, 65536 };
			numericUpDown.Maximum = new decimal(numArray1);
			this.versionUD.Name = "versionUD";
			this.versionUD.Size = new System.Drawing.Size(44, 20);
			this.versionUD.TabIndex = 42;
			this.wcRB.AutoSize = true;
			this.wcRB.Location = new Point(9, 36);
			this.wcRB.Name = "wcRB";
			this.wcRB.Size = new System.Drawing.Size(46, 17);
			this.wcRB.TabIndex = 43;
			this.wcRB.TabStop = true;
			this.wcRB.Text = "WC:";
			this.wcRB.UseVisualStyleBackColor = true;
			this.wcRB.CheckedChanged += new EventHandler(this.wcRB_CheckedChanged);
			this.pnRB.AutoSize = true;
			this.pnRB.Location = new Point(125, 36);
			this.pnRB.Name = "pnRB";
			this.pnRB.Size = new System.Drawing.Size(72, 17);
			this.pnRB.TabIndex = 44;
			this.pnRB.TabStop = true;
			this.pnRB.Text = "Part Num:";
			this.pnRB.UseVisualStyleBackColor = true;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(511, 278);
			base.Controls.Add(this.pnRB);
			base.Controls.Add(this.wcRB);
			base.Controls.Add(this.versionUD);
			base.Controls.Add(this.workCodeMTB);
			base.Controls.Add(this.label6);
			base.Controls.Add(this.groupBox2);
			base.Controls.Add(this.m_regtestChk);
			base.Controls.Add(this.label5);
			base.Controls.Add(this.m_mantestChk);
			base.Controls.Add(this.groupBox1);
			base.Controls.Add(this.m_regburnChk);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.label7);
			base.Controls.Add(this.testprogTB);
			base.Controls.Add(this.m_testprogTB);
			base.Controls.Add(this.m_manburnChk);
			base.Controls.Add(this.label4);
			base.Controls.Add(this.groupBox5);
			base.Controls.Add(this.manburnChk);
			base.Controls.Add(this.mantestChk);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.regtestChk);
			base.Controls.Add(this.regburnChk);
			base.Controls.Add(this.groupBox4);
			base.Controls.Add(this.partlNumberTB);
			base.Controls.Add(this.ictreqChk);
			base.Controls.Add(this.label8);
			base.Controls.Add(this.updateBtn);
			base.Controls.Add(this.getHistBtn);
			base.Icon = (System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "HistoryTestFlagsFixForm";
			this.Text = "Fix History Test Flags";
			base.Load += new EventHandler(this.Form1_Load);
			((ISupportInitialize)this.versionUD).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		private void ToggleEabledStates(bool bEnable)
		{
			this.updateBtn.Enabled = bEnable;
			this.ictreqChk.Enabled = bEnable;
			this.regtestChk.Enabled = bEnable;
			this.regburnChk.Enabled = bEnable;
			this.mantestChk.Enabled = bEnable;
			this.manburnChk.Enabled = bEnable;
			this.m_regtestChk.Enabled = bEnable;
			this.m_regburnChk.Enabled = bEnable;
			this.m_mantestChk.Enabled = bEnable;
			this.m_manburnChk.Enabled = bEnable;
			this.testprogTB.Enabled = bEnable;
			this.m_testprogTB.Enabled = bEnable;
		}

		private void updateBtn_Click(object sender, EventArgs e)
		{
			if (this._histTable == null)
			{
				return;
			}
			if (this._histTable.UpdateTable(string.Concat("and version = \"", this.versionUD.Value.ToString(), "\"")))
			{
				MessageBox.Show("Part Successfully Updated");
				return;
			}
			MessageBox.Show("Error Updating Part!");
		}

		private void wcRB_CheckedChanged(object sender, EventArgs e)
		{
			bool @checked = this.wcRB.Checked;
			this.workCodeMTB.Enabled = @checked;
			this.partlNumberTB.Enabled = !@checked;
		}
	}
}