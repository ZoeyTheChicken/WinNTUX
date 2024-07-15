using System;
using System.Runtime.InteropServices;

namespace WinNTUX
{
    public class WallpaperHandler
    {
        private const uint SPI_SETDESKWALLPAPER = 0x0014;
        private const uint SPIF_UPDATEINIFILE = 0x01;
        private const uint SPIF_SENDCHANGE = 0x02;
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SystemParametersInfo(uint uiAction, uint uiParam, string pvParam, uint fWinIni);

        /// <summary>
        /// Changes the desktop wallpaper.
        /// </summary>
        /// <param name="imagePath">The path to the image file.</param>
        /// <returns>True if the wallpaper was successfully changed, otherwise false.</returns>
        public bool SetDesktopWallpaper(string imagePath)
        {
            int result = SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, imagePath, SPIF_UPDATEINIFILE | SPIF_SENDCHANGE);
            return result != 0;
        }
    }
}
