using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;

namespace PointerPosition
{
    class Program
    {
        [DllImport("user32.dll")]
        private static extern bool GetCursorPos(out POINT lpPoint);

        [DllImport("user32.dll")]
        private static extern int GetSystemMetrics(int nIndex);

        [StructLayout(LayoutKind.Sequential)]
        private struct POINT
        {
            public int X;
            public int Y;
        }

        private const int SM_CXSCREEN = 0;
        private const int SM_CYSCREEN = 1;

        static void Main(string[] args)
        {
            string logFilePath = "log.txt";

            // Verifica se o arquivo de log já existe e, se sim, exclui o conteúdo existente
            if (File.Exists(logFilePath))
                File.WriteAllText(logFilePath, string.Empty);

            Console.WriteLine("Exibindo a posição do cursor. Pressione Enter para sair.");

            // Obtém a posição atual do cursor e tira um print da tela continuamente até que a tecla Enter seja pressionada
            while (true)
            {
                if (Console.KeyAvailable && Console.ReadKey().Key == ConsoleKey.Enter)
                    break;

                Point cursorPosition = GetCursorPosition();

                Bitmap screenshot = CaptureScreen(cursorPosition);
                string screenshotPath = $"screenshot_{DateTime.Now:yyyyMMddHHmmss}.png";
                screenshot.Save(screenshotPath, ImageFormat.Png);

                string logMessage = $"Posição do cursor: X={cursorPosition.X}, Y={cursorPosition.Y} | Captura de tela: {screenshotPath}";
                Console.WriteLine(logMessage);
                AppendToLog(logFilePath, logMessage);

                System.Threading.Thread.Sleep(100);
            }
        }

        static Point GetCursorPosition()
        {
            GetCursorPos(out POINT lpPoint);
            return new Point(lpPoint.X, lpPoint.Y);
        }

        static Bitmap CaptureScreen(Point cursorPosition)
        {
            Rectangle screenBounds = new Rectangle(0, 0, ScreenWidth(), ScreenHeight());

            Bitmap screenshot = new Bitmap(screenBounds.Width, screenBounds.Height, PixelFormat.Format32bppArgb);

            using (Graphics graphics = Graphics.FromImage(screenshot))
            {
                graphics.CopyFromScreen(screenBounds.X, screenBounds.Y, 0, 0, screenBounds.Size, CopyPixelOperation.SourceCopy);

                int squareSize = 20;
                int squareX = cursorPosition.X - squareSize / 2;
                int squareY = cursorPosition.Y - squareSize / 2;

                using (Pen pen = new Pen(Color.Red, 2))
                using (Font font = new Font("Arial", 12, FontStyle.Bold))
                using (SolidBrush brush = new SolidBrush(Color.White))
                {
                    graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    graphics.DrawRectangle(pen, squareX, squareY, squareSize, squareSize);
                    graphics.DrawString($"X={cursorPosition.X}, Y={cursorPosition.Y}", font, brush, squareX + squareSize, squareY);
                }
            }

            return screenshot;
        }

        static void AppendToLog(string filePath, string logMessage)
        {
            using (StreamWriter writer = File.AppendText(filePath))
            {
                writer.WriteLine(logMessage);
            }
        }

        // Função para obter a largura da tela
        static int ScreenWidth()
        {
            return GetSystemMetrics(SM_CXSCREEN);
        }

        // Função para obter a altura da tela
        static int ScreenHeight()
        {
            return GetSystemMetrics(SM_CYSCREEN);
        }
    }
}
