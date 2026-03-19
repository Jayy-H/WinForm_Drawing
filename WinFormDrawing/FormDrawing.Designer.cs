namespace WinFormDrawing
{
    partial class FormDrawing
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
            this.PanelDrawing = new System.Windows.Forms.Panel();
            this.BtnSave = new System.Windows.Forms.Button();
            this.BtnLoad = new System.Windows.Forms.Button();
            this.DrawingHistory = new System.Windows.Forms.TrackBar();
            this.BtnReset = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DrawingHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelDrawing
            // 
            this.PanelDrawing.BackColor = System.Drawing.Color.White;
            this.PanelDrawing.Location = new System.Drawing.Point(12, 69);
            this.PanelDrawing.Name = "PanelDrawing";
            this.PanelDrawing.Size = new System.Drawing.Size(776, 309);
            this.PanelDrawing.TabIndex = 0;
            this.PanelDrawing.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelDrawing_Paint);
            this.PanelDrawing.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PanelDrawing_MouseDown);
            this.PanelDrawing.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PanelDrawing_MouseMove);
            this.PanelDrawing.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PanelDrawing_MouseUp);
            // 
            // BtnSave
            // 
            this.BtnSave.Location = new System.Drawing.Point(12, 12);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(200, 44);
            this.BtnSave.TabIndex = 1;
            this.BtnSave.Text = "Save";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // BtnLoad
            // 
            this.BtnLoad.Location = new System.Drawing.Point(227, 12);
            this.BtnLoad.Name = "BtnLoad";
            this.BtnLoad.Size = new System.Drawing.Size(200, 44);
            this.BtnLoad.TabIndex = 2;
            this.BtnLoad.Text = "Load";
            this.BtnLoad.UseVisualStyleBackColor = true;
            this.BtnLoad.Click += new System.EventHandler(this.BtnLoad_Click);
            // 
            // DrawingHistory
            // 
            this.DrawingHistory.BackColor = System.Drawing.SystemColors.Control;
            this.DrawingHistory.Location = new System.Drawing.Point(12, 393);
            this.DrawingHistory.Name = "DrawingHistory";
            this.DrawingHistory.Size = new System.Drawing.Size(776, 45);
            this.DrawingHistory.TabIndex = 3;
            this.DrawingHistory.Scroll += new System.EventHandler(this.DrawingHistory_Scroll);
            // 
            // BtnReset
            // 
            this.BtnReset.BackColor = System.Drawing.Color.MistyRose;
            this.BtnReset.Location = new System.Drawing.Point(698, 12);
            this.BtnReset.Name = "BtnReset";
            this.BtnReset.Size = new System.Drawing.Size(90, 44);
            this.BtnReset.TabIndex = 4;
            this.BtnReset.Text = "Reset";
            this.BtnReset.UseVisualStyleBackColor = false;
            this.BtnReset.Click += new System.EventHandler(this.BtnReset_Click);
            // 
            // FormDrawing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BtnReset);
            this.Controls.Add(this.DrawingHistory);
            this.Controls.Add(this.BtnLoad);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.PanelDrawing);
            this.Name = "FormDrawing";
            this.Text = "DrawingApp";
            ((System.ComponentModel.ISupportInitialize)(this.DrawingHistory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel PanelDrawing;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Button BtnLoad;
        private System.Windows.Forms.TrackBar DrawingHistory;
        private System.Windows.Forms.Button BtnReset;
    }
}

