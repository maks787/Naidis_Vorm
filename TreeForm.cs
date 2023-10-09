using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naidis_Vorm
{
    public partial class TreeForm : Form
    {
        TreeView tree;
        Button btn;
        TreeNode tn = new TreeNode("Elemendid");
        Label lbl;
        TextBox txt_box;
        RadioButton r1, r2;
        CheckBox c1, c2;
        PictureBox pb;
       
        double i=0;
        int j, o = 0;
        public TreeForm()
        {
            this.Height = 600;
            this.Width = 800;
            this.Text = "Vorm põhielementidega";
            tree = new TreeView();
            tree.Dock = DockStyle.Top;
            tree.BorderStyle = BorderStyle.Fixed3D;
            tree.AfterSelect+=Tree_AfterSelect;
            tn.Nodes.Add(new TreeNode("Nupp-Button"));
            btn = new Button();
            btn.Height = 50;
            btn.Width = 100;
            btn.Text= "Click!\n"+i;
            btn.Location = new Point(400, 300);
            btn.Click+=Btn_Click;
            btn.MouseWheel +=Btn_MouseWheel;
            //Label
            tn.Nodes.Add("Silt-Label");
            lbl = new Label();
            lbl.Text = "Pealkiri";
            lbl.Location = new Point(0,0);
            lbl.BackColor = Color.Gray;
            lbl.Size = new Size(this.Width,btn.Location.Y);
            tree.Nodes.Add(tn);
            
            //tekst
            tn.Nodes.Add("Tekstkast-Textbox");
            txt_box = new TextBox();
            txt_box.Height = 50;
            txt_box.Width = 100;
            txt_box.Text = "....";
            txt_box.Location = new Point(tree.Width, btn.Top + btn.Height);
            txt_box.KeyDown += (new KeyEventHandler(Txt_box_keyDown));

            //radioButton
            tn.Nodes.Add("Radionupp-Radiobutton");
            r1 = new RadioButton();
            r1.Text = "Valik 1";
            r1.Location = new Point(tree.Width,txt_box.Location.Y-txt_box.Height);
            r1.Visible = false;
            r1.CheckedChanged += new EventHandler(RadioButtons_Changed);
            r2 = new RadioButton();
            r2.Text = "Valik 2";
            r2.Location = new Point(r1.Location.X + r1.Width, txt_box.Location.Y + txt_box.Height);
            r2.Visible = false;
            r2.CheckedChanged += new EventHandler(RadioButtons_Changed);
            //checkbox
            tn.Nodes.Add("Checkbox");
            c1 = new CheckBox();
            c1.Text = "Näita nupp";
            c1.Location = new Point(r1.Location.Y+r1.Height, tree.Width);
            c1.Visible = false;
            c1.CheckedChanged += new EventHandler(C1_CheckedChandeg);   
            c2 = new CheckBox();
            c2.Text = "Näita veel midagi";
            c2.Location = new Point(tree.Width, c1.Location.Y + c1.Height);
            c2.Visible = false;
            //picturebox
            tn.Nodes.Add("PictureBox");
            pb = new PictureBox();
            pb.Location= new Point(tree.Width, c2.Location.Y + c2.Height);
            pb.Visible = false;
            pb.Image = new Bitmap("../../../untitled.png");
            pb.Size = new Size(200, 200);
            pb.SizeMode = PictureBoxSizeMode.Zoom;
            pb.BorderStyle = BorderStyle.Fixed3D;
            this.Controls.Add(tree);

            
            this.Controls.Add(btn);
            this.Controls.Add(lbl);
            this.Controls.Add(txt_box);
            this.Controls.Add(r1);
            this.Controls.Add(r2);
            this.Controls.Add(c1);
            this.Controls.Add(c2);
            this.Controls.Add(pb);

            btn.Visible = false;
            lbl.Visible = false;
            txt_box.Visible = false;
        }
        private void Txt_box_keyDown(object? sender,KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DialogResult result = MessageBox.Show("Kas sa oled kindel?","Küsimus",MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes) { this.Text = txt_box.Text; }
                
            }
        }
        private void C1_CheckedChandeg(object? sender, EventArgs e)
        {
            if (c1.Checked == true && c2.Checked == false)
            {

            }
            else if (c1.Checked == true && c2.Checked == false)
            {

            }
            else if (c1.Checked == false && c2.Checked == true)
            {

            }
        }

        private void RadioButtons_Changed(object? sender, EventArgs e)
        {
            if (r1.BackColor == Color.Red)
            {
                r1.BackColor = Color.Green;
            }
            else if (r2.BackColor == Color.Green)
            {
                r2.BackColor = Color.Blue;
            }
            else
            {
                r2.BackColor = Color.Red;
            }

        }

        private void Btn_MouseWheel(object? sender, MouseEventArgs e)
        {
            i+=1;
            btn.Text= "Click!\n"+i;
        }

        private void Tree_AfterSelect(object? sender, TreeViewEventArgs e)
        {
            if (e.Node.Text=="Nupp-Button")
            {
                if (j%2==0)
                {
                    btn.Visible = true;
                }
                else
                {
                    btn.Visible = false;
                }
                j++;
            }
            else if (e.Node.Text == "Silt-Label")
            {
                if (o%2==0)
                {
                    lbl.Visible = true;
                }
                else
                {
                    lbl.Visible = false;                   
                }
                o++;
            }
            if (e.Node.Text == "Tekstkast-Textbox" && txt_box.Visible == true)
            {
                txt_box.Visible = false;
            }
            else if (e.Node.Text == "Tekstkast-Textbox" && txt_box.Visible == false)
            {
                txt_box.Visible = true;
            }
            if (e.Node.Text == "Radionupp-Radiobutton" && r1.Visible == true)
            {
                r1.Visible = false;
                r2.Visible = false;
            }
            else if (e.Node.Text == "Radionupp-Radiobutton" && r1.Visible == false)
            {
                r1.Visible = true;
                r2.Visible = true;
            }
            if (e.Node.Text == "Checkbox" && c1.Visible == true)
            {
                c1.Visible = false;
                c2.Visible = false;
            }
            else if (e.Node.Text == "Checkbox" && c1.Visible == false)
            {
                c1.Visible = true;
                c2.Visible = true;
            }
            if (e.Node.Text == "PictureBox" && pb.Visible == true)
            {
                pb.Visible = false;
              
            }
            else if (e.Node.Text == "PictureBox" && pb.Visible == false)
            {
                pb.Visible = true;
               
            }


            tree.SelectedNode = null;
            
        }

        private void Btn_Click(object? sender, EventArgs e)
        {
            i+=1;
            btn.Text= "Click!\n"+i;
            if (btn.BackColor==Color.Red)
            {
                btn.BackColor= Color.Green;
            }
            else if (btn.BackColor==Color.Green)
            {
                btn.BackColor= Color.Blue;
            }
            else
            {
                btn.BackColor= Color.Red;
            }
            btn.Location = new Point(new Random().Next(0,600), new Random().Next(200, 500));
            lbl.Size = new Size(this.Width, btn.Location.Y);
        }
    }
}
