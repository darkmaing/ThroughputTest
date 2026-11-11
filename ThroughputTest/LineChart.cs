
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

    // Y축 범위와 눈금 간격을 고정 (interval이 0이면 간격은 자동)
    public void SetYAxisFixed(double min, double max, double interval)
    {
        Axis y = _chart.ChartAreas["MainArea"].AxisY;
        y.Minimum = min;
        y.Maximum = max;
        y.Interval = interval;
        _chart.Invalidate();
    }

    // Y축 고정 해제 (자동 범위로 복귀)
    public void SetYAxisAuto()
    {
        Axis y = _chart.ChartAreas["MainArea"].AxisY;
        y.Minimum = double.NaN;
        y.Maximum = double.NaN;
        y.Interval = 0;
        _chart.Invalidate();
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

    // 가장 높은 값(동률이면 모두)의 점과 라벨을 빨간색으로 표시
    public void HighlightMax()
    {
        if (_series.Points.Count == 0) return;

        double max = _series.Points.Max(p => p.YValues[0]);
        foreach (WinPoint p in _series.Points)
        {
            bool isMax = p.YValues[0] == max;
            p.Color = isMax ? Color.Red : Color.Empty;
            p.MarkerColor = isMax ? Color.Red : Color.Empty;
            p.LabelForeColor = isMax ? Color.Red : Color.Black;
            p.MarkerSize = isMax ? 10 : 6;
        }
        _chart.Invalidate();
    }

    // 전체 데이터 삭제
    public void Clear()
    {
        _series.Points.Clear();
        _chart.Invalidate();
    }
}
