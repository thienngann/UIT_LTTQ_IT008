using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai05
{
    public partial class Form2 : Form
    {
        private Form1 mainForm;
        public Form2(Form1 form1)
        {
            InitializeComponent();
            this.mainForm = form1;
            //this.Closed += Form2_Closed;
        }

        private void buttonThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxMSSV.Text) || string.IsNullOrEmpty(textBoxTen.Text) || string.IsNullOrEmpty(textBoxDTB.Text) || comboBox1.SelectedIndex == -1) 
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!!!");
                return;
            }
            if (!float.TryParse(textBoxDTB.Text, out float num))
            {
                MessageBox.Show("Điểm trung bình không hợp lệ !!!");
                return;
            }
            if (!textBoxTen.Text.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)))
            {
                MessageBox.Show("Tên sinh viên không hợp lệ !!!");
                return;
            }

            bool TonTai = false;
            foreach (DataGridViewRow r in mainForm.dataGridView1.Rows)
            {
                if (r.IsNewRow) continue;

                if (textBoxMSSV.Text == r.Cells[1].Value.ToString())
                {
                    TonTai = true;
                    break;
                }
            }
            if (TonTai)
                MessageBox.Show("Đã tồn tại mã số sinh viên này!", "Thông báo");
            else
            {
                using (SqlConnection conn = new SqlConnection(Form1.ConnectionStr))
                {
                    conn.Open();
                    SqlCommand sqlCmd = new SqlCommand();
                     sqlCmd.CommandType = System.Data.CommandType.Text;
                     sqlCmd.CommandText = @"Insert into SinhVien(MSSV, TenSV, Khoa, DiemTB) Values (@mssv, @ten, @khoa, @diem)";

                     sqlCmd.Connection = conn;
                     sqlCmd.Parameters.Clear();
                     sqlCmd.Parameters.AddWithValue("@mssv", int.Parse(textBoxMSSV.Text));
                    sqlCmd.Parameters.AddWithValue("@ten", textBoxTen.Text);
                    sqlCmd.Parameters.AddWithValue("@khoa", comboBox1.SelectedItem.ToString());
                    sqlCmd.Parameters.AddWithValue("@diem", float.Parse(textBoxDTB.Text));

                    sqlCmd.ExecuteNonQuery();                    
                }             
               // Form1 form1 = new Form1();
               mainForm.dataGridView1.Rows.Clear();
                mainForm.ShowData();
                textBoxMSSV.Clear();
                textBoxTen.Clear();
                textBoxDTB.Clear();
                comboBox1.SelectedIndex = -1;
                comboBox1.Text = "Chọn tên khoa";
            }        
          
        }

        private void buttonThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
