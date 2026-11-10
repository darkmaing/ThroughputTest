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
            this.logtext = new System.Windows.Forms.Label();
            this.STACKER_DATA = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.GENTRY_DATA = new System.Windows.Forms.ListBox();
            this.Combo_Graph = new System.Windows.Forms.ComboBox();
            this.ViewChart = new System.Windows.Forms.Panel();
            this.Btn_Capture = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Btn_Stacker_File
            // 
            this.Btn_Stacker_File.Location = new System.Drawing.Point(326, 16);
            this.Btn_Stacker_File.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Btn_Stacker_File.Name = "Btn_Stacker_File";
            this.Btn_Stacker_File.Size = new System.Drawing.Size(79, 31);
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
            this.File_Path_Stacker.Location = new System.Drawing.Point(107, 20);
            this.File_Path_Stacker.Name = "File_Path_Stacker";
            this.File_Path_Stacker.Size = new System.Drawing.Size(211, 21);
            this.File_Path_Stacker.TabIndex = 1;
            // 
            // Label_Stacker
            // 
            this.Label_Stacker.Location = new System.Drawing.Point(12, 21);
            this.Label_Stacker.Name = "Label_Stacker";
            this.Label_Stacker.Size = new System.Drawing.Size(89, 22);
            this.Label_Stacker.TabIndex = 2;
            this.Label_Stacker.Text = "스 태 커  :";
            this.Label_Stacker.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label_Gantry
            // 
            this.Label_Gantry.Location = new System.Drawing.Point(12, 55);
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
            this.File_Path_Gantry.Location = new System.Drawing.Point(107, 56);
            this.File_Path_Gantry.Name = "File_Path_Gantry";
            this.File_Path_Gantry.Size = new System.Drawing.Size(211, 20);
            this.File_Path_Gantry.TabIndex = 4;
            // 
            // Btn_Gantry_File
            // 
            this.Btn_Gantry_File.Location = new System.Drawing.Point(324, 53);
            this.Btn_Gantry_File.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Btn_Gantry_File.Name = "Btn_Gantry_File";
            this.Btn_Gantry_File.Size = new System.Drawing.Size(82, 27);
            this.Btn_Gantry_File.TabIndex = 5;
            this.Btn_Gantry_File.Text = "파일 선택";
            this.Btn_Gantry_File.UseVisualStyleBackColor = true;
            this.Btn_Gantry_File.Click += new System.EventHandler(this.Btn_Gantry_File_Click);
            // 
            // Btn_Output_Data
            // 
            this.Btn_Output_Data.Location = new System.Drawing.Point(19, 97);
            this.Btn_Output_Data.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Btn_Output_Data.Name = "Btn_Output_Data";
            this.Btn_Output_Data.Size = new System.Drawing.Size(392, 27);
            this.Btn_Output_Data.TabIndex = 6;
            this.Btn_Output_Data.Text = "데이터 출력";
            this.Btn_Output_Data.UseVisualStyleBackColor = true;
            this.Btn_Output_Data.Click += new System.EventHandler(this.Btn_Output_Data_Click);
            // 
            // logtext
            // 
            this.logtext.BackColor = System.Drawing.Color.White;
            this.logtext.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.logtext.Location = new System.Drawing.Point(10, 517);
            this.logtext.Name = "logtext";
            this.logtext.Size = new System.Drawing.Size(395, 22);
            this.logtext.TabIndex = 8;
            // 
            // STACKER_DATA
            // 
            this.STACKER_DATA.BackColor = System.Drawing.Color.White;
            this.STACKER_DATA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.STACKER_DATA.Location = new System.Drawing.Point(10, 149);
            this.STACKER_DATA.Name = "STACKER_DATA";
            this.STACKER_DATA.Size = new System.Drawing.Size(196, 362);
            this.STACKER_DATA.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(15, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 22);
            this.label4.TabIndex = 10;
            this.label4.Text = "스 태 커  DATA";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(216, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 22);
            this.label5.TabIndex = 12;
            this.label5.Text = "갠트리  DATA";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // GENTRY_DATA
            // 
            this.GENTRY_DATA.FormattingEnabled = true;
            this.GENTRY_DATA.ItemHeight = 12;
            this.GENTRY_DATA.Location = new System.Drawing.Point(212, 148);
            this.GENTRY_DATA.Name = "GENTRY_DATA";
            this.GENTRY_DATA.Size = new System.Drawing.Size(197, 364);
            this.GENTRY_DATA.TabIndex = 13;
            // 
            // Combo_Graph
            // 
            this.Combo_Graph.FormattingEnabled = true;
            this.Combo_Graph.Location = new System.Drawing.Point(10, 547);
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
            this.Btn_Capture.Location = new System.Drawing.Point(10, 574);
            this.Btn_Capture.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Btn_Capture.Name = "Btn_Capture";
            this.Btn_Capture.Size = new System.Drawing.Size(400, 27);
            this.Btn_Capture.TabIndex = 24;
            this.Btn_Capture.Text = "capture";
            this.Btn_Capture.UseVisualStyleBackColor = true;
            this.Btn_Capture.Click += new System.EventHandler(this.Btn_Capture_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1893, 933);
            this.Controls.Add(this.Btn_Capture);
            this.Controls.Add(this.Combo_Graph);
            this.Controls.Add(this.ViewChart);
            this.Controls.Add(this.GENTRY_DATA);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.STACKER_DATA);
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
        private System.Windows.Forms.Label logtext;
        private System.Windows.Forms.Label STACKER_DATA;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox GENTRY_DATA;
        private System.Windows.Forms.ComboBox Combo_Graph;
        private System.Windows.Forms.Panel ViewChart;
        private System.Windows.Forms.Button Btn_Capture;
    }
}

