using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Amazon.S3;
using Amazon.S3.Model;

namespace Lab7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Text = "File Encrypt/Decrypt";
        }

        private void label1_Click(object sender, EventArgs e)

        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog Directory = new OpenFileDialog();

            //Directory.ShowDialog();

            if (Directory.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = Directory.FileName;
                this.Invalidate();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            bool errorflag = false;
            if (textBox1.Text == "")
            {
                MessageBox.Show("Could not open source or destination file.");
                errorflag = true;
                return;
            }
            if (textBox2.Text == "")
            {
                MessageBox.Show("Please enter a key.");
                errorflag = true;
                return;
            }
            if (!File.Exists(textBox1.Text))
            {
                MessageBox.Show("Could not open source or destination file.");
                errorflag = true;
                return;
            }
            if (!errorflag)
            {
                
                FileStream infile = null, outfile = null;
                byte[] infilebuff = new byte[512];
                byte[] encryptedbuff = new byte[512];
                int readstatus;
                infile = new FileStream(textBox1.Text, FileMode.Open, FileAccess.Read);
                if (File.Exists(textBox1.Text + ".enc"))
                {
                    DialogResult dialogResult = MessageBox.Show("Output file Exists Overwrite?", "Error", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.No)
                        return;
                }
                outfile = new FileStream(textBox1.Text + ".enc", FileMode.Create, FileAccess.Write);
                
                string key = textBox2.Text;
                int keylength = key.Length;
                int keyposition = 0;

                while ((readstatus = infile.Read(infilebuff, 0, 512)) > 0)
                {
                    for(int i = 0; i < readstatus; i++)
                    {
                        if (keyposition > keylength - 1)
                        {
                            keyposition = 0;
                        }
                        encryptedbuff[i] = (byte)(infilebuff[i] ^ key[keyposition]);
                        keyposition++;
                       
                    }

                    outfile.Write(encryptedbuff, 0, readstatus);
                }



                infile.Close();
                outfile.Close();
                MessageBox.Show("Operation completed successfully");

            }
            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            bool errorflag2= false;
            if (textBox1.Text == "")
            {
                MessageBox.Show("Could not open source or destination file.");
                errorflag2 = true;
                return;
            }
            if (textBox2.Text == "")
            {
                MessageBox.Show("Please enter a key.");
                errorflag2 = true;
                return;
            }
            if (!File.Exists(textBox1.Text))
            {
                MessageBox.Show("Could not open source or destination file.");
                errorflag2 = true;
                return;

            }
            FileInfo encfile = new FileInfo(textBox1.Text);
            if(encfile.Extension != ".enc")
            {
                MessageBox.Show("Not a .enc File");
                errorflag2 = true;
                return;
            }
            if (!errorflag2)
            {

                FileStream infile = null, outfile = null;
                byte[] infilebuff = new byte[512];
                byte[] encryptedbuff = new byte[512];
                int readstatus;
                string resultstr = textBox1.Text.Remove(textBox1.Text.Length - 4, 4);
                infile = new FileStream(textBox1.Text, FileMode.Open, FileAccess.Read);
                if (File.Exists(resultstr))
                {
                    DialogResult dialogResult = MessageBox.Show("Output file Exists Overwrite?", "Error", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.No)
                        return;
                }
                //string resultstr = textBox1.Text.Remove(textBox1.Text.Length - 4, 4);
                outfile = new FileStream(resultstr, FileMode.Create, FileAccess.Write);

                string key = textBox2.Text;
                int keylength = key.Length;
                int keyposition = 0;

                while ((readstatus = infile.Read(infilebuff, 0, 512)) > 0)
                {
                    for (int i = 0; i < readstatus; i++)
                    {
                        if (keyposition > keylength - 1)
                        {
                            keyposition = 0;
                        }
                        encryptedbuff[i] = (byte)(infilebuff[i] ^ key[keyposition]);
                        keyposition++;

                    }
                    outfile.Write(encryptedbuff, 0, readstatus);
                }



                infile.Close();
                outfile.Close();
                MessageBox.Show("Operation completed successfully");
                
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            bool errorflag = false;
            if (textBox1.Text == "")
            {
                MessageBox.Show("Could not open source or destination file.");
                errorflag = true;
                return;
            }
            if (textBox2.Text == "")
            {
                MessageBox.Show("Please enter a key.");
                errorflag = true;
                return;
            }
            if (!File.Exists(textBox1.Text))
            {
                MessageBox.Show("Could not open source or destination file.");
                errorflag = true;
                return;
            }
            if (!errorflag)
            {

                FileStream infile = null, outfile = null;
                byte[] infilebuff = new byte[512];
                byte[] encryptedbuff = new byte[512];
                int readstatus;
                infile = new FileStream(textBox1.Text, FileMode.Open, FileAccess.Read);
                if (File.Exists(textBox1.Text + ".enc"))
                {
                    DialogResult dialogResult = MessageBox.Show("Output file Exists Overwrite?", "Error", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.No)
                        return;
                }
                outfile = new FileStream(textBox1.Text + ".enc", FileMode.Create, FileAccess.Write);

                string key = textBox2.Text;
                int keylength = key.Length;
                int keyposition = 0;

                while ((readstatus = infile.Read(infilebuff, 0, 512)) > 0)
                {
                    for (int i = 0; i < readstatus; i++)
                    {
                        if (keyposition > keylength - 1)
                        {
                            keyposition = 0;
                        }
                        encryptedbuff[i] = (byte)(infilebuff[i] ^ key[keyposition]);
                        keyposition++;

                    }

                    outfile.Write(encryptedbuff, 0, readstatus);
                }



                infile.Close();
                outfile.Close();
                MessageBox.Show("Operation completed successfully");

            }
            

            FileInfo upfile = new FileInfo(textBox1.Text+".enc");
            
            IAmazonS3 client;
            client = new AmazonS3Client(Amazon.RegionEndpoint.USEast1);
            PutObjectRequest request = new PutObjectRequest()
            {
                BucketName = "filestoragesoon",
                Key = upfile.Name,
                FilePath = textBox1.Text + ".enc"

           };
            PutObjectResponse response2 = client.PutObject(request);
            MessageBox.Show("Operation completed successfully");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            IAmazonS3 client;
            string keyName = textBox1.Text; 
            using (client = new AmazonS3Client(Amazon.RegionEndpoint.USEast1))
            {
                GetObjectRequest request = new GetObjectRequest
                {
                    BucketName = "filestoragesoon",
                    Key = keyName
                };

                using (GetObjectResponse response = client.GetObject(request))
                {
                    string dest = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), keyName);
                    if (!File.Exists(dest))
                    {
                        response.WriteResponseStreamToFile(dest);
                    }
                }
            }

            bool errorflag2 = false;
            if (textBox1.Text == "")
            {
                MessageBox.Show("Could not open source or destination file.");
                errorflag2 = true;
                return;
            }
            if (textBox2.Text == "")
            {
                MessageBox.Show("Please enter a key.");
                errorflag2 = true;
                return;
            }
       
            FileInfo encfile = new FileInfo(textBox1.Text);
            if (encfile.Extension != ".enc")
            {
                MessageBox.Show("Not a .enc File");
                errorflag2 = true;
                return;
            }
            if (!errorflag2)
            {

                FileStream infile = null, outfile = null;
                byte[] infilebuff = new byte[512];
                byte[] encryptedbuff = new byte[512];
                int readstatus;
                FileInfo downfile = new FileInfo("C:/Users/Lee/Desktop/" + textBox1.Text );
                string downpath = "C:/Users/Lee/Desktop/" + textBox1.Text;
                string resultstr = downpath.Remove(downpath.Length - 4, 4);
                
                infile = new FileStream("C:/Users/Lee/Desktop/" + textBox1.Text, FileMode.Open, FileAccess.Read);
                if (File.Exists(resultstr))
                {
                    DialogResult dialogResult = MessageBox.Show("Output file Exists Overwrite?", "Error", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.No)
                        return;
                }
                //string resultstr = textBox1.Text.Remove(textBox1.Text.Length - 4, 4);
                outfile = new FileStream(resultstr, FileMode.Create, FileAccess.Write);

                string key = textBox2.Text;
                int keylength = key.Length;
                int keyposition = 0;

                while ((readstatus = infile.Read(infilebuff, 0, 512)) > 0)
                {
                    for (int i = 0; i < readstatus; i++)
                    {
                        if (keyposition > keylength - 1)
                        {
                            keyposition = 0;
                        }
                        encryptedbuff[i] = (byte)(infilebuff[i] ^ key[keyposition]);
                        keyposition++;

                    }
                    outfile.Write(encryptedbuff, 0, readstatus);
                }



                infile.Close();
                outfile.Close();
                MessageBox.Show("Operation completed successfully");

            }

        }
    }

    
}
