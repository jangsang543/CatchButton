namespace CatchButton
{
    public partial class Form1 : Form
    {
        int score = 0; // 초기 점수

        public Form1()
        {
            InitializeComponent();
        }

        private void myButton_MouseEnter(object sender, EventArgs e)
        {
            // 도망가면 점수 감점
            score -= 10;

            // 버튼이 완전히 보이도록 가용영역 계산
            int maxX = Math.Max(0, this.ClientSize.Width - myButton.Width);
            int maxY = Math.Max(0, this.ClientSize.Height - myButton.Height);

            // 3. 랜덤좌표추출(0 ~ 최대가용치사이)
            int nextX = rd.Next(0, maxX + 1);
            int nextY = rd.Next(0, maxY + 1);

            // 4. 위치할당(새로운Point 객체생성)
            myButton.Location = new Point(nextX, nextY);

            // 5. 시각적피드백(폼제목표시줄에좌표출력)
            this.Text = $"점수: {score} - 버튼위치: ({nextX}, {nextY})";
        }

        private void myButton_Click(object sender, EventArgs e)
        {
            score += 100;

            // 버튼 크기를 10% 축소
            const double shrinkFactor = 0.9;
            const int minWidth = 20;
            const int minHeight = 20;

            int newWidth = Math.Max(minWidth, (int)(myButton.Width * shrinkFactor));
            int newHeight = Math.Max(minHeight, (int)(myButton.Height * shrinkFactor));
            myButton.Size = new Size(newWidth, newHeight);

            // 축소 후 버튼이 클라이언트 영역을 벗어나지 않도록 위치 보정
            int maxX = Math.Max(0, this.ClientSize.Width - myButton.Width);
            int maxY = Math.Max(0, this.ClientSize.Height - myButton.Height);
            int correctedX = Math.Min(myButton.Location.X, maxX);
            int correctedY = Math.Min(myButton.Location.Y, maxY);
            myButton.Location = new Point(correctedX, correctedY);

            // 제목과 메시지박스에 점수 반영
            this.Text = $"점수: {score}";
            MessageBox.Show("축하합니다~~!", $"점수: {score}");
        }
    }
}
