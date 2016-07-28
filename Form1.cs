

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;

        //전체 카운팅 무채색: 하양 회색 검정 
        //유채색: 빨강 주황 노랑 연두 초록 청록
        //시안 파랑 남색 보라 자홍 분홍 갈색 
namespace PaintProgram
{
    public partial class Form1 : Form
    {

        #region Fields
        //0 : pen, 1 : circle, 2 : rectangle
        int state = 0;
        Pen pen = new Pen(Color.Black);
        Brush brush = Brushes.Black;
        private DrawLine myDrawLine;
        private DrawRect myDrawRect;
        private DrawRect myDrawCircle;
        private int x, y;
        private string path = "";
        Bitmap th_Bitmap;
        Bitmap th_copy_bitmap;
        Bitmap CroppedImage;
        Graphics th_Graphics;
        public static int[, ,] rgbArray;
        public static int PublicHeight;
        public static int PublicWidth;
        int[,] sectionResult;
        int[, , , ,] sectionArray;
        int[] placing;
        int LUP, CUP1, CUP2, RUP, Left1, Left2, Center1, Center2, Center3, Center4, Right1, Right2, LDO, CDO1, CDO2, RDO;
        int CntCir=0;
        int CntRec=0;
        const string sRe = "빨강";
        const string sOr = "주황";
        const string sYe = "노랑";
        const string sYg = "연두";
        const string sGe = "초록";
        const string sTu = "청록";
        const string sBl = "파랑";
        const string sBv = "남색";
        const string sPu = "보라";
        const string sMa = "자홍";
        const string sPi = "분홍";
        const string sBr = "갈색";
        const string sBu = "검정";
        const string sGr = "회색";

        //위치정보
        const string ssLUP = "왼쪽 위";
        const string ssCUP = "중앙 위";
        const string ssRUP = "오른쪽 위";
        const string ssLEFT = "왼쪽";
        const string ssCenter = "중앙";
        const string ssRight = "오른쪽";
        const string ssLDO = "왼쪽 아래";
        const string ssCDO = "중앙 아래";
        const string ssRDO = "오른쪽 아래";

        int cntsRe=0;
        int cntsOr=0;
        int cntsYe=0;
        int cntsYg=0;
        int cntsGe=0;
        int cntsTu=0;
        int cntsBl=0;
        int cntsBv=0;
        int cntsPu=0;
        int cntsMa=0;
        int cntsPi=0;
        int cntsBr=0;
        int cntsBu=0;
        int cntsGr=0;
        int[] re = new int[3];


        //형태적 위치
        String sLUP = " ▶ 정신분열적 자폐적공상이 있습니다.";
        String sCUP = " ▶ 욕구와 포부가 높습니다. 지나친 목표로 인한 갈등과 스트레스, 공상적이며 낙관주의적이며 주위에 지나치게 무관심과 고립적 경향이 있습니다. ";
        String sRUP = " ▶ 불쾌한 과거 기억을 억압하고자 합니다. 미래지향적인 환상을 나타냅니다. ";
        String sLEFT = " ▶ 충동적이며 욕구와 충동에 즉각적으로 만족을 축구하며 변화와 외향성을 반영합니다 ";
        String sCenter = " ▶ 일반적이나 지나치게 가운데를 맞추려 애쓴다면 완고하고 융통성이 부족합니다. ";
        String sRight = " ▶ 안정적 행동통제를 잘하며 욕구만족 지연 능력이 있습니다. 지적인 만족감을 선호 합니다. ";
        String sLDO = " ▶ 불안정감,자신감결여,의존적인 경향을 나타냅니다. 과거와 관련된 우울감을 나타냅니다. ";
        String sCDO = " ▶ 불안정감,자신감결여,의존적인 경향을 나타냅니다. 내면에 불안정감과 부적절감이 내면화 되어 있거나 우울증적 상태를 나타냄 현실에 뿌리를 두고 분명하고 실제적인 것을 추구합니다. ";
        String sRDO = " ▶ 불안정감,자신감결여,의존적인 경향을 나타냅니다. 미래와 관련된 우울감을 나타냅니다. ";


        //색체
        String Re = " ▶ 매우 활발하고 자기주장이 강합니다. 의식적으로 거친행동이 많으며 부모의 말을 잘 듣지 않습니다. 또한 친구를 오래 사귀지 못합니다. ";
        String Or = " ▶ 활발하여 사교적입니다. 용기가 있고 친절하지만 자기과시가 강하며 거만한 행동을 보입니다. ";
        String Ye = " ▶ 성격이 매우 냉정하며 친구를 골라 사귀는 편입니다. 결단력이 강하고 의지력이 강하며 신경이 예민한 편 입니다. ";
        String Yg = " ▶ ";
        String Ge = " ▶ 자기 주장이 강하며 주위의 친구들과 잘 어울립니다. 사물의 판단을 잘 하는편이며 상상력이 풍부하고 노력형입니다. ";
        String Tu = " ▶ ";
        String Bl = " ▶ 긴장을 잘하고 집중하지 못하는 성격입니다. 공상적인 생각을 많이 하며 잘 놀라는 편입니다. 기분이 좋을 때 파란색을 칠하는 경우가 많습니다. ";
        String Bv = " ▶ 긴장을 잘하고 집중하지 못하는 성격입니다. 공상적인 생각을 많이 하며 잘 놀라는 편입니다. 기분이 좋을 때 파란색을 칠하는 경우가 많습니다. ";
        String Pu = " ▶ 창의적이며 상상력이 풍부합니다. 내적으로 긴장하고 있으며 분위기에 민감한 편 입니다. ";
        String Ma = " ▶ 청결한 습관을 강요 받거나, 자유스러운 분위기와 감정이 구속될 때  많이 사용함.";
        String Pi = " ▶ 섬세한 감정과 부드러운 성격을 가지고 있습니다. 보호욕구가 강하며 허약한 체질이 많습니다. 또한 자제력이 강합니다. ";
        String Br = " ▶ 의지력이 약하며 의존심이 강합니다. 항상 불만이 많으며 자기주장을 잘 나타내지 않습니다. 외로움을 타며 형제가 적은경우가 많습니다. ";
        String Bu = " ▶ 짓궃고 실천력이 강하며 적응력이 있습니다. 다만 가정환경이 대체로 밝지 않습니다. 지능지수는 높은편입니다. ";
        String Gr = " ▶ 경계심이 많고 외로움을 많이 탑니다. ";

        //도형
        String rect = " ▶ 외향적이며 직설적인 표현을 자주 사용하는 편입니다. ";
        String cir = " ▶ 내향적이며 직설적인 표현보다는 우회적으로 표현을 하는 편입니다. ";

        String lotemp1 = "";
        String lotemp2 = "";
        String cotemp1 = "";
        String cotemp2 = "";
        #endregion
        
        #region Constructor
        public Form1()
        {
            InitializeComponent();
            myDrawLine = new DrawLine();
            myDrawRect = new DrawRect();
            myDrawCircle = new DrawRect();

        }

        #endregion

        #region Events
        private void 새로만들기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            th_Graphics = CreateGraphics();
            th_Graphics.Clear(Color.White);
            th_Graphics.Dispose();

            myDrawLine = new DrawLine();
            myDrawRect = new DrawRect();
            myDrawCircle = new DrawRect();
        }
        private void 열기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "그림을 선택하세요";
            openFileDialog1.Filter = " All Files(*.*) |*.*| Bitmap File(*.bmp) |*.bmp| Jpeg File(*.jpeg) |*.jpeg";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string strFilename = openFileDialog1.FileName;
                FileStream fs = File.OpenRead(strFilename);
                Bitmap bitmap = new Bitmap(fs);
                th_Bitmap = bitmap.Clone() as Bitmap;
                th_Graphics = CreateGraphics();
                th_Graphics.Clear(Color.White);
                th_Graphics.DrawImage(bitmap, 10, 100);

                th_Graphics.Dispose();
                fs.Dispose();
                fs.Close();
            }


        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {

            if (!path.Equals(""))
            {
                e.Graphics.DrawImage(th_Bitmap, 10, 100);
            }

            Draw(e.Graphics);
            
        }
        private void colorEdit_click(object sender, EventArgs e)
        {
            DialogResult result = colorDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.sltColor.BackColor = colorDialog1.Color;
                pen.Color = colorDialog1.Color;
            }

        }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (Capture && e.Button == MouseButtons.Left)
            {

                Graphics G = CreateGraphics();
                switch (state)
                {
                    case 0://pen
                        G.DrawLine(pen, x, y, e.X, e.Y);
                        x = e.X;
                        y = e.Y;
                        myDrawLine.getMyDrawLine()[myDrawLine.getLength() - 1].setPoints(new COO(x, y, pen.Color, pen.Width));
                        G.Dispose();
                        break;
                }

            }
            if (Capture && e.Button == MouseButtons.Right)
            {

                Graphics G = CreateGraphics();
                switch (state)
                {
                    case 0://pen
                        G.DrawLine(pen, x, y, e.X, e.Y);
                        x = e.X;
                        y = e.Y;
                        myDrawLine.getMyDrawLine()[myDrawLine.getLength() - 1].setPoints(new COO(x, y, pen.Color, pen.Width));
                        G.Dispose();
                        break;
                }

            }
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            
            if (e.Button == MouseButtons.Left)
            {
                x = e.X;
                y = e.Y;
                if (state == 0)
                {
                    //drawline
                    
                    Draw draw = new Draw();
                    myDrawLine.setMyDrawLine(draw);
                }
            }
            if (e.Button == MouseButtons.Right)
            {
                x = e.X;
                y = e.Y;
                if (state == 0)
                {
                    //drawline
                    Draw draw = new Draw();
                    myDrawLine.setMyDrawLine(draw);
                }
            }
            
        }
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            Graphics G = CreateGraphics();
            Rectangle myRectangle;
            int x2, y2;

            x2 = x;
            y2 = y;
            if (x > e.X)
            {
                x2 = e.X;
            }
            if (y > e.Y)
            {
                y2 = e.Y;
            }
            myRectangle = new Rectangle(x2, y2, Math.Abs(e.X - x), Math.Abs(e.Y - y));

            switch (state)
            {
                case 1:
                    //circle
                    G.FillEllipse(brush,myRectangle);
                    //G.DrawEllipse(pen, myRectangle);
                    myDrawCircle.setRect(new Rect(myRectangle, pen.Color, pen.Width));

                    break;
                case 2:
                    //rectangle
                    G.FillRectangle(brush,myRectangle);
                    //G.DrawRectangle(pen, myRectangle);
                    myDrawRect.setRect(new Rect(myRectangle, pen.Color, pen.Width));
                    break;
            }
            G.Dispose();
        }
        private void 저장ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Title ="그림 저장하기...";
            saveFileDialog1.Filter = " All Files(*.*) |*.*| Bitmap File(*.bmp) |*.bmp| Jpeg File(*.jpeg) |*.jpeg";
            saveFileDialog1.OverwritePrompt = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Bitmap bmp = GetFormImageWithoutBorders(this);
                Rectangle section = new Rectangle(new Point(60, 30), new Size(bmp.Width - 60, bmp.Height - 30));
                CroppedImage = CropImage(bmp, section);
                CroppedImage.Save(saveFileDialog1.FileName);
                th_Bitmap = CroppedImage.Clone() as Bitmap;
                bmp.Dispose();
                CroppedImage.Dispose();
            }
        }

        private void 아동심리ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ChangedBitmap();
            copyBitmap2RgbArray();
            copyBitmap2RgbArray25Section();
            sectionResult = new int[5, 5];
            placing = new int[25];
            int temp = 0;
            int temp2 = 0;
            int co = 0;



            for (int y = 0; y < 5; y++) { 
                for (int x = 0; x < 5; x++)
                {
                    sectionResult[y, x] = AnalysisPixelSection(y, x);
                    placing[co] = sectionResult[y, x];
                    co++;
                }
            }

            for (int i = 0; i < 24; i++)
            {
                for(int j = 0; j < 24-i; j++)
                {
                    if(placing[j]<placing[j+1])
                    {
                        temp = placing[j];
                        placing[j] = placing[j + 1];
                        placing[j + 1] = temp;
                    }
                }
            }

            LUP = (sectionResult[0, 0] + sectionResult[0, 1] + sectionResult[1, 0] + sectionResult[1, 1]) / 4;

            CUP1 = (sectionResult[0, 1] + sectionResult[0, 2] + sectionResult[1, 1] + sectionResult[1, 2]) / 4;

            CUP2 = (sectionResult[0, 2] + sectionResult[0, 3] + sectionResult[1, 2] + sectionResult[1, 3]) / 4;

            RUP = (sectionResult[0, 3] + sectionResult[0, 4] + sectionResult[1, 3] + sectionResult[1, 4]) / 4;

            Left1 = (sectionResult[1, 0] + sectionResult[1, 1] + sectionResult[2, 0] + sectionResult[2, 1]) / 4;

            Left2 = (sectionResult[2, 0] + sectionResult[2, 1] + sectionResult[3, 0] + sectionResult[3, 1]) / 4;

            Center1 = (sectionResult[1, 1] + sectionResult[1, 2] + sectionResult[2, 1] + sectionResult[2, 2]) / 4;

            Center2 = (sectionResult[1, 2] + sectionResult[1, 3] + sectionResult[2, 2] + sectionResult[2, 3]) / 4;

            Center3 = (sectionResult[2, 1] + sectionResult[2, 2] + sectionResult[3, 1] + sectionResult[3, 2]) / 4;

            Center4 = (sectionResult[2, 2] + sectionResult[2, 3] + sectionResult[3, 2] + sectionResult[3, 3]) / 4;

            Right1 = (sectionResult[1, 3] + sectionResult[1, 4] + sectionResult[2, 3] + sectionResult[2, 4]) / 4;

            Right2 = (sectionResult[2, 3] + sectionResult[2, 4] + sectionResult[3, 3] + sectionResult[3, 4]) / 4;

            LDO = (sectionResult[3, 0] + sectionResult[3, 1] + sectionResult[4, 0] + sectionResult[4, 1]) / 4;

            CDO1 = (sectionResult[3, 1] + sectionResult[3, 2] + sectionResult[4, 1] + sectionResult[4, 2]) / 4;

            CDO2 = (sectionResult[3, 2] + sectionResult[3, 3] + sectionResult[4, 2] + sectionResult[4, 3]) / 4;

            RDO = (sectionResult[3, 3] + sectionResult[3, 4] + sectionResult[4, 3] + sectionResult[4, 4]) / 4;


            int[] sectionCount;
            sectionCount = new int[16] {LUP, CUP1, CUP2, RUP, Left1, Left2, Center1, Center2, Center3, Center4, Right1, Right2, LDO, CDO1, CDO2, RDO};

            result re = new result();

            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 15 - i; j++)
                {
                    if (sectionCount[j] < sectionCount[j + 1])
                    {
                        temp2 = sectionCount[j];
                        sectionCount[j] = sectionCount[j + 1];
                        sectionCount[j + 1] = temp2;
                    }
                }
            }
            //첫번째 위치
            if (sectionCount[0] == LUP) { re.textBox4.Text = ssLUP; lotemp1 = sLUP; } // MessageBox.Show(Convert.ToString(sectionCount[0] + "% LUP!"));

            else if (sectionCount[0] == CUP1) { re.textBox4.Text = ssCUP; lotemp1 = sCUP; } //MessageBox.Show(Convert.ToString(sectionCount[0] + "% CUP1!"));

            else if (sectionCount[0] == CUP2) { re.textBox4.Text = ssCUP; lotemp1 = sCUP; }  //MessageBox.Show(Convert.ToString(sectionCount[0] + "% CUP2!"));

            else if (sectionCount[0] == RUP) { re.textBox4.Text = ssRUP; lotemp1 = sRUP; } //MessageBox.Show(Convert.ToString(sectionCount[0] + "% RUP!"));

            else if (sectionCount[0] == Left1) { re.textBox4.Text = ssLEFT; lotemp1 = sLEFT; } //MessageBox.Show(Convert.ToString(sectionCount[0] + "% Left1!"));

            else if (sectionCount[0] == Left2) { re.textBox4.Text = ssLEFT; lotemp1 = sLEFT; } //MessageBox.Show(Convert.ToString(sectionCount[0] + "% Left2!"));

            else if (sectionCount[0] == Center1) { re.textBox4.Text = ssCenter; lotemp1 = sCenter; } //MessageBox.Show(Convert.ToString(sectionCount[0] + "% Center1!"));

            else if (sectionCount[0] == Center2) { re.textBox4.Text = ssCenter; lotemp1 = sCenter; } //MessageBox.Show(Convert.ToString(sectionCount[0] + "% Center2!"));

            else if (sectionCount[0] == Center3)  { re.textBox4.Text = ssCenter;lotemp1 = sCenter; }//MessageBox.Show(Convert.ToString(sectionCount[0] + "% Center3!"));

            else if (sectionCount[0] == Center4) { re.textBox4.Text = ssCenter; lotemp1 = sCenter; } //MessageBox.Show(Convert.ToString(sectionCount[0] + "% Center4!"));

            else if (sectionCount[0] == Right1) { re.textBox4.Text = ssRight; lotemp1 = sRight; } //MessageBox.Show(Convert.ToString(sectionCount[0] + "% Right1!"));

            else if (sectionCount[0] == Right2) { re.textBox4.Text = ssRight; lotemp1 = sRight; }//MessageBox.Show(Convert.ToString(sectionCount[0] + "% Right2!"));

            else if (sectionCount[0] == LDO) { re.textBox4.Text = ssLDO; lotemp1 = sLDO; } //MessageBox.Show(Convert.ToString(sectionCount[0] + "% LDO!"));

            else if (sectionCount[0] == CDO1) { re.textBox4.Text = ssCDO; lotemp1 = sCDO; } //MessageBox.Show(Convert.ToString(sectionCount[0] + "% CDO1!"));

            else if (sectionCount[0] == CDO2) { re.textBox4.Text = ssCDO; lotemp1 = sCDO; } //MessageBox.Show(Convert.ToString(sectionCount[0] + "% CDO2!"));

            else if (sectionCount[0] == RDO) { re.textBox4.Text = sRDO; lotemp1 = sRDO; }//MessageBox.Show(Convert.ToString(sectionCount[0] + "% RDO!"));

            //두번째 위치

            if (sectionCount[1] == LUP) { re.textBox5.Text = ssLUP; lotemp2 = sLUP; } //MessageBox.Show(Convert.ToString(sectionCount[1] + "% LUP!"));

            else if (sectionCount[1] == CUP1) { re.textBox5.Text = ssCUP; lotemp2 = sCUP; } //MessageBox.Show(Convert.ToString(sectionCount[1] + "% CUP1!"));

            else if (sectionCount[1] == CUP2) { re.textBox5.Text = ssCUP; lotemp2 = sCUP; }//MessageBox.Show(Convert.ToString(sectionCount[1] + "% CUP2!"));

            else if (sectionCount[1] == RUP) { re.textBox5.Text = ssRUP; lotemp2 = sRUP; }//MessageBox.Show(Convert.ToString(sectionCount[1] + "% RUP!"));

            else if (sectionCount[1] == Left1) { re.textBox5.Text = ssLEFT; lotemp2 = sLEFT; } //MessageBox.Show(Convert.ToString(sectionCount[1] + "% Left1!"));

            else if (sectionCount[1] == Left2) { re.textBox5.Text = ssLEFT; lotemp2 = sLEFT; }//MessageBox.Show(Convert.ToString(sectionCount[1] + "% Left2!"));

            else if (sectionCount[1] == Center1) { re.textBox5.Text = ssCenter; lotemp2 = sCenter; } //MessageBox.Show(Convert.ToString(sectionCount[1] + "% Center1!"));

            else if (sectionCount[1] == Center2) { re.textBox5.Text = ssCenter; lotemp2 = sCenter; } //MessageBox.Show(Convert.ToString(sectionCount[1] + "% Center2!"));

            else if (sectionCount[1] == Center3) { re.textBox5.Text = ssCenter; lotemp2 = sCenter; } //MessageBox.Show(Convert.ToString(sectionCount[1] + "% Center3!"));

            else if (sectionCount[1] == Center4) { re.textBox5.Text = ssCenter; lotemp2 = sCenter; } //MessageBox.Show(Convert.ToString(sectionCount[1] + "% Center4!"));

            else if (sectionCount[1] == Right1) { re.textBox5.Text = ssRight; lotemp2 = sRight; } //MessageBox.Show(Convert.ToString(sectionCount[1] + "% Right1!"));

            else if (sectionCount[1] == Right2) { re.textBox5.Text = ssRight; lotemp2 = sRight; } //MessageBox.Show(Convert.ToString(sectionCount[1] + "% Right2!"));

            else if (sectionCount[1] == LDO) { re.textBox5.Text = ssLDO; lotemp2 = sLDO; } //MessageBox.Show(Convert.ToString(sectionCount[1] + "% LDO!"));

            else if (sectionCount[1] == CDO1) { re.textBox5.Text = ssCDO; lotemp2 = sCDO; } //MessageBox.Show(Convert.ToString(sectionCount[1] + "% CDO1!"));

            else if (sectionCount[1] == CDO2) { re.textBox5.Text = ssCDO; lotemp2 = sCDO; } //MessageBox.Show(Convert.ToString(sectionCount[1] + "% CDO2!"));

            else if (sectionCount[1] == RDO) { re.textBox5.Text = sRDO; lotemp2 = sRDO; } //MessageBox.Show(Convert.ToString(sectionCount[1] + "% RDO!"));

 
            for (int i = 0; i < 3; i++)
            {
                //MessageBox.Show(Convert.ToString((y + 1) + "행" + (x + 1) + "번째 영역: " + sectionResult[y, x] + "%"));
                //MessageBox.Show(Convert.ToString(placing[i] + "%"));
            }

            int[] colorCount;
            colorCount = new int[14] {cntsRe, cntsOr, cntsYe, cntsYg, cntsGe, cntsTu, cntsBl, cntsBv, cntsPu, cntsMa, cntsPi, cntsBr, cntsBu, cntsGr};

            for (int i = 0; i < 13; i++)
            {
                for (int j = 0; j < 13 - i; j++)
                {
                    if (colorCount[j] < colorCount[j + 1])
                    {
                        temp2 = colorCount[j];
                        colorCount[j] = colorCount[j + 1];
                        colorCount[j + 1] = temp2;
                    }
                }
            }

            if (colorCount[0] == cntsRe) { re.textBox2.Text = sRe; cotemp1 = Re; } //MessageBox.Show(Convert.ToString(colorCount[0] + "% 빨강!"));

            else if (colorCount[0] == cntsOr)  { re.textBox2.Text = sOr; cotemp1 = Or; }//MessageBox.Show(Convert.ToString(colorCount[0] + "% 주황!"));

            else if (colorCount[0] == cntsYe)  { re.textBox2.Text = sYe; cotemp1 = Ye; }//MessageBox.Show(Convert.ToString(colorCount[0] + "% 노랑!"));

            else if (colorCount[0] == cntsYg)  { re.textBox2.Text = sYg; cotemp1 = Yg; }//MessageBox.Show(Convert.ToString(colorCount[0] + "% 연두!"));

            else if (colorCount[0] == cntsGe)  { re.textBox2.Text = sGe;cotemp1 = Ge; }//MessageBox.Show(Convert.ToString(colorCount[0] + "% 초록!"));

            else if (colorCount[0] == cntsTu)  { re.textBox2.Text = sTu;cotemp1 = Tu; }//MessageBox.Show(Convert.ToString(colorCount[0] + "% 청록!"));

            else if (colorCount[0] == cntsBl)  { re.textBox2.Text = sBl;cotemp1 = Bl; }//MessageBox.Show(Convert.ToString(colorCount[0] + "% 파랑!"));

            else if (colorCount[0] == cntsBv)  { re.textBox2.Text = sBv;cotemp1 = Bv; }//MessageBox.Show(Convert.ToString(colorCount[0] + "% 남색!"));

            else if (colorCount[0] == cntsPu)  { re.textBox2.Text = sPu;cotemp1 = Pu; }//MessageBox.Show(Convert.ToString(colorCount[0] + "% 보라!"));

            else if (colorCount[0] == cntsMa)  { re.textBox2.Text = sMa;cotemp1 = Ma; }//MessageBox.Show(Convert.ToString(colorCount[0] + "% 자홍!"));

            else if (colorCount[0] == cntsPi)  { re.textBox2.Text = sPi;cotemp1 = Pi; }//MessageBox.Show(Convert.ToString(colorCount[0] + "% 분홍!"));

            else if (colorCount[0] == cntsBr)  { re.textBox2.Text = sBr;cotemp1 = Br; }//MessageBox.Show(Convert.ToString(colorCount[0] + "% 갈색!"));

            else if (colorCount[0] == cntsBu)  { re.textBox2.Text = sBu;cotemp1 = Bu; }//MessageBox.Show(Convert.ToString(colorCount[0] + "% 검정!"));

            else if (colorCount[0] == cntsGr) { re.textBox2.Text = sGr; cotemp1 = Gr; }//MessageBox.Show(Convert.ToString(colorCount[0] + "% 회색!"));


            //두번째 색상
            if (colorCount[1] == cntsRe) { re.textBox3.Text = sRe; cotemp2 = Re;} //MessageBox.Show(Convert.ToString(colorCount[1] + "% 빨강!"));

            else if (colorCount[1] == cntsOr) { re.textBox3.Text = sOr; cotemp2 = Or; }//MessageBox.Show(Convert.ToString(colorCount[1] + "% 주황!"));

            else if (colorCount[1] == cntsYe) { re.textBox3.Text = sYe; cotemp2 = Ye; }//MessageBox.Show(Convert.ToString(colorCount[1] + "% 노랑!"));

            else if (colorCount[1] == cntsYg) { re.textBox3.Text = sYg; cotemp2 = Yg; }//MessageBox.Show(Convert.ToString(colorCount[1] + "% 연두!"));

            else if (colorCount[1] == cntsGe) { re.textBox3.Text = sGe; cotemp2 = Ge; }//MessageBox.Show(Convert.ToString(colorCount[1] + "% 초록!"));

            else if (colorCount[1] == cntsTu) { re.textBox3.Text = sTu; cotemp2 = Tu; }//MessageBox.Show(Convert.ToString(colorCount[1] + "% 청록!"));

            else if (colorCount[1] == cntsBl) { re.textBox3.Text = sBl; cotemp2 = Bl; }//MessageBox.Show(Convert.ToString(colorCount[1] + "% 파랑!"));

            else if (colorCount[1] == cntsBv) { re.textBox3.Text = sBv; cotemp2 = Bv; }//MessageBox.Show(Convert.ToString(colorCount[1] + "% 남색!"));

            else if (colorCount[1] == cntsPu) { re.textBox3.Text = sPu; cotemp2 = Pu; }//MessageBox.Show(Convert.ToString(colorCount[1] + "% 보라!"));

            else if (colorCount[1] == cntsMa) { re.textBox3.Text = sMa; cotemp2 = Ma; }//MessageBox.Show(Convert.ToString(colorCount[1] + "% 자홍!"));

            else if (colorCount[1] == cntsPi) { re.textBox3.Text = sPi; cotemp2 = Pi; }//MessageBox.Show(Convert.ToString(colorCount[1] + "% 분홍!"));

            else if (colorCount[1] == cntsBr) { re.textBox3.Text = sBr; cotemp2 = Br; }//MessageBox.Show(Convert.ToString(colorCount[1] + "% 갈색!"));

            else if (colorCount[1] == cntsBu) { re.textBox3.Text = sBu; cotemp2 = Bu; }//MessageBox.Show(Convert.ToString(colorCount[1] + "% 검정!"));

            else if (colorCount[1] == cntsGr) { re.textBox3.Text = sGr; cotemp2 = Gr; }//MessageBox.Show(Convert.ToString(colorCount[1] + "% 회색!"));

            
            Form form2 = new Form();
            //chart1.Size = new System.Drawing.Size(300 , 300);
            ChartArea chartarea = new ChartArea();
            chartarea.Name = "bar chart";
            chart1.ChartAreas.Add(chartarea);
            chart1.Dock = DockStyle.Fill;

            chart1.Series.Clear();
            chart1.BackColor = Color.White;
            chart1.Palette = ChartColorPalette.Fire;
            chart1.ChartAreas[0].BackColor = Color.Transparent;
            chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            Series series = new Series
            {
                Name = "series2",
                IsVisibleInLegend = false,
                ChartType = SeriesChartType.Column
            };
            chart1.Series.Add(series);

            series.Points.Add((double)cntsRe / (th_copy_bitmap.Height * th_copy_bitmap.Width) * 100);
            var p1 = series.Points[0];
            p1.Color = Color.Red;
           // p1.AxisLabel = "Red";
            p1.LegendText = "test1";
            p1.Label = "Red";

            series.Points.Add((double)cntsOr / (th_copy_bitmap.Height * th_copy_bitmap.Width) * 100);
            var p2 = series.Points[1];
            p2.Color = Color.Orange;
          //  p2.AxisLabel = "Orange";
            p2.LegendText = "test2";
            p2.Label = "Orange";

            series.Points.Add(((double)cntsYe / (th_copy_bitmap.Height * th_copy_bitmap.Width)) * 100);
            var p3 = series.Points[2];
            p3.Color = Color.Yellow;
           // p3.AxisLabel = "Yellow";
            p3.LegendText = "test3";
            p3.Label = "Yellow";

            series.Points.Add(((double)cntsYg / (th_copy_bitmap.Height * th_copy_bitmap.Width)) * 100);
            var p4 = series.Points[3];
            p4.Color = Color.YellowGreen;
           // p4.AxisLabel = "YellowGreen";
            p4.LegendText = "test3";
            p4.Label = "YellowGreen";

            series.Points.Add(((double)cntsGe / (th_copy_bitmap.Height * th_copy_bitmap.Width)) * 100);
            var p5 = series.Points[4];
            p5.Color = Color.Green;
           // p5.AxisLabel = "Green";
            p5.LegendText = "test3";
            p5.Label = "Green";

            series.Points.Add(((double)cntsTu / (th_copy_bitmap.Height * th_copy_bitmap.Width)) * 100);
            var p6 = series.Points[5];
            p6.Color = Color.Turquoise;
          //  p6.AxisLabel = "Turquoise";
            p6.LegendText = "test3";
            p6.Label = "Turquoise";

            series.Points.Add(((double)cntsBl / (th_copy_bitmap.Height * th_copy_bitmap.Width)) * 100);
            var p7 = series.Points[6];
            p7.Color = Color.Blue;
           // p7.AxisLabel = "Blue";
            p7.LegendText = "test3";
            p7.Label = "Blue";

            series.Points.Add(((double)cntsBv / (th_copy_bitmap.Height * th_copy_bitmap.Width)) * 100);
            var p8 = series.Points[7];
            p8.Color = Color.Navy;
            // p8.AxisLabel = "Navy";
            p8.LegendText = "test3";
            p8.Label = "Navy";

            series.Points.Add(((double)cntsPu / (th_copy_bitmap.Height * th_copy_bitmap.Width)) * 100);
            var p9 = series.Points[8];
            p9.Color = Color.Purple;
           // p9.AxisLabel = "Purple";
            p9.LegendText = "test3";
            p9.Label = "Purple";

            series.Points.Add(((double)cntsMa / (th_copy_bitmap.Height * th_copy_bitmap.Width)) * 100);
            var p10 = series.Points[9];
            p10.Color = Color.Magenta;
           // p10.AxisLabel = "Purple";
            p10.LegendText = "test3";
            p10.Label = "Purple";

            series.Points.Add(((double)cntsPi / (th_copy_bitmap.Height * th_copy_bitmap.Width)) * 100);
            var p11 = series.Points[10];
            p11.Color = Color.Pink;
           // p11.AxisLabel = "Pink";
            p11.LegendText = "test3";
            p11.Label = "Pink";

            series.Points.Add(((double)cntsBr / (th_copy_bitmap.Height * th_copy_bitmap.Width)) * 100);
            var p12 = series.Points[11];
            p12.Color = Color.Brown;
           // p12.AxisLabel = "Brown";
            p12.LegendText = "test3";
            p12.Label = "Brown";

            series.Points.Add(((double)cntsBu / (th_copy_bitmap.Height * th_copy_bitmap.Width)) * 100);
            var p13 = series.Points[12];
            p13.Color = Color.Black;
            //p13.AxisLabel = "Black";
            p13.LegendText = "test3";
            p13.Label = "Black";

            series.Points.Add(((double)cntsGr / (th_copy_bitmap.Height * th_copy_bitmap.Width)) * 100);
            var p14 = series.Points[13];
            p14.Color = Color.Gray;
            //p14.AxisLabel = "Gray";
            p14.LegendText = "test3";
            p14.Label = "Gray";



            chart1.Invalidate();
            form2.Controls.Add(chart1);
            form2.Show();

            if (lotemp1 == lotemp2)
            {
                re.textBox1.Text = lotemp1;
            }
            else re.textBox1.Text = lotemp1 + lotemp2;

            if (CntRec > CntCir) re.textBox7.Text = rect;

            else if (CntRec < CntCir) re.textBox7.Text = cir;

            re.textBox6.Text = cotemp1 + cotemp2;
            re.Show();

            //re.ShowDialog();
            //MessageBox.Show(lotemp1 + lotemp2 + cotemp1 + cotemp2);

        }
        private void 결과보기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(lotemp1 + lotemp2 + cotemp1 + cotemp2);
            //result re = new result();
            
            
        }


        #region colorChanged Events
        private void boxBlack_Click(object sender, EventArgs e)
        {
            this.sltColor.BackColor = this.boxBlack.BackColor;
            pen.Color = this.boxBlack.BackColor;
            brush = Brushes.Black;
        }

        private void boxWhite_Click(object sender, EventArgs e)
        {
            this.sltColor.BackColor = this.boxWhite.BackColor;
            pen.Color = this.boxWhite.BackColor;
            brush = Brushes.White;
        }

        private void boxNavy_Click(object sender, EventArgs e)
        {
            this.sltColor.BackColor = this.boxNavy.BackColor;
            pen.Color = this.boxNavy.BackColor;
            brush = Brushes.Navy;
        }

        private void boxRed_Click(object sender, EventArgs e)
        {
            this.sltColor.BackColor = this.boxRed.BackColor;
            pen.Color = this.boxRed.BackColor;
            brush = Brushes.Red;
        }

        private void boxPink_Click(object sender, EventArgs e)
        {
            this.sltColor.BackColor = this.boxPurple.BackColor;
            pen.Color = this.boxPurple.BackColor;
            brush = Brushes.Purple;
        }

        private void boxOrange_Click(object sender, EventArgs e)
        {
            this.sltColor.BackColor = this.boxOrange.BackColor;
            pen.Color = this.boxOrange.BackColor;
            brush = Brushes.Orange;
        }


        private void boxYellow_Click(object sender, EventArgs e)
        {
            this.sltColor.BackColor = this.boxYellow.BackColor;
            pen.Color = this.boxYellow.BackColor;
            brush = Brushes.Yellow;
        }




        private void boxGreen_Click(object sender, EventArgs e)
        {
            this.sltColor.BackColor = this.boxGreen.BackColor;
            pen.Color = this.boxGreen.BackColor;
            brush = Brushes.Green;
        }


        private void boxBlue_Click(object sender, EventArgs e)
        {
            this.sltColor.BackColor = this.boxBlue.BackColor;
            pen.Color = this.boxBlue.BackColor;
            brush = Brushes.Blue;
        }
         

        #endregion

        #endregion

        #region Methods

        public int AnalysisPixelSection(int h, int w)
        {
            int vR, vG, vB;
            int count = 0;
            //ChangedBitmap();
            //copyBitmap2RgbArray();
            //copyBitmap2RgbArray25Section();
            int totalPixel = (th_copy_bitmap.Height * th_copy_bitmap.Width) / 25;

            for (y = (th_copy_bitmap.Height / 5) * h; y < (th_copy_bitmap.Height / 5) + ((th_copy_bitmap.Height / 5) * h); y++)
            {
                for (x = (th_copy_bitmap.Width / 5) * w; x < (th_copy_bitmap.Width / 5) + ((th_copy_bitmap.Width / 5) * w); x++)
                {

                    vB = sectionArray[h, w, 0, y, x];
                    vG = sectionArray[h, w, 1, y, x];
                    vR = sectionArray[h, w, 2, y, x];


                    if (vG != 255 || vB != 255 || vR != 255)
                    {
                        count++;
                    }


                }
            }
            return (int)((count / (double)totalPixel) * 100);
        }

        private void ChangedPenWidth(int width)
        {
            if (width < 1)
                this.pen.Width = 1;
            else
                this.pen.Width = width;
        }
  
        public void ChangedBitmap()
        {
            Bitmap bmp = GetFormImageWithoutBorders(this);
            Rectangle section = new Rectangle(new Point(60, 30), new Size(bmp.Width - 60, bmp.Height - 30));
            th_copy_bitmap = CropImage(bmp, section);
        }


        public Bitmap CropImage(Bitmap source, Rectangle section)
        {
            Bitmap bmp = new Bitmap(section.Width, section.Height);

            Graphics g = Graphics.FromImage(bmp);

            // source 이미지의 내가 원하는 범위(section)을 그린다.
            // at location 0,0 on the empty bitmap (bmp)
            g.DrawImage(source, 0, 0, section, GraphicsUnit.Pixel);
            g.Dispose();
            return bmp;
        }
        private Bitmap GetFormImageWithoutBorders(Form frm)
        {
            using (Bitmap whole_form = GetControlImage(frm))
            {

                // from the upper left corner of its client area.
                Point origin = frm.PointToScreen(new Point(0, 0));
                int dx = origin.X - frm.Left;
                int dy = origin.Y - frm.Top;

                // Copy the client area into a new Bitmap.
                int wid = frm.ClientSize.Width;
                int hgt = frm.ClientSize.Height;
                Bitmap bm = new Bitmap(wid, hgt);
                Graphics gr;
                using (gr = Graphics.FromImage(bm))
                {
                    gr.DrawImage(whole_form, 0, 0,
                        new Rectangle(dx, dy, wid, hgt),
                        GraphicsUnit.Pixel);
                    Draw(gr);
                    
                }
                
              
                return bm;
    
            }
        }

        void copyBitmap2RgbArray()
        {
            int x, y;
            Color color;
            PublicHeight = th_copy_bitmap.Height;
            PublicWidth = th_copy_bitmap.Width;
            rgbArray = new int[3, th_copy_bitmap.Height, th_copy_bitmap.Width];
            for (y = 0; y < th_copy_bitmap.Height; y++)
                for (x = 0; x < th_copy_bitmap.Width; x++)
                {
                    color = th_copy_bitmap.GetPixel(x, y);
                    rgbArray[0, y, x] = color.R;
                    rgbArray[1, y, x] = color.G;
                    rgbArray[2, y, x] = color.B;

                    spoidColor(color.R, color.G, color.B);
                }
        }
        ///////////////////////////////////////
        /// R,G,B 8구역                     ///
        /// 총 512가지 조합                 ///
        ///////////////////////////////////////
        ///
        void spoidColor(int r,int g, int b)
        {
            int tr=0,tg=0,tb=0;

            if (0 <= r && r <= 32) tr = 1;
            else if (33 <= r && r <= 65) tr = 2;
            else if (66 <= r && r <= 98) tr = 3;
            else if (99 <= r && r <= 131) tr = 4;
            else if (132 <= r  && r <= 164 ) tr = 5;
            else if (165 <= r && r <= 197) tr = 6;
            else if (198 <= r && r <= 230) tr = 7;
            else if (231 <= r && r <= 255) tr = 8;

            if (0 <= g && g <= 32) tg = 1;
            else if (33 <= g && g <= 65) tg = 2;
            else if (66 <= g && g <= 98) tg = 3;
            else if (99 <= g && g <= 131) tg = 4;
            else if (132 <= g && g <= 164) tg = 5;
            else if (165 <= g && g <= 197) tg = 6;
            else if (198 <= g && g <= 230) tg = 7;
            else if (231 <= g && g <= 255) tg = 8;

            if (0 <= b && b <= 32) tb = 1;
            else if (33 <= b && b <= 65) tb = 2;
            else if (66 <= b && b <= 98) tb = 3;
            else if (99 <= b && b <= 131) tb = 4;
            else if (132 <= b && b <= 164) tb = 5;
            else if (165 <= b && b <= 197) tb = 6;
            else if (198 <= b && b <= 230) tb = 7;
            else if (231 <= b && b <= 255) tb = 8;

            re[0] = tr;
            re[1] = tg;
            re[2] = tb;

            //빨강
            if ((re[0] == 4 &&  re[1] == 1 &&  re[2] ==1) || 
                (re[0] == 5 &&  re[1] == 1 &&  re[2] ==1) || 
                (re[0] == 5 &&  re[1] == 1 &&  re[2] ==2) || 
                (re[0] == 6 &&  re[1] == 1 &&  re[2] ==1) || 
                (re[0] == 6 &&  re[1] == 1 &&  re[2] ==2) || 
                (re[0] == 7 &&  re[1] == 1 &&  re[2] ==1) || 
                (re[0] == 7 &&  re[1] == 1 &&  re[2] ==2) || 
                (re[0] == 7 &&  re[1] == 2 &&  re[2] ==2) || 
                (re[0] == 7 &&  re[1] == 3 &&  re[2] ==3) || 
                (re[0] == 8 &&  re[1] == 1 &&  re[2] ==1) || 
                (re[0] == 8 &&  re[1] == 1 &&  re[2] ==2) || 
                (re[0] == 8 &&  re[1] == 1 &&  re[2] ==3) || 
                (re[0] == 8 &&  re[1] == 1 &&  re[2] ==4) || 
                (re[0] == 8 &&  re[1] == 2 &&  re[2] ==1) || 
                (re[0] == 8 &&  re[1] == 2 &&  re[2] ==2) || 
                (re[0] == 8 &&  re[1] == 2 &&  re[2] ==3) || 
                (re[0] == 8 &&  re[1] == 3 &&  re[2] ==4)) cntsRe++;

            //주황
            if ((re[0] == 4 &&  re[1] == 3 &&  re[2] ==1) || 
                (re[0] == 5 &&  re[1] == 3 &&  re[2] ==1) || 
                (re[0] == 5 &&  re[1] == 3 &&  re[2] ==2) || 
                (re[0] == 5 &&  re[1] == 4 &&  re[2] ==2) || 
                (re[0] == 6 &&  re[1] == 4 &&  re[2] ==1) || 
                (re[0] == 6 &&  re[1] == 4 &&  re[2] ==2) || 
                (re[0] == 6 &&  re[1] == 4 &&  re[2] ==3) || 
                (re[0] == 7 &&  re[1] == 2 &&  re[2] ==1) || 
                (re[0] == 7 &&  re[1] == 3 &&  re[2] ==1) || 
                (re[0] == 7 &&  re[1] == 3 &&  re[2] ==2) || 
                (re[0] == 7 &&  re[1] == 4 &&  re[2] ==1) || 
                (re[0] == 7 &&  re[1] == 4 &&  re[2] ==2) || 
                (re[0] == 7 &&  re[1] == 4 &&  re[2] ==3) || 
                (re[0] == 7 &&  re[1] == 5 &&  re[2] ==1) || 
                (re[0] == 7 &&  re[1] == 5 &&  re[2] ==2) || 
                (re[0] == 7 &&  re[1] == 5 &&  re[2] ==3) || 
                (re[0] == 7 &&  re[1] == 5 &&  re[2] ==4) || 
                (re[0] == 8 &&  re[1] == 3 &&  re[2] ==1) || 
                (re[0] == 8 &&  re[1] == 3 &&  re[2] ==2) || 
                (re[0] == 8 &&  re[1] == 3 &&  re[2] ==3) || 
                (re[0] == 8 &&  re[1] == 4 &&  re[2] ==1) || 
                (re[0] == 8 &&  re[1] == 4 &&  re[2] ==2) || 
                (re[0] == 8 &&  re[1] == 4 &&  re[2] ==3) || 
                (re[0] == 8 &&  re[1] == 4 &&  re[2] ==4) || 
                (re[0] == 8 &&  re[1] == 5 &&  re[2] ==1) || 
                (re[0] == 8 &&  re[1] == 5 &&  re[2] ==2) || 
                (re[0] == 8 &&  re[1] == 5 &&  re[2] ==3) || 
                (re[0] == 8 &&  re[1] == 5 &&  re[2] ==4) || 
                (re[0] == 8 &&  re[1] == 6 &&  re[2] ==1) || 
                (re[0] == 8 &&  re[1] == 6 &&  re[2] ==2) || 
                (re[0] == 8 &&  re[1] == 6 &&  re[2] ==3) || 
                (re[0] == 8 &&  re[1] == 6 &&  re[2] ==4)) cntsOr++;

            //노랑
            if ((re[0] == 4 &&  re[1] == 4 &&  re[2] ==1) || 
                (re[0] == 4 &&  re[1] == 4 &&  re[2] ==2) || 
                (re[0] == 5 &&  re[1] == 4 &&  re[2] ==1) || 
                (re[0] == 5 &&  re[1] == 5 &&  re[2] ==1) || 
                (re[0] == 5 &&  re[1] == 5 &&  re[2] ==2) || 
                (re[0] == 5 &&  re[1] == 5 &&  re[2] ==3) || 
                (re[0] == 6 &&  re[1] == 5 &&  re[2] ==1) || 
                (re[0] == 6 &&  re[1] == 5 &&  re[2] ==2) || 
                (re[0] == 6 &&  re[1] == 5 &&  re[2] ==3) || 
                (re[0] == 6 &&  re[1] == 6 &&  re[2] ==1) || 
                (re[0] == 6 &&  re[1] == 6 &&  re[2] ==2) || 
                (re[0] == 6 &&  re[1] == 6 &&  re[2] ==3) || 
                (re[0] == 6 &&  re[1] == 6 &&  re[2] ==4) || 
                (re[0] == 7 &&  re[1] == 6 &&  re[2] ==1) || 
                (re[0] == 7 &&  re[1] == 6 &&  re[2] ==2) || 
                (re[0] == 7 &&  re[1] == 6 &&  re[2] ==3) || 
                (re[0] == 7 &&  re[1] == 6 &&  re[2] ==4) || 
                (re[0] == 8 &&  re[1] == 7 &&  re[2] ==1) || 
                (re[0] == 8 &&  re[1] == 7 &&  re[2] ==2) || 
                (re[0] == 8 &&  re[1] == 7 &&  re[2] ==3) || 
                (re[0] == 8 &&  re[1] == 7 &&  re[2] ==4) || 
                (re[0] == 8 &&  re[1] == 7 &&  re[2] ==5) || 
                (re[0] == 8 &&  re[1] == 7 &&  re[2] ==6) || 
                (re[0] == 8 &&  re[1] == 8 &&  re[2] ==1) || 
                (re[0] == 8 &&  re[1] == 8 &&  re[2] ==2) || 
                (re[0] == 8 &&  re[1] == 8 &&  re[2] ==3) || 
                (re[0] == 8 &&  re[1] == 8 &&  re[2] ==4) || 
                (re[0] == 8 &&  re[1] == 8 &&  re[2] ==5) || 
                (re[0] == 8 &&  re[1] == 8 &&  re[2] ==6)) cntsYe++;

            //연두
            if ((re[0] == 1 &&  re[1] == 7 &&  re[2] ==4) || 
                (re[0] == 3 &&  re[1] == 8 &&  re[2] ==5) || 
                (re[0] == 4 &&  re[1] == 6 &&  re[2] ==1) || 
                (re[0] == 4 &&  re[1] == 6 &&  re[2] ==2) || 
                (re[0] == 4 &&  re[1] == 6 &&  re[2] ==3) || 
                (re[0] == 4 &&  re[1] == 6 &&  re[2] ==4) || 
                (re[0] == 4 &&  re[1] == 8 &&  re[2] ==5) || 
                (re[0] == 5 &&  re[1] == 6 &&  re[2] ==1) || 
                (re[0] == 5 &&  re[1] == 6 &&  re[2] ==2) || 
                (re[0] == 5 &&  re[1] == 6 &&  re[2] ==3) || 
                (re[0] == 5 &&  re[1] == 6 &&  re[2] ==4) || 
                (re[0] == 5 &&  re[1] == 6 &&  re[2] ==5) || 
                (re[0] == 5 &&  re[1] == 7 &&  re[2] ==1) || 
                (re[0] == 5 &&  re[1] == 7 &&  re[2] ==2) || 
                (re[0] == 5 &&  re[1] == 7 &&  re[2] ==3) || 
                (re[0] == 5 &&  re[1] == 7 &&  re[2] ==4) || 
                (re[0] == 5 &&  re[1] == 7 &&  re[2] ==5) || 
                (re[0] == 5 &&  re[1] == 8 &&  re[2] ==1) || 
                (re[0] == 5 &&  re[1] == 8 &&  re[2] ==2) || 
                (re[0] == 5 &&  re[1] == 8 &&  re[2] ==3) || 
                (re[0] == 5 &&  re[1] == 8 &&  re[2] ==4) || 
                (re[0] == 5 &&  re[1] == 8 &&  re[2] ==5) || 
                (re[0] == 5 &&  re[1] == 8 &&  re[2] ==6) || 
                (re[0] == 6 &&  re[1] == 7 &&  re[2] ==1) || 
                (re[0] == 6 &&  re[1] == 7 &&  re[2] ==2) || 
                (re[0] == 6 &&  re[1] == 7 &&  re[2] ==3) || 
                (re[0] == 6 &&  re[1] == 7 &&  re[2] ==4) || 
                (re[0] == 6 &&  re[1] == 7 &&  re[2] ==5) || 
                (re[0] == 6 &&  re[1] == 7 &&  re[2] ==6) || 
                (re[0] == 6 &&  re[1] == 8 &&  re[2] ==1) || 
                (re[0] == 6 &&  re[1] == 8 &&  re[2] ==2) || 
                (re[0] == 6 &&  re[1] == 8 &&  re[2] ==3) || 
                (re[0] == 6 &&  re[1] == 8 &&  re[2] ==4) || 
                (re[0] == 6 &&  re[1] == 8 &&  re[2] ==5) || 
                (re[0] == 7 &&  re[1] == 7 &&  re[2] ==1) || 
                (re[0] == 7 &&  re[1] == 7 &&  re[2] ==2) || 
                (re[0] == 7 &&  re[1] == 7 &&  re[2] ==3) || 
                (re[0] == 7 &&  re[1] == 7 &&  re[2] ==4) || 
                (re[0] == 7 &&  re[1] == 7 &&  re[2] ==5) || 
                (re[0] == 7 &&  re[1] == 8 &&  re[2] ==1) || 
                (re[0] == 7 &&  re[1] == 8 &&  re[2] ==2) || 
                (re[0] == 7 &&  re[1] == 8 &&  re[2] ==3) || 
                (re[0] == 7 &&  re[1] == 8 &&  re[2] ==4) || 
                (re[0] == 7 &&  re[1] == 8 &&  re[2] ==5) || 
                (re[0] == 7 &&  re[1] == 8 &&  re[2] ==6) || 
                (re[0] == 7 &&  re[1] == 8 &&  re[2] ==7)) cntsYg++;

            //초록
            if ((re[0] == 1 &&  re[1] == 2 &&  re[2] ==1) || 
                (re[0] == 1 &&  re[1] == 3 &&  re[2] ==1) || 
                (re[0] == 1 &&  re[1] == 4 &&  re[2] ==1) || 
                (re[0] == 1 &&  re[1] == 4 &&  re[2] ==2) || 
                (re[0] == 1 &&  re[1] == 5 &&  re[2] ==1) || 
                (re[0] == 1 &&  re[1] == 5 &&  re[2] ==2) || 
                (re[0] == 1 &&  re[1] == 5 &&  re[2] ==3) || 
                (re[0] == 1 &&  re[1] == 6 &&  re[2] ==1) || 
                (re[0] == 1 &&  re[1] == 6 &&  re[2] ==2) || 
                (re[0] == 1 &&  re[1] == 6 &&  re[2] ==3) || 
                (re[0] == 1 &&  re[1] == 7 &&  re[2] ==1) || 
                (re[0] == 1 &&  re[1] == 7 &&  re[2] ==2) || 
                (re[0] == 1 &&  re[1] == 7 &&  re[2] ==3) || 
                (re[0] == 1 &&  re[1] == 8 &&  re[2] ==1) || 
                (re[0] == 1 &&  re[1] == 8 &&  re[2] ==2) || 
                (re[0] == 1 &&  re[1] == 8 &&  re[2] ==3) || 
                (re[0] == 1 &&  re[1] == 8 &&  re[2] ==4) || 
                (re[0] == 2 &&  re[1] == 3 &&  re[2] ==1) || 
                (re[0] == 2 &&  re[1] == 3 &&  re[2] ==2) || 
                (re[0] == 2 &&  re[1] == 4 &&  re[2] ==1) || 
                (re[0] == 2 &&  re[1] == 4 &&  re[2] ==2) || 
                (re[0] == 2 &&  re[1] == 5 &&  re[2] ==1) || 
                (re[0] == 2 &&  re[1] == 5 &&  re[2] ==2) || 
                (re[0] == 2 &&  re[1] == 5 &&  re[2] ==3) || 
                (re[0] == 2 &&  re[1] == 6 &&  re[2] ==1) || 
                (re[0] == 2 &&  re[1] == 6 &&  re[2] ==2) || 
                (re[0] == 2 &&  re[1] == 6 &&  re[2] ==3) || 
                (re[0] == 2 &&  re[1] == 7 &&  re[2] ==1) || 
                (re[0] == 2 &&  re[1] == 7 &&  re[2] ==2) || 
                (re[0] == 2 &&  re[1] == 7 &&  re[2] ==3) || 
                (re[0] == 2 &&  re[1] == 8 &&  re[2] ==1) || 
                (re[0] == 2 &&  re[1] == 8 &&  re[2] ==2) || 
                (re[0] == 2 &&  re[1] == 8 &&  re[2] ==3) || 
                (re[0] == 2 &&  re[1] == 8 &&  re[2] ==4) || 
                (re[0] == 3 &&  re[1] == 4 &&  re[2] ==1) || 
                (re[0] == 3 &&  re[1] == 4 &&  re[2] ==2) || 
                (re[0] == 3 &&  re[1] == 4 &&  re[2] ==3) || 
                (re[0] == 3 &&  re[1] == 5 &&  re[2] ==1) || 
                (re[0] == 3 &&  re[1] == 5 &&  re[2] ==2) || 
                (re[0] == 3 &&  re[1] == 5 &&  re[2] ==3) || 
                (re[0] == 3 &&  re[1] == 6 &&  re[2] ==1) || 
                (re[0] == 3 &&  re[1] == 6 &&  re[2] ==2) || 
                (re[0] == 3 &&  re[1] == 6 &&  re[2] ==3) || 
                (re[0] == 3 &&  re[1] == 7 &&  re[2] ==1) || 
                (re[0] == 3 &&  re[1] == 7 &&  re[2] ==2) || 
                (re[0] == 3 &&  re[1] == 7 &&  re[2] ==3) || 
                (re[0] == 3 &&  re[1] == 8 &&  re[2] ==1) || 
                (re[0] == 3 &&  re[1] == 8 &&  re[2] ==2) || 
                (re[0] == 3 &&  re[1] == 8 &&  re[2] ==3) || 
                (re[0] == 3 &&  re[1] == 8 &&  re[2] ==4) || 
                (re[0] == 4 &&  re[1] == 5 &&  re[2] ==1) || 
                (re[0] == 4 &&  re[1] == 5 &&  re[2] ==2) || 
                (re[0] == 4 &&  re[1] == 5 &&  re[2] ==3) || 
                (re[0] == 4 &&  re[1] == 7 &&  re[2] ==1) || 
                (re[0] == 4 &&  re[1] == 7 &&  re[2] ==2) || 
                (re[0] == 4 &&  re[1] == 7 &&  re[2] ==3) || 
                (re[0] == 4 &&  re[1] == 7 &&  re[2] ==4) || 
                (re[0] == 4 &&  re[1] == 7 &&  re[2] ==5) || 
                (re[0] == 4 &&  re[1] == 8 &&  re[2] ==1) || 
                (re[0] == 4 &&  re[1] == 8 &&  re[2] ==2) || 
                (re[0] == 4 &&  re[1] == 8 &&  re[2] ==3) || 
                (re[0] == 4 &&  re[1] == 8 &&  re[2] ==4) || 
                (re[0] == 5 &&  re[1] == 7 &&  re[2] ==6) || 
                (re[0] == 6 &&  re[1] == 8 &&  re[2] ==6)) cntsGe++;

            //청록
            if ((re[0] == 1 &&  re[1] == 2 &&  re[2] ==2) || 
                (re[0] == 1 &&  re[1] == 3 &&  re[2] ==2) || 
                (re[0] == 1 &&  re[1] == 3 &&  re[2] ==3) || 
                (re[0] == 1 &&  re[1] == 3 &&  re[2] ==4) || 
                (re[0] == 1 &&  re[1] == 4 &&  re[2] ==3) || 
                (re[0] == 1 &&  re[1] == 4 &&  re[2] ==4) || 
                (re[0] == 1 &&  re[1] == 4 &&  re[2] ==5) || 
                (re[0] == 1 &&  re[1] == 5 &&  re[2] ==4) || 
                (re[0] == 1 &&  re[1] == 5 &&  re[2] ==5) || 
                (re[0] == 1 &&  re[1] == 6 &&  re[2] ==4) || 
                (re[0] == 1 &&  re[1] == 6 &&  re[2] ==5) || 
                (re[0] == 1 &&  re[1] == 6 &&  re[2] ==6) || 
                (re[0] == 1 &&  re[1] == 7 &&  re[2] ==5) || 
                (re[0] == 1 &&  re[1] == 7 &&  re[2] ==6) || 
                (re[0] == 1 &&  re[1] == 7 &&  re[2] ==7) || 
                (re[0] == 1 &&  re[1] == 8 &&  re[2] ==5) || 
                (re[0] == 1 &&  re[1] == 8 &&  re[2] ==6) || 
                (re[0] == 1 &&  re[1] == 8 &&  re[2] ==7) || 
                (re[0] == 2 &&  re[1] == 4 &&  re[2] ==3) || 
                (re[0] == 2 &&  re[1] == 4 &&  re[2] ==4) || 
                (re[0] == 2 &&  re[1] == 5 &&  re[2] ==4) || 
                (re[0] == 2 &&  re[1] == 5 &&  re[2] ==5) || 
                (re[0] == 2 &&  re[1] == 6 &&  re[2] ==4) || 
                (re[0] == 2 &&  re[1] == 6 &&  re[2] ==5) || 
                (re[0] == 2 &&  re[1] == 6 &&  re[2] ==6) || 
                (re[0] == 2 &&  re[1] == 7 &&  re[2] ==4) || 
                (re[0] == 2 &&  re[1] == 7 &&  re[2] ==5) || 
                (re[0] == 2 &&  re[1] == 8 &&  re[2] ==5) || 
                (re[0] == 2 &&  re[1] == 8 &&  re[2] ==6) || 
                (re[0] == 2 &&  re[1] == 8 &&  re[2] ==7) || 
                (re[0] == 3 &&  re[1] == 5 &&  re[2] ==4) || 
                (re[0] == 3 &&  re[1] == 5 &&  re[2] ==5) || 
                (re[0] == 3 &&  re[1] == 6 &&  re[2] ==4) || 
                (re[0] == 3 &&  re[1] == 6 &&  re[2] ==6) || 
                (re[0] == 3 &&  re[1] == 7 &&  re[2] ==4) || 
                (re[0] == 3 &&  re[1] == 7 &&  re[2] ==5) || 
                (re[0] == 3 &&  re[1] == 7 &&  re[2] ==6) || 
                (re[0] == 3 &&  re[1] == 8 &&  re[2] ==6) || 
                (re[0] == 3 &&  re[1] == 8 &&  re[2] ==7) || 
                (re[0] == 4 &&  re[1] == 6 &&  re[2] ==5) || 
                (re[0] == 4 &&  re[1] == 6 &&  re[2] ==6) || 
                (re[0] == 4 &&  re[1] == 6 &&  re[2] ==7) || 
                (re[0] == 4 &&  re[1] == 7 &&  re[2] ==6) || 
                (re[0] == 4 &&  re[1] == 7 &&  re[2] ==7) || 
                (re[0] == 4 &&  re[1] == 8 &&  re[2] ==6) || 
                (re[0] == 4 &&  re[1] == 8 &&  re[2] ==7) || 
                (re[0] == 5 &&  re[1] == 8 &&  re[2] ==7)) cntsTu++;

            //파랑
            if ((re[0] == 1 &&  re[1] == 1 &&  re[2] ==6) || 
                (re[0] == 1 &&  re[1] == 1 &&  re[2] ==7) || 
                (re[0] == 1 &&  re[1] == 1 &&  re[2] ==8) || 
                (re[0] == 1 &&  re[1] == 2 &&  re[2] ==4) || 
                (re[0] == 1 &&  re[1] == 2 &&  re[2] ==5) || 
                (re[0] == 1 &&  re[1] == 2 &&  re[2] ==6) || 
                (re[0] == 1 &&  re[1] == 2 &&  re[2] ==7) || 
                (re[0] == 1 &&  re[1] == 2 &&  re[2] ==8) || 
                (re[0] == 1 &&  re[1] == 3 &&  re[2] ==5) || 
                (re[0] == 1 &&  re[1] == 3 &&  re[2] ==6) || 
                (re[0] == 1 &&  re[1] == 3 &&  re[2] ==7) || 
                (re[0] == 1 &&  re[1] == 3 &&  re[2] ==8) || 
                (re[0] == 1 &&  re[1] == 4 &&  re[2] ==6) || 
                (re[0] == 1 &&  re[1] == 4 &&  re[2] ==7) || 
                (re[0] == 1 &&  re[1] == 4 &&  re[2] ==8) || 
                (re[0] == 1 &&  re[1] == 5 &&  re[2] ==6) || 
                (re[0] == 1 &&  re[1] == 5 &&  re[2] ==7) || 
                (re[0] == 1 &&  re[1] == 5 &&  re[2] ==8) || 
                (re[0] == 1 &&  re[1] == 6 &&  re[2] ==7) || 
                (re[0] == 1 &&  re[1] == 6 &&  re[2] ==8) || 
                (re[0] == 1 &&  re[1] == 7 &&  re[2] ==8) || 
                (re[0] == 1 &&  re[1] == 8 &&  re[2] ==8) || 
                (re[0] == 2 &&  re[1] == 4 &&  re[2] ==5) || 
                (re[0] == 2 &&  re[1] == 4 &&  re[2] ==6) || 
                (re[0] == 2 &&  re[1] == 4 &&  re[2] ==7) || 
                (re[0] == 2 &&  re[1] == 4 &&  re[2] ==8) || 
                (re[0] == 2 &&  re[1] == 5 &&  re[2] ==6) || 
                (re[0] == 2 &&  re[1] == 5 &&  re[2] ==7) || 
                (re[0] == 2 &&  re[1] == 5 &&  re[2] ==8) || 
                (re[0] == 2 &&  re[1] == 6 &&  re[2] ==7) || 
                (re[0] == 2 &&  re[1] == 6 &&  re[2] ==8) || 
                (re[0] == 2 &&  re[1] == 7 &&  re[2] ==6) || 
                (re[0] == 2 &&  re[1] == 7 &&  re[2] ==7) || 
                (re[0] == 2 &&  re[1] == 7 &&  re[2] ==8) || 
                (re[0] == 2 &&  re[1] == 8 &&  re[2] ==8) || 
                (re[0] == 3 &&  re[1] == 4 &&  re[2] ==6) || 
                (re[0] == 3 &&  re[1] == 4 &&  re[2] ==7) || 
                (re[0] == 3 &&  re[1] == 4 &&  re[2] ==8) || 
                (re[0] == 3 &&  re[1] == 5 &&  re[2] ==6) || 
                (re[0] == 3 &&  re[1] == 5 &&  re[2] ==7) || 
                (re[0] == 3 &&  re[1] == 5 &&  re[2] ==8) || 
                (re[0] == 3 &&  re[1] == 6 &&  re[2] ==5) || 
                (re[0] == 3 &&  re[1] == 6 &&  re[2] ==7) || 
                (re[0] == 3 &&  re[1] == 6 &&  re[2] ==8) || 
                (re[0] == 3 &&  re[1] == 7 &&  re[2] ==7) || 
                (re[0] == 3 &&  re[1] == 7 &&  re[2] ==8) || 
                (re[0] == 3 &&  re[1] == 8 &&  re[2] ==8) || 
                (re[0] == 4 &&  re[1] == 5 &&  re[2] ==7) || 
                (re[0] == 4 &&  re[1] == 5 &&  re[2] ==8) || 
                (re[0] == 4 &&  re[1] == 6 &&  re[2] ==8) || 
                (re[0] == 4 &&  re[1] == 7 &&  re[2] ==8) || 
                (re[0] == 4 &&  re[1] == 8 &&  re[2] ==8) || 
                (re[0] == 5 &&  re[1] == 6 &&  re[2] ==7) || 
                (re[0] == 5 &&  re[1] == 6 &&  re[2] ==8) || 
                (re[0] == 5 &&  re[1] == 7 &&  re[2] ==7) || 
                (re[0] == 5 &&  re[1] == 7 &&  re[2] ==8) || 
                (re[0] == 5 &&  re[1] == 8 &&  re[2] ==8) || 
                (re[0] == 6 &&  re[1] == 7 &&  re[2] ==7) || 
                (re[0] == 6 &&  re[1] == 7 &&  re[2] ==8) || 
                (re[0] == 6 &&  re[1] == 8 &&  re[2] ==7) || 
                (re[0] == 6 &&  re[1] == 8 &&  re[2] ==8) || 
                (re[0] == 7 &&  re[1] == 8 &&  re[2] ==8)) cntsBl++;

            //남색
            if ((re[0] == 1 &&  re[1] == 1 &&  re[2] ==2) || 
                (re[0] == 1 &&  re[1] == 1 &&  re[2] ==3) || 
                (re[0] == 1 &&  re[1] == 1 &&  re[2] ==4) || 
                (re[0] == 1 &&  re[1] == 1 &&  re[2] ==5) || 
                (re[0] == 1 &&  re[1] == 2 &&  re[2] ==3) || 
                (re[0] == 2 &&  re[1] == 3 &&  re[2] ==4) || 
                (re[0] == 2 &&  re[1] == 3 &&  re[2] ==5) || 
                (re[0] == 2 &&  re[1] == 3 &&  re[2] ==6) || 
                (re[0] == 2 &&  re[1] == 3 &&  re[2] ==7) || 
                (re[0] == 2 &&  re[1] == 3 &&  re[2] ==8) || 
                (re[0] == 3 &&  re[1] == 4 &&  re[2] ==5) || 
                (re[0] == 4 &&  re[1] == 5 &&  re[2] ==6) || 
                (re[0] == 5 &&  re[1] == 5 &&  re[2] ==7) || 
                (re[0] == 5 &&  re[1] == 5 &&  re[2] ==8) || 
                (re[0] == 6 &&  re[1] == 6 &&  re[2] ==8)) cntsBv++;
            
            //보라
            if ((re[0] == 2 &&  re[1] == 1 &&  re[2] ==2) || 
                (re[0] == 2 &&  re[1] == 1 &&  re[2] ==3) || 
                (re[0] == 2 &&  re[1] == 1 &&  re[2] ==4) || 
                (re[0] == 2 &&  re[1] == 1 &&  re[2] ==5) || 
                (re[0] == 2 &&  re[1] == 1 &&  re[2] ==6) || 
                (re[0] == 2 &&  re[1] == 1 &&  re[2] ==7) || 
                (re[0] == 2 &&  re[1] == 1 &&  re[2] ==8) || 
                (re[0] == 2 &&  re[1] == 2 &&  re[2] ==4) || 
                (re[0] == 2 &&  re[1] == 2 &&  re[2] ==5) || 
                (re[0] == 2 &&  re[1] == 2 &&  re[2] ==6) || 
                (re[0] == 2 &&  re[1] == 2 &&  re[2] ==7) || 
                (re[0] == 2 &&  re[1] == 2 &&  re[2] ==8) || 
                (re[0] == 3 &&  re[1] == 1 &&  re[2] ==2) || 
                (re[0] == 3 &&  re[1] == 1 &&  re[2] ==3) || 
                (re[0] == 3 &&  re[1] == 1 &&  re[2] ==4) || 
                (re[0] == 3 &&  re[1] == 1 &&  re[2] ==5) || 
                (re[0] == 3 &&  re[1] == 1 &&  re[2] ==6) || 
                (re[0] == 3 &&  re[1] == 1 &&  re[2] ==7) || 
                (re[0] == 3 &&  re[1] == 1 &&  re[2] ==8) || 
                (re[0] == 3 &&  re[1] == 2 &&  re[2] ==3) || 
                (re[0] == 3 &&  re[1] == 2 &&  re[2] ==4) || 
                (re[0] == 3 &&  re[1] == 2 &&  re[2] ==5) || 
                (re[0] == 3 &&  re[1] == 2 &&  re[2] ==6) || 
                (re[0] == 3 &&  re[1] == 2 &&  re[2] ==7) || 
                (re[0] == 3 &&  re[1] == 2 &&  re[2] ==8) || 
                (re[0] == 3 &&  re[1] == 3 &&  re[2] ==5) || 
                (re[0] == 3 &&  re[1] == 3 &&  re[2] ==6) || 
                (re[0] == 3 &&  re[1] == 3 &&  re[2] ==7) || 
                (re[0] == 3 &&  re[1] == 3 &&  re[2] ==8) || 
                (re[0] == 4 &&  re[1] == 1 &&  re[2] ==4) || 
                (re[0] == 4 &&  re[1] == 1 &&  re[2] ==5) || 
                (re[0] == 4 &&  re[1] == 1 &&  re[2] ==6) || 
                (re[0] == 4 &&  re[1] == 1 &&  re[2] ==7) || 
                (re[0] == 4 &&  re[1] == 1 &&  re[2] ==8) || 
                (re[0] == 4 &&  re[1] == 2 &&  re[2] ==4) || 
                (re[0] == 4 &&  re[1] == 2 &&  re[2] ==5) || 
                (re[0] == 4 &&  re[1] == 2 &&  re[2] ==6) || 
                (re[0] == 4 &&  re[1] == 2 &&  re[2] ==7) || 
                (re[0] == 4 &&  re[1] == 2 &&  re[2] ==8) || 
                (re[0] == 4 &&  re[1] == 3 &&  re[2] ==5) || 
                (re[0] == 4 &&  re[1] == 3 &&  re[2] ==6) || 
                (re[0] == 4 &&  re[1] == 3 &&  re[2] ==7) || 
                (re[0] == 4 &&  re[1] == 3 &&  re[2] ==8) || 
                (re[0] == 4 &&  re[1] == 4 &&  re[2] ==6) || 
                (re[0] == 4 &&  re[1] == 4 &&  re[2] ==7) || 
                (re[0] == 4 &&  re[1] == 4 &&  re[2] ==8) || 
                (re[0] == 5 &&  re[1] == 1 &&  re[2] ==5) || 
                (re[0] == 5 &&  re[1] == 1 &&  re[2] ==6) || 
                (re[0] == 5 &&  re[1] == 1 &&  re[2] ==7) || 
                (re[0] == 5 &&  re[1] == 1 &&  re[2] ==8) || 
                (re[0] == 5 &&  re[1] == 2 &&  re[2] ==4) || 
                (re[0] == 5 &&  re[1] == 2 &&  re[2] ==5) || 
                (re[0] == 5 &&  re[1] == 2 &&  re[2] ==6) || 
                (re[0] == 5 &&  re[1] == 2 &&  re[2] ==7) || 
                (re[0] == 5 &&  re[1] == 2 &&  re[2] ==8) || 
                (re[0] == 5 &&  re[1] == 3 &&  re[2] ==5) || 
                (re[0] == 5 &&  re[1] == 3 &&  re[2] ==6) || 
                (re[0] == 5 &&  re[1] == 3 &&  re[2] ==7) || 
                (re[0] == 5 &&  re[1] == 3 &&  re[2] ==8) || 
                (re[0] == 5 &&  re[1] == 4 &&  re[2] ==6) || 
                (re[0] == 5 &&  re[1] == 4 &&  re[2] ==7) || 
                (re[0] == 5 &&  re[1] == 4 &&  re[2] ==8) || 
                (re[0] == 6 &&  re[1] == 1 &&  re[2] ==6) || 
                (re[0] == 6 &&  re[1] == 1 &&  re[2] ==7) || 
                (re[0] == 6 &&  re[1] == 1 &&  re[2] ==8) || 
                (re[0] == 6 &&  re[1] == 2 &&  re[2] ==5) || 
                (re[0] == 6 &&  re[1] == 2 &&  re[2] ==6) || 
                (re[0] == 6 &&  re[1] == 2 &&  re[2] ==7) || 
                (re[0] == 6 &&  re[1] == 2 &&  re[2] ==8) || 
                (re[0] == 6 &&  re[1] == 3 &&  re[2] ==6) || 
                (re[0] == 6 &&  re[1] == 3 &&  re[2] ==7) || 
                (re[0] == 6 &&  re[1] == 3 &&  re[2] ==8) || 
                (re[0] == 6 &&  re[1] == 4 &&  re[2] ==5) || 
                (re[0] == 6 &&  re[1] == 4 &&  re[2] ==6) || 
                (re[0] == 6 &&  re[1] == 4 &&  re[2] ==7) || 
                (re[0] == 6 &&  re[1] == 4 &&  re[2] ==8) || 
                (re[0] == 6 &&  re[1] == 5 &&  re[2] ==6) || 
                (re[0] == 6 &&  re[1] == 5 &&  re[2] ==7) || 
                (re[0] == 6 &&  re[1] == 5 &&  re[2] ==8) || 
                (re[0] == 7 &&  re[1] == 1 &&  re[2] ==8) || 
                (re[0] == 7 &&  re[1] == 2 &&  re[2] ==6) || 
                (re[0] == 7 &&  re[1] == 2 &&  re[2] ==7) || 
                (re[0] == 7 &&  re[1] == 2 &&  re[2] ==8) || 
                (re[0] == 7 &&  re[1] == 3 &&  re[2] ==6) || 
                (re[0] == 7 &&  re[1] == 3 &&  re[2] ==7) || 
                (re[0] == 7 &&  re[1] == 3 &&  re[2] ==8) || 
                (re[0] == 7 &&  re[1] == 4 &&  re[2] ==7) || 
                (re[0] == 7 &&  re[1] == 4 &&  re[2] ==8) || 
                (re[0] == 7 &&  re[1] == 5 &&  re[2] ==8) || 
                (re[0] == 8 &&  re[1] == 1 &&  re[2] ==8) || 
                (re[0] == 8 &&  re[1] == 2 &&  re[2] ==6) || 
                (re[0] == 8 &&  re[1] == 2 &&  re[2] ==7) || 
                (re[0] == 8 &&  re[1] == 2 &&  re[2] ==8) || 
                (re[0] == 8 &&  re[1] == 3 &&  re[2] ==7) || 
                (re[0] == 8 &&  re[1] == 3 &&  re[2] ==8)) cntsPu++;

            //자홍
            if ((re[0] == 4 &&  re[1] == 1 &&  re[2] ==2) || 
                (re[0] == 4 &&  re[1] == 1 &&  re[2] ==3) || 
                (re[0] == 4 &&  re[1] == 2 &&  re[2] ==3) || 
                (re[0] == 5 &&  re[1] == 1 &&  re[2] ==3) || 
                (re[0] == 5 &&  re[1] == 1 &&  re[2] ==4) || 
                (re[0] == 6 &&  re[1] == 1 &&  re[2] ==3) || 
                (re[0] == 6 &&  re[1] == 1 &&  re[2] ==4) || 
                (re[0] == 6 &&  re[1] == 1 &&  re[2] ==5) || 
                (re[0] == 7 &&  re[1] == 1 &&  re[2] ==3) || 
                (re[0] == 8 &&  re[1] == 1 &&  re[2] ==5) || 
                (re[0] == 8 &&  re[1] == 2 &&  re[2] ==4) || 
                (re[0] == 8 &&  re[1] == 2 &&  re[2] ==5)) cntsMa++;

            //분홍
            if ((re[0] == 5 &&  re[1] == 3 &&  re[2] ==4) || 
                (re[0] == 6 &&  re[1] == 2 &&  re[2] ==3) || 
                (re[0] == 6 &&  re[1] == 2 &&  re[2] ==4) || 
                (re[0] == 6 &&  re[1] == 3 &&  re[2] ==3) || 
                (re[0] == 6 &&  re[1] == 3 &&  re[2] ==4) || 
                (re[0] == 6 &&  re[1] == 3 &&  re[2] ==5) || 
                (re[0] == 6 &&  re[1] == 4 &&  re[2] ==4) || 
                (re[0] == 6 &&  re[1] == 5 &&  re[2] ==4) || 
                (re[0] == 6 &&  re[1] == 5 &&  re[2] ==5) || 
                (re[0] == 7 &&  re[1] == 1 &&  re[2] ==4) || 
                (re[0] == 7 &&  re[1] == 1 &&  re[2] ==5) || 
                (re[0] == 7 &&  re[1] == 1 &&  re[2] ==6) || 
                (re[0] == 7 &&  re[1] == 1 &&  re[2] ==7) || 
                (re[0] == 7 &&  re[1] == 2 &&  re[2] ==3) || 
                (re[0] == 7 &&  re[1] == 2 &&  re[2] ==4) || 
                (re[0] == 7 &&  re[1] == 2 &&  re[2] ==5) || 
                (re[0] == 7 &&  re[1] == 3 &&  re[2] ==4) || 
                (re[0] == 7 &&  re[1] == 3 &&  re[2] ==5) || 
                (re[0] == 7 &&  re[1] == 4 &&  re[2] ==4) || 
                (re[0] == 7 &&  re[1] == 4 &&  re[2] ==5) || 
                (re[0] == 7 &&  re[1] == 4 &&  re[2] ==6) || 
                (re[0] == 7 &&  re[1] == 5 &&  re[2] ==5) || 
                (re[0] == 7 &&  re[1] == 5 &&  re[2] ==6) || 
                (re[0] == 7 &&  re[1] == 5 &&  re[2] ==7) || 
                (re[0] == 7 &&  re[1] == 6 &&  re[2] ==6) || 
                (re[0] == 7 &&  re[1] == 6 &&  re[2] ==7) || 
                (re[0] == 7 &&  re[1] == 6 &&  re[2] ==8) || 
                (re[0] == 8 &&  re[1] == 1 &&  re[2] ==6) || 
                (re[0] == 8 &&  re[1] == 1 &&  re[2] ==7) || 
                (re[0] == 8 &&  re[1] == 3 &&  re[2] ==5) || 
                (re[0] == 8 &&  re[1] == 3 &&  re[2] ==6) || 
                (re[0] == 8 &&  re[1] == 4 &&  re[2] ==5) || 
                (re[0] == 8 &&  re[1] == 4 &&  re[2] ==6) || 
                (re[0] == 8 &&  re[1] == 4 &&  re[2] ==7) || 
                (re[0] == 8 &&  re[1] == 4 &&  re[2] ==8) || 
                (re[0] == 8 &&  re[1] == 5 &&  re[2] ==5) || 
                (re[0] == 8 &&  re[1] == 5 &&  re[2] ==6) || 
                (re[0] == 8 &&  re[1] == 5 &&  re[2] ==7) || 
                (re[0] == 8 &&  re[1] == 5 &&  re[2] ==8) || 
                (re[0] == 8 &&  re[1] == 6 &&  re[2] ==5) || 
                (re[0] == 8 &&  re[1] == 6 &&  re[2] ==6) || 
                (re[0] == 8 &&  re[1] == 6 &&  re[2] ==7) || 
                (re[0] == 8 &&  re[1] == 6 &&  re[2] ==8) || 
                (re[0] == 8 &&  re[1] == 7 &&  re[2] ==7) || 
                (re[0] == 8 &&  re[1] == 7 &&  re[2] ==8)) cntsPi++;

            //갈색
            if ((re[0] == 2 &&  re[1] == 1 &&  re[2] ==1) || 
                (re[0] == 2 &&  re[1] == 2 &&  re[2] ==1) || 
                (re[0] == 3 &&  re[1] == 1 &&  re[2] ==1) || 
                (re[0] == 3 &&  re[1] == 2 &&  re[2] ==1) || 
                (re[0] == 3 &&  re[1] == 2 &&  re[2] ==2) || 
                (re[0] == 3 &&  re[1] == 3 &&  re[2] ==1) || 
                (re[0] == 4 &&  re[1] == 2 &&  re[2] ==1) || 
                (re[0] == 4 &&  re[1] == 2 &&  re[2] ==2) || 
                (re[0] == 4 &&  re[1] == 3 &&  re[2] ==2) || 
                (re[0] == 5 &&  re[1] == 2 &&  re[2] ==1) || 
                (re[0] == 5 &&  re[1] == 2 &&  re[2] ==2) || 
                (re[0] == 5 &&  re[1] == 2 &&  re[2] ==3) || 
                (re[0] == 5 &&  re[1] == 3 &&  re[2] ==3) || 
                (re[0] == 5 &&  re[1] == 4 &&  re[2] ==3) || 
                (re[0] == 6 &&  re[1] == 2 &&  re[2] ==1) || 
                (re[0] == 6 &&  re[1] == 2 &&  re[2] ==2) || 
                (re[0] == 6 &&  re[1] == 3 &&  re[2] ==1) || 
                (re[0] == 6 &&  re[1] == 3 &&  re[2] ==2) || 
                (re[0] == 7 &&  re[1] == 6 &&  re[2] ==5)) cntsBr++;

            //검정
            if ((re[0] == 1 &&  re[1] == 1 &&  re[2] ==1) || 
                (re[0] == 2 &&  re[1] == 2 &&  re[2] ==2)) cntsBu++;

            //회색
            if ((re[0] == 2 &&  re[1] == 2 &&  re[2] ==3) || 
                (re[0] == 2 &&  re[1] == 3 &&  re[2] ==3) || 
                (re[0] == 3 &&  re[1] == 3 &&  re[2] ==2) || 
                (re[0] == 3 &&  re[1] == 3 &&  re[2] ==3) || 
                (re[0] == 3 &&  re[1] == 3 &&  re[2] ==4) || 
                (re[0] == 3 &&  re[1] == 4 &&  re[2] ==4) || 
                (re[0] == 4 &&  re[1] == 3 &&  re[2] ==3) || 
                (re[0] == 4 &&  re[1] == 3 &&  re[2] ==4) || 
                (re[0] == 4 &&  re[1] == 4 &&  re[2] ==3) || 
                (re[0] == 4 &&  re[1] == 4 &&  re[2] ==4) || 
                (re[0] == 4 &&  re[1] == 4 &&  re[2] ==5) || 
                (re[0] == 4 &&  re[1] == 5 &&  re[2] ==4) || 
                (re[0] == 4 &&  re[1] == 5 &&  re[2] ==5) || 
                (re[0] == 5 &&  re[1] == 4 &&  re[2] ==4) || 
                (re[0] == 5 &&  re[1] == 4 &&  re[2] ==5) || 
                (re[0] == 5 &&  re[1] == 5 &&  re[2] ==4) || 
                (re[0] == 5 &&  re[1] == 5 &&  re[2] ==5) || 
                (re[0] == 5 &&  re[1] == 5 &&  re[2] ==6) || 
                (re[0] == 5 &&  re[1] == 6 &&  re[2] ==6) || 
                (re[0] == 6 &&  re[1] == 6 &&  re[2] ==5) || 
                (re[0] == 6 &&  re[1] == 6 &&  re[2] ==6) || 
                (re[0] == 6 &&  re[1] == 6 &&  re[2] ==7) || 
                (re[0] == 7 &&  re[1] == 7 &&  re[2] ==6) || 
                (re[0] == 7 &&  re[1] == 7 &&  re[2] ==7) || 
                (re[0] == 7 &&  re[1] == 7 &&  re[2] ==8)) cntsGr++;


        }

        void copyBitmap2RgbArray25Section()
        {
            int x, y, h, w;
            Color color;
            sectionArray = new int[5, 5, 3, (th_copy_bitmap.Height), (th_copy_bitmap.Width)];
            for (h = 0; h < 5; h++) 
            {
                for (w = 0; w < 5; w++)
                {
                    for (y = (th_copy_bitmap.Height / 5) * h; y < (th_copy_bitmap.Height / 5) + ((th_copy_bitmap.Height / 5) * h); y++)
                    {
                        for (x = (th_copy_bitmap.Width / 5) * w; x < (th_copy_bitmap.Width / 5) + ((th_copy_bitmap.Width / 5) * w) ; x++)
                        {
                            color = th_copy_bitmap.GetPixel(x, y);
                            sectionArray[h, w, 0, y, x] = color.R;
                            sectionArray[h, w, 1, y, x] = color.G;
                            sectionArray[h, w, 2, y, x] = color.B;
                        }
                    }
                }
            }
        
        }



        private Bitmap GetControlImage(Control ctl)
        {
            Bitmap bm = new Bitmap(ctl.Width, ctl.Height);
            ctl.DrawToBitmap(bm, new Rectangle(0, 0, ctl.Width, ctl.Height));
            return bm;
        }
        public void Draw(Graphics gr){
            /////my drawline
            foreach (Draw draw in myDrawLine.getMyDrawLine())
            {
                COO coo = null;
                foreach (COO pList in draw.getPoints())
                {
                    if (coo == null)
                    {
                        pen.Color = pList.getColor();
                        pen.Width = pList.getWidth();
                        gr.DrawLine(pen, pList.getX(), pList.getY(), pList.getX(), pList.getY());
                        coo = pList;
                    }
                    else
                    {
                        pen.Color = pList.getColor();
                        pen.Width = pList.getWidth();
                        gr.DrawLine(pen, coo.getX(), coo.getY(), pList.getX(), pList.getY());
                        coo = pList;
                    }
                }
            }

            //my drawRectangle
            foreach (Rect rect in myDrawRect.getRectList())
            {
                //pen.Color = rect.getColor();
                //pen.Width = 30;
                //brush = Brushes.(rect.getColor());
                //gr.DrawRectangle(pen, rect.getRect());
                brush = new SolidBrush(rect.getColor());
                gr.FillRectangle(brush, rect.getRect());
                CntRec++;
                
            }

            //my drawCircle
            foreach (Rect rect in myDrawCircle.getRectList())
            {
                //pen.Color = rect.getColor();
                //pen.Width = rect.getWidth();
                //gr.DrawEllipse(pen, rect.getRect());
                brush = new SolidBrush(rect.getColor());
                gr.FillEllipse(brush, rect.getRect());
                CntCir++;
            }

            if (gr != null)
            {
                gr.Dispose();
            }


  
            
        }

        #endregion

        #region Buttons
        private void linewidth1_Click(object sender, EventArgs e)
        {
            this.ChangedPenWidth(3);
        }

        private void linewidth3_Click(object sender, EventArgs e)
        {
            this.ChangedPenWidth(10);
        }

        private void linewidth5_Click(object sender, EventArgs e)
        {
            this.ChangedPenWidth(30);
        }

        private void Circle_Click(object sender, EventArgs e)
        {
            state = 1;
        }

        private void Square_Click(object sender, EventArgs e)
        {
            state = 2;
        }

        private void Line_Click(object sender, EventArgs e)
        {
            state = 0;
        }
        #endregion

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void chart2_Click(object sender, EventArgs e)
        {

        }


        private void 그래프ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.Show();                              //모달리스 방식

            //또는 frm.ShowDialog();          //모달 방식

        }

        private void 보기ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

 








    }
}