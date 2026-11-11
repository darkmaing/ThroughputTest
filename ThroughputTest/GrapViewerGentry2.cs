using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ThroughputTest.Main;

namespace ThroughputTest
{
    public class GrapViewerGentry2 :Form
    {
        private Panel panel1;

        private Panel panel2;
        private Panel panel3;
        private List<string> m_listData;

        LineChartControl[] lineChart = new LineChartControl[3];
        public GrapViewerGentry2()
        {
            InitializeComponent();

            for (int i = 0; i < lineChart.Length; i++)
            {
                lineChart[i] = new LineChartControl();
                lineChart[i].SetYAxisFixed(0, 1400, 200);   // 0~100, 10 간격
            }
            this.ClientSize = new System.Drawing.Size(1669, 841);
            this.ControlBox = false;
            this.Name = "GrapViewerStacker";
            this.ResumeLayout(false);
            panel1.Controls.Add(lineChart[0].Chart);
            panel2.Controls.Add(lineChart[1].Chart);
            panel3.Controls.Add(lineChart[2].Chart);

            Resize += (s, e) => LayoutPanels();
            LayoutPanels();
        }

        // 창 크기에 맞춰 3개의 그래프를 가로로 동일하게 나눠 채운다
        private void LayoutPanels()
        {
            int w = ClientSize.Width, h = ClientSize.Height;
            if (w <= 0 || h <= 0) return;

            Panel[] panels = { panel1, panel2, panel3 };
            for (int i = 0; i < panels.Length; i++)
            {
                int left = w * i / 3;
                int right = w * (i + 1) / 3;
                panels[i].SetBounds(left, 0, right - left, h);
            }
        }

        public void makeChart(string data)
        {
            allClear();
            m_listData = data
                .Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            for (int i = 0; i < m_listData.Count; i++)
            {
                List<string> data1;
                data1 = m_listData[i].Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries).ToList();

                if(data1[0].Trim() == "1~3" )
                {
                    addValue(0, data1[1], int.Parse(data1[2]));
                }
                else if (data1[0].Trim() == "4~6")
                {
                    addValue(1, data1[1], int.Parse(data1[2]));
                }

                else
                {
                    addValue(2, data1[1], int.Parse(data1[2]));
                }
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
            if (m_listData != null && m_listData.Count > 0)
            {
                m_listData.Clear();
            }

            for (int i = 0; i < 3; i++)
            {
                initChart(i);
            }
        }

        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            //
            // panel1
            //
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(478, 337);
            this.panel1.TabIndex = 47;
            //
            // panel2
            //
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Location = new System.Drawing.Point(485, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(478, 337);
            this.panel2.TabIndex = 48;
            //
            // panel3
            //
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Location = new System.Drawing.Point(968, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(478, 337);
            this.panel3.TabIndex = 49;
            //
            // GrapViewerGentry2
            //
            this.ClientSize = new System.Drawing.Size(1469, 932);
            this.ControlBox = false;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "GrapViewerGentry2";
            this.ResumeLayout(false);
        }
    }
}
