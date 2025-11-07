using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Bai09
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Text = "Nhập liệu sinh viên";
        }

        private void comboBoxCN_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxCN.SelectedItem == null)
            {
                listBox1.Items.Clear();
                listBox2.Items.Clear();
                return;
            }

            listBox1.Items.Clear();
            listBox2.Items.Clear();
            string item = comboBoxCN.SelectedItem.ToString();                    
           
            switch (item)
            {
                case "Công nghệ thông tin":
                    listBox1.Items.Add("Quản lý dự án công nghệ thông tin");
                    listBox1.Items.Add("Hệ cơ sở dữ liệu không gian");
                    listBox1.Items.Add("Giới thiệu ngành Công nghệ thông tin");
                    break;
                case "Hệ thống thông tin":
                    listBox1.Items.Add("Hệ quản trị cơ sở dữ liệu");
                    listBox1.Items.Add("Cơ sở dữ liệu phân tán");
                    listBox1.Items.Add("Giới thiệu ngành Hệ thống thông tin");
                    break;
                case "Khoa học máy tính":
                    listBox1.Items.Add("Toán cho KHMT");
                    listBox1.Items.Add("Máy học trong xử lý ngôn ngữ tự nhiên");
                    listBox1.Items.Add("Giới thiệu ngành Khoa học Máy tính");
                    break;
                case "Kỹ thuật phần mềm":
                    listBox1.Items.Add("Thiết kế game");
                    listBox1.Items.Add("Công nghệ Web và ứng dụng");
                    listBox1.Items.Add("Giới thiệu ngành Kỹ thuật phần mềm");
                    break;
                case "Kỹ thuật máy tính":
                    listBox1.Items.Add("Kỹ thuật hệ thống máy tính");
                    listBox1.Items.Add("Điều khiển thông minh cho robot");
                    listBox1.Items.Add("Giới thiệu ngành Kỹ thuật máy tính");
                    break;
                case "Mạng máy tính & Truyền thông dữ liệu":
                    listBox1.Items.Add("Mạng không dây thế hệ mới");
                    listBox1.Items.Add("Công nghệ truyền thông đa phương tiện");
                    listBox1.Items.Add("Giới thiệu ngành Mạng máy tính & Truyền thông dữ liệu");
                    break;
                case "An toàn thông tin":
                    listBox1.Items.Add("Tấn công mạng");
                    listBox1.Items.Add("An toàn mạng máy tính nâng cao");
                    listBox1.Items.Add("Giới thiệu ngành An toàn thông tin");
                    break;
                case "Thương mại điện tử":
                    listBox1.Items.Add("Quản trị tài chính doanh nghiệp");
                    listBox1.Items.Add("Tối ưu hóa công cụ tìm kiếm trong TMĐT");
                    listBox1.Items.Add("Giới thiệu ngành Thương mại điện tử");
                    break;
                case "Khoa học dữ liệu":
                    listBox1.Items.Add("Tư duy tính toán cho Khoa học dữ liệu");
                    listBox1.Items.Add("Phân tích dữ liệu lớn");
                    listBox1.Items.Add("Giới thiệu ngành Khoa học dữ liệu");
                    break;
                case "Trí tuệ nhân tạo":
                    listBox1.Items.Add("Tư duy Trí tuệ nhân tạo");
                    listBox1.Items.Add("Trí tuệ nhân tạo nâng cao");
                    listBox1.Items.Add("Giới thiệu ngành Trí tuệ nhân tạo");
                    break;
                case "Thiết kế vi mạch":
                    listBox1.Items.Add("Các thiết bị và mạch điện tử");
                    listBox1.Items.Add("Tự động hóa thiết kế vi mạch");
                    listBox1.Items.Add("Giới thiệu ngành Thiết kế vi mạch");
                    break;
                case "Truyền thông đa phương tiện":
                    listBox1.Items.Add("Lý luận truyền thông đại chúng");
                    listBox1.Items.Add("Học máy ứng dụng trong TTĐPT");
                    listBox1.Items.Add("Giới thiệu ngành Truyền thông đa phương tiện");
                    break;
                default:
                    listBox1.Items.Add("null");
                    break;
            }
        }

        private void buttonRight_Click(object sender, EventArgs e)
        {
            List<Object> MonDuocChon = new List<Object>();
            foreach(var item in listBox1.SelectedItems)
                MonDuocChon.Add(item);
            if (MonDuocChon.Count <= 0)
                MessageBox.Show("Chưa chọn môn học nào để thêm vào");
            else
            {
                foreach (var item in MonDuocChon)
                {
                    listBox2.Items.Add(item);
                    listBox1.Items.Remove(item);
                }
            }                        
        }

        private void buttonLeft_Click(object sender, EventArgs e)
        {
            List<Object> MonBoChon = new List<Object>();
            foreach (var item in listBox2.SelectedItems)
                MonBoChon.Add(item);
            if (MonBoChon.Count <= 0)
                MessageBox.Show("Chưa chọn môn học nào để bỏ chọn");
            else
            {
                foreach (var item in MonBoChon)
                {
                    listBox1.Items.Add(item);
                    listBox2.Items.Remove(item);
                }
            }                
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxHoTen.Text) ||
                string.IsNullOrWhiteSpace(textBoxMaSinhVien.Text) ||
                comboBoxCN.SelectedItem == null ||
                (!radioButtonNam.Checked && !radioButtonNu.Checked) ||
                 listBox2.Items.Count == 0)
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
            else
            {
                bool TonTai = false;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.IsNewRow) continue;

                    if (textBoxMaSinhVien.Text == row.Cells[0].Value.ToString())
                    {
                        TonTai = true;
                        break;
                    }
                }               
                if (TonTai)
                    MessageBox.Show("Đã tồn tại mã số sinh viên này!", "Thông báo");
                else
                {
                    int RowIndex = dataGridView1.Rows.Add();
                    dataGridView1.Rows[RowIndex].Cells[0].Value = textBoxMaSinhVien.Text;
                    dataGridView1.Rows[RowIndex].Cells[1].Value = textBoxHoTen.Text;
                    dataGridView1.Rows[RowIndex].Cells[2].Value = comboBoxCN.SelectedItem.ToString();
                    dataGridView1.Rows[RowIndex].Cells[3].Value = (radioButtonNam.Checked ? "Nam" : "Nữ");
                    dataGridView1.Rows[RowIndex].Cells[4].Value = listBox2.Items.Count.ToString();
                    MessageBox.Show("Thêm sinh viên mới thành công", "Thông báo");

                    textBoxHoTen.Clear();
                    textBoxMaSinhVien.Clear();
                    comboBoxCN.SelectedIndex = -1;
                    comboBoxCN.Text = "Chọn chuyên ngành";
                    radioButtonNam.Checked = false;
                    radioButtonNu.Checked = false;
                    if (comboBoxCN.SelectedIndex == 0)
                    {
                        listBox1.Items.Clear();
                        listBox2.Items.Clear();
                    }
                }               
            }                 
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxMaSinhVien.Text))
                MessageBox.Show("Vui lòng nhập mã số sinh viên cần xóa");
            else
            {
                bool TonTai = false;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.IsNewRow) continue;

                    if (textBoxMaSinhVien.Text == row.Cells[0].Value.ToString())
                    {
                        TonTai = true;
                        dataGridView1.Rows.Remove(row);                       
                        break;
                    }
                }
                if (!TonTai)
                    MessageBox.Show("Không tồn tại mã số sinh viên này!", "Thông báo");
                else
                {
                    MessageBox.Show("Đã xóa sinh viên thành công", "Thông báo");
                    textBoxHoTen.Clear();
                    textBoxMaSinhVien.Clear();
                    comboBoxCN.SelectedIndex = -1;
                    comboBoxCN.Text = "Chọn chuyên ngành";
                    radioButtonNam.Checked = false;
                    radioButtonNu.Checked = false;
                    if (comboBoxCN.SelectedIndex == 0)
                    {
                        listBox1.Items.Clear();
                        listBox2.Items.Clear();

                    }
                }
            }
        }
    }
}
