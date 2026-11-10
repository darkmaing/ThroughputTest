using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ThroughputTest
{
    public partial class Main : Form
    {
        /// <summary>엑셀 한 행(출고작업)의 출고 타이어 정보</summary>
        public struct StReleaseInfo
        {
            public string date;          // 작업일자 (yyyy-MM-dd HH:mm:ss)
            public int dock;             // 도크번호 (1~9)
            public string division;      // 입/출고 구분
            public string sourceNo;      // 출발지
            public int destinationNo;    // 목적지 번호
            public string workStatus;    // 작업상태
            public int tyreCount;        // 입출고수량 (스태커는 0)
        }

        // 엑셀에서 읽은 출고 데이터
        private List<StReleaseInfo> m_stackerList = new List<StReleaseInfo>();      // 스태커 출하 정보 데이터
        private List<StReleaseInfo> m_gentryList = new List<StReleaseInfo>();       // 갠트리 출하 정보 데이터.

        // 그래프 화면 (panel1 안에 도킹, 콤보박스로 전환)
        private readonly GrapViewerStacker m_stackerViewer;
        private readonly GrapViewerGentry m_gentryViewer;
        private readonly GrapViewerGentry2 m_gentryViewer2;

        // 디자인 시점의 각 컨트롤 위치/크기/글꼴. 창 크기 비율에 맞춰 모두 같이 키운다.
        private Size m_baseClientSize;
        private readonly Dictionary<Control, Rectangle> m_baseBounds = new Dictionary<Control, Rectangle>();
        private readonly Dictionary<Control, Font> m_baseFonts = new Dictionary<Control, Font>();
        private bool m_layoutReady;

        private void ApplyLayout()
        {
            if (!m_layoutReady || WindowState == FormWindowState.Minimized) return;

            float sx = (float)ClientSize.Width / m_baseClientSize.Width;
            float sy = (float)ClientSize.Height / m_baseClientSize.Height;
            float fontScale = Math.Max(0.5f, Math.Min(4f, Math.Min(sx, sy)));

            SuspendLayout();
            foreach (var pair in m_baseBounds)
            {
                Control c = pair.Key;
                Rectangle b = pair.Value;
                c.SetBounds(
                    (int)Math.Round(b.X * sx), (int)Math.Round(b.Y * sy),
                    Math.Max(1, (int)Math.Round(b.Width * sx)), Math.Max(1, (int)Math.Round(b.Height * sy)));

                if (c == ViewChart) continue;

                Font baseFont = m_baseFonts[c];
                float newSize = baseFont.Size * fontScale;
                if (Math.Abs(c.Font.Size - newSize) > 0.1f)
                {
                    Font old = c.Font;
                    c.Font = new Font(baseFont.FontFamily, newSize, baseFont.Style);
                    if (old != baseFont) old.Dispose();
                }
            }
            ResumeLayout(true);
        }

        public Main()
        {
            InitializeComponent();

            m_baseClientSize = ClientSize;
            foreach (Control c in Controls)
            {
                m_baseBounds[c] = c.Bounds;
                m_baseFonts[c] = c.Font;
            }
            m_layoutReady = true;

            SizeChanged += (s, e) => ApplyLayout();
            Load += (s, e) => ApplyLayout();
            WindowState = FormWindowState.Maximized;
            // 그래프
            m_stackerViewer = new GrapViewerStacker();
            m_stackerViewer.TopLevel = false;
            m_stackerViewer.FormBorderStyle = FormBorderStyle.None;
            m_stackerViewer.Dock = DockStyle.Fill;

            m_gentryViewer = new GrapViewerGentry();
            m_gentryViewer.TopLevel = false;
            m_gentryViewer.FormBorderStyle = FormBorderStyle.None;
            m_gentryViewer.Dock = DockStyle.Fill;

            m_gentryViewer2 = new GrapViewerGentry2();
            m_gentryViewer2.TopLevel = false;
            m_gentryViewer2.FormBorderStyle = FormBorderStyle.None;
            m_gentryViewer2.Dock = DockStyle.Fill;

            ViewChart.Controls.Add(m_stackerViewer);
            ViewChart.Controls.Add(m_gentryViewer);
            ViewChart.Controls.Add(m_gentryViewer2);

            // 처음에는 갠트리 그래프만 표시
            m_stackerViewer.Hide();
            m_gentryViewer.Show();

            // 콤보박스 순서는 combo_graph_view_SelectedIndexChanged의 인덱스와 같아야 한다
            Combo_Graph.Items.Add("스태커 그래프");
            Combo_Graph.Items.Add("갠트리 그래프");
            Combo_Graph.Items.Add("갠트리2 그래프");

            Combo_Graph.SelectedIndex = 0;
            File_Path_Stacker.Text = "C:\\DATA\\CRANE.xls";
            File_Path_Gantry.Text = "C:\\DATA\\GANTRY.xls";

        }

        // 스태커 / 갠트리 집계 대상 목적지 번호
        private static readonly int[] StackerDestinations = { 1310, 1320, 1330, 1340, 1350, 1360 };
        private static readonly int[] GentryDestinations = { 1411, 1420, 1430, 1440, 1450, 1460, 1470, 1480, 1491 };

        #region 공통 헬퍼

        /// <summary>엑셀 파일의 첫 번째 시트를 DataTable로 읽는다. (1행은 컬럼 헤더)</summary>
        private static DataTable ReadFirstSheet(string filePath)
        {
            // 한글 깨짐 방지: ExcelDataReader가 옛 인코딩을 읽을 수 있도록 등록
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
            using (var reader = ExcelReaderFactory.CreateReader(stream))
            {
                var result = reader.AsDataSet(new ExcelDataSetConfiguration
                {
                    ConfigureDataTable = _ => new ExcelDataTableConfiguration
                    {
                        UseHeaderRow = true
                    }
                });

                return result.Tables[0];
            }
        }

        /// <summary>파일 선택 대화상자를 띄우고 선택된 경로를 돌려준다. (취소 시 null)</summary>
        private static string SelectExcelFile(string initialDirectory)
        {
            using (var dialog = new OpenFileDialog())
            {
                dialog.InitialDirectory = initialDirectory;
                dialog.Filter = "텍스트 파일 (*.*)|*.*|모든 파일 (*.*)|*.*";
                dialog.FilterIndex = 1;
                dialog.RestoreDirectory = true;

                return dialog.ShowDialog() == DialogResult.OK ? dialog.FileName : null;
            }
        }

        /// <summary>
        /// '출고작업' 행을 StReleaseInfo로 변환한다.
        /// 출고작업이 아니거나, 도크번호(1~9)·목적지 번호가 대상이 아니면 false를 돌려준다.
        /// </summary>
        private static bool TryParseReleaseRow(DataRow row, int[] validDestinations, bool readTyreCount, out StReleaseInfo data)
        {
            data = new StReleaseInfo();

            string division = row["입/출고 구분"].ToString();
            if (division.Trim() != "출고작업")
            {
                return false;
            }

            string dateText = "";
            try
            {
                dateText = Convert.ToDateTime(row["작업일자"]).ToString("yyyy-MM-dd HH:mm:ss");
            }
            catch (Exception ex)
            {
                MessageBox.Show($" 날짜 오류 발생: {ex.Message}");
            }

            string dockText = "";
            try
            {
                dockText = row["도크번호"].ToString();
                if (dockText == "")
                {
                    // 도크번호가 비어 있으면 범위 밖(100) 값으로 두어 아래에서 제외시킨다
                    dockText = "100";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"알 수 없는 오류 발생: {ex.Message}");
            }

            int dock = Convert.ToInt16(dockText);
            if (dock <= 0 || dock >= 10)
            {
                return false;
            }

            int destination = Convert.ToInt16(row["목적지"]);
            if (!validDestinations.Contains(destination))
            {
                return false;
            }

            data.date = dateText;
            data.dock = dock;
            data.destinationNo = destination;
            data.division = division;
            data.sourceNo = row["출발지"].ToString();
            data.workStatus = row["작업상태"].ToString();
            data.tyreCount = readTyreCount ? Convert.ToInt16(row["입출고수량"]) : 0;

            return true;
        }

        #endregion

        // 스태커(크레인) 엑셀 파일 선택
    

        /// <summary>스태커(크레인) 엑셀에서 출고작업 데이터를 읽어 m_stackerList에 채운다.</summary>
        private void readStackerData(string filePath)
        {
            m_stackerList.Clear();

            DataTable table = ReadFirstSheet(filePath);
            foreach (DataRow row in table.Rows)
            {
                if (TryParseReleaseRow(row, StackerDestinations, readTyreCount: false, out StReleaseInfo data))
                {
                    m_stackerList.Add(data);
                }
            }
        }

        /// <summary>갠트리 엑셀에서 출고작업 데이터를 읽어 m_gentryList에 채운다.</summary>
        private void readGentryData(string filePath)
        {
            m_gentryList.Clear();

            DataTable table = ReadFirstSheet(filePath);
            foreach (DataRow row in table.Rows)
            {
                if (TryParseReleaseRow(row, GentryDestinations, readTyreCount: true, out StReleaseInfo data))
                {
                    m_gentryList.Add(data);
                }
            }
        }

        // 갠트리 엑셀 파일 선택
       

        /// <summary>스태커 출고 목록과 시간별 집계를 C:\DATA\Stacker.csv로 저장하고 그래프/화면에 표시한다.</summary>
        public void SaveStakerData()
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            // 두 번째 인자가 절대경로이므로 실제 저장 위치는 C:\DATA\Stacker.csv
            string filePath = System.IO.Path.Combine(desktopPath, "C:\\DATA\\Stacker.csv");
            Encoding encoding = new UTF8Encoding(true);
            int ncount = m_stackerList.Count;

            StreamWriter sw = new StreamWriter(filePath, false, encoding);
            {
                // 헤더 + 출고 목록
                sw.WriteLine("작업일자,입/출고구분,작업상태,출발지,목적지,도크번호");
                for (int i = 0; i < ncount; i++)
                {
                    string line = "";
                    line +=
                          m_stackerList[i].date + " , " + m_stackerList[i].division + " , " + m_stackerList[i].workStatus + " , " + m_stackerList[i].sourceNo + "," +
                         m_stackerList[i].destinationNo.ToString() + " , " + m_stackerList[i].dock.ToString();

                    sw.WriteLine(line);
                }
                // 시간별 집계: CSV에 쓰고, 그래프와 텍스트박스에 반영
                string reportData = makeHourlyExtractorfnStackerCounting();
                m_stackerViewer.makeChart(reportData);
                sw.WriteLine(reportData);
                STACKER_DATA.Text = reportData;
            }
            sw.Close();
        }

        /// <summary>갠트리 출고 목록과 도크/시간별 집계를 C:\DATA\Gentry.csv로 저장하고 그래프/화면에 표시한다.</summary>
        public void SaveGentryData()
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            // 두 번째 인자가 절대경로이므로 실제 저장 위치는 C:\DATA\Gentry.csv
            string filePath = System.IO.Path.Combine(desktopPath, "C:\\DATA\\Gentry.csv");
            Encoding encoding = new UTF8Encoding(true);
            int ncount = m_gentryList.Count;

            StreamWriter sw = new StreamWriter(filePath, false, encoding);
            {
                // 헤더 + 출고 목록
                sw.WriteLine("작업일자,입/출고구분,작업상태,출발지,목적지,입출고수량,도크번호");
                for (int i = 0; i < ncount; i++)
                {
                    string line = "";
                    line +=
                          m_gentryList[i].date + " , " + m_gentryList[i].division + " , " + m_gentryList[i].workStatus + " , " + m_gentryList[i].sourceNo + "," +
                         m_gentryList[i].destinationNo.ToString() + " , " + m_gentryList[i].tyreCount.ToString() + " , " + m_gentryList[i].dock.ToString();

                    sw.WriteLine(line);
                }
                // 도크별 시간 집계 → CSV, 갠트리 그래프(도크 9개)
                string reportData = makeHourlyExtractorfnGantryCounting();
                sw.WriteLine("도크,시간,총수량+\r\n" + reportData);

                m_gentryViewer.makeChart(reportData);

                // 도크 3개씩 묶은 시간 집계 → 갠트리2 그래프(3개)
                string reportData2 = fnGentryCounting2();

                m_gentryViewer2.makeChart(reportData2);

                // 도크별 집계를 리스트박스에 표시
                GENTRY_DATA.Items.AddRange(
                reportData2.Split(new[] { "\r\n", "\n" },
                StringSplitOptions.None)
                );
            }
            sw.Close();
        }

        private void Btn_Output_Data_Click(object sender, EventArgs e)
        {
            // 이전 결과 초기화
            if (GENTRY_DATA.IsHandleCreated)
            {
                GENTRY_DATA.Invoke((MethodInvoker)delegate {
                    STACKER_DATA.Text = "";
                    GENTRY_DATA.Items.Clear();
                });
            }
            else
            {
                // 핸들이 아직 없다면 메인 스레드가 알아서 지우도록 위임
                BeginInvoke((MethodInvoker)delegate {
                    STACKER_DATA.Text = "";
                    GENTRY_DATA.Items.Clear();
                });
            }

            // 2. GENTRY_DATA 안전하게 비우기 (개별 체크)
            if (GENTRY_DATA.InvokeRequired)
            {
                GENTRY_DATA.Invoke((MethodInvoker)(() => GENTRY_DATA.Items.Clear()));
            }
            else
            {
                GENTRY_DATA.Items.Clear();
            }

            // 스태커: 경로가 비어 있으면 기본 파일 사용
            string filePath = "";
            if (File_Path_Stacker.Text == "")
            {
                filePath = "C:\\DATA\\CRANE.xls";
            }
            else
            {
                filePath = File_Path_Stacker.Text;
            }
            readStackerData(filePath);

            m_stackerList.Sort((a, b) => a.date.CompareTo(b.date));
            SaveStakerData();

            logtext.Text = "Crane 데이터 출력";

            // 갠트리: 경로가 비어 있으면 기본 파일 사용
            filePath = "";
            if (File_Path_Gantry.Text == "")
            {
                filePath = "C:\\DATA\\GANTRY.xls";
            }
            else
            {
                filePath = File_Path_Gantry.Text;
            }
            logtext.Text = "갠트리 데이터 출력";

            readGentryData(filePath);

            SaveGentryData();
        }

        private void Btn_Stacker_File_Click(object sender, EventArgs e)
        {
            string filePath = SelectExcelFile(@"C:\DATA\11월 데이터\");
            if (filePath != null)
            {
                File_Path_Stacker.Text = filePath;
            }

            logtext.Text = File_Path_Stacker.Text + "파일이 선택 되었습니다. ";
        }

        private void Btn_Capture_Click(object sender, EventArgs e)
        {
            try
            {
                // 현재 선택된 그래프 종류를 파일명에 사용
                string toolName = "";
                if (Combo_Graph.SelectedIndex == 0)
                {
                    toolName = "스태커";
                }
                else if (Combo_Graph.SelectedIndex == 1)
                {
                    toolName = "갠트리";
                }
                else
                {
                    toolName = "갠트리2";
                }

                // 첫 데이터의 날짜(yyyy-MM-dd)를 파일명에 사용
                string date = m_stackerList[0].date
          .Split(new[] { " " }, StringSplitOptions.None)[0];

                string FileName =
                        "C:\\Users\\mino\\Desktop\\물동량 테스트\\" + date + "_" + toolName +
                        ".jpg";

                // 기본 모니터 전체 영역
                System.Drawing.Rectangle bounds =
  System.Windows.Forms.SystemInformation.VirtualScreen;

                using (Bitmap bitmap = new Bitmap(
                    bounds.Width, bounds.Height))
                {
                    using (Graphics graphics = Graphics.FromImage(bitmap))
                    {
                        graphics.CopyFromScreen(
                            bounds.Left,
                            bounds.Top,
                            0,
                            0,
                            bounds.Size);
                    }
                    // JPG 파일로 저장
                    bitmap.Save(FileName, ImageFormat.Jpeg);
                }

                MessageBox.Show(
                    "화면 캡처가 저장되었습니다.\r\n" + FileName,
                    "캡처 완료",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "화면 캡처 중 오류가 발생했습니다.\r\n" + ex.Message,
                    "오류",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void Btn_Gantry_File_Click(object sender, EventArgs e)
        {
            string filePath = SelectExcelFile(@"C:\DATA\11월 데이터\");
            if (filePath != null)
            {
                File_Path_Gantry.Text = filePath;
            }

            logtext.Text = File_Path_Gantry.Text + "파일이 선택 되었습니다. ";
        }

        /// <summary>스태커 시간별 집계. "시 : 수량" 줄 목록 (1건 = 24개로 계산)</summary>
        private string makeHourlyExtractorfnStackerCounting()
        {
            string result = string.Join("\r\n",
            m_stackerList
             .GroupBy(x => DateTime.Parse(x.date).Hour)
             .OrderBy(g => g.Key)
             .Select(g => $"{g.Key} : {g.Count()*24} "));

            return result;
        }

        /// <summary>갠트리 도크별·시간별 집계. "도크 / 시 / 수량" 줄 목록</summary>
        private string makeHourlyExtractorfnGantryCounting()
        {
            string result = string.Join(Environment.NewLine,
                m_gentryList
                    // 1. 도크번호별 그룹화
                    .GroupBy(x => x.dock)
                    .OrderBy(g => g.Key)
                    .SelectMany(dockGroup =>
                        // 2. 각 도크 안에서 시간별 그룹화
                        dockGroup
                            .GroupBy(x => DateTime.Parse(x.date).Hour)
                            .OrderBy(g => g.Key)
                            .Select(hourGroup =>
                                // 3. 입출고 수량 합계 출력
                                $"{dockGroup.Key} / " +
                                $"{hourGroup.Key:00} / " +
                                $"{hourGroup.Sum(x => Convert.ToInt32(x.tyreCount))}"
                            )
                    )
            );

            return result;
        }

        /// <summary>갠트리 도크 그룹(1~3, 4~6, 7~9)별·시간별 집계. "그룹 / 시 / 수량" 줄 목록</summary>
        private string fnGentryCounting2()
        {
            string result = string.Join(
                Environment.NewLine,
                m_gentryList
                   // 1. 도크 그룹화: 1~3, 4~6, 7~9
                   .GroupBy(x => (Convert.ToInt32(x.dock) - 1) / 3)
                   .OrderBy(g => g.Key)

                   // 2. 그룹 안에서 시간별로 합산
                   .SelectMany(dockGroup =>
                       dockGroup
                           .GroupBy(x => DateTime.Parse(x.date).Hour)
                           .OrderBy(hourGroup => hourGroup.Key)
                           .Select(hourGroup =>
                               $"{dockGroup.Key * 3 + 1}~{dockGroup.Key * 3 + 3} / " +
                               $"{hourGroup.Key:00}시 / " +
                               $"{hourGroup.Sum(x => Convert.ToInt32(x.tyreCount))}"
                           )
                   )
                );

            return result;
        }

        // 실행 버튼: 기존 결과를 지우고 스태커 → 갠트리 순서로 읽기/저장/그래프 갱신
       

        // 선택한 그래프 화면(0:스태커, 1:갠트리, 2:갠트리2)만 보이게 전환
        private void combo_graph_view_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Combo_Graph.SelectedIndex == 0)
            {
                m_stackerViewer.Show();
                m_gentryViewer.Hide();
                m_gentryViewer2.Hide();
            }
            else if (Combo_Graph.SelectedIndex == 1)
            {
                m_stackerViewer.Hide();
                m_gentryViewer.Show();
                m_gentryViewer2.Hide();
            }
            else
            {
                m_stackerViewer.Hide();
                m_gentryViewer.Hide();
                m_gentryViewer2.Show();
            }
        }

        // 캡처 버튼: 전체 화면을 "날짜_그래프종류.jpg"로 저장
       
    }
}
