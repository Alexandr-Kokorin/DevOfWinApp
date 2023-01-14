using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace Lab2CS
{
    public partial class MainForm : Form
    {
        private IFunction function;
        private Graphics graphics;
        private int PIX_IN_ONE;
        private int ARR_LEN;
        private int sizeX;
        private int sizeY;
        private Color graphicsColor;
        private int offsetX;
        private int offsetY;
        private bool isMove;
        private int mousePositionX;
        private int mousePositionY;
        private BackgroundSettings BGSettings;
        private bool isControlPressed;
        private float circleSizeMultiplier;
        private bool isCircleResize;

        public MainForm() {
            InitializeComponent();
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty
            | BindingFlags.Instance | BindingFlags.NonPublic, null,
            panel, new object[] { true });
            saveFileDialog.Filter = "PNG|*.png";
            this.MouseWheel += new MouseEventHandler(panel_MouseWheel);
            BGSettings = new BackgroundSettings();
            graphics = panel.CreateGraphics();
            panel.BackColor = Color.White;
            graphicsColor = Color.Black;
            PIX_IN_ONE = 20;
            ARR_LEN = 10;
            offsetX = 0;
            offsetY = 0;
            isMove = false;
            isControlPressed = false;
            circleSizeMultiplier = 1;
            isCircleResize = false;
        }

        private void randomFunction_Click(object sender, EventArgs e) {
            Random random = new Random();
            switch (random.Next(1,6)) {
                case 1: function = new Sin(); break;
                case 2: function = new X2(); break;
                case 3: function = new Tg(); break;
                case 4: function = new X3(); break;
                case 5: function = new _2xPlus5(); break;
            }
            PIX_IN_ONE = 20;
            offsetX = 0;
            offsetY = 0;
            panel.Invalidate();
        }

        private void save_Click(object sender, EventArgs e) {
            if (saveFileDialog.ShowDialog() == DialogResult.OK) {
                Bitmap bmp = new Bitmap(panel.ClientSize.Width, panel.ClientSize.Height);
                panel.DrawToBitmap(bmp, panel.ClientRectangle);
                bmp.Save(saveFileDialog.FileName, ImageFormat.Bmp);
            }
        }

        private void colorSelection_Click(object sender, EventArgs e) {
            if (colorDialog.ShowDialog() == DialogResult.OK) {
                graphicsColor = colorDialog.Color;
                panel.Invalidate();
            }
        }

        private void backgroundSelection_Click(object sender, EventArgs e) {
            if (BGSettings.ShowDialog() == DialogResult.OK) {
                panel.BackColor = Color.White;
                panel.BackgroundImage = null;
                if (BGSettings.selectedIndex == 0) panel.BackColor = BGSettings.color;
                if (BGSettings.selectedIndex == 3) panel.BackgroundImage = Image.FromFile("img" + BGSettings.image + ".png");
                panel.Invalidate();
            }
        }

        private void panel_Paint(object sender, PaintEventArgs e) {
            graphicsUpdate(e.Graphics);
            drawBackground();
            DrawXAxis(new Point(-sizeX + offsetX, 0), new Point(sizeX + offsetX, 0));
            DrawYAxis(new Point(0, sizeY + offsetY), new Point(0, -sizeY + offsetY));
            graphics.FillEllipse(Brushes.Red, -2, -2, 4, 4);
            drawDashCircle();
            if (function != null) drawFunction();
            if (PIX_IN_ONE != 20) drawZoom("x" + ((float)PIX_IN_ONE / 20).ToString());
        }

        private void MainForm_Resize(object sender, EventArgs e) {
            panel.Invalidate();
        }

        private void panel_MouseWheel(object sender, MouseEventArgs e) {
            if (e.Delta < 0 && PIX_IN_ONE > 5) {
                if (PIX_IN_ONE >= 50) PIX_IN_ONE -= 2;
                else PIX_IN_ONE--;
            }
            if (e.Delta > 0 && PIX_IN_ONE < 100) {
                if (PIX_IN_ONE >= 50) PIX_IN_ONE += 2;
                else PIX_IN_ONE++;
            }
            panel.Invalidate();
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.ControlKey) isControlPressed = true;
        }

        private void MainForm_KeyUp(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.ControlKey) isControlPressed = false;
        }

        private void panel_MouseMove(object sender, MouseEventArgs e) {
            if (isMove) {
                if (!isControlPressed) {
                offsetX -= (e.X - mousePositionX);
                offsetY -= (e.Y - mousePositionY);
                } else if (isCircleResize) {
                    float distance = (float)Math.Sqrt(Math.Pow(e.X - (sizeX - offsetX), 2) + Math.Pow(e.Y - (sizeY - offsetY), 2));
                    circleSizeMultiplier = distance / PIX_IN_ONE;
                }
                panel.Invalidate();
                mousePositionX = e.X;
                mousePositionY = e.Y;
            }
        }

        private void panel_MouseDown(object sender, MouseEventArgs e) {
            isMove = true;
            float distance = (float)Math.Sqrt(Math.Pow(e.X - (sizeX - offsetX), 2) + Math.Pow(e.Y - (sizeY - offsetY), 2));
            float size = PIX_IN_ONE * circleSizeMultiplier;
            if (distance > size - 3 && distance < size + 3) isCircleResize = true;
            mousePositionX = e.X;
            mousePositionY = e.Y;
        }

        private void panel_MouseUp(object sender, MouseEventArgs e) {
            isMove = false;
            isCircleResize = false;
        }

        private void graphicsUpdate(Graphics graphics) {
            this.graphics = graphics;
            sizeX = panel.ClientSize.Width / 2;
            sizeY = panel.ClientSize.Height / 2;
            this.graphics.TranslateTransform(sizeX - offsetX, sizeY - offsetY);
        }

        private void drawDashCircle() {
            Pen pen = new Pen(Color.Black, 1);
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            int size = (int)(PIX_IN_ONE * circleSizeMultiplier);
            graphics.DrawEllipse(pen, -size, -size, size * 2, size * 2);
        }

        private void drawBackground() {
            if (BGSettings.selectedIndex == 1) {
                switch (BGSettings.hatching) {
                    case 0: drawHorizontalHatching(); break;
                    case 1: drawVerticalHatching(); break;
                    case 2: drawObliqueHatching1(); break;
                    case 3: drawObliqueHatching2(); break;
                    case 4: drawObliqueHatching1(); drawObliqueHatching2(); break;
                }
            }
            if (BGSettings.selectedIndex == 2) {
                drawCharacterBG();
            }
        }

        private void drawHorizontalHatching() {
            for (int y = -sizeY + offsetY; y < sizeY + offsetY; y += 10) {
                Point p1 = new Point(-sizeX + offsetX, y);
                Point p2 = new Point(sizeX + offsetX, y);
                graphics.DrawLine(Pens.LightGray, p1, p2);
            }
        }

        private void drawVerticalHatching() {
            for (int x = -sizeX + offsetX; x < sizeX + offsetX; x += 10) {
                Point p1 = new Point(x, -sizeY + offsetY);
                Point p2 = new Point(x, sizeY + offsetY);
                graphics.DrawLine(Pens.LightGray, p1, p2);
            }
        }

        private void drawObliqueHatching1() {
            for (int x = -sizeX + offsetX; x < sizeX + offsetX + sizeY; x += 10) {
                Point p1 = new Point(x, -sizeY + offsetY);
                Point p2 = new Point(x - sizeY, sizeY + offsetY);
                graphics.DrawLine(Pens.LightGray, p1, p2);
            }
        }

        private void drawObliqueHatching2() {
            for (int x = -sizeX + offsetX - sizeY; x < sizeX + offsetX; x += 10) {
                Point p1 = new Point(x, -sizeY + offsetY);
                Point p2 = new Point(x + sizeY, sizeY + offsetY);
                graphics.DrawLine(Pens.LightGray, p1, p2);
            }
        }

        private void drawCharacterBG() {
            if (BGSettings.characters.Length == 0) return;
            var font = new Font(Font.FontFamily, 10);
            var size = graphics.MeasureString(BGSettings.characters, font);
            for (int y = -sizeY + offsetY; y < sizeY + offsetY; y += (int)size.Height) {
                for (int x = -sizeX + offsetX; x < sizeX + offsetX; x += (int)size.Width) {
                    var rect = new RectangleF(new Point(x, y), size);
                    graphics.DrawString(BGSettings.characters, font, Brushes.LightGray, rect);
                }
            }
        }

        private void drawFunction() {
            Pen pen = new Pen(graphicsColor, 2);
            if (function is Tg) {
                Point point1 = new Point(-sizeX + offsetX, -(int)(function.calc((float)(-sizeX + offsetX) / PIX_IN_ONE) * PIX_IN_ONE));
                for (int i = 1; i < panel.ClientSize.Width; i++) {
                    Point point2= new Point(i - sizeX + offsetX, -(int)(function.calc((float)(i - sizeX + offsetX) / PIX_IN_ONE) * PIX_IN_ONE));
                    if (!(point1.Y * point2.Y < 0 && Math.Abs(point1.Y - point2.Y) > PIX_IN_ONE)) {
                        graphics.DrawLine(pen, point1, point2);
                        IntersectionPointSignature(point2);
                    }
                    point1 = point2;
                }
            } else {
                Point[] points = new Point[panel.ClientSize.Width];
                for (int i = 0; i < points.Length; i++) {
                    points[i] = new Point(i - sizeX + offsetX, -(int)(function.calc((float)(i - sizeX + offsetX) / PIX_IN_ONE) * PIX_IN_ONE));
                    IntersectionPointSignature(points[i]);
                }
                graphics.DrawLines(pen, points);
            }
        }

        private void IntersectionPointSignature(Point point) {
            int distance = (int)Math.Sqrt(Math.Pow(point.X, 2) + Math.Pow(point.Y, 2));
            int size = (int)(PIX_IN_ONE * circleSizeMultiplier);
            if (distance == size) {
                var font = new Font(Font.FontFamily, 6);
                var sizeText = graphics.MeasureString(point.X + " , " + point.Y, font);
                var rect = new RectangleF(new Point(point.X + 5, point.Y - 5), sizeText);
                graphics.DrawString(point.X + " , " + point.Y, font, Brushes.Black, rect);
            }
        }

        private void drawZoom(string text) {
            var font = new Font(Font.FontFamily, 12);
            var size = graphics.MeasureString(text, font);
            var rect = new RectangleF(new Point(sizeX + offsetX - sizeX/10 - (int)size.Width/2, -sizeY + offsetY + sizeY / 10 - (int)size.Height / 2), size);
            graphics.DrawString(text, font, Brushes.Black, rect);
        }

        private void DrawXAxis(Point start, Point end) {
            for (int i = PIX_IN_ONE; i < end.X - ARR_LEN; i += PIX_IN_ONE) {
                graphics.DrawLine(Pens.Black, i, -5, i, 5);
                DrawText(new Point(i, 5), (i / PIX_IN_ONE).ToString());
            }
            for (int i = -PIX_IN_ONE; i > start.X; i -= PIX_IN_ONE) {
                graphics.DrawLine(Pens.Black, i, -5, i, 5);
                DrawText(new Point(i, 5), (i / PIX_IN_ONE).ToString());
            }
            graphics.DrawLine(Pens.Black, start, end);
            if (end.X > ARR_LEN) graphics.DrawLines(Pens.Black, GetArrow(start.X, start.Y, end.X, end.Y, ARR_LEN));
        }

        private void DrawYAxis(Point start, Point end) {
            for (int i = PIX_IN_ONE; i < start.Y; i += PIX_IN_ONE) {
                graphics.DrawLine(Pens.Black, -5, i, 5, i);
                DrawText(new Point(5, i), (-i / PIX_IN_ONE).ToString(), true);
            }
            for (int i = -PIX_IN_ONE; i > end.Y + ARR_LEN; i -= PIX_IN_ONE) {
                graphics.DrawLine(Pens.Black, -5, i, 5, i);
                DrawText(new Point(5, i), (-i / PIX_IN_ONE).ToString(), true);
            }
            graphics.DrawLine(Pens.Black, start, end);
            if (end.Y < -ARR_LEN) graphics.DrawLines(Pens.Black, GetArrow(start.X, start.Y, end.X, end.Y, ARR_LEN));
        }

        private void DrawText(Point point, string text, bool isYAxis = false) {
            var font = new Font(Font.FontFamily, 6);
            var size = graphics.MeasureString(text, font);
            var pt = isYAxis
                ? new PointF(point.X + 1, point.Y - size.Height / 2)
                : new PointF(point.X - size.Width / 2, point.Y + 1);
            var rect = new RectangleF(pt, size);
            graphics.DrawString(text, font, Brushes.Black, rect);
        }

        private static PointF[] GetArrow(float x1, float y1, float x2, float y2, float len = 10, float width = 4) {
            PointF[] result = new PointF[3];
            var n = new PointF(x2 - x1, y2 - y1);
            var l = (float)Math.Sqrt(n.X * n.X + n.Y * n.Y);
            var v1 = new PointF(n.X / l, n.Y / l);
            n.X = x2 - v1.X * len;
            n.Y = y2 - v1.Y * len;
            result[0] = new PointF(n.X + v1.Y * width, n.Y - v1.X * width);
            result[1] = new PointF(x2, y2);
            result[2] = new PointF(n.X - v1.Y * width, n.Y + v1.X * width);
            return result;
        }

    }
}
