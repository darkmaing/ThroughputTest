
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using WinChart =
    System.Windows.Forms.DataVisualization.Charting.Chart;
using WinChartArea =
    System.Windows.Forms.DataVisualization.Charting.ChartArea;
using WinMarkerStyle =
    System.Windows.Forms.DataVisualization.Charting.MarkerStyle;
using WinPoint =
    System.Windows.Forms.DataVisualization.Charting.DataPoint;
using WinSeries =
    System.Windows.Forms.DataVisualization.Charting.Series;
using WinSeriesType =
    System.Windows.Forms.DataVisualization.Charting.SeriesChartType;

public class LineChartControl
{
    private readonly WinChart _chart;
    private readonly WinSeries _series;

    public WinChart Chart
    {
        get { return _chart; }
    }

    public LineChartControl()
    {
        _chart = new WinChart();
        _chart.Dock = DockStyle.Fill;

        WinChartArea area = new WinChartArea("MainArea");
        area.AxisX.Title = "X축";
        area.AxisY.Title = "Y축";
        area.AxisX.MajorGrid.Enabled = false;
        area.AxisY.MajorGrid.LineColor = Color.LightGray;

        _chart.ChartAreas.Add(area);

        _series = new WinSeries("데이터");
        _series.ChartType = WinSeriesType.Line;
        _series.BorderWidth = 2;
        _series.MarkerStyle = WinMarkerStyle.Circle;
        _series.MarkerSize = 6;
        _series.ChartArea = "MainArea";
        _series.IsValueShownAsLabel = true;
        _series.LabelFormat = "0";
        _chart.Series.Add(_series);
    }

    // 데이터 한 건 추가
    public void AddPoint(string x, double y)
    {
        WinPoint point = new WinPoint();
        point.AxisLabel = x ?? "";
        point.YValues = new double[] { y };

        _series.Points.Add(point);
        _chart.Invalidate();
    }

    // 전체 데이터 삭제
    public void Clear()
    {
        _series.Points.Clear();
        _chart.Invalidate();
    }
}
