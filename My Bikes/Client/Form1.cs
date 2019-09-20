using System;
using System.Collections.Generic;

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

using System.Xml;
using System.Xml.Serialization;
using Mybikes.Bus;

namespace Mybikes.Client
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int index;
        List<Bike> Bikelist = new List<Bike>();
        List<Mountainbike> Mountainlist = new List<Mountainbike>();
        List<Roadbike> Roadlist = new List<Roadbike>();

        private void Form1_Load(object sender, EventArgs e)
        {
            // color
            foreach (EnumColor color in Enum.GetValues(typeof(EnumColor)))
            {
                this.comboBoxColor.Items.Add(color);
            }
            this.comboBoxColor.Text = Convert.ToString(comboBoxColor.Items[0]);

            // style
            foreach (EnumStyle style in Enum.GetValues(typeof(EnumStyle)))
            {
                this.comboBoxStyle.Items.Add(style);
            }
            this.comboBoxStyle.Text = Convert.ToString(comboBoxStyle.Items[0]);

            // speed
            foreach (EnumSpeed speed in Enum.GetValues(typeof(EnumSpeed)))
            {
                this.comboBoxSpeed.Items.Add(speed);
            }
            this.comboBoxSpeed.Text = Convert.ToString(comboBoxSpeed.Items[0]);

            // type of suspension
            foreach (EnumType type in Enum.GetValues(typeof(EnumType)))
            {
                this.comboBoxTypeofsuspension.Items.Add(type);
            }
            this.comboBoxTypeofsuspension.Text = Convert.ToString(comboBoxTypeofsuspension.Items[0]);
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (radioButtonMountain.Checked == true)
            {

                Mountainbike M1 = new Mountainbike();
                M1.Biketype = radioButtonMountain.Text;
                M1.Sn = (Convert.ToInt32(textBoxSn.Text));
                M1.Model = textBoxModel.Text;
                M1.Price = (Convert.ToDouble(textBoxPrice.Text));
                M1.Brand = textBoxBrand.Text;
                M1.Color = ((EnumColor)this.comboBoxColor.SelectedItem);
                M1.Style = ((EnumStyle)this.comboBoxStyle.SelectedItem);
                M1.Speed = ((EnumSpeed)this.comboBoxColor.SelectedItem);
                M1.Typefs = ((EnumType)this.comboBoxTypeofsuspension.SelectedItem);
                M1.Heightfg = (Convert.ToDouble(textBoxHeightfromground.Text));

                Date madedate = new Date();
                madedate.Year = (Convert.ToInt32(textBoxYear.Text));
                madedate.Month = (Convert.ToInt32(textBoxMonth.Text));
                madedate.Day = (Convert.ToInt32(textBoxDay.Text));

                M1.Madedate = madedate;
                Bike b1 = M1;
                Bikelist.Add(b1);
                Mountainlist.Add(M1);
            }
            else if (radioButtonRoad.Checked == true)
            {
                Roadbike R1 = new Roadbike();
                R1.Biketype = radioButtonRoad.Text;
                R1.Sn = (Convert.ToInt32(textBoxSn.Text));
                R1.Model = textBoxModel.Text;
                R1.Price = (Convert.ToDouble(textBoxPrice.Text));
                R1.Brand = textBoxBrand.Text;
                R1.Color = ((EnumColor)this.comboBoxColor.SelectedItem);
                R1.Style = ((EnumStyle)this.comboBoxStyle.SelectedItem);
                R1.Speed = ((EnumSpeed)this.comboBoxColor.SelectedItem);
                R1.Seatheight = (Convert.ToDouble(textBoxSeat.Text));

                Date madedate = new Date();
                madedate.Year = (Convert.ToInt32(textBoxYear.Text));
                madedate.Month = (Convert.ToInt32(textBoxMonth.Text));
                madedate.Day = (Convert.ToInt32(textBoxDay.Text));

                R1.Madedate = madedate;
                Bike b2 = R1;
                Bikelist.Add(b2);
                Roadlist.Add(R1);
            }

         }

        private void ShowMountainbike(List<Mountainbike> Mountainlist, ListBox listBox)
        {
            this.Display.Items.Clear();

            if (this.Mountainlist.Capacity != 0)
            {
                foreach (Mountainbike list in this.Mountainlist)
                {
                    this.Display.Items.Add(list);
                }
            }
            else
            {
                MessageBox.Show("................. NO DATA ....................");
                textBoxSn.Focus();
            }
        }

        private void ShowRoadbike(List<Roadbike> Roadlist, ListBox listbox)
        {
            this.Display.Items.Clear();
            if (this.Roadlist.Capacity != 0)
            {
                foreach (Roadbike list in this.Roadlist)
                {
                    this.Display.Items.Add(list);
                }
            }
            else
            {
                MessageBox.Show("................. NO DATA ....................");
                textBoxSn.Focus();
            }
        }

        private void buttonDisplayall_Click(object sender, EventArgs e)
        {
            foreach (Bike bike in Bikelist)
            {
                Display.Items.Add(bike);
            }

        }

        private void Display_SelectedIndexChanged(object sender, EventArgs e)
        {
            index = Display.SelectedIndex;

            //MessageBox.Show("Index Number is "+index);

            if (radioButtonMountain.Checked == true)
            {
                radioButtonMountain.Checked = true;

                textBoxSn.Text = Convert.ToString(this.Mountainlist[index].Sn);
                textBoxModel.Text = this.Mountainlist[index].Model;
                textBoxPrice.Text = Convert.ToString(this.Mountainlist[index].Price);
                textBoxBrand.Text = this.Mountainlist[index].Brand;
                comboBoxColor.Text = Convert.ToString(this.Mountainlist[index].Color);
                comboBoxStyle.Text = Convert.ToString(this.Mountainlist[index].Style);
                comboBoxSpeed.Text = Convert.ToString(this.Mountainlist[index].Speed);
                textBoxYear.Text = Convert.ToString(this.Mountainlist[index].Madedate.Year);
                textBoxMonth.Text = Convert.ToString(this.Mountainlist[index].Madedate.Month);
                textBoxDay.Text = Convert.ToString(this.Mountainlist[index].Madedate.Day);
                textBoxHeightfromground.Text = Convert.ToString(this.Mountainlist[index].Heightfg);
                comboBoxTypeofsuspension.Text = Convert.ToString(this.Mountainlist[index].Typefs);
            }
            else if (radioButtonRoad.Checked == true)
            {
                textBoxSn.Text = Convert.ToString(this.Roadlist[index].Sn);
                textBoxModel.Text = this.Roadlist[index].Model;
                textBoxPrice.Text = Convert.ToString(this.Roadlist[index].Price);
                textBoxBrand.Text = this.Roadlist[index].Brand;
                comboBoxColor.Text = Convert.ToString(this.Roadlist[index].Color);
                comboBoxStyle.Text = Convert.ToString(this.Roadlist[index].Style);
                comboBoxSpeed.Text = Convert.ToString(this.Roadlist[index].Speed);
                textBoxYear.Text = Convert.ToString(this.Roadlist[index].Madedate.Year);
                textBoxMonth.Text = Convert.ToString(this.Roadlist[index].Madedate.Month);
                textBoxDay.Text = Convert.ToString(this.Roadlist[index].Madedate.Day);
                textBoxSeat.Text = Convert.ToString(this.Roadlist[index].Seatheight);
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (radioButtonMountain.Checked == true)
            {
                this.Mountainlist[index].Sn = Convert.ToInt32(textBoxSn.Text);
                this.Mountainlist[index].Model = textBoxModel.Text;
                this.Mountainlist[index].Price = Convert.ToInt32(textBoxPrice.Text);
                this.Mountainlist[index].Brand = textBoxBrand.Text;
                this.Mountainlist[index].Color = (EnumColor)this.comboBoxColor.SelectedIndex;
                this.Mountainlist[index].Style = (EnumStyle)this.comboBoxStyle.SelectedIndex;
                this.Mountainlist[index].Speed = (EnumSpeed)this.comboBoxSpeed.SelectedIndex;
                this.Mountainlist[index].Madedate.Year = Convert.ToInt32(textBoxYear.Text);
                this.Mountainlist[index].Madedate.Month = Convert.ToInt32(textBoxMonth.Text);
                this.Mountainlist[index].Madedate.Day = Convert.ToInt32(textBoxDay.Text);
                this.Mountainlist[index].Heightfg = Convert.ToInt32(textBoxHeightfromground.Text);
                this.Mountainlist[index].Typefs = (EnumType)this.comboBoxTypeofsuspension.SelectedIndex;
                ShowMountainbike(this.Mountainlist, this.Display);
            }
            else if (radioButtonRoad.Checked == true)
            {
                this.Roadlist[index].Sn = Convert.ToInt32(textBoxSn.Text);
                this.Roadlist[index].Model = textBoxModel.Text;
                this.Roadlist[index].Price = Convert.ToInt32(textBoxPrice.Text);
                this.Roadlist[index].Brand = textBoxBrand.Text;
                this.Roadlist[index].Color = (EnumColor)this.comboBoxColor.SelectedIndex;
                this.Roadlist[index].Style = (EnumStyle)this.comboBoxStyle.SelectedIndex;
                this.Roadlist[index].Speed = (EnumSpeed)this.comboBoxSpeed.SelectedIndex;
                this.Roadlist[index].Madedate.Year = Convert.ToInt32(textBoxYear.Text);
                this.Roadlist[index].Madedate.Month = Convert.ToInt32(textBoxMonth.Text);
                this.Roadlist[index].Madedate.Day = Convert.ToInt32(textBoxDay.Text);
                this.Roadlist[index].Seatheight = Convert.ToInt32(textBoxSeat.Text);
                ShowRoadbike(this.Roadlist, this.Display);
            }

        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            if (radioButtonMountain.Checked == true)
            {
                this.Mountainlist.RemoveAt(index);
                ShowMountainbike(Mountainlist, Display);
            }
            else if (radioButtonRoad.Checked == true)
            {
                this.Roadlist.RemoveAt(index);
                ShowRoadbike(Roadlist, Display);
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            if (radioButtonMountain.Checked == true)
            {
                int temp = Convert.ToInt32(textBoxSearch.Text);

                bool found = false;
                Mountainbike searchedMountain = new Mountainbike();

                foreach (Mountainbike item in this.Mountainlist)
                {
                    if (item.Sn == temp)
                    {
                        found = true;
                        searchedMountain = item;
                        break;
                    }
                }

                if (found)
                {
                    MessageBox.Show("Mountianbike Found....\n" + searchedMountain);
                }
                else
                {
                    MessageBox.Show("Mountainbike Not Found");
                }
            }
            else if (radioButtonRoad.Checked == true)
            {
                int temp = Convert.ToInt32(textBoxSearch.Text);

                bool found = false;

                Roadbike searchedRoad = new Roadbike();

                foreach (Roadbike item in this.Roadlist)
                {
                    if (item.Sn == temp)
                    {
                        found = true;
                        searchedRoad = item;
                        break;
                    }
                }

                if (found)
                {
                    MessageBox.Show("Roadbike Found....\n" + searchedRoad);
                }
                else
                {
                    MessageBox.Show("Roadbike Not Found");
                }
            }
        }

        private void radioButtonMountain_CheckedChanged(object sender, EventArgs e)
        {
            foreach (Control acontrol in Controls)
            {
                if (acontrol is TextBox)
                {
                    acontrol.Text = "";
                }
            }
            comboBoxSpeed.Text = Convert.ToString(EnumSpeed.Undefined);
            comboBoxColor.Text = Convert.ToString(EnumColor.Undefined);
            comboBoxStyle.Text = Convert.ToString(EnumStyle.Undefined);
            comboBoxTypeofsuspension.Text = Convert.ToString(EnumType.Undefined);
            Display.Items.Clear();
            textBoxSn.Focus();
            textBoxHeightfromground.Enabled = true;
            comboBoxTypeofsuspension.Enabled = true;
            textBoxSeat.Enabled = false;
            label14.Visible = true;
            label6.Visible = true;
            label15.Visible = false;
        }

        private void radioButtonRoad_CheckedChanged(object sender, EventArgs e)
        {
            foreach (Control acontrol in Controls)
            {
                if (acontrol is TextBox)
                {
                    acontrol.Text = "";
                }
            }
            comboBoxSpeed.Text = Convert.ToString(EnumSpeed.Undefined);
            comboBoxColor.Text = Convert.ToString(EnumColor.Undefined);
            comboBoxStyle.Text = Convert.ToString(EnumStyle.Undefined);
            comboBoxTypeofsuspension.Text = Convert.ToString(EnumType.Undefined);
            Display.Items.Clear();
            textBoxSn.Focus();
            textBoxHeightfromground.Enabled = false;
            comboBoxTypeofsuspension.Enabled = false;
            textBoxSeat.Enabled = true;
            label14.Visible = false;
            label6.Visible = false;
            label15.Visible = true;
        }

        private void toolStripMenuItemExit_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Are you want to Exit?");
            this.Close();
        }

        private void displayAllBikesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Display.Items.Clear();
            foreach (Bike bike in Bikelist)
            {
                Display.Items.Add(bike);
            }
        }

        private void displayMountainBikesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (radioButtonMountain.Checked == true)
            {

                ShowMountainbike(Mountainlist, Display);
            }
        }

        private void displayRoadBikesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (radioButtonRoad.Checked == true)
            {
                ShowRoadbike(Roadlist, Display);
            }
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            foreach (Control acontrol in Controls)
            {
                if (acontrol is TextBox)
                {
                    acontrol.Text = "";
                }
            }

            comboBoxSpeed.Text = Convert.ToString(EnumSpeed.Undefined);
            comboBoxColor.Text = Convert.ToString(EnumColor.Undefined);
            comboBoxStyle.Text = Convert.ToString(EnumStyle.Undefined);
            comboBoxTypeofsuspension.Text = Convert.ToString(EnumType.Undefined);
            Display.Items.Clear();
            textBoxSn.Focus();

        }

        private void ToolStripMenuItemXml_Click(object sender, EventArgs e)
        {
            IFileHandler interface1;
            interface1 = new FileHandler();
            interface1.WriteToXmlFileBike(this.Bikelist);

        }

        private void fromXMLFileToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Display.Items.Clear();
            IFileHandler interface3;
            interface3 = new FileHandler();
            this.Bikelist = interface3.ReadFromXmlFileA();
            foreach (Bike item in Bikelist)
            {
                this.Display.Items.Add(item);
            }
        }

        private void menuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}

 

 

    
