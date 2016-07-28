using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintProgram
{
    class Draw
    {
        private List<COO> points;

        public Draw()
        {
            points = new List<COO>();
        }

        public void setPoints(COO c)
        {
            points.Add(c);
        }

        public List<COO> getPoints()
        {
            return points;
        }

     
    }


}
