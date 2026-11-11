using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static ThroughputTest.Main;

namespace ThroughputTest
{
    public class GrapViewerGentry3 :Form
    {
        private Panel panel1;
        private List<string> m_listData;

        private Chart m_chart;

        public GrapViewerGentry3()
        {
            InitializeComponent();
            InitColumnChart();

            Resize += (s, e) => LayoutPanels();
            LayoutPanels();
        }

        // 세로 막대(Column) 그래프 초기 설정: 차트/축/시리즈를 만들고 panel1에 붙인다
        private void InitColumnChart()
        {
            m_chart = new Chart();
            m_chart.Dock = DockStyle.Fill;

            ChartArea area = new ChartArea("MainArea");
            area.AxisX.Title = "";
            area.AxisY.Title = "수량";
            area.AxisX.MajorGrid.Enabled = false;
            area.AxisX.Interval = 1;
            area.AxisY.MajorGrid.LineColor = Color.LightGray;
            // 데이터가 없어도 축이 그려지도록 Y축 범위를 고정한다
            area.AxisY.Minimum = 0;
            area.AxisY.Maximum = 40;
            area.AxisY.Interval = 10;
            area.BorderColor = Color.Gray;
            area.BorderDashStyle = ChartDashStyle.Solid;
            m_chart.ChartAreas.Add(area);

            m_chart.Legends.Add(new Legend("Legend") { Docking = Docking.Top });
            panel1.Controls.Add(m_chart);
        }

        // "도크 / yyyy-MM-dd HH:mm:ss / 수량" 줄 목록을 받아 도크별 합계를 하나의 막대에 색을 달리해 쌓아 표시한다
        public void makeChart(string data)
        {
            m_chart.Series.Clear();

            var totals = data
                .Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries)
                .Select(row => row.Split(new[] { " / " }, StringSplitOptions.None))
                .Where(cols => cols.Length >= 3)
                .GroupBy(cols => int.Parse(cols[0].Trim()))
                .OrderBy(g => g.Key)
                .Select(g => new { Dock = g.Key, Total = g.Sum(cols => int.Parse(cols[2].Trim())) })
                .ToList();

            const string category = "도크별 합계";
            foreach (var item in totals)
            {
                Series series = new Series("Dock " + item.Dock);
                series.ChartType = SeriesChartType.StackedColumn;
                series.ChartArea = "MainArea";
                series.Legend = "Legend";
                series["PointWidth"] = "0.4";
                series.IsValueShownAsLabel = true;
                series.LabelFormat = "0";
                series.Font = new Font("Arial", 11, FontStyle.Bold);
                series.LabelForeColor = Color.White;
                series.Points.AddXY(category, item.Total);
                m_chart.Series.Add(series);
            }

            // 맨 위에 전체 합계를 표시하는 보이지 않는 점
            int sum = totals.Sum(x => x.Total);
            if (totals.Count > 0)
            {
                Series top = new Series("합계");
                top.ChartType = SeriesChartType.Point;
                top.ChartArea = "MainArea";
                top.IsVisibleInLegend = false;
                top.MarkerStyle = MarkerStyle.None;
                top.Points.AddXY(category, sum);
                top.Points[0].Label = "합계 " + sum;
                top.Points[0].LabelForeColor = Color.Black;
                top.Font = new Font("Arial", 12, FontStyle.Bold);
                m_chart.Series.Add(top);
            }

            Axis y = m_chart.ChartAreas["MainArea"].AxisY;
            y.Maximum = sum > 0 ? Math.Ceiling(sum / 100.0) * 100 + 100 : 40;
            y.Interval = 0;
            m_chart.Invalidate();
        }
        // 창 크기에 맞춰 하나뿐인
        private void LayoutPanels()
        {
            int w = ClientSize.Width, h = ClientSize.Height;
            if (w <= 0 || h <= 0) return;

            panel1.SetBounds(0, 0, w, h);
        }

        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1469, 932);
            this.panel1.TabIndex = 47;
            // 
            // GrapViewerGentry3
            // 
            this.ClientSize = new System.Drawing.Size(1469, 932);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Name = "GrapViewerGentry3";
            this.ResumeLayout(false);

        }
    }
}
