using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintProgram
{
    class COO
    {
        int x;
        int y;
        Color color;
        float width;


        public COO(int x, int y, Color c, float w)
        {
            this.x = x;
            this.y = y;
            this.color = c;
            width = w;
        }

        public int getX()
        {
            return x;
        }

        public int getY()
        {
            return y;
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
