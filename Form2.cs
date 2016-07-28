using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace PaintProgram
{
    public partial class Form2 : Form
    {
        public Form2()
        {

            InitializeComponent();
            //chart2.Series.Clear(); //default series를 삭제한다.

              //Series sR = chart2.Series.Add("r"); //새로운 series 생성

              //sR.ChartType = SeriesChartType.Line; //그래프 모양을 '선'으로 지정

              //데이터 포인트 저장

              //for (double k=0;k<2*Math.PI;k+=0.1)
              for (double k = 0; k < 200; k ++)
              {

                   //sR.Points.AddXY(1, Form1.rgbArray[0,y);

              }
           




            //Series sG = chart2.Series.Add("g"); //새로운 series 생성

            //sG.ChartType = SeriesChartType.Line;
            for (double k = 0; k < Form1.PublicWidth* Form1.PublicHeight; k++)
             for (int y = 0; y < Form1.PublicHeight; y++)
                for (int x = 0; x < Form1.PublicWidth; x++)
                {
                    //sG.Points.AddXY(k, y*x);
                }


            for (double k = 0; k < Form1.PublicWidth* Form1.PublicHeight; k++)
            {

                //sG.Points.AddXY(10, k);

            }




            //Series sB = chart2.Series.Add("b"); //새로운 series 생성

           // sB.ChartType = SeriesChartType.Line;

            for (double k = 0; k < 200; k ++)

            {

                //sB.Points.AddXY(5, k);

            }





        }

        private void chart2_Click(object sender, EventArgs e)
        {

        }
    }
}
