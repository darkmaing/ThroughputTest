namespace ThroughputTest
{
    partial class Main
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.Btn_Stacker_File = new System.Windows.Forms.Button();
            this.File_Path_Stacker = new System.Windows.Forms.Label();
            this.Label_Stacker = new System.Windows.Forms.Label();
            this.Label_Gantry = new System.Windows.Forms.Label();
            this.File_Path_Gantry = new System.Windows.Forms.Label();
            this.Btn_Gantry_File = new System.Windows.Forms.Button();
            this.Btn_Output_Data = new System.Windows.Forms.Button();
            this.logtext = new System.Windows.Forms.ListBox();
            this.STACKER_DATA = new System.Windows.Forms.ListView();
            this.colStTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colStTotal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label_Stalker = new System.Windows.Forms.Label();
            this.label_Stalker_data = new System.Windows.Forms.Label();
            this.GENTRY_DATA = new System.Windows.Forms.ListView();
            this.colDock = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTotal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Combo_Graph = new System.Windows.Forms.ComboBox();
            this.ViewChart = new System.Windows.Forms.Panel();
            this.Btn_Capture = new System.Windows.Forms.Button();
            this.label_gantry_data2 = new System.Windows.Forms.Label();
            this.GENTRY_DATA2 = new System.Windows.Forms.ListView();
            this.GENTRY_DATA3 = new System.Windows.Forms.ListView();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Label_Stack_Date = new System.Windows.Forms.Label();
            this.Label_Gantry_Date = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Btn_Stacker_File
            // 
            this.Btn_Stacker_File.Location = new System.Drawing.Point(326, 3);
            this.Btn_Stacker_File.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Btn_Stacker_File.Name = "Btn_Stacker_File";
            this.Btn_Stacker_File.Size = new System.Drawing.Size(79, 25);
            this.Btn_Stacker_File.TabIndex = 0;
            this.Btn_Stacker_File.Text = "파일 선택";
            this.Btn_Stacker_File.UseVisualStyleBackColor = true;
            this.Btn_Stacker_File.Click += new System.EventHandler(this.Btn_Stacker_File_Click);
            // 
            // File_Path_Stacker
            // 
            this.File_Path_Stacker.BackColor = System.Drawing.Color.White;
            this.File_Path_Stacker.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.File_Path_Stacker.ForeColor = System.Drawing.Color.Black;
            this.File_Path_Stacker.Location = new System.Drawing.Point(107, 6);
            this.File_Path_Stacker.Name = "File_Path_Stacker";
            this.File_Path_Stacker.Size = new System.Drawing.Size(211, 21);
            this.File_Path_Stacker.TabIndex = 1;
            // 
            // Label_Stacker
            // 
            this.Label_Stacker.Location = new System.Drawing.Point(12, 7);
            this.Label_Stacker.Name = "Label_Stacker";
            this.Label_Stacker.Size = new System.Drawing.Size(89, 22);
            this.Label_Stacker.TabIndex = 2;
            this.Label_Stacker.Text = "스 태 커  :";
            this.Label_Stacker.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label_Gantry
            // 
            this.Label_Gantry.Location = new System.Drawing.Point(12, 41);
            this.Label_Gantry.Name = "Label_Gantry";
            this.Label_Gantry.Size = new System.Drawing.Size(89, 21);
            this.Label_Gantry.TabIndex = 3;
            this.Label_Gantry.Text = "갠 트 리 :";
            this.Label_Gantry.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // File_Path_Gantry
            // 
            this.File_Path_Gantry.BackColor = System.Drawing.Color.White;
            this.File_Path_Gantry.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.File_Path_Gantry.ForeColor = System.Drawing.Color.Black;
            this.File_Path_Gantry.Location = new System.Drawing.Point(107, 39);
            this.File_Path_Gantry.Name = "File_Path_Gantry";
            this.File_Path_Gantry.Size = new System.Drawing.Size(211, 20);
            this.File_Path_Gantry.TabIndex = 4;
            // 
            // Btn_Gantry_File
            // 
            this.Btn_Gantry_File.Location = new System.Drawing.Point(324, 39);
            this.Btn_Gantry_File.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Btn_Gantry_File.Name = "Btn_Gantry_File";
            this.Btn_Gantry_File.Size = new System.Drawing.Size(82, 23);
            this.Btn_Gantry_File.TabIndex = 5;
            this.Btn_Gantry_File.Text = "파일 선택";
            this.Btn_Gantry_File.UseVisualStyleBackColor = true;
            this.Btn_Gantry_File.Click += new System.EventHandler(this.Btn_Gantry_File_Click);
            // 
            // Btn_Output_Data
            // 
            this.Btn_Output_Data.Location = new System.Drawing.Point(12, 67);
            this.Btn_Output_Data.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Btn_Output_Data.Name = "Btn_Output_Data";
            this.Btn_Output_Data.Size = new System.Drawing.Size(399, 27);
            this.Btn_Output_Data.TabIndex = 6;
            this.Btn_Output_Data.Text = "데이터 출력";
            this.Btn_Output_Data.BackColor = System.Drawing.Color.FromArgb(190, 170, 240);
            this.Btn_Output_Data.ForeColor = System.Drawing.Color.White;
            this.Btn_Output_Data.UseVisualStyleBackColor = false;
            this.Btn_Output_Data.Click += new System.EventHandler(this.Btn_Output_Data_Click);
            // 
            // logtext
            // 
            this.logtext.BackColor = System.Drawing.Color.White;
            this.logtext.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.logtext.FormattingEnabled = true;
            this.logtext.HorizontalScrollbar = true;
            this.logtext.ItemHeight = 12;
            this.logtext.Location = new System.Drawing.Point(11, 848);
            this.logtext.Name = "logtext";
            this.logtext.Size = new System.Drawing.Size(395, 74);
            this.logtext.TabIndex = 8;
            // 
            // STACKER_DATA
            // 
            this.STACKER_DATA.BackColor = System.Drawing.Color.White;
            this.STACKER_DATA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.STACKER_DATA.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colStTime,
            this.colStTotal});
            this.STACKER_DATA.FullRowSelect = true;
            this.STACKER_DATA.GridLines = true;
            this.STACKER_DATA.HideSelection = false;
            this.STACKER_DATA.Location = new System.Drawing.Point(2, 48);
            this.STACKER_DATA.Name = "STACKER_DATA";
            this.STACKER_DATA.Size = new System.Drawing.Size(196, 245);
            this.STACKER_DATA.TabIndex = 9;
            this.STACKER_DATA.UseCompatibleStateImageBehavior = false;
            this.STACKER_DATA.View = System.Windows.Forms.View.Details;
            // 
            // colStTime
            // 
            this.colStTime.Text = "Time";
            this.colStTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colStTime.Width = 90;
            // 
            // colStTotal
            // 
            this.colStTotal.Text = "Total";
            this.colStTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colStTotal.Width = 90;
            // 
            // label_Stalker
            // 
            this.label_Stalker.Location = new System.Drawing.Point(6, 3);
            this.label_Stalker.Name = "label_Stalker";
            this.label_Stalker.Size = new System.Drawing.Size(195, 22);
            this.label_Stalker.TabIndex = 10;
            this.label_Stalker.Text = "스 태 커  DATA";
            this.label_Stalker.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Stalker_data
            // 
            this.label_Stalker_data.Location = new System.Drawing.Point(2, 2);
            this.label_Stalker_data.Name = "label_Stalker_data";
            this.label_Stalker_data.Size = new System.Drawing.Size(204, 22);
            this.label_Stalker_data.TabIndex = 12;
            this.label_Stalker_data.Text = "갠트리  DATA";
            this.label_Stalker_data.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GENTRY_DATA
            // 
            this.GENTRY_DATA.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colDock,
            this.colTime,
            this.colTotal});
            this.GENTRY_DATA.FullRowSelect = true;
            this.GENTRY_DATA.GridLines = true;
            this.GENTRY_DATA.HideSelection = false;
            this.GENTRY_DATA.Location = new System.Drawing.Point(3, 48);
            this.GENTRY_DATA.Name = "GENTRY_DATA";
            this.GENTRY_DATA.Size = new System.Drawing.Size(207, 245);
            this.GENTRY_DATA.TabIndex = 13;
            this.GENTRY_DATA.UseCompatibleStateImageBehavior = false;
            this.GENTRY_DATA.View = System.Windows.Forms.View.Details;
            // 
            // colDock
            // 
            this.colDock.Text = "Dock";
            this.colDock.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // colTime
            // 
            this.colTime.Text = "Time";
            this.colTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // colTotal
            // 
            this.colTotal.Text = "Total";
            this.colTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Combo_Graph
            // 
            this.Combo_Graph.FormattingEnabled = true;
            this.Combo_Graph.Location = new System.Drawing.Point(14, 100);
            this.Combo_Graph.Name = "Combo_Graph";
            this.Combo_Graph.Size = new System.Drawing.Size(395, 20);
            this.Combo_Graph.TabIndex = 23;
            this.Combo_Graph.SelectedIndexChanged += new System.EventHandler(this.combo_graph_view_SelectedIndexChanged);
            // 
            // ViewChart
            // 
            this.ViewChart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ViewChart.Location = new System.Drawing.Point(417, 3);
            this.ViewChart.Name = "ViewChart";
            this.ViewChart.Size = new System.Drawing.Size(1476, 931);
            this.ViewChart.TabIndex = 14;
            // 
            // Btn_Capture
            // 
            this.Btn_Capture.Location = new System.Drawing.Point(10, 814);
            this.Btn_Capture.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Btn_Capture.Name = "Btn_Capture";
            this.Btn_Capture.Size = new System.Drawing.Size(400, 27);
            this.Btn_Capture.TabIndex = 24;
            this.Btn_Capture.Text = "capture";
            this.Btn_Capture.UseVisualStyleBackColor = true;
            this.Btn_Capture.Click += new System.EventHandler(this.Btn_Capture_Click);
            // 
            // label_gantry_data2
            // 
            this.label_gantry_data2.Location = new System.Drawing.Point(12, 417);
            this.label_gantry_data2.Name = "label_gantry_data2";
            this.label_gantry_data2.Size = new System.Drawing.Size(123, 22);
            this.label_gantry_data2.TabIndex = 25;
            this.label_gantry_data2.Text = "스 태 커  DATA 2";
            this.label_gantry_data2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // GENTRY_DATA2
            // 
            this.GENTRY_DATA2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.GENTRY_DATA2.FullRowSelect = true;
            this.GENTRY_DATA2.GridLines = true;
            this.GENTRY_DATA2.HideSelection = false;
            this.GENTRY_DATA2.Location = new System.Drawing.Point(7, 438);
            this.GENTRY_DATA2.Name = "GENTRY_DATA2";
            this.GENTRY_DATA2.Size = new System.Drawing.Size(409, 183);
            this.GENTRY_DATA2.TabIndex = 26;
            this.GENTRY_DATA2.UseCompatibleStateImageBehavior = false;
            this.GENTRY_DATA2.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Dock";
            this.columnHeader1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Time";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Total";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Label_Stack_Date
            // 
            this.Label_Stack_Date.Location = new System.Drawing.Point(7, 25);
            this.Label_Stack_Date.Name = "Label_Stack_Date";
            this.Label_Stack_Date.Size = new System.Drawing.Size(191, 22);
            this.Label_Stack_Date.TabIndex = 27;
            this.Label_Stack_Date.Text = "Date : ";
            this.Label_Stack_Date.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label_Gantry_Date
            // 
            this.Label_Gantry_Date.Location = new System.Drawing.Point(3, 23);
            this.Label_Gantry_Date.Name = "Label_Gantry_Date";
            this.Label_Gantry_Date.Size = new System.Drawing.Size(191, 22);
            this.Label_Gantry_Date.TabIndex = 28;
            this.Label_Gantry_Date.Text = "Date : ";
            this.Label_Gantry_Date.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.Label_Stack_Date);
            this.panel1.Controls.Add(this.label_Stalker);
            this.panel1.Controls.Add(this.STACKER_DATA);
            this.panel1.Location = new System.Drawing.Point(5, 124);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(201, 294);
            this.panel1.TabIndex = 29;
            // 
            // GENTRY_DATA3
            // 
            this.GENTRY_DATA3.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.GENTRY_DATA3.FullRowSelect = true;
            this.GENTRY_DATA3.GridLines = true;
            this.GENTRY_DATA3.HideSelection = false;
            this.GENTRY_DATA3.Location = new System.Drawing.Point(7, 627);
            this.GENTRY_DATA3.Name = "GENTRY_DATA3";
            this.GENTRY_DATA3.Size = new System.Drawing.Size(409, 183);
            this.GENTRY_DATA3.TabIndex = 31;
            this.GENTRY_DATA3.UseCompatibleStateImageBehavior = false;
            this.GENTRY_DATA3.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Dock";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Time";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Total";
            this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label_Stalker_data);
            this.panel2.Controls.Add(this.Label_Gantry_Date);
            this.panel2.Controls.Add(this.GENTRY_DATA);
            this.panel2.Location = new System.Drawing.Point(205, 124);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(211, 294);
            this.panel2.TabIndex = 30;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1893, 933);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.GENTRY_DATA3);
            this.Controls.Add(this.GENTRY_DATA2);
            this.Controls.Add(this.label_gantry_data2);
            this.Controls.Add(this.Btn_Capture);
            this.Controls.Add(this.Combo_Graph);
            this.Controls.Add(this.ViewChart);
            this.Controls.Add(this.logtext);
            this.Controls.Add(this.Btn_Output_Data);
            this.Controls.Add(this.Btn_Gantry_File);
            this.Controls.Add(this.File_Path_Gantry);
            this.Controls.Add(this.Label_Gantry);
            this.Controls.Add(this.Label_Stacker);
            this.Controls.Add(this.File_Path_Stacker);
            this.Controls.Add(this.Btn_Stacker_File);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Main";
            this.Text = "물동량 분석 프로그램";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Btn_Stacker_File;
        private System.Windows.Forms.Label File_Path_Stacker;
        private System.Windows.Forms.Label Label_Stacker;
        private System.Windows.Forms.Label Label_Gantry;
        private System.Windows.Forms.Label File_Path_Gantry;
        private System.Windows.Forms.Button Btn_Gantry_File;
        private System.Windows.Forms.Button Btn_Output_Data;
        private System.Windows.Forms.ListBox logtext;
        private System.Windows.Forms.ListView STACKER_DATA;
        private System.Windows.Forms.ColumnHeader colStTime;
        private System.Windows.Forms.ColumnHeader colStTotal;
        private System.Windows.Forms.Label label_Stalker;
        private System.Windows.Forms.Label label_Stalker_data;
        private System.Windows.Forms.ListView GENTRY_DATA;
        private System.Windows.Forms.ColumnHeader colDock;
        private System.Windows.Forms.ColumnHeader colTime;
        private System.Windows.Forms.ColumnHeader colTotal;
        private System.Windows.Forms.ComboBox Combo_Graph;
        private System.Windows.Forms.Panel ViewChart;
        private System.Windows.Forms.Button Btn_Capture;
        private System.Windows.Forms.Label label_gantry_data2;
        private System.Windows.Forms.ListView GENTRY_DATA2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ListView GENTRY_DATA3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.Label Label_Stack_Date;
        private System.Windows.Forms.Label Label_Gantry_Date;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}

