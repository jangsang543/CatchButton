namespace CatchButton
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void myButton_MouseEnter(object sender, EventArgs e)
        {
            // 1. 난수생성기준비
            Random rd= new Random();

            // 2. 가용영역계산(버튼이폼테두리에걸리지않게보호)// ClientSize는타이틀바와테두리를제외한실제흰도화지영역임
            int maxX= Math.Max(0, this.ClientSize.Width - myButton.Width);
            int maxY= Math.Max(0, this.ClientSize.Height - myButton.Height);

            // 3. 랜덤좌표추출(0 ~ 최대가용치사이)
            int nextX= rd.Next(0, maxX + 1);
            int nextY= rd.Next(0, maxY + 1);

            // 4. 위치할당(새로운Point 객체생성)
            myButton.Location= new Point(nextX, nextY);

            // 5. 시각적피드백(폼제목표시줄에좌표출력)
            this.Text= $"버튼위치: ({nextX}, {nextY})";
        }
    }
}
