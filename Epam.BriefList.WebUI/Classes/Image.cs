using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Epam.BriefList.WebUI.Classes
{
    public static class Image
    {
        public static byte[] CreateBllImage(HttpPostedFile loadImage)
        {
            var image = new byte[loadImage.ContentLength];
            loadImage.InputStream.Read(image, 0, loadImage.ContentLength);
            loadImage.InputStream.Close();
            return image;
        }
    }
}