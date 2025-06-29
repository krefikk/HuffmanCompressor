using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;



namespace HuffmanCompressor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void compressFileChooseButton_Click(object sender, EventArgs e)
        {
            if (openCompressFileDialog.ShowDialog() == DialogResult.OK)
            {
                string file = openCompressFileDialog.FileName;
                compressFileTextBox.Text = file;
                logBox.Text += "Choosed to compress: " + file + Environment.NewLine;
            }
            else
            {
                MessageBox.Show("Invalid file.");
            }
        }

        private void compressFileButton_Click(object sender, EventArgs e)
        {
            if (compressFileTextBox.Text == "")
            {
                MessageBox.Show("You must choose a file to compress!");
                return;
            }

            string log = HuffmanMethods.CompressFileWrapper(compressFileTextBox.Text);
            if (log.StartsWith("Error"))
            {
                MessageBox.Show(log);
                return;
            }

            logBox.Text += log;
        }

        private void decompressFileChooseButton_Click(object sender, EventArgs e)
        {
            if (openDecompressFileDialog.ShowDialog() == DialogResult.OK)
            {
                string file = openDecompressFileDialog.FileName;
                decompressFileTextBox.Text = file;
                logBox.Text += "Choosed to decompress: " + file + Environment.NewLine;
            }
            else
            {
                MessageBox.Show("Invalid file.");
            }
        }

        private void keyFileChooseButton_Click(object sender, EventArgs e)
        {
            if (openKeyFileDialog.ShowDialog() == DialogResult.OK)
            {
                string file = openKeyFileDialog.FileName;
                keyFileTextBox.Text = file;
                logBox.Text += "Choosed as key file: " + file + Environment.NewLine;
            }
            else
            {
                MessageBox.Show("Invalid file.");
            }
        }

        private void decompressFileButton_Click(object sender, EventArgs e)
        {
            if (decompressFileTextBox.Text == "")
            {
                MessageBox.Show("You must choose a file to decompress!");
                return;
            }
            if (keyFileTextBox.Text == "")
            {
                MessageBox.Show("You must choose your key file!");
                return;
            }

            string log = HuffmanMethods.DecompressFileWrapper(decompressFileTextBox.Text, keyFileTextBox.Text);
            if (log.StartsWith("Error"))
            {
                MessageBox.Show(log);
                return;
            }

            logBox.Text += log;
        }

        private void footerLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("cmd", "/c start https://github.com/krefikk");
        }
    }
}

class HuffmanMethods
{
    [DllImport("huffman.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    private static extern IntPtr compressFile(string inputFileName);

    [DllImport("huffman.dll", CallingConvention = CallingConvention.Cdecl)]
    private static extern IntPtr decompressFile(string compressedFileName, string keyFileName);

    public static string CompressFileWrapper(string inputFileName)
    {
        IntPtr ptr = compressFile(inputFileName);
        if (ptr == IntPtr.Zero)
            return "Error: Null pointer returned from DLL";

        string log = Marshal.PtrToStringAnsi(ptr);
        return log ?? "Error: Failed to marshal string from DLL";
    }

    public static string DecompressFileWrapper(string compressedFileName, string keyFileName)
    {
        IntPtr ptr = decompressFile(compressedFileName, keyFileName);
        if (ptr == IntPtr.Zero)
            return "Error: Null pointer returned from DLL";

        string log = Marshal.PtrToStringAnsi(ptr);
        return log ?? "Error: Failed to marshal string from DLL";
    }
}
