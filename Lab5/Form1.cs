using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab5
{
    public partial class MainForm : Form
    {

        Color currcolor1, currcolor2;
        // текущий выбранный цвет, толщина кисти, порядковый номер действия и режим
        int currthick;
        int scale;
        int historyCounter;
        int width, height;
        string currmode;
        bool changed, m_left, m_right; // для корректной работы функций


        Bitmap img;

        private List<Point> linePoints = new List<Point>(); // лист для сохранения точек для построения линии
        List<Image> History = new List<Image>();


        public MainForm()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint, true);
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Изображения (*.png, *.jpg, *.bmp)|*.png;*.jpg;*.bmp|All files (*.*)|*.*";
            saveFileDialog1.Filter = "Формат .png|*.png|Формат .jpg|*.jpg|Формат .bmp|*.bmp";
            // задаем фильтры для диалогов открытия и сохранения
            // и начальные цвет и толщину кисти
            currcolor1 = currcolor1Panel.BackColor;
            currcolor2 = currcolor2Panel.BackColor;
            currthick = Convert.ToInt32(thickSelector.Text);
            currmode = "pen";
            scale = 100; // указывается в процентах
            changed = false;
            m_left = m_right = false;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (changed == true)
            // если открыто и изменено либо создано и изменено предложить сохранение
            {
                var ExitBox = MessageBox.Show("Сохранить?",
                    "Изображение не сохранено",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Exclamation);
                if (ExitBox == DialogResult.No) return;
                if (ExitBox == DialogResult.Cancel) e.Cancel = true;
                if (ExitBox == DialogResult.Yes)
                {
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        saveImg(saveFileDialog1.FileName);
                        return;
                    }
                    else e.Cancel = true; // Передумал выходить из ПГМ
                }
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //
        }

        private void toolStripMenuCreate_Click(object sender, EventArgs e)
        {
            closeImg(ref img);
            createImg();

            History.Clear();
            historyCounter = 0;
            MenuHistory.Enabled = true;
            History.Add(new Bitmap(pictureEditor.Image));
        }

        private void toolStripMenuOpen_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.ShowDialog();
                if (openFileDialog1.FileName != String.Empty)
                {
                    closeImg(ref img);
                    img = new Bitmap(openFileDialog1.FileName);
                    openImg();

                    saveFileDialog1.FileName = String.Empty;
                    History.Clear();
                    historyCounter = 0;
                    MenuHistory.Enabled = true;
                    History.Add(new Bitmap(pictureEditor.Image));
                }
            }
            // обрабатываем исключения
            catch (System.IO.FileNotFoundException Ситуация)
            {
                MessageBox.Show(Ситуация.Message + "\nНет такого файла",
                "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
            }
            catch (Exception Ситуация)
            { // Отчет о других ошибках
                MessageBox.Show(Ситуация.Message, "Ошибка1",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void toolStripMenuSave_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.FileName == String.Empty)
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    saveImg(saveFileDialog1.FileName);
            }
            else
                saveImg(saveFileDialog1.FileName);
        }


        private void toolStripMenuSaveAs_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
            saveImg(saveFileDialog1.FileName);
        }


        private void toolStripMenuExit_Click(object sender, EventArgs e)
        {
            this.Close(); // закрываем форму
        }

        private void createImg()
        {
            width = editorPanel.Width - 2;
            height = editorPanel.Height - 2;

            pictureEditor.Size = new Size(width, height);

            img = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);

            using (Graphics graf = Graphics.FromImage(img))
                graf.Clear(Color.White);

            pictureEditor.Image = img;

            openFileDialog1.FileName = saveFileDialog1.FileName = String.Empty;

            scale = 100;
            scaleLabel.Text = "Масштаб\n" + scale + "%";
            changed = false;
        }

        private void closeImg(ref Bitmap img)
        {
            linePoints.Clear();
            History.Clear();
            pictureEditor.Image = img = null;
            changed = false;
            MenuHistory.Enabled = MenuHistoryClear.Enabled = MenuHistoryItem1.Enabled = MenuHistoryItem2.Enabled = false;

        }

        private void openImg()
        {
            try
            {
                width = img.Width;
                height = img.Height;
                pictureEditor.Size = new Size(width, height);

                pictureEditor.Image = img;

                scale = 100;
                scaleLabel.Text = "Масштаб\n" + scale + "%";
                changed = false;
            }
            // обрабатываем исключения
            catch (System.IO.FileNotFoundException Ситуация)
            {
                MessageBox.Show(Ситуация.Message + "\nФайл не найден",
                "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
            }
            catch (Exception Ситуация)
            { // Отчет о других ошибках
                MessageBox.Show(Ситуация.Message, "Ошибка2",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void pasteImg()
        {
            closeImg(ref img);
            // Объявление объекта-получателя из буфера обмена
            var ClipBoard = Clipboard.GetDataObject();
            // Если данные в БО представлены в формате Bitmap...
            if (ClipBoard.GetDataPresent(DataFormats.Bitmap) == true)
            {
                try
                {
                    img = (Bitmap)ClipBoard.GetData(DataFormats.Bitmap);
                    openImg();
                    openFileDialog1.FileName = saveFileDialog1.FileName = String.Empty;

                    scale = 100;
                    scaleLabel.Text = "Масштаб\n" + scale + "%";
                    changed = false;

                    History.Clear();
                    historyCounter = 0;
                    MenuHistory.Enabled = true;
                    History.Add(new Bitmap(pictureEditor.Image));
                }
                catch (Exception Ситуация)
                { // Отчет об ошибках
                    MessageBox.Show(Ситуация.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void copyImg()
        {
            // скопировать картинку из PictureBox в буфер обмена
            if (pictureEditor.Image != null)
                Clipboard.SetDataObject(pictureEditor.Image);
        }

        private void saveImg(string FileName)
        {
            img  = (Bitmap)pictureEditor.Image;
            if (img != null)
            {
                if (FileName != String.Empty)
                {
                    try
                    {
                        img.Save(FileName);
                        changed = false;
                    }
                    catch (Exception Ситуация)
                    {
                        // Отчет обо всех возможных ошибках
                        MessageBox.Show(Ситуация.Message, "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }

        private void swap_coords(ref int x0, ref int x1, ref int y0, ref int y1)
        {
            if (linePoints[0].X < linePoints[1].X)
            {
                x0 = linePoints[0].X;
                x1 = linePoints[1].X;
            }
            else
            {
                x1 = linePoints[0].X;
                x0 = linePoints[1].X;
            }
            if (linePoints[0].Y < linePoints[1].Y)
            {
                y0 = linePoints[0].Y;
                y1 = linePoints[1].Y;
            }
            else
            {
                y1 = linePoints[0].Y;
                y0 = linePoints[1].Y;
            }
        }

        private void scale_coords(ref int x0, ref int x1, ref int y0, ref int y1)
        {
            x0 = x0 * 100 / scale;
            x1 = x1 * 100 / scale;
            y0 = y0 * 100 / scale;
            y1 = y1 * 100 / scale;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (changed != true)
                changed = true;

            var pen = new Pen(currcolor1, currthick);
            var brush = new SolidBrush(currcolor2);
            var graf = Graphics.FromImage(img);
            int x0, x1, y0, y1;

            try
            {
                x1 = linePoints[0].X;
                y1 = linePoints[0].Y;
                x0 = y0 = 0;
                if (linePoints.Count > 1)
                {
                    x0 = linePoints[1].X;
                    y0 = linePoints[1].Y;
                }

                switch (currmode)
                {
                    case "pen":
                        //nothing
                        break;
                    case "line":
                        scale_coords(ref x0, ref x1, ref y0, ref y1);
                        graf.DrawLine(pen, new Point(x0, y0), new Point(x1, y1));
                        break;
                    case "square":
                        swap_coords(ref x0, ref x1, ref y0, ref y1);
                        scale_coords(ref x0, ref x1, ref y0, ref y1);
                        if (m_right)
                            graf.FillRectangle(brush, x0, y0, x1 - x0, y1 - y0);
                        graf.DrawRectangle(pen, x0, y0, x1 - x0, y1 - y0);
                        break;
                    case "circle":
                        swap_coords(ref x0, ref x1, ref y0, ref y1);
                        scale_coords(ref x0, ref x1, ref y0, ref y1);
                        if (m_right)
                            graf.FillEllipse(brush, x0, y0, x1 - x0, y1 - y0);
                        graf.DrawEllipse(pen, x0, y0, x1 - x0, y1 - y0);
                        break;
                    case "eraser":
                        scale_coords(ref x0, ref x1, ref y0, ref y1);
                        Point first = new Point(x1 - (currthick / 2), y1 - (currthick / 2));
                        Point second = new Point(x1 + (currthick / 2), y1 - (currthick / 2));
                        Point third = new Point(x1 - (currthick / 2), y1 + (currthick / 2));
                        Point[] destPara = { first, second, third };

                        // Create rectangle for source image.
                        Rectangle srcRect = new Rectangle(x1 - (currthick / 2), y1 - (currthick / 2), currthick, currthick);
                        GraphicsUnit units = GraphicsUnit.Pixel;
                        graf.DrawImage(History[0], destPara, srcRect, units);
                        pictureEditor.Invalidate();
                        break;
                    case "fill":
                        break;
                }
            }
            catch (System.ArgumentOutOfRangeException)
            {
                MessageBox.Show("Начало и конец линии \nНе должны находиться в одной точке\n", "Подсказка",
        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                linePoints.Clear();
                pen.Dispose();
                brush.Dispose();
            }

            MenuHistoryItem1.Enabled = MenuHistoryClear.Enabled = true;

            History.RemoveRange(historyCounter + 1, History.Count - historyCounter - 1);
            History.Add(new Bitmap(pictureEditor.Image));
            if (historyCounter + 1 < 6) historyCounter++;
            if (History.Count - 1 == 6) History.RemoveAt(1);
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                m_left = true;
                m_right = false;
            }
            if (e.Button == MouseButtons.Right)
            {
                m_left = false;
                m_right = true;
            }

            base.OnMouseDown(e);
            linePoints.Clear();

            if (currmode == "eraser" || currmode == "fill")
                linePoints.Add(e.Location);

            pictureEditor.Invalidate();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right)
            {
                switch (currmode)
                {
                    case "pen":
                        int x, y;
                        x = e.X * 100 / scale;
                        y = e.Y * 100 / scale;
                        linePoints.Add(new Point(x, y));
                        pictureEditor.Invalidate();
                        break;
                    case "eraser":
                        break;
                    case "fill":
                        break;
                    default:
                        if (linePoints.Count >= 2)
                            linePoints.RemoveAt(1);
                        linePoints.Add(e.Location);
                        pictureEditor.Invalidate();
                        break;
                }
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            base.OnPaint(e);
            img = (Bitmap)pictureEditor.Image;

            if (linePoints.Count > 1)
            {
                var pen = new Pen(currcolor1, currthick * scale / 100) { StartCap = LineCap.Round, EndCap = LineCap.Round, LineJoin = LineJoin.Round };
                var brush = new SolidBrush(currcolor2);
                Graphics graf = Graphics.FromImage(img);
                int x0, x1, y0, y1;


                if (img != null)
                {
                    if (linePoints[0].X < linePoints[1].X)
                    {
                        x0 = linePoints[0].X;
                        x1 = linePoints[1].X;
                    }
                    else
                    {
                        x1 = linePoints[0].X;
                        x0 = linePoints[1].X;
                    }
                    if (linePoints[0].Y < linePoints[1].Y)
                    {
                        y0 = linePoints[0].Y;
                        y1 = linePoints[1].Y;
                    }
                    else
                    {
                        y1 = linePoints[0].Y;
                        y0 = linePoints[1].Y;
                    }
                    switch (currmode)
                    {
                        case "pen":
                            graf.DrawLines(pen, linePoints.ToArray());
                            break;
                        case "line":
                            e.Graphics.DrawLine(pen, linePoints[0], linePoints[1]);
                            break;
                        case "square":
                            if (m_right)
                                e.Graphics.FillRectangle(brush, x0, y0, x1 - x0, y1 - y0);
                            e.Graphics.DrawRectangle(pen, x0, y0, x1 - x0, y1 - y0);
                            break;
                        case "circle":
                            if (m_right)
                                e.Graphics.FillEllipse(brush, x0, y0, x1 - x0, y1 - y0);
                            e.Graphics.DrawEllipse(pen, x0, y0, x1 - x0, y1 - y0);
                            break;
                        case "eraser":

                            Point first = new Point(linePoints[0].X - (currthick / 2), linePoints[0].Y - (currthick / 2));
                            Point second = new Point(linePoints[0].X + (currthick / 2), linePoints[0].Y - (currthick / 2));
                            Point third = new Point(linePoints[0].X - (currthick / 2), linePoints[0].Y + (currthick / 2));
                            Point[] destPara = { first, second, third };

                            // Create rectangle for source image.
                            Rectangle srcRect = new Rectangle(linePoints[0].X - (currthick / 2), linePoints[0].Y - (currthick / 2), currthick, currthick);
                            GraphicsUnit units = GraphicsUnit.Pixel;
                            e.Graphics.DrawImage(History[0], destPara, srcRect, units);
                            break;
                        case "fill":
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("Для рисования - создайте или откройте изображение\n\n" +
                        "Смотрите (Файл->Создать/Открыть)", "Подсказка",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                pen.Dispose();
                brush.Dispose();
                graf.Dispose();
            }
        }

        private void currcolorpanel_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            currcolor1 = colorDialog1.Color;
            currcolor1Panel.BackColor = currcolor1;

            lineBox.Invalidate();
            penBox.Invalidate();
            squareBox.Invalidate();
            circleBox.Invalidate();
        }

        private void currcolor2Panel_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            currcolor2 = colorDialog1.Color;
            currcolor2Panel.BackColor = currcolor2;

            lineBox.Invalidate();
            penBox.Invalidate();
            squareBox.Invalidate();
            circleBox.Invalidate();
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            if (History.Count != 0)
            {
                MessageBox.Show("Вы вышли за границы изображения\n\n", "Подсказка",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Для рисования - создайте или откройте изображение\n\n" +
                    "Смотрите (Файл->Создать/Открыть)", "Подсказка",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void toolStripMenuPaste_Click(object sender, EventArgs e)
        {
            closeImg(ref img);
            pasteImg();
        }

        private void toolStripMenuCopy_Click(object sender, EventArgs e)
        {
            copyImg();
        }

        private void MenuHistoryClear_Click(object sender, EventArgs e)
        {
            pictureEditor.Image = new Bitmap(History[0]);
            historyCounter = 0;
            linePoints.Clear();
            MenuHistoryClear.Enabled = MenuHistoryItem1.Enabled = false;
            MenuHistoryItem2.Enabled = true;
        }

        private void MenuHistoryItem1_Click(object sender, EventArgs e)
        {
            if (History.Count != 0 && historyCounter != 0)
            {
                MenuHistoryItem2.Enabled = true;
                pictureEditor.Image = new Bitmap(History[--historyCounter]);
                linePoints.Clear();
                pictureEditor.Invalidate();

                if (historyCounter == 0)
                    MenuHistoryItem1.Enabled = MenuHistoryClear.Enabled = false;
            }
        }

        private void MenuHistoryItem2_Click(object sender, EventArgs e)
        {
            if (historyCounter < History.Count - 1)
            {
                MenuHistoryItem1.Enabled = MenuHistoryClear.Enabled = true;
                pictureEditor.Image = new Bitmap(History[++historyCounter]);
                linePoints.Clear();
                pictureEditor.Invalidate();
            }
            if (historyCounter == History.Count - 1)
                MenuHistoryItem2.Enabled = false;
        }

        private void toolStripMenuClose_Click(object sender, EventArgs e)
        {
            closeImg(ref img);
        }

        private void thickSelector_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Разрешаем ввод только десятичных цифр кроме нуля:
            if ((e.KeyChar) == '0') e.Handled = true;
            if (Char.IsDigit(e.KeyChar) == true) return;
            // Запрет на ввод других вводимых символов:
            e.Handled = true;
        }


        private void thickSelector_TextChanged(object sender, EventArgs e)
        {
            currthick = Convert.ToInt32(thickSelector.Text);
        }

        private void lineBox_Click(object sender, EventArgs e)
        {
            currmode = "line";
        }

        private void lineBox_Paint(object sender, PaintEventArgs e)
        {
            using (var pen = new Pen(currcolor1, 3))
                e.Graphics.DrawLine(pen, 0, 0, 27, 27);
        }

        private void lineBox_MouseDown(object sender, MouseEventArgs e)
        {
            lineBox.BackColor = Color.DarkGray;
            lineBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            eraserBox.BorderStyle = squareBox.BorderStyle = circleBox.BorderStyle = penBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        }

        private void lineBox_MouseHover(object sender, EventArgs e)
        {
            lineBox.BackColor = Color.Silver;
        }

        private void lineBox_MouseLeave(object sender, EventArgs e)
        {
            lineBox.BackColor = Color.White;
        }

        private void lineBox_MouseUp(object sender, MouseEventArgs e)
        {
            lineBox.BackColor = Color.White;
        }


        private void penBox_Click(object sender, EventArgs e)
        {
            currmode = "pen";
            penBox.Invalidate();
        }

        private void penBox_Paint(object sender, PaintEventArgs e)
        {
            using (var pen = new Pen(Color.Black, 3))
                e.Graphics.DrawLine(pen, 27, -2, 7, 18);
            using (var brush = new SolidBrush(currcolor1))
                e.Graphics.FillEllipse(brush, -1, 18, 7, 7);
        }

        private void penBox_MouseUp(object sender, MouseEventArgs e)
        {
            penBox.BackColor = Color.White;
        }

        private void penBox_MouseHover(object sender, EventArgs e)
        {
            penBox.BackColor = Color.Silver;
        }

        private void penBox_MouseLeave(object sender, EventArgs e)
        {
            penBox.BackColor = Color.White;
        }

        private void penBox_MouseDown(object sender, MouseEventArgs e)
        {
            penBox.BackColor = Color.DarkGray;
            penBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            eraserBox.BorderStyle = lineBox.BorderStyle = circleBox.BorderStyle = squareBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        }

        private void squareBox_Click(object sender, EventArgs e)
        {
            currmode = "square";
            squareBox.Invalidate();
        }

        private void circleBox_Click(object sender, EventArgs e)
        {
            currmode = "circle";
            circleBox.Invalidate();
        }

        private void squareBox_MouseDown(object sender, MouseEventArgs e)
        {
            squareBox.BackColor = Color.DarkGray;
            squareBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            eraserBox.BorderStyle = lineBox.BorderStyle = circleBox.BorderStyle = penBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        }

        private void squareBox_MouseUp(object sender, MouseEventArgs e)
        {
            squareBox.BackColor = Color.White;
        }

        private void squareBox_MouseHover(object sender, EventArgs e)
        {
            squareBox.BackColor = Color.Silver;
        }

        private void squareBox_MouseLeave(object sender, EventArgs e)
        {
            squareBox.BackColor = Color.White;
        }

        private void squareBox_Paint(object sender, PaintEventArgs e)
        {
            using (var brush = new SolidBrush(currcolor2))
                e.Graphics.FillRectangle(brush, 5, 5, 14, 14);
            using (var pen = new Pen(currcolor1, 3))
                e.Graphics.DrawRectangle(pen, 4, 4, 16, 16);
        }

        private void circleBox_MouseDown(object sender, MouseEventArgs e)
        {
            circleBox.BackColor = Color.DarkGray;
            circleBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            eraserBox.BorderStyle = lineBox.BorderStyle = squareBox.BorderStyle = penBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        }

        private void circleBox_MouseHover(object sender, EventArgs e)
        {
            circleBox.BackColor = Color.Silver;
        }

        private void circleBox_MouseLeave(object sender, EventArgs e)
        {
            circleBox.BackColor = Color.White;
        }

        private void circleBox_MouseUp(object sender, MouseEventArgs e)
        {
            circleBox.BackColor = Color.White;
        }

        private void circleBox_Paint(object sender, PaintEventArgs e)
        {
            using (var brush = new SolidBrush(currcolor2))
                e.Graphics.FillEllipse(brush, 5, 5, 14, 14);
            using (var pen = new Pen(currcolor1, 3))
                e.Graphics.DrawEllipse(pen, 4, 4, 16, 16);
        }

        private void eraserBox_MouseDown(object sender, MouseEventArgs e)
        {
            eraserBox.BackColor = Color.DarkGray;
            eraserBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            circleBox.BorderStyle = lineBox.BorderStyle = squareBox.BorderStyle = penBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        }

        private void eraserBox_MouseLeave(object sender, EventArgs e)
        {
            eraserBox.BackColor = Color.White;
        }

        private void scale_p_button_Click(object sender, EventArgs e)
        {
            if (scale >= 100)
                scale = scale + 25;
            else if (scale < 100 && scale >= 20)
                scale = scale + 10;
            else if (scale < 20 && scale >= 5)
                scale = scale + 5;
            else if (scale < 5 && scale >= 1)
                scale = scale + 1;
            scaleLabel.Text = "Масштаб\n" + scale + "%";

            if (img != null)
            {
                int nwidth, nheight;
                nwidth = width * scale / 100;
                nheight = height * scale / 100;
                pictureEditor.Width = nwidth;
                pictureEditor.Height = nheight;
            }

            pictureEditor.Invalidate();
        }

        private void fillBox_Click(object sender, EventArgs e)
        {
            
        }

        private void scale_m_button_Click(object sender, EventArgs e)
        {
            if (scale > 100)
                scale = scale - 25;
            else if (scale <= 100 && scale > 20)
                scale = scale - 10;
            else if (scale <= 20 && scale > 5)
                scale = scale - 5;
            else if (scale <= 5 && scale > 1)
                scale = scale - 1;
            scaleLabel.Text = "Масштаб\n" + scale + "%";

            if (img != null)
            {
                int nwidth, nheight;
                nwidth = width * scale / 100;
                nheight = height * scale / 100;
                pictureEditor.Width = nwidth;
                pictureEditor.Height = nheight;
            }

            pictureEditor.Invalidate();
        }

        private void eraserBox_MouseHover(object sender, EventArgs e)
        {
            eraserBox.BackColor = Color.Silver;
        }

        private void eraserBox_MouseUp(object sender, MouseEventArgs e)
        {
            eraserBox.BackColor = Color.White;
        }

        private void eraserBox_Click(object sender, EventArgs e)
        {
            currmode = "eraser";
            eraserBox.BackColor = Color.White;
        }

    }
}
