using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace Bai05
{
    public partial class Form1 : Form
    {
        public static string ConnectionStr = @"Data Source=DESKTOP-U9F0M33;Initial Catalog=LTTQ_BTH4_QLSV;Integrated Security=True;TrustServerCertificate=True";
        public Form1()
        {
            InitializeComponent();
            ShowData();          

        }
        public void ShowData()
        {
            using (SqlConnection conn = new SqlConnection(ConnectionStr))
            {
               conn.Open();
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = System.Data.CommandType.Text;
                sqlCmd.CommandText = "Select * from SinhVien";

                sqlCmd.Connection = conn;
                sqlCmd.Parameters.Clear();

                using (SqlDataReader reader = sqlCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        dataGridView1.Rows.Add(
                          reader.GetInt32(0),
                          reader.GetInt32(1),
                          reader.GetString(2),
                          reader.GetString(3),
                          reader.GetDecimal(4));
                    }
                }
             /*   conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("Select * from SinhVien", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;*/
            }
        }
        private void thêmMớiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2(this);
            form.ShowDialog();
        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            string search = toolStripTextBox1.Text.Trim().ToLower();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;
                string hoten = row.Cells[2].Value.ToString();
                string[] parts = hoten.Trim().Split(' ');
                string ten = parts[parts.Length - 1].Trim().ToLower();
                row.Visible = ten.StartsWith(search);
            }
        }
        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dataGridView1.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }
        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {
            toolStripTextBox1.Clear();
        }
    }
}
   
    

