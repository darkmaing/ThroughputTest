using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThroughputTest
{
    public class GrapViewerStacker :Form
    {
        private Panel panel1;
        LineChartControl lineChart;
        private List<string> m_listData;
        public  GrapViewerStacker()
        {
            InitializeComponent();

            lineChart = new LineChartControl();
            this.ClientSize = new System.Drawing.Size(1669, 841);
            this.ControlBox = false;
            this.Name = "GrapViewerStacker";
            this.ResumeLayout(false);
           lineChart.SetYAxisFixed(100, 4100,500);   // 0~100, 10 간격
            panel1.Controls.Add(lineChart.Chart);
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
                data1 = m_listData[i].Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries).ToList();

                addValue(data1[0], int.Parse(data1[1]));
            }
            lineChart.HighlightMax();
        }

        public void addValue(string sttime, int data)
        {
            lineChart.AddPoint(sttime, data);
        }

        private void allClear()
        {
            if (m_listData != null && m_listData.Count > 0)
            {
                m_listData.Clear();
            }
            lineChart.Clear();
        }

        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            //
            // panel1
            //
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(-1, -2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1469, 933);
            this.panel1.TabIndex = 47;
            //
            // GrapViewerStacker
            //
            this.ClientSize = new System.Drawing.Size(1469, 932);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Name = "GrapViewerStacker";
            this.ResumeLayout(false);
        }
    }
}
