using System.Drawing.Imaging;
using ZedGraph;
using NCalc;

namespace GraphDrawer
{
    public partial class Form1 : Form
    {
        newForm form;
        bool info;
        GraphPane graphPane;
        bool debug;
        public Form1(bool debug)
        {
            InitializeComponent();
            info = true;
            form = new newForm();
            form.Left = Right + 5;
            form.Top = Top;
            form.Height = 595;
            this.debug = debug;

            label1.Visible = this.debug;
            numericUpDown2.Visible = this.debug;
            checkBox1.Visible = this.debug;
            checkBox2.Visible = this.debug;
            richTextBox1.Visible = this.debug;

            if (debug) Text += " (debug)";

            form.Show();
            form.Hide();
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            UpLimY.Enabled = !checkBox1.Checked;
            DownLimY.Enabled = !checkBox1.Checked;
        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            UpLimX.Enabled = !checkBox1.Checked;
            DownLimX.Enabled = !checkBox1.Checked;
        }
        private void Form1_Move(object sender, EventArgs e)
        {
            // Изменяем координаты второй формы при перемещении этой формы
            form.Left = Right + 5;
            form.Top = Top;
        }
        public static bool CheckForBreak(double y_1, double y0, double y1, double delta)
        {
            if (Math.Abs((y0 - y1) - (y_1 - y0)) > delta) return true;
            else return false;
        }
        public List<PointPairList> Parse(string expression, double startX, double endX, double startY, double endY, double step)
        {
            List<PointPairList> pointPairs = new();

            List<double> prevY = new();
            PointPairList pointList = new();
            double x = startX;

            double d = (((Math.Abs(startX) + Math.Abs(endX)) * (Math.Abs(startY) + Math.Abs(endY))) / 1000);
            richTextBox1.Text = "Дельта графика: " + Math.Sqrt(d);

            NCalc.Expression calculator = new(FixExpression(expression));
            double y;


            if (!double.TryParse(expression, out y)) y = Evaluate(calculator, x);

            prevY.Add(y);
            // Добавляем первую точку в список
            pointList.Add(x, y);

            while (x < endX)
            {
                // Идем по диапазону значений x с шагом step и добавляем координаты x и y для каждой точки
                x += step;

                if (double.TryParse(expression, out y)) { }
                else y = Evaluate(calculator, x);

                prevY.Add((double)y);

                if (prevY.Count >= 2)
                {
                    if (CheckForBreak(prevY[^2], prevY[^1], y, Math.Sqrt(d)))
                    {
                        pointPairs.Add(pointList);
                        pointList = new();
                    }
                    pointList.Add(x, y);
                }
                x += step;
            }
            pointPairs.Add(pointList);

            return pointPairs;
        }
        private double Evaluate(NCalc.Expression calculator, double x)
        {
            // Создаем новый экземпляр класса Calculator и вычисляем значение выражения для заданного значения x

            calculator.Parameters["x"] = x;
            calculator.Parameters["pi"] = Math.PI;
            calculator.Parameters["e"] = Math.E;
            calculator.Parameters["phi"] = 1.61803398874989;

            double c = (double)calculator.Evaluate();

            if (double.IsNaN(c) && debug)
            {
                calculator.Parameters["x"] = -x;
                return -((double)calculator.Evaluate());
            }
            else return c;
        }
        private static string FixExpression(string expression)
        {
            expression = expression.Replace("arccos(", "Acos(");
            expression = expression.Replace("deg(", "ToDegrees(");
            expression = expression.Replace("rad(", "ToRadians(");
            expression = expression.Replace("arcctg(", "pi/2 - Atan(");
            expression = expression.Replace("arcsin(", "Asin(");
            expression = expression.Replace("arctg(", "Atan(");
            expression = expression.Replace("sgn(", "Sign(");
            expression = expression.Replace("sqrt(", "Sqrt(");
            expression = expression.Replace("abs(", "Abs(");
            expression = expression.Replace("cos(", "Cos(");
            expression = expression.Replace("ACos(", "Acos(");
            expression = expression.Replace("sin(", "Sin(");
            expression = expression.Replace("ASin(", "Asin(");
            /*expression = expression.Replace("ctg(", "ctg(");*/
            expression = expression.Replace("e(", "Exp(");
            expression = expression.Replace("log(", "Log(");
            expression = expression.Replace("lg(", "Log10(");
            expression = expression.Replace("pow(", "Pow(");
            expression = expression.Replace("tg(", "Tan(");
            expression = expression.Replace("ATan(", "Atan(");

            expression = expression.Replace("X", "x");
            expression = expression.Replace("х", "x");
            expression = expression.Replace("Х", "x");

            expression = expression.Trim();

            return expression;
        }
        private void DrawGraph_Click(object sender, EventArgs e)
        {
            string function = FunctionFill.Text;
            double stepf = (double)numericUpDown2.Value;
            try
            {
                if ((double)DownLimX.Value >= (double)UpLimX.Value) MessageBox.Show("Значения верхнего и нижнего значения абциссы не должны быть меньше или равны друг другу",
                                                                                    "Предупреждение", MessageBoxButtons.OK);
                else if ((double)DownLimY.Value >= (double)UpLimY.Value) MessageBox.Show("Значения верхнего и нижнего значения ординаты не должны быть меньше или равны друг другу",
                                                                                        "Предупреждение", MessageBoxButtons.OK);
                else
                {

                    graphPane = new GraphPane();

                    graphPane.XAxis.Scale.FontSpec.Size = 14;
                    graphPane.YAxis.Scale.FontSpec.Size = 14;

                    graphPane.YAxis.Scale.Min = (double)DownLimY.Value;
                    graphPane.YAxis.Scale.Max = (double)UpLimY.Value;
                    graphPane.XAxis.Scale.Min = (double)DownLimX.Value;
                    graphPane.XAxis.Scale.Max = (double)UpLimX.Value;

                    graphPane.YAxis.Scale.MaxAuto = checkBox1.Checked;
                    graphPane.YAxis.Scale.MinAuto = checkBox1.Checked;
                    graphPane.XAxis.Scale.MaxAuto = checkBox2.Checked;
                    graphPane.XAxis.Scale.MinAuto = checkBox2.Checked;

                    graphPane.XAxis.Cross = 0;
                    graphPane.YAxis.Cross = 0;

                    graphPane.Legend.IsVisible = false;

                    graphPane.CurveList.Clear();

                    graphPane.AxisChange();

                    var pointList = Parse(function, (double)DownLimX.Value, (double)UpLimX.Value, (double)DownLimY.Value, (double)UpLimY.Value, stepf);

                    foreach (var point in pointList)
                    {
                        graphPane.AddCurve(string.Empty, point, System.Drawing.Color.Blue, SymbolType.None);
                    }

                    // Создаем объект Bitmap для PictureBox
                    Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);

                    // Получаем объект Graphics из Bitmap
                    Graphics g = Graphics.FromImage(bmp);

                    // Очищаем поверхность
                    g.Clear(Color.White);

                    // Рисуем график на поверхности
                    graphPane.Rect = new RectangleF(0, 0, pictureBox1.Width, pictureBox1.Height);
                    graphPane.Draw(g);

                    // Отображаем Bitmap в PictureBox
                    pictureBox1.Image = bmp;
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("can't be empty")) MessageBox.Show("Некоторые поля остались незаполненными", "Предупреждение");
                else
                {
                    MessageBox.Show("Возникла следующая внутренняя ошибка программы :\n" + ex.Message + '\n' +
                        "Перепроверь все вводимые тобою данные функции в соответствии с инструкцией (Жми \"Инструкция\")",
                        "Критическая ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void Instruction_Click(object sender, EventArgs e)
        {
            info = !info;
            if (!info)
            {
                if (form == null) form = new();
                form.Left = Right + 5;
                form.Top = Top;
                form.Show();
            }
            else
            {
                form.Hide();
            }
        }
        private void BMPexport_Click(object sender, EventArgs e)
        {
            if (graphPane is null || FunctionFill.Text is null || FunctionFill.Text == string.Empty)
            {
                MessageBox.Show("Первым делом сгенерируй график функции и не оставляй поле ввода функции пустой", "Предупреждение", MessageBoxButtons.OK);
            }
            else using (FolderBrowserDialog folderBrowser = new FolderBrowserDialog())
                {
                    DialogResult result = folderBrowser.ShowDialog();

                    if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowser.SelectedPath))
                    {
                        string selectedPath = folderBrowser.SelectedPath;
                        // здесь можно сохранять файл в выбранную директорию
                        // Получаем объект Graphics из Bitmap
                        Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                        Graphics g = Graphics.FromImage(bmp);

                        // Очищаем поверхность
                        g.Clear(Color.White);

                        // Рисуем график на поверхности
                        graphPane.Draw(g);
                        // Сохраняем Bitmap в файл в формате png, jpeg или bmp
                        bmp.Save(selectedPath + "\\" + $"GraphDrawer {DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss")}.bmp", ImageFormat.Bmp);
                    }
                }
        }
        private void JPEGexport_Click(object sender, EventArgs e)
        {
            if (graphPane is null || FunctionFill.Text is null || FunctionFill.Text == string.Empty)
            {
                MessageBox.Show("Первым делом сгенерируй график функции и не оставляй поле ввода функции пустой", "Предупреждение", MessageBoxButtons.OK);
            }
            else using (FolderBrowserDialog folderBrowser = new FolderBrowserDialog())
                {
                    DialogResult result = folderBrowser.ShowDialog();

                    if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowser.SelectedPath))
                    {
                        string selectedPath = folderBrowser.SelectedPath;
                        // здесь можно сохранять файл в выбранную директорию
                        // Получаем объект Graphics из Bitmap
                        Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                        Graphics g = Graphics.FromImage(bmp);

                        // Очищаем поверхность
                        g.Clear(Color.White);

                        // Рисуем график на поверхности
                        graphPane.Draw(g);
                        // Сохраняем Bitmap в файл в формате png, jpeg или bmp
                        bmp.Save(selectedPath + "\\" + $"GraphDrawer {DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss")}.jpeg", ImageFormat.Jpeg);
                    }
                }
        }
        private void PNGexport_Click(object sender, EventArgs e)
        {
            if (graphPane is null || FunctionFill.Text is null || FunctionFill.Text == string.Empty)
            {
                MessageBox.Show("Первым делом сгенерируй график функции и не оставляй поле ввода функции пустой", "Предупреждение", MessageBoxButtons.OK);
            }
            else using (FolderBrowserDialog folderBrowser = new FolderBrowserDialog())
                {
                    DialogResult result = folderBrowser.ShowDialog();

                    if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowser.SelectedPath))
                    {
                        string selectedPath = folderBrowser.SelectedPath;
                        // здесь можно сохранять файл в выбранную директорию
                        // Получаем объект Graphics из Bitmap
                        Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                        Graphics g = Graphics.FromImage(bmp);

                        // Очищаем поверхность
                        g.Clear(Color.White);

                        // Рисуем график на поверхности
                        graphPane.Draw(g);
                        // Сохраняем Bitmap в файл в формате png, jpeg или bmp
                        bmp.Save(selectedPath + "\\" + $"GraphDrawer {DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss")}.png", ImageFormat.Png);

                    }
                }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}