using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; // 파일 읽기/쓰기를 위해 필요
using System.Windows.Forms;

namespace WinFormDrawing
{
    public partial class FormDrawing : Form
    {
        // 필요한 변수들 선언 (클래스 바로 아래에 작성)
        private List<Point> points = new List<Point>(); // 마우스 좌표들을 저장할 바구니
        private bool isDrawing = false; // 지금 마우스를 누르고 있는지 체크

        public FormDrawing()
        {
            InitializeComponent();
        }
        
        // --- 마우스 동작 처리 ---

        // PanelDrawing의 MouseDown 이벤트 (마우스 누를 때)
        // 디자인 창에서 Panel을 선택하고 '번개 모양(이벤트)' 아이콘에서 MouseDown을 더블클릭해서 연결해줘!
        private void PanelDrawing_MouseDown(object sender, MouseEventArgs e)
        {
            isDrawing = true;
            points.Add(e.Location); // 클릭한 지점 저장
        }

        // PanelDrawing의 MouseMove 이벤트 (마우스 움직일 때)
        private void PanelDrawing_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing)
            {
                points.Add(e.Location); // 움직이는 경로 저장
                
                // 점이 추가될 때마다 트랙바 갱신
                DrawingHistory.Maximum = points.Count;
                DrawingHistory.Value = points.Count;

                PanelDrawing.Invalidate(); // 중요! 화면을 다시 그려라(Paint 이벤트 호출)
            }
        }

        // PanelDrawing의 MouseUp 이벤트 (마우스 뗄 때)
        private void PanelDrawing_MouseUp(object sender, MouseEventArgs e)
        {
            isDrawing = false;
        }

        // --- 실제 선 그리기 ---

        // PanelDrawing의 Paint 이벤트 (화면을 그려주는 역할)
        private void PanelDrawing_Paint(object sender, PaintEventArgs e)
        {
            int countToDraw = DrawingHistory.Value;

            // 트랙바 위치까지만 선 그리기 (과거/현재 변환 핵심)
            if (countToDraw > 1 && countToDraw <= points.Count)
            {
                Point[] pointsToDraw = points.GetRange(0, countToDraw).ToArray();
                e.Graphics.DrawLines(Pens.Black, pointsToDraw);
            }
        }

        // --- 버튼 & 트랙바 기능 ---

        // Save 버튼 클릭 시: 좌표를 txt 파일로 저장
        private void BtnSave_Click(object sender, EventArgs e)
        {
            // 저장할 경로를 선택하는 창 띄우기
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "마우스 좌표 저장하기";
            sfd.Filter = "텍스트 파일 (*.txt)|*.txt|모든 파일 (*.*)|*.*";
            sfd.DefaultExt = "txt";

            // 사용자가 '저장' 버튼을 눌렀을 때만 실행
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(sfd.FileName))
                {
                    foreach (Point p in points)
                    {
                        sw.WriteLine($"{p.X},{p.Y}");
                    }
                }
                MessageBox.Show("원하는 경로에 저장이 완료되었습니다!", "저장 성공");
            }
        }

        // Load 버튼 클릭 시: txt 파일에서 좌표 불러오기
        private void BtnLoad_Click(object sender, EventArgs e)
        {
            // 불러올 파일을 선택하는 창 띄우기
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "마우스 좌표 불러오기";
            ofd.Filter = "텍스트 파일 (*.txt)|*.txt|모든 파일 (*.*)|*.*";

            // 사용자가 파일을 선택하고 '열기'를 눌렀을 때만 실행
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                points.Clear(); // 기존 그림 초기화
                
                string[] lines = File.ReadAllLines(ofd.FileName);
                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');
                    // 혹시 빈 줄이거나 형식이 안 맞을 때 튕기는 거 방지
                    if (parts.Length == 2 && int.TryParse(parts[0], out int x) && int.TryParse(parts[1], out int y))
                    {
                        points.Add(new Point(x, y));
                    }
                }

                // 불러온 점 개수에 맞춰서 트랙바 세팅
                if (points.Count > 0)
                {
                    DrawingHistory.Maximum = points.Count;
                    DrawingHistory.Value = points.Count;
                }
                else
                {
                    DrawingHistory.Maximum = 0;
                    DrawingHistory.Value = 0;
                }

                PanelDrawing.Invalidate(); // 불러온 그림 화면에 띄우기
            }
        }

        // Reset 버튼 클릭 시: 리셋
        private void BtnReset_Click(object sender, EventArgs e)
        {
            // 1. 저장된 점(좌표) 리스트 싹 비우기
            points.Clear();

            // 2. 트랙바 초기화 (0으로 만들기)
            DrawingHistory.Maximum = 0;
            DrawingHistory.Value = 0;

            // 3. 화면 다시 그리기 (점이 없으므로 깨끗한 하얀 캔버스가 됨)
            PanelDrawing.Invalidate();
        }

        // 트랙바 스크롤 시: 히스토리 보여주기
        private void DrawingHistory_Scroll(object sender, EventArgs e)
        {
            // 사실 이 과제의 트랙바는 "현재까지 그린 점들 중 어디까지 보여줄까?"를 정하는 거야.
            // 복잡한 로직이 필요하지만, 일단 트랙바를 움직일 때 화면을 갱신하게만 해둘게.
            PanelDrawing.Invalidate();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
