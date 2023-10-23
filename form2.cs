using System;
using System.Drawing;
using System.Windows.Forms;

namespace Naidis_Vorm
{
    public class Form2 : Form
    {
        PictureBox pb;
        TextBox textBox;
        TextBox txtb;
        Label lblA;
        Label lblB;
        Button btn2;
        ListView listView1;
        Triangle triangle; 

        public Form2()
        {
            this.Height = 400;
            this.Width = 600;
            this.Text = "Teine form";
            this.BackColor = Color.Yellow;

            pb = new PictureBox();
            pb.Location = new Point(400, 0);
            pb.Visible = true;
            pb.Image = new Bitmap("../../../form2.png");
            pb.Size = new Size(200, 200);
            pb.SizeMode = PictureBoxSizeMode.Zoom;
            pb.BorderStyle = BorderStyle.Fixed3D;

            lblA = new Label();
            lblA.Text = "Külg A:";
            lblA.Location = new Point(0, 200);

            textBox = new TextBox();
            textBox.Location = new Point(100, 200);
            textBox.Size = new Size(100, 30);

            lblB = new Label();
            lblB.Text = "Kõrgus";
            lblB.Location = new Point(0, textBox.Top + textBox.Height + 10);

            txtb = new TextBox();
            txtb.Location = new Point(100, textBox.Top + textBox.Height + 10);
            txtb.Size = new Size(100, 30);

            btn2 = new Button();
            btn2.Location = new Point(200, textBox.Top + textBox.Height + 10);
            btn2.Text = "Käivitamine";
            btn2.Size = new Size(100, 50);
            btn2.BackColor = Color.White;
            btn2.Click += new EventHandler(run_button_click); 

            listView1 = new ListView();
            listView1.Name = "listView1";
            listView1.Location = new Point(10, 10);
            listView1.Size = new Size(250, 150);

            this.Controls.Add(btn2);
            this.Controls.Add(lblA);
            this.Controls.Add(lblB);
            this.Controls.Add(pb);
            this.Controls.Add(textBox);
            this.Controls.Add(txtb);
            this.Controls.Add(listView1);

            triangle = new Triangle(0, 0, 0); 
        }

        private void run_button_click(object sender, EventArgs e)
        {
            double a, h, s;

            Triangle triangle = new Triangle(1,3,4);

            listView1.Clear();
            
            listView1.View = View.Details;

            if (double.TryParse(textBox.Text, out a) && double.TryParse(txtb.Text, out h))
            {
                s = triangle.Surface2(a, h);
                listView1.Columns.Add("Parameeter", 100);
                listView1.Columns.Add("Tähtsus", 150);

                listView1.Items.Add(new ListViewItem(new[] { "Külg A", triangle.outputA() }));
                listView1.Items.Add(new ListViewItem(new[] { "Kõrgus", h.ToString() }));
                listView1.Items.Add(new ListViewItem(new[] { "Pindala", Convert.ToString(triangle.Surface2(a,h)) }));
            }
        }
    }
}
