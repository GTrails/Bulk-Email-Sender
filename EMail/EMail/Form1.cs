using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Net.Mail;
using System.Net;
using System.Net.NetworkInformation;
using System.IO;
using System.Configuration;
using System.Web;
namespace EMail
{
    delegate void SetTextCallBack(string text);
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Random random = new Random(); 

        private void button1_Click(object sender, EventArgs e)
        {
            
            bool isInternetThere = NetworkInterface.GetIsNetworkAvailable();
            if (isInternetThere == false)
            {
                MessageBox.Show("No active internet Connection found! Make sure you are connected to Internet.");
            }
            try
            {                
                //instance of MailMessage
                //tell from who?
                //instance of smtpClient
                //enable ssl, host, port, credentials
                //receiver's address 
                //mail subject, body
                //send mail              

                if (checkBox1.Checked)
                {
                    int spam = Convert.ToInt32(textBox7.Text);
                    for (int i = 0; i < spam; i++)
                    {
                        sendMail();
                    }
                    MessageBox.Show("Emails sent successfully!");
                }
                else if (!checkBox1.Checked)
                {
                    sendMail();
                    MessageBox.Show("Email Sent Successfully!");
                }
                textBox2.Clear();
                textBox6.Clear();
                richTextBox1.Clear();

                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void sendMail()
        {
                string from = textBox1.Text;
                string to = textBox5.Text;
                string subject = textBox6.Text;
                string body = richTextBox1.Text;
                string pass = textBox2.Text;
                string host = textBox3.Text;
                int port = Convert.ToInt32(textBox4.Text);

                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(from);
                //instance of SmtpClient
                SmtpClient smtp = new SmtpClient();
                smtp.EnableSsl = true;
                smtp.Host = host;
                smtp.Port = port;
                smtp.Credentials = new NetworkCredential(from, pass);
                mail.To.Add(new MailAddress(to));
                mail.Subject = subject + random.Next(1,500000);
            if (checkBox2.Checked)
            {
                mail.IsBodyHtml = true;
                mail.Body = body;
            }
            else
            {
                mail.Body = body;
            }
                            
            progressBar1.Value = 60;
                smtp.Send(mail);
            progressBar1.Value = 100;
            
            
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
           
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        //initials for title_bar_movement
        private bool mouseDown;
        private Point lastLocation;

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                Location = new Point((Location.X - lastLocation.X) + e.X, (Location.Y - lastLocation.Y) + e.Y);
                Update();
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            panel2.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }
        public string location;
        public void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.ShowDialog();
            string path = openFileDialog1.InitialDirectory + openFileDialog1.FileName;
            location = path;
            
        }

        void bombMail()
        {
            progressBar2.Value = 60;
            string[] to = File.ReadAllLines(location);
            foreach (string line in to)
            {
                string from = textBox8.Text;
                string pass = textBox9.Text;
                string host = textBox11.Text;
                int port = Convert.ToInt32(textBox12.Text);
                string subject = textBox13.Text;
                string body = richTextBox2.Text;
                MailMessage mail = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                if (checkBox3.Checked)
                {
                    mail.IsBodyHtml = true;
                    mail.Body = body;
                }
                else
                {
                    mail.Body = body;
                }
                mail.From = new MailAddress(from);
                smtp.Host = host;
                smtp.Port = port;
                smtp.EnableSsl = true;
                smtp.Credentials = new NetworkCredential(from, pass);
                if (checkBox4.Checked == true && checkBox5.Checked == true)
                {
                    mail.Subject = subject + random.Next(1,500000); //random int from 1 to max emails loaded.drawback, if only one email is loaded, no unique spams. FIX IT!
                }
                else
                {
                    mail.Subject = subject;
                }
                mail.To.Add(new MailAddress(line));
                smtp.Send(mail);
                progressBar2.Value = 100;
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_DoWork_1(object sender, DoWorkEventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void progressBar2_Click(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            try
            {
                bool isInternetThere = NetworkInterface.GetIsNetworkAvailable();
                if (isInternetThere == false)
                {
                    MessageBox.Show("No active internet Connection found! Make sure you are connected to Internet.");
                }

                if (checkBox4.Checked)
                {
                    int spam = Convert.ToInt32(textBox14.Text);
                    for (int i = 0; i < spam; i++)
                    {
                        bombMail();
                    }
                    MessageBox.Show("Emails sent successfully!");
                }
                else
                {
                    bombMail();
                    MessageBox.Show("Email sent successfully!");
                }
                textBox9.Clear();
                textBox13.Clear();
                richTextBox2.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
