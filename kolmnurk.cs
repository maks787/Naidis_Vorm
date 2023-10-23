using System;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace Naidis_Vorm
{
    public class Kolmnurk : Form
    {
        PictureBox pb;
        Button btn;
        TextBox txtA;
        TextBox txtB;
        TextBox txtC;
        Label lblA;
        Label lblB;
        Label lblC;
        ListView listView1;
        Button btn2;
        
        public Kolmnurk()
        {
            this.Height = 600;
            this.Width = 800;
            this.Text = "";



            btn2 = new Button();
            btn2.Location = new Point(450, 350);
            btn2.Text = "Teine Form";
            btn2.Size = new Size(100, 50);
            btn2.BackColor = Color.Red;

            btn = new Button();
            btn.Location = new Point(400, 100);
            btn.Text = "Käivitamine";
            btn.Size = new Size(200, 100);
            btn.BackColor = Color.Yellow;

            pb = new PictureBox();
            pb.Location = new Point(425, 200);
            pb.Visible = true;
            pb.Image = new Bitmap("../../../triangle-png.png");
            pb.Size = new Size(150, 150);
            pb.SizeMode = PictureBoxSizeMode.Zoom;
            pb.BorderStyle = BorderStyle.Fixed3D;

            lblA = new Label();
            lblA.Text = "Külg A:";
            lblA.Location = new Point(100, 260);

            txtA = new TextBox();
            txtA.Name = "txtA";
            txtA.Height = 50;
            txtA.Width = 100;
            txtA.Text = "";
            txtA.Location = new Point(200, 250);

            lblB = new Label();
            lblB.Text = "Külg B:";
            lblB.Location = new Point(100, txtA.Top + txtA.Height + 10);

            txtB = new TextBox();
            txtB.Name = "txtB";
            txtB.Height = 50;
            txtB.Width = 100;
            txtB.Text = "";
            txtB.Location = new Point(200, txtA.Top + txtA.Height + 10);

            lblC = new Label();
            lblC.Text = "Külg C:";
            lblC.Location = new Point(100, txtB.Top + txtB.Height + 10);

            txtC = new TextBox();
            txtC.Name = "txtC";
            txtC.Height = 50;
            txtC.Width = 100;
            txtC.Text = "";
            txtC.Location = new Point(200, txtB.Top + txtB.Height + 10);

            listView1 = new ListView();
            listView1.Name = "listView1";
            listView1.Location = new Point(10, 10);
            listView1.Size = new Size(350, 230);




            this.Controls.Add(btn2);
            this.Controls.Add(btn);
            this.Controls.Add(pb);
            this.Controls.Add(lblA);
            this.Controls.Add(txtA);
            this.Controls.Add(lblB);
            this.Controls.Add(txtB);
            this.Controls.Add(lblC);
            this.Controls.Add(txtC);
            this.Controls.Add(listView1);

            btn.Click += Run_button_click;
            btn2.Click += OpenForm2;
        }
        private string GetTriangleType(double a, double b, double c)
        {
            if (a + b > c && a + c > b && b + c > a)
            {
                if (a == b && b == c)
                {
                    return "Võrdkülgne kolmnurk";
                }
                else if (a == b || a == c || b == c)
                {
                    return "Võrdhaardne kolmnurk";
                }
                else
                {
                    return "Külgmine kolmnurk";
                }
            }
            else
            {
                return "ei ole";
            }
        }
        public void OpenForm2(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }
        private void Run_button_click(object sender, EventArgs e)
        {
            listView1.Clear();
            double a, b, c;
            a = Convert.ToDouble(txtA.Text);
            b = Convert.ToDouble(txtB.Text);
            c = Convert.ToDouble(txtC.Text);
            Triangle triangle = new Triangle(a, b, c);
            listView1.View = View.Details;

            listView1.Columns.Add("Parameeter", 100);
            listView1.Columns.Add("Tähtsus", 150);

            listView1.Items.Add(new ListViewItem(new[] { "Külg A", triangle.outputA() }));
            listView1.Items.Add(new ListViewItem(new[] { "Külg B", triangle.outputB() }));
            listView1.Items.Add(new ListViewItem(new[] { "Külg C", triangle.outputC() }));
            listView1.Items.Add(new ListViewItem(new[] { "Ümbermõõt", Convert.ToString(triangle.Perimeter()) }));
            listView1.Items.Add(new ListViewItem(new[] { "Pindala", Convert.ToString(triangle.Surface()) }));
            listView1.Items.Add(new ListViewItem(new[] { "Kõrgus", Convert.ToString(triangle.Height()) }));

            string triangleType = GetTriangleType(a, b, c);
            listView1.Items.Add(new ListViewItem(new[] { "Kolmnurk tüüpi", triangleType }));

            ListViewItem existsItem = new ListViewItem(new[] { "On olemas?" });
            if (triangle.ExistTriange)
            {
                existsItem.SubItems.Add("On olemas");
            }
            else
            {
                existsItem.SubItems.Add("Ei ole olemas");
            }
            listView1.Items.Add(existsItem);
        }

    }
}
