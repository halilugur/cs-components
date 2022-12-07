using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginApplication
{
    internal class RoundePanel : Panel
    {
        private Form mainForm = null;
        private bool dragging;
        private Point offset;

        public Form MainForm { get => mainForm; set => mainForm = value; }

        public RoundePanel() : base()
        {
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.RoundePanel_MouseUp);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.RoundePanel_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.RoundePanel_MouseMove);
            this.ResumeLayout(false);
        }

        private void RoundePanel_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void RoundePanel_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            offset.X = e.X;
            offset.Y = e.Y;
        }

        private void RoundePanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging && mainForm != null)
            {
                Point currentPoint = PointToScreen(e.Location);
                MainForm.Location = Point.Subtract(currentPoint,
                    new Size(totalLocation_of_Parent(this, new Point(offset.X + Location.X, offset.Y + Location.Y))));
            }
        }

        private Point totalLocation_of_Parent(Control panel, Point point)
        {
            if (panel.Parent is Form)
            {
                return point;
            }
            return totalLocation_of_Parent(panel.Parent, Point.Add(point, new Size(panel.Parent.Location)));
        }
    }
}
