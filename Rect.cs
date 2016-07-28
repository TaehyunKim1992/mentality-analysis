using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PaintProgram
{
    class Rect
    {
        Rectangle rect;
        Color color;
        float width;

        public Rect(Rectangle r, Color c, float w)
        {
            rect = r;
            color = c;
            width = w;
        }

        public Rectangle getRect()
        {
            return rect;
        }

        public Color getColor()
        {
            return color;
        }

        public float getWidth()
        {
            return width;
        }

    }
}
