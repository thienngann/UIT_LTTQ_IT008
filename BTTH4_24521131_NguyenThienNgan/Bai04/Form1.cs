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
        private Font currentTypingFont = null;

        public Form1()
        {
            InitializeComponent();
            foreach (var font in FontFamily.Families)
                toolStripComboBoxFont.Items.Add(font.Name);

            toolStripComboBoxFont.SelectedIndex = 353;
            toolStripComboBoxSize.SelectedIndex = 5;

            currentTypingFont = new Font("Tahoma", 14, FontStyle.Regular);
            richTextBox1.Font = currentTypingFont;
        }

        private void toolStripButtonBold_Click(object sender, EventArgs e)
        {
            ToggleStyle(FontStyle.Bold);
            UpdateStyleButtons();
        }

        private void toolStripButtonItalic_Click(object sender, EventArgs e)
        {
            ToggleStyle(FontStyle.Italic);
            UpdateStyleButtons();
        }

        private void toolStripButtonUnderline_Click(object sender, EventArgs e)
        {
            ToggleStyle(FontStyle.Underline);
            UpdateStyleButtons();
        }

        private void ToggleStyle(FontStyle style)
        {
            Font selFont = richTextBox1.SelectionFont ?? currentTypingFont ?? richTextBox1.Font;

            FontStyle newStyle = selFont.Style.HasFlag(style)
                ? selFont.Style & ~style
                : selFont.Style | style;

            Font newFont = new Font(selFont.FontFamily, selFont.Size, newStyle);

            richTextBox1.SelectionFont = newFont;
            currentTypingFont = newFont;
        }

        private void UpdateStyleButtons()
        {
            var font = richTextBox1.SelectionFont;

            if (font == null)
            {
                toolStripButtonBold.BackColor = SystemColors.Control;
                toolStripButtonItalic.BackColor = SystemColors.Control;
                toolStripButtonUnderline.BackColor = SystemColors.Control;
                return;
            }

            toolStripButtonBold.BackColor = font.Bold ? SystemColors.ActiveBorder : SystemColors.Control;
            toolStripButtonItalic.BackColor = font.Italic ? SystemColors.ActiveBorder : SystemColors.Control;
            toolStripButtonUnderline.BackColor = font.Underline ? SystemColors.ActiveBorder : SystemColors.Control;
        }

        private void địnhDạngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                Font newFont = new Font(fd.Font.FontFamily, fd.Font.Size, fd.Font.Style);
                currentTypingFont = newFont;

                if (richTextBox1.SelectionLength > 0)
                    richTextBox1.SelectionFont = newFont;
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

        private void toolStripComboBoxSize_TextChanged(object sender, EventArgs e)
        {
            if (float.TryParse(toolStripComboBoxSize.Text, out float temp) || toolStripComboBoxSize.Text == "")
                ApplyFont();
            else
                MessageBox.Show("Size chữ không hợp lệ!!!");
        }

        private void ApplyFont()
        {
            if (string.IsNullOrEmpty(toolStripComboBoxFont.Text)
                || string.IsNullOrEmpty(toolStripComboBoxSize.Text))
                return;

            if (!float.TryParse(toolStripComboBoxSize.Text, out float size))
                return;

            FontStyle style = richTextBox1.SelectionFont?.Style
                              ?? currentTypingFont?.Style
                              ?? FontStyle.Regular;

            Font newFont = new Font(toolStripComboBoxFont.Text, size, style);

            currentTypingFont = newFont;

            richTextBox1.SelectionFont = newFont;
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

            currentTypingFont = new Font(
                toolStripComboBoxFont.SelectedItem.ToString(),
                float.Parse(toolStripComboBoxSize.SelectedItem.ToString()),
                FontStyle.Regular
            );

            richTextBox1.SelectionFont = currentTypingFont;
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
                                richTextBox1.Text = sr.ReadToEnd();
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

            if (selFont == null)
            {
                toolStripComboBoxFont.SelectedIndex = -1;
                toolStripComboBoxFont.Text = "";
                toolStripComboBoxSize.SelectedIndex = -1;
                toolStripComboBoxSize.Text = "";
                return;
            }

            toolStripComboBoxFont.Text = selFont.FontFamily.Name;
            toolStripComboBoxSize.Text = ((int)selFont.Size).ToString();

            toolStripButtonBold.BackColor = selFont.Bold ? SystemColors.ActiveBorder : SystemColors.Control;
            toolStripButtonItalic.BackColor = selFont.Italic ? SystemColors.ActiveBorder : SystemColors.Control;
            toolStripButtonUnderline.BackColor = selFont.Underline ? SystemColors.ActiveBorder : SystemColors.Control;

            currentTypingFont = selFont;
        }
    }
}
