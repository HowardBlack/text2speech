using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace arduino
{
    public partial class Form1 : Form
    {
        public static string arduino_var = "";
        ServiceReference1.webserver_arduinoSoapClient myarduino_control = new ServiceReference1.webserver_arduinoSoapClient();
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = myarduino_control.webserver_arduino_control();
            if (myarduino_control.webserver_arduino_control() != arduino_var)
            {
                serialPort1.Write(myarduino_control.webserver_arduino_control());
                label1.Text = "送出指令：LED " + myarduino_control.webserver_arduino_control();
                arduino_var = myarduino_control.webserver_arduino_control();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            serialPort1.BaudRate = 9600;
            serialPort1.Parity = Parity.None;
            serialPort1.DataBits = 8;
            serialPort1.StopBits = StopBits.One;
            serialPort1.PortName = "COM3";
            serialPort1.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            serialPort1.Close();
        }
    }
}
