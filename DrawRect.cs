using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PaintProgram
{
    class DrawRect
    {
        List<Rect> rectList;

        public DrawRect()
        {
            rectList = new List<Rect>();
        }

        public void setRect(Rect r)
        {
            rectList.Add(r);
        }

        public List<Rect> getRectList()
        {
            return rectList;
        }
    }
}
