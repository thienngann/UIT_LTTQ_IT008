using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Bai04
{
    public partial class Form1 : Form
    {
        private string currentFilePath = null;
        private FontFamily font = null;
        private float size;
        private FontStyle style = FontStyle.Regular;
        public Form1()
        {
            InitializeComponent();
            foreach(var font in FontFamily.Families)
                toolStripComboBoxFont.Items.Add(font.Name);

            toolStripComboBoxFont.SelectedIndex = 353;
            font = new FontFamily(toolStripComboBoxFont.SelectedItem.ToString());
         
            toolStripComboBoxSize.SelectedIndex = 5;
            size = float.Parse(toolStripComboBoxSize.SelectedItem as string);
        }

        private void toolStripButtonBold_Click(object sender, EventArgs e)
        {
            Font old = richTextBox1.SelectionFont;
            FontStyle oldStyle = old.Style;
            if (oldStyle.HasFlag(FontStyle.Bold))
                toolStripButtonBold.BackColor = SystemColors.Control;
            else
                toolStripButtonBold.BackColor = SystemColors.ActiveBorder;
            richTextBox1.SelectionFont = new Font (old, old.Style ^ FontStyle.Bold);
        }

        private void toolStripButtonItalic_Click(object sender, EventArgs e)
        {
            Font old = richTextBox1.SelectionFont;
            FontStyle oldStyle = old.Style;
            if (oldStyle.HasFlag(FontStyle.Italic))
                toolStripButtonItalic.BackColor = SystemColors.Control;
            else
                toolStripButtonItalic.BackColor = SystemColors.ActiveBorder;
            richTextBox1.SelectionFont = new Font(old, old.Style ^ FontStyle.Italic);
        }

        private void toolStripButtonUnderline_Click(object sender, EventArgs e)
        {
            Font old = richTextBox1.SelectionFont;
            FontStyle oldStyle = old.Style;
            if (oldStyle.HasFlag(FontStyle.Underline))
                toolStripButtonUnderline.BackColor = SystemColors.Control;
            else
                toolStripButtonUnderline.BackColor = SystemColors.ActiveBorder;
            richTextBox1.SelectionFont = new Font(old, old.Style ^ FontStyle.Underline);
        }

        private void địnhDạngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                if (fontDialog1.Font.Style.HasFlag(FontStyle.Bold))
                    toolStripButtonBold.BackColor = SystemColors.ActiveBorder;
                else
                    toolStripButtonBold.BackColor = SystemColors.Control;
                if (fontDialog1.Font.Style.HasFlag(FontStyle.Italic))
                    toolStripButtonItalic.BackColor = SystemColors.ActiveBorder;
                else
                    toolStripButtonItalic.BackColor = SystemColors.Control;
                toolStripButtonUnderline.BackColor= SystemColors.Control;
                int index_f = Array.FindIndex(FontFamily.Families, f => f.Name.Equals(fontDialog1.Font.Name, StringComparison.OrdinalIgnoreCase));
                toolStripComboBoxFont.SelectedIndex = index_f;

                float selectedSize = fontDialog1.Font.Size;              
              
                for (int i = 0; i < toolStripComboBoxSize.Items.Count; i++)
                {
                    if (float.TryParse(toolStripComboBoxSize.Items[i].ToString(), out float size))
                    {                       
                        if (Math.Abs(size - selectedSize) < 0.9f) // So sánh gần đúng
                        {
                           toolStripComboBoxSize.SelectedIndex = i;
                            break; // thoát vòng lặp khi tìm thấy
                        }
                    }                    
                }
                richTextBox1.SelectionFont = fontDialog1.Font;
            }

        }
        private void toolStripComboBoxFont_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFont();
        }

        private void toolStripComboBoxSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFont();
        }

        void ApplyFont()
        {
            
            if (toolStripComboBoxFont.SelectedItem == null || toolStripComboBoxSize.SelectedItem == null)
                return;
            if (toolStripComboBoxFont.Text == "" || toolStripComboBoxSize.Text == "") return;

            //MessageBox.Show("hii");
            FontFamily newFont = new FontFamily(toolStripComboBoxFont.SelectedItem.ToString());
            float newSize = float.Parse(toolStripComboBoxSize.SelectedItem.ToString());

            FontStyle currentStyle = richTextBox1.SelectionFont?.Style ?? FontStyle.Regular;

            richTextBox1.SelectionFont = new Font(newFont, newSize, currentStyle);
        }

        private void toolStripComboBoxSize_TextChanged(object sender, EventArgs e)
        {
          
            if (float.TryParse(toolStripComboBoxSize.Text, out float temp) || toolStripComboBoxSize.Text == "")
            {
                ApplyFont();
            }
            else
                MessageBox.Show("Size chữ không hợp lệ!!!");
        }

        private void tạoVănBảnMớiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            toolStripComboBoxFont.SelectedIndex = 353;
            toolStripComboBoxSize.SelectedIndex = 5;
            toolStripButtonBold.BackColor = SystemColors.Control;
            toolStripButtonItalic.BackColor = SystemColors.Control;
            toolStripButtonUnderline.BackColor = SystemColors.Control;

            currentFilePath = null;            
            font = new FontFamily(toolStripComboBoxFont.SelectedItem.ToString());                 
            size = float.Parse(toolStripComboBoxSize.SelectedItem as string);            
            style = FontStyle.Regular;


            richTextBox1.SelectionFont = new Font(font, size, style);
        }

        private void mởTậpTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Text File | *.txt; *.rtf";
                openFileDialog.Title = "Mở văn bản";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filepath = openFileDialog.FileName;
                    try
                    {
                        if (filepath.EndsWith(".rtf", StringComparison.OrdinalIgnoreCase))
                            richTextBox1.LoadFile(filepath, RichTextBoxStreamType.RichText);
                        else
                        {
                            using (var sr = new StreamReader(filepath, Encoding.UTF8))
                            {
                                richTextBox1.Text = sr.ReadToEnd();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi mở file: " + ex.Message);
                    }
                }
            }                 
        }

        private void lưuNộiDungVănBảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(currentFilePath))
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Rich Text File (*.rtf) | *.rtf";
                    saveFileDialog.Title = "Lưu văn bản";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            richTextBox1.SaveFile(saveFileDialog.FileName, RichTextBoxStreamType.RichText);
                            currentFilePath = saveFileDialog.FileName;
                            MessageBox.Show("Lưu file thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi khi lưu file: " + ex.Message);
                        }
                    }    
                }                     
            }
            else
            {
                richTextBox1.SaveFile(currentFilePath, RichTextBoxStreamType.RichText);
                MessageBox.Show("Lưu file thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }           
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }       

        private void SelectionChange(object sender, EventArgs e)
        {         

            Font selFont = richTextBox1.SelectionFont;

            if (selFont != null)
            {
                style = selFont.Style;
                size = selFont.Size;
                font = selFont.FontFamily;               

                toolStripComboBoxFont.Text = font.Name;
                toolStripComboBoxSize.Text = size.ToString();
            }
            else
            {               
                toolStripComboBoxFont.Text = "";
                 toolStripComboBoxSize.Text = "";
            }

            if (richTextBox1.SelectionFont.Style.HasFlag(FontStyle.Bold))
            {
                toolStripButtonBold.BackColor = SystemColors.ActiveBorder;
            }    
            else
                toolStripButtonBold.BackColor = SystemColors.Control;

            if (richTextBox1.SelectionFont.Style.HasFlag(FontStyle.Italic))
            {              
                toolStripButtonItalic.BackColor = SystemColors.ActiveBorder;
            }
            else
                toolStripButtonItalic.BackColor = SystemColors.Control;

            if (richTextBox1.SelectionFont.Style.HasFlag(FontStyle.Underline))
            {               
                toolStripButtonUnderline.BackColor = SystemColors.ActiveBorder;
            }
            else
                toolStripButtonUnderline.BackColor = SystemColors.Control;

              
        }       
    }
}
