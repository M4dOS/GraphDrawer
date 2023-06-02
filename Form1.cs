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
            form.Height = 575;
            this.debug = debug;

            label1.Visible = debug;
            numericUpDown2.Visible = debug;
            label2.Visible = debug;
            if (debug) Text += " (debug)";
            /*else
            {
                Ytext.Top -= 100;
                UpLimX.Top -= 100;
                DownLimX.Top -= 100;
                checkBox1.Top -= 100;
            }*/

            form.Show();
            form.Hide();
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            UpLimY.Enabled = !checkBox1.Checked;
            DownLimY.Enabled = !checkBox1.Checked;
        }

        private void Form1_Move(object sender, EventArgs e)
        {
            // Изменяем координаты второй формы при перемещении этой формы
            form.Left = Right + 5;
            form.Top = Top;
        }
        public static PointPairList Parse(string expression, double startX, double endX, double step)
        {
            // Создаем новый список точек
            PointPairList pointList = new PointPairList();

            NCalc.Expression calculator = new NCalc.Expression(FixExpression(expression));

            double y;
            double x = startX;
            if (double.TryParse(expression, out y)) { }
            else y = Evaluate(calculator, x);

            // Добавляем первую точку в список
            pointList.Add(x, y);

            // Идем по диапазону значений x с шагом step и добавляем координаты x и y для каждой точки
            while (x < endX)
            {
                x += step;
                if (double.TryParse(expression, out y)) { }
                else y = Evaluate(calculator, x);
                pointList.Add(x, y);
            }

            return pointList;
        }

        private static double Evaluate(NCalc.Expression calculator, double x)
        {
            // Создаем новый экземпляр класса Calculator и вычисляем значение выражения для заданного значения x

            calculator.Parameters["x"] = x;
            calculator.Parameters["pi"] = Math.PI;
            calculator.Parameters["phi"] = 1.61803398874989;

            return (double)calculator.Evaluate();
        }

        private static string FixExpression(string expression)
        {
            expression = expression.Replace("arccos", "Acos");
            expression = expression.Replace("deg", "ToDegrees");
            expression = expression.Replace("rad", "ToRadians");
            expression = expression.Replace("arcctg", "Atan");
            expression = expression.Replace("arcsin", "Asin");
            expression = expression.Replace("arctg", "Atan");
            expression = expression.Replace("sgn", "Sign");
            expression = expression.Replace("sqrt", "Sqrt");
            expression = expression.Replace("abs", "Abs");
            expression = expression.Replace("cos", "Cos");
            expression = expression.Replace("sin", "Sin");
            expression = expression.Replace("ctg", "Cot");
            expression = expression.Replace("e(", "Exp");
            expression = expression.Replace("log", "Log");
            expression = expression.Replace("lg", "Log10");
            expression = expression.Replace("pow", "Pow");
            expression = expression.Replace("tg", "Tan");
            expression = expression.Replace("e", "Exp(1)");

            expression = expression.Replace("X", "x");
            expression = expression.Replace("х", "x");
            expression = expression.Replace("Х", "x");

            expression.Trim();

            return expression;
        }

        double Gradate(decimal start, decimal end)
        {
            decimal line = Math.Abs(start) + Math.Abs(end);
            int count = 0;
            while (line > 0)
            {
                line /= 10;
                count++;
            }
            return (double)Math.Pow(10, count);
        }
        private void DrawGraph_Click(object sender, EventArgs e)
        {
            string function = FunctionFill.Text;
            double stepf = (double)numericUpDown2.Value;
            try
            {
                if ((double)DownLimX.Value == (double)UpLimX.Value) MessageBox.Show("Значения верхнего и нижнего значения абциссы не должны быть равны друг другу", "Предупреждение", MessageBoxButtons.OK);
                else if ((double)DownLimY.Value == (double)UpLimY.Value) MessageBox.Show("Значения верхнего и нижнего значения ординаты не должны быть равны друг другу", "Предупреждение", MessageBoxButtons.OK);
                else
                {
                    PointPairList pointList = /*FunctionParser.*/Parse(function, (double)DownLimX.Value, (double)UpLimX.Value, stepf);
                    graphPane = new GraphPane();
                    graphPane.XAxis.Scale.Min = (double)DownLimX.Value;
                    graphPane.XAxis.Scale.Max = (double)UpLimX.Value;
                    graphPane.YAxis.Scale.Min = (double)DownLimY.Value;
                    graphPane.YAxis.Scale.Max = (double)UpLimY.Value;

                    /*graphPane.YAxis.Type = AxisType.Linear;
                    graphPane.XAxis.Type = AxisType.Linear;*/

                    graphPane.YAxis.Scale.MaxAuto = checkBox1.Checked;
                    graphPane.YAxis.Scale.MinAuto = checkBox1.Checked;

                    graphPane.XAxis.Cross = 0.0;
                    graphPane.YAxis.Cross = 0.0;

                    /*graphPane.YAxis.Scale.MajorStep = Gradate(DownLimY.Value, UpLimY.Value);
                    graphPane.YAxis.Scale.MinorStep = Gradate(DownLimY.Value, UpLimY.Value)/10;*/

                    graphPane.XAxis.Scale.MajorStep = Gradate(DownLimX.Value, UpLimX.Value);
                    graphPane.XAxis.Scale.MinorStep = Gradate(DownLimX.Value, UpLimX.Value) / 10;

                    /*// Отключим отображение первых и последних меток по осям
                    graphPane.XAxis.Scale.IsSkipFirstLabel = true;
                    graphPane.XAxis.Scale.IsSkipLastLabel = true;

                    // Отключим отображение меток в точке пересечения с другой осью
                    graphPane.XAxis.Scale.IsSkipCrossLabel = true;

                    // Отключим отображение первых и последних меток по осям
                    graphPane.YAxis.Scale.IsSkipFirstLabel = true;

                    // Отключим отображение меток в точке пересечения с другой осью
                    graphPane.YAxis.Scale.IsSkipLastLabel = true;
                    graphPane.YAxis.Scale.IsSkipCrossLabel = true;

                    graphPane.XAxis.Title.IsVisible = false;
                    graphPane.YAxis.Title.IsVisible = false;*/

                    graphPane.AxisChange();

                    graphPane.AddCurve(function, pointList, System.Drawing.Color.Blue, SymbolType.None);

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

        private void LaTEXconv_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Данная функция ещё не реализована", "Предупреждение", MessageBoxButtons.OK);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}