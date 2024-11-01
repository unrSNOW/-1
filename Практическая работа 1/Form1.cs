namespace Практическая_работа_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[] numbers = GenerateRandomNumbers(10000);
            int evenCount = 0;
            int oddCount = 0;

            Task.Run(() =>
            {
                evenCount = numbers.Count(n => n % 2 == 0);
                oddCount = numbers.Length - evenCount;

                Invoke((MethodInvoker)(() =>
                {
                    label1.Text = $"Четные: {evenCount}, Нечетные: {oddCount}";
                }));
            });
        }

        private int[] GenerateRandomNumbers(int count)
        {
            Random random = new Random();
            return Enumerable.Range(0, count).Select(_ => random.Next(1, 100)).ToArray();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
