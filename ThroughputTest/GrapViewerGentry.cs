using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace ThroughputTest
{
    public class GrapViewerGentry : Form
    {
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel6;
        private Panel panel5;
        private Panel panel4;
        private Panel panel9;
        private Panel panel8;
        private Panel panel7;
        private Panel panel10;

        public List<string> m_listData ;

        LineChartControl[] lineChart = new LineChartControl[9];
        public GrapViewerGentry()
        {
            InitializeComponent();

            for (int i = 0; i < lineChart.Length; i++)
            {
                lineChart[i] = new LineChartControl();
                lineChart[i].SetYAxisFixed(0, 550, 50);   // 0~100, 10 간격
            }

            this.ClientSize = new System.Drawing.Size(1669, 841);
            this.ControlBox = false;
            this.Name = "GrapViewerStacker";
            this.ResumeLayout(false);

            panel1.Controls.Add(lineChart[0].Chart);
            panel2.Controls.Add(lineChart[1].Chart);
            panel3.Controls.Add(lineChart[2].Chart);
            panel4.Controls.Add(lineChart[3].Chart);
            panel5.Controls.Add(lineChart[4].Chart);
            panel6.Controls.Add(lineChart[5].Chart);
            panel7.Controls.Add(lineChart[6].Chart);
            panel8.Controls.Add(lineChart[7].Chart);
            panel9.Controls.Add(lineChart[8].Chart);

            for (int i = 0; i < 9; i++)
            {
                string str = (i+1).ToString();
                SetChartTitle(i, str);
            }

            Resize += (s, e) => LayoutPanels();
            LayoutPanels();
        }

        // 창 크기에 맞춰 3x3 그래프를 동일한 크기로 채운다
        private void LayoutPanels()
        {
            int w = ClientSize.Width, h = ClientSize.Height;
            if (w <= 0 || h <= 0) return;

            Panel[] panels = { panel1, panel2, panel3, panel4, panel5, panel6, panel7, panel8, panel9 };
            for (int i = 0; i < panels.Length; i++)
            {
                int col = i % 3, row = i / 3;
                int left = w * col / 3, right = w * (col + 1) / 3;
                int top = h * row / 3, bottom = h * (row + 1) / 3;
                panels[i].SetBounds(left, top, right - left, bottom - top);
            }
        }

        public void SetChartTitle(int index, string title)
        {
            var chart = lineChart[index].Chart;

            chart.Titles.Clear();
            chart.Titles.Add(title);

            chart.Titles[0].Font =
                new Font("맑은 고딕", 12, FontStyle.Bold);

            chart.Titles[0].Alignment =
                ContentAlignment.TopCenter;
        }

        public void makeChart(string data)
        {
            allClear();
            m_listData = data
                .Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            for (int i = 0; i < m_listData.Count;i++)
            {
                List<string> data1;
                data1 = m_listData[i].Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries).ToList();

                addValue(int.Parse(data1[0])-1, data1[1], int.Parse(data1[2]) );
            }
            foreach (LineChartControl chart in lineChart) chart.HighlightMax();
        }

        public void addValue(int gentrynum, string sttime, int data)
        {
                lineChart[gentrynum].AddPoint(sttime, data);
        }

        private void initChart(int gentrynum)
        {
            lineChart[gentrynum].Clear();
        }

        private void allClear()
        {
            if(  m_listData != null &&  m_listData.Count > 0)
            {
                m_listData.Clear();
            }

            for (int i= 0; i < 9;i++)
            {
                initChart(i);
            }
        }

        private void InitializeComponent()
        {
                    this.panel2 = new System.Windows.Forms.Panel();
                    this.panel3 = new System.Windows.Forms.Panel();
                    this.panel6 = new System.Windows.Forms.Panel();
                    this.panel5 = new System.Windows.Forms.Panel();
                    this.panel4 = new System.Windows.Forms.Panel();
                    this.panel9 = new System.Windows.Forms.Panel();
                    this.panel8 = new System.Windows.Forms.Panel();
                    this.panel7 = new System.Windows.Forms.Panel();
                    this.panel10 = new System.Windows.Forms.Panel();
                    this.panel1 = new System.Windows.Forms.Panel();
                    this.SuspendLayout();
                    //
                    // panel2
                    //
                    this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                    this.panel2.Location = new System.Drawing.Point(493, 1);
                    this.panel2.Name = "panel2";
                    this.panel2.Size = new System.Drawing.Size(490, 308);
                    this.panel2.TabIndex = 44;
                    //
                    // panel3
                    //
                    this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                    this.panel3.Location = new System.Drawing.Point(985, 1);
                    this.panel3.Name = "panel3";
                    this.panel3.Size = new System.Drawing.Size(490, 308);
                    this.panel3.TabIndex = 44;
                    //
                    // panel6
                    //
                    this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                    this.panel6.Location = new System.Drawing.Point(985, 311);
                    this.panel6.Name = "panel6";
                    this.panel6.Size = new System.Drawing.Size(490, 308);
                    this.panel6.TabIndex = 47;
                    //
                    // panel5
                    //
                    this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                    this.panel5.Location = new System.Drawing.Point(493, 311);
                    this.panel5.Name = "panel5";
                    this.panel5.Size = new System.Drawing.Size(490, 308);
                    this.panel5.TabIndex = 46;
                    //
                    // panel4
                    //
                    this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                    this.panel4.Location = new System.Drawing.Point(0, 311);
                    this.panel4.Name = "panel4";
                    this.panel4.Size = new System.Drawing.Size(490, 308);
                    this.panel4.TabIndex = 45;
                    //
                    // panel9
                    //
                    this.panel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                    this.panel9.Location = new System.Drawing.Point(985, 622);
                    this.panel9.Name = "panel9";
                    this.panel9.Size = new System.Drawing.Size(490, 308);
                    this.panel9.TabIndex = 50;
                    //
                    // panel8
                    //
                    this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                    this.panel8.Location = new System.Drawing.Point(493, 622);
                    this.panel8.Name = "panel8";
                    this.panel8.Size = new System.Drawing.Size(490, 308);
                    this.panel8.TabIndex = 49;
                    //
                    // panel7
                    //
                    this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                    this.panel7.Location = new System.Drawing.Point(0, 622);
                    this.panel7.Name = "panel7";
                    this.panel7.Size = new System.Drawing.Size(490, 308);
                    this.panel7.TabIndex = 48;
                    //
                    // panel10
                    //
                    this.panel10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                    this.panel10.Location = new System.Drawing.Point(0, 0);
                    this.panel10.Name = "panel10";
                    this.panel10.Size = new System.Drawing.Size(490, 308);
                    this.panel10.TabIndex = 45;
                    //
                    // panel1
                    //
                    this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                    this.panel1.Location = new System.Drawing.Point(0, 0);
                    this.panel1.Name = "panel1";
                    this.panel1.Size = new System.Drawing.Size(490, 308);
                    this.panel1.TabIndex = 46;
                    //
                    // GrapViewerGentry
                    //
                    this.ClientSize = new System.Drawing.Size(2212, 1402);
                    this.ControlBox = false;
                    this.Controls.Add(this.panel1);
                    this.Controls.Add(this.panel9);
                    this.Controls.Add(this.panel6);
                    this.Controls.Add(this.panel8);
                    this.Controls.Add(this.panel7);
                    this.Controls.Add(this.panel3);
                    this.Controls.Add(this.panel5);
                    this.Controls.Add(this.panel4);
                    this.Controls.Add(this.panel2);
                    this.Name = "GrapViewerGentry";
                    this.ResumeLayout(false);
        }
    }
}
