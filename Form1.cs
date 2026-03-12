namespace CatchButton
{
    public partial class Form1 : Form
    {
        int score = 0; // 초기 점수
        int misses = 0; // 놓친 횟수
        private readonly Random rd = new Random();
        // 초기 버튼 상태 저장용
        private Size initialButtonSize;
        private Point initialButtonLocation;
        private Button restartButton;

        public Form1()
        {
            InitializeComponent();
            // 초기 버튼 크기와 위치 저장
            initialButtonSize = myButton.Size;
            initialButtonLocation = myButton.Location;

            // 재시작 버튼을 동적으로 생성하여 폼에 추가
            restartButton = new Button();
            restartButton.Name = "restartButton";
            restartButton.Text = "다시 시작";
            restartButton.Size = new Size(120, 30);
            restartButton.Location = new Point(10, 10);
            restartButton.Click += RestartButton_Click;
            this.Controls.Add(restartButton);
        }

        private void myButton_MouseEnter(object sender, EventArgs e)
        {
            // 도망가면 점수 감점
            score -= 10;

            // 놓친 횟수 증가 및 게임오버 체크
            misses++;
            if (misses >= 20)
            {
                // 모든 버튼 비활성화
                DisableAllButtons();
                // Game Over 메시지 출력
                MessageBox.Show("Game Over", "Game Over");
                // 폼 제목에 게임오버와 최종 점수 표시
                this.Text = $"Game Over - 점수: {score}";
                return;
            }

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

        // 모든 버튼을 비활성화하는 재귀 함수
        private void DisableAllButtons()
        {
            DisableButtonsRecursive(this.Controls);
        }

        private void DisableButtonsRecursive(Control.ControlCollection controls)
        {
            foreach (Control c in controls)
            {
                // 재시작 버튼은 항상 활성 상태로 남겨둠
                if (c is Button b && c.Name != "restartButton")
                    b.Enabled = false;
                if (c.HasChildren)
                    DisableButtonsRecursive(c.Controls);
            }
        }

        // 모든 버튼을 활성화하는 재귀 함수
        private void EnableAllButtons()
        {
            EnableButtonsRecursive(this.Controls);
        }

        private void EnableButtonsRecursive(Control.ControlCollection controls)
        {
            foreach (Control c in controls)
            {
                if (c is Button b)
                    b.Enabled = true;
                if (c.HasChildren)
                    EnableButtonsRecursive(c.Controls);
            }
        }

        // 게임을 초기 상태로 되돌림
        private void ResetGame()
        {
            score = 0;
            misses = 0;
            // 버튼 크기/위치 초기화
            myButton.Size = initialButtonSize;
            myButton.Location = initialButtonLocation;
            // 모든 버튼 활성화(다시시작 버튼 포함)
            EnableAllButtons();
            // 폼 제목 초기화
            this.Text = $"점수: {score}";
        }

        private void RestartButton_Click(object? sender, EventArgs e)
        {
            ResetGame();
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
