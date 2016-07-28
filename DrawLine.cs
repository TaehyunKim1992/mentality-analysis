using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintProgram
{
    class DrawLine
    {
        private List<Draw> myDrawLine;
        private int length;

        public DrawLine()
        {
            myDrawLine = new List<Draw>();
            length = 0;
        }

        public void setMyDrawLine(Draw d){
            myDrawLine.Add(d);
            setLength();
        }

        public List<Draw> getMyDrawLine()
        {
            return myDrawLine;
        }

        public void setLength()
        {
            length++;
        }

        public int getLength()
        {
            return length;
        }
    }
}
