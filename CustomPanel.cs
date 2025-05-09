using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyCustomPanel
{
    class CustomPanel : Panel
    {
        //Field
        private int borderRadius = 30;
        private float gradiantAngle = 90F;
        private Color gradiantTopColor = Color.DodgerBlue;
        private Color gradiantBottomColor = Color.CadetBlue;

        //Constructor
        public CustomPanel()
        {
            this.BackColor = Color.White;
            this.ForeColor = Color.Black;
            this.Size = new Size(350, 200);
        }

        //Properties
        public int BorderRadius {
            get => borderRadius;
            set { borderRadius = value; this.Invalidate(); }
        }
        public float GradiantAngle {
            get => gradiantAngle;
            set { gradiantAngle = value; this.Invalidate(); }
        }
        public Color GradiantTopColor {
            get => gradiantTopColor;
            set { gradiantTopColor = value; this.Invalidate(); }
        }
        public Color GradiantBottomColor {
            get => gradiantBottomColor;
            set {gradiantBottomColor = value; this.Invalidate();}
        }
        
        //Methords
        private GraphicsPath GetCustomPath(RectangleF rectangle,float radius)
        {
            GraphicsPath graphicsPath = new GraphicsPath();
            graphicsPath.StartFigure();
            graphicsPath.AddArc(rectangle.Width - radius, rectangle.Height - radius, radius,radius, 0,90);
            graphicsPath.AddArc(rectangle.X, rectangle.Height - radius, radius,radius, 90,90);
            graphicsPath.AddArc(rectangle.X, rectangle.Y, radius,radius, 180,90);
            graphicsPath.AddArc(rectangle.Width - radius, rectangle.Y, radius, radius, 270, 90);
            graphicsPath.CloseFigure();
            return graphicsPath;
        }

        //override
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            //gradiant
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            LinearGradientBrush brushCustom = new LinearGradientBrush(this.ClientRectangle,this.GradiantTopColor,this.gradiantBottomColor,this.gradiantAngle);

            Graphics graphicsCustom = e.Graphics;
            graphicsCustom.FillRectangle(brushCustom,ClientRectangle);


            //borderRadius
            RectangleF rectangleF = new RectangleF(0,0,this.Width,this.Height);
            if (borderRadius > 2)
            {
                using (GraphicsPath graphicsPath = GetCustomPath(rectangleF, borderRadius))
                using (Pen pen = new Pen(this.Parent.BackColor, 2))
                {
                    this.Region = new Region(graphicsPath);
                    e.Graphics.DrawPath(pen, graphicsPath);
                }
            }
            else this.Region = new Region(rectangleF);
        }

    }
}
