using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Bai06
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            toolTip1.SetToolTip(textBoxSource, "Đường dẫn file nguồn");
            toolTip1.SetToolTip(textBoxDes, "Đường dẫn thư mục đích");
            toolTip1.SetToolTip(buttonSource, "Chọn file nguồn");
            toolTip1.SetToolTip(buttonDes, "Chọn thư mục đích");
            toolTip1.SetToolTip(progressBar, "Tiến trình sao chép");

            toolStripStatusLabel1.Text = "Đang sao chép: ";
            statusStrip1.ShowItemToolTips = true;
            toolStripStatusLabel1.ToolTipText = "Hiển thị trạng thái hiện tại";           
        }

        private void buttonSource_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxSource.Text = openFileDialog.FileName;
            }    
        }

        private void buttonDes_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                textBoxDes.Text = dialog.SelectedPath;
            }    
        }

        private void buttonSaoChep_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxDes.Text) || string.IsNullOrEmpty(textBoxSource.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                return;
            }
            string destFile = Path.Combine(textBoxDes.Text, Path.GetFileName(textBoxSource.Text));
            int percent = 0;
            using (FileStream source = new FileStream(textBoxSource.Text, FileMode.Open, FileAccess.Read))
            using (FileStream des = new FileStream (destFile, FileMode.Create, FileAccess.Write))
            {
                byte[] buffer = new byte[4096];
                long totalBytes = source.Length;
                long bytesCopied = 0;
                int bytesRead;

                progressBar.Minimum = 0;
                progressBar.Maximum = 100;
                progressBar.Value = 0;
                
                while ((bytesRead = source.Read(buffer, 0, buffer.Length))>0)
                {
                    des.Write(buffer, 0, bytesRead);
                    bytesCopied += bytesRead;

                    percent = (int) (bytesCopied *100 / totalBytes);
                    progressBar.Value = percent;
                    progressBar.Refresh();
                    
                    toolStripStatusLabel1.ToolTipText = $"Đang sao chép: {Path.GetFileName(textBoxSource.Text)}";
                }                
            }
            toolStripStatusLabel1.Text = "Hoàn tất";
            MessageBox.Show("Đã sao chép xong");
        }

        
    }
}
