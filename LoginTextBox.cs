using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class LoginTextBox : UserControl
    {
        private Color borderColor = Color.MediumSlateBlue;
        private int borderSize = 2;
        private bool underlinedStyle= false;
        private String placeHolder = "";
        public LoginTextBox()
        {
            InitializeComponent();
        }

        public Color BorderColor { get => borderColor; set => borderColor = value; }
        public int BorderSize { get => borderSize; set => borderSize = value; }
        public bool UnderlinedStyle { get => underlinedStyle; set => underlinedStyle = value; }
        public string PlaceHolder { get => placeHolder; set => placeHolder = value; }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics graphics = e.Graphics;
             
            using (Pen penBorder = new Pen(borderColor, borderSize)) 
            {
                penBorder.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
                if(underlinedStyle)
                {
                    graphics.DrawLine(penBorder, 0, this.Height-1, this.Width,this.Height-1);
                } else
                {
                    graphics.DrawRectangle(penBorder, 0,0, this.Width-0.5F,this.Height-0.5F);
                }
;            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (this.DesignMode)
            {
                UpdateControlHeight();
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            UpdateControlHeight();
            this.textBox_Placeholder(textBox1);
        }

        private void UpdateControlHeight()
        {
            if (!textBox1.Multiline)
            {
                int txtHeight = TextRenderer.MeasureText("Text", this.Font).Height+ 1;
                textBox1.Multiline= true;
                textBox1.MinimumSize = new Size(0, txtHeight);
                textBox1.Multiline= false;

                this.Height = textBox1.Height + this.Padding.Top + this.Padding.Bottom;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            textBox_Placeholder(textBox1);
        }

        private void textBox_Placeholder(TextBox textBox)
        {
            if (textBox.Text.Equals(""))
            {
                textBox.Text = placeHolder;
            }
            this.Invalidate();
        }
    }
}
