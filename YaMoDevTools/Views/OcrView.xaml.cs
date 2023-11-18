using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ImTools;
using Microsoft.Win32;
using PaddleOCRSharp;
using Prism.Services.Dialogs;
using static System.Collections.Specialized.BitVector32;
using static System.Net.Mime.MediaTypeNames;
using Image = System.Drawing.Image;

namespace YaMoDevTools.Views
{
    /// <summary>
    /// OcrView.xaml 的交互逻辑
    /// </summary>
    public partial class OcrView : UserControl
    {
        private readonly string[] ImgAllow = new string[] { "jpg", "png", "peg", "bmp" };
        private PaddleOCREngine engine;
        public OcrView()
        {
            InitializeComponent();
           
            this.Dispatcher.Invoke(new Action(
                delegate
                {
                    OcrEngineInit();
                }
                ));
        }

        private void OcrEngineInit()
        {
            OCRModelConfig config = null;
            OCRParameter oCRParameter = new OCRParameter();
            engine = new PaddleOCREngine(config, oCRParameter);
        }
        /// <summary>
        /// 子线程执行完成时的回调
        /// </summary>
        private void CallBack(IAsyncResult ar)
        {
        }
        /// <summary>
        /// OCR页面中的拖放图像功能事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void imgOcrImgInputDragDrop_Event(object sender, DragEventArgs e)
        {
            string file = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
            string ext = file.ToLower().Substring(file.Length - 3);
            if (ImgAllow.Contains(ext))
            {

                img_OcrImgInput.Source = new BitmapImage(new Uri(file));

                Thread cancelThread = new Thread(ImageOcrStart);
                cancelThread.IsBackground = true;
                cancelThread.Start();
                //ImageOcrStart();
            }
        }

        private void imgOcrImgInputDragEnter_Event(object sender, DragEventArgs e)
        {

        }

        /// <summary>
        /// OCR页面中的OCR识别功能
        /// </summary>
        private void ImageOcrStart()
        {
            OCRResult ocrResult = new OCRResult();

            Bitmap bitmap;
            this.Dispatcher.Invoke(new Action(delegate
            {
                bitmap = ImageSourceToBitmap(img_OcrImgInput.Source);
                ocrResult = engine.DetectText(bitmap);
                if (ocrResult != null)
                {
                    txt_OcrResultOutput.Text = ocrResult.Text.ToString();
                }
            }));
        }

        /// <summary>
        /// ImageSource转Bitmap工具函数
        /// </summary>
        /// <param name="imageSource">From Image Control Source</param>
        /// <returns></returns>
        private static System.Drawing.Bitmap ImageSourceToBitmap(ImageSource imageSource)
        {
            BitmapSource m = (BitmapSource)imageSource;
            // 坑点：选Format32bppRgb将不带透明度
            System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(m.PixelWidth, m.PixelHeight, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);

            System.Drawing.Imaging.BitmapData data = bmp.LockBits(
            new System.Drawing.Rectangle(System.Drawing.Point.Empty, bmp.Size), System.Drawing.Imaging.ImageLockMode.WriteOnly, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);

            m.CopyPixels(Int32Rect.Empty, data.Scan0, data.Height * data.Stride, data.Stride);
            bmp.UnlockBits(data);

            return bmp;
        }

        private void btn_importImgFromClip(object sender, MouseButtonEventArgs e)
        {

            if (Clipboard.ContainsImage())
            {
                var img = Clipboard.GetImage();
                img_OcrImgInput.Source = img;
                ImageOcrStart();
            }
            else
            {
                MessageBox.Show("剪贴板没有可以使用的图像资源", "ERROR");
            }

        }
    }
}
