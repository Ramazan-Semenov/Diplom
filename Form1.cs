using BarcodeLib;
using iTextSharp.text.pdf;
using MaterialSkin.Controls;
using MessagingToolkit.QRCode.Codec;
using System;
using System.Drawing;
using System.Windows.Forms;
namespace WindowsFormsApp4
{
    public partial class Form1 : MaterialForm
    {
        private readonly decimal cena;
        private readonly string name;
        private readonly int id;
        public Form1()
        {
            InitializeComponent();
        }
        public Form1(decimal cena, string name, int id)
        {
            InitializeComponent();
            this.cena = cena;
            this.name = name;
            this.id = id;
        }
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        public static extern long BitBlt(IntPtr hdcDest, int nXDest, int nYDest,
         int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, int dwRop);
        private Bitmap memoryImage;
        private void CaptureScreen()
        {
            Graphics mygraphics = CreateGraphics();
            Size s = Size;
            memoryImage = new Bitmap(s.Width, s.Height, mygraphics);
            Graphics memoryGraphics = Graphics.FromImage(memoryImage);
            IntPtr dc1 = mygraphics.GetHdc();
            IntPtr dc2 = memoryGraphics.GetHdc();
            BitBlt(dc2, 0, 0, ClientRectangle.Width,
                ClientRectangle.Height, dc1, 0, 0, 13369376);
            mygraphics.ReleaseHdc(dc1);
            memoryGraphics.ReleaseHdc(dc2);
        }
        private void qr()
        {
            string qrtext = id.ToString(); //считываем текст из TextBox'a
            QRCodeEncoder encoder = new QRCodeEncoder(); //создаем объект класса QRCodeEncoder
            Bitmap qrcode = encoder.Encode(qrtext); // кодируем слово, полученное из TextBox'a (qrtext) в переменную qrcode. класса Bitmap(класс, который используется для работы с изображениями)
            pictureBox1.Image = qrcode; // pictureBox выводит qrcode как изображение.
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Barcode_Generator(pictureBox2);
            qr();
            label5.Text = name;
            label6.Text = DateTime.Now.ToString();
            label7.Text = cena.ToString();
        }

        private void Barcode_Generator(PictureBox picture)
        {
            try
            {
                BarcodeLib.Barcode barcode = new BarcodeLib.Barcode()
                {
                    IncludeLabel =true ,
                    Alignment = AlignmentPositions.CENTER,
                    Width = 300,
                    Height = 100,
                    RotateFlipType = RotateFlipType.RotateNoneFlipNone,
                    BackColor = Color.White,
                    ForeColor = Color.Black,
                };
                BaseFont baseFont = BaseFont.CreateFont(@"C:\Windows\Fonts\Arial.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                iTextSharp.text.Font font = new iTextSharp.text.Font(baseFont, 14);
                
                    Image img = barcode.Encode(TYPE.CODE128B, id.ToString(), Color.Black, Color.White, picture.Width, picture.Height);

                    picture.Image = img;
                
                
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void Form1_DoubleClick(object sender, EventArgs e)
        {
            CaptureScreen();
            SaveFileDialog save = new SaveFileDialog
            {
                Filter = "PNG|*.png|JPEG|*.jpg|GIF|*.gif|BMP|*.bmp" //создаём фильтр, который определяет, в каких форматах мы сможем сохранить нашу информацию. В данном случае выбираем форматы изображений. Записывается так: "название_формата_в обозревателе|*.расширение_формата")
            }; // save будет запрашивать у пользователя место, в которое он захочет сохранить файл. 
            if (save.ShowDialog() == System.Windows.Forms.DialogResult.OK) //если пользователь нажимает в обозревателе кнопку "Сохранить".
            {
                memoryImage.Save(save.FileName); //изображение из pictureBox'a сохраняется под именем, которое введёт пользователь
            }
        }
    }
}
