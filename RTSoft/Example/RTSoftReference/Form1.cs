using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
namespace RTSoftReference
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // References
        public string CPtoString(IntPtr pointer)
        {
            return Marshal.PtrToStringAnsi(pointer);
        }
        public string GetChar(string sign)
        {
            string res = "";

            sign = sign.Replace("\\x", "");
            Byte[] rw = new Byte[sign.Length / 2];
            for (int i = 0; i < rw.Length; i++)
            {
                rw[i] = Convert.ToByte(sign.Substring(i * 2, 2), 16);
            }
            res = Encoding.Default.GetString(rw);
            return res;
        }
      
        // Initialize
        [DllImport(@"C:\Users\Asus\documents\visual studio 2012\Projects\C++\RTSoft\x64\Debug\RTSoft.dll")]
        public static extern bool GT_INIT();

        // Accessing Growtopia
        [DllImport(@"C:\Users\Asus\documents\visual studio 2012\Projects\C++\RTSoft\x64\Debug\RTSoft.dll")]
        public static extern int GET_GT(out IntPtr res);

        // Hook Address Ban Bypass Growtopia
        [DllImport(@"C:\Users\Asus\documents\visual studio 2012\Projects\C++\RTSoft\x64\Debug\RTSoft.dll")]
        public static extern IntPtr GET_BAN_BYPASS_ADDR(IntPtr proc);

        // Search Address Growtopia
        [DllImport(@"C:\Users\Asus\documents\visual studio 2012\Projects\C++\RTSoft\x64\Debug\RTSoft.dll")]
        public static extern IntPtr GET_ADDR(IntPtr proc, string ptr, string msk, out IntPtr resaddr);

        // Search Address Growtopia With Increase
        [DllImport(@"C:\Users\Asus\documents\visual studio 2012\Projects\C++\RTSoft\x64\Debug\RTSoft.dll")]
        public static extern IntPtr GET_ADDR_INC(IntPtr proc, string ptr, string msk, int inc, out IntPtr resaddr);

        // Read Address Memory Growtopia
        [DllImport(@"C:\Users\Asus\documents\visual studio 2012\Projects\C++\RTSoft\x64\Debug\RTSoft.dll")]
        public static extern IntPtr READ_MEM_ADDR(IntPtr proc, IntPtr addr);

        // Write Address Memory Growtopia
        [DllImport(@"C:\Users\Asus\documents\visual studio 2012\Projects\C++\RTSoft\x64\Debug\RTSoft.dll")]
        public static extern bool WRITE_MEM_ADDR(IntPtr proc, string val, int size, IntPtr addr);

        // Patch 0x90 Memory
        [DllImport(@"C:\Users\Asus\documents\visual studio 2012\Projects\C++\RTSoft\x64\Debug\RTSoft.dll")]
        public static extern bool NOP(IntPtr proc, IntPtr addr, int size);

        // Patch Memory
        [DllImport(@"C:\Users\Asus\documents\visual studio 2012\Projects\C++\RTSoft\x64\Debug\RTSoft.dll")]
        public static extern bool PATCH(IntPtr proc, IntPtr addr, byte[] mem, int size);

        private void Form1_Load(object sender, EventArgs e)
        {            
        }       

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (GT_INIT()) MessageBox.Show("Privelege Success");
            else MessageBox.Show("Privelege Failed");
        }

        IntPtr proc;
        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Respons GET : " + GET_GT(out proc).ToString());
            MessageBox.Show("Respons HANDLE : " + proc.ToString());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            label2.Text = CPtoString(GET_BAN_BYPASS_ADDR(proc));
        }

        IntPtr addr;
        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "")
            {
                try
                {
                    IntPtr resaddr;
                    IntPtr res = GET_ADDR(proc, GetChar(textBox3.Text), GetChar(textBox3.Text), out resaddr);
                    textBox4.Text = CPtoString(res);

                    textBox5.Text = CPtoString(READ_MEM_ADDR(proc, resaddr));

                    addr = resaddr;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (addr == null)
            {
                MessageBox.Show("Address still empty!");
            }
            else
            {
                WRITE_MEM_ADDR(proc, textBox11.Text, textBox11.TextLength, addr);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "")
            {
                try
                {
                    IntPtr resaddr;
                    IntPtr res = GET_ADDR_INC(proc, GetChar(textBox3.Text), GetChar(textBox3.Text), (int)numericUpDown1.Value, out resaddr);
                    textBox4.Text = CPtoString(res);

                    textBox5.Text = CPtoString(READ_MEM_ADDR(proc, resaddr));

                    addr = resaddr;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        IntPtr AutoHarvest;
        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                IntPtr res = GET_ADDR(proc, "\x74\x0E\xB9\xAE", "\x74\x0E\xB9\xAE", out AutoHarvest);
                label3.Text = CPtoString(res);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            NOP(proc, AutoHarvest, 2);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            PATCH(proc, AutoHarvest, new byte[] { 0x74, 0x0E }, 2);
        }
    }
}
