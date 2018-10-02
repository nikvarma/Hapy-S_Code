using Hapy.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Hapy.MiddelLayer
{
    public class Location : ILocation
    {
        public ActionReturn GetMapStaticImage(LocationImage image)
        {
            string base64String = string.Empty;
            string fileName = Guid.NewGuid().ToString();
            string filePath = string.Format("{0}\\{1}.{2}", CommonLibrary.Util.ServerPath("LocationImages"), fileName, image.ImageFormat);
            
            string url = image.MapURL + "?center=" + image.Center + "&zoom=" + image.Zoom + "&size=" + image.Size + "&key=" + image.APIKey;
            using (WebClient client = new WebClient())
            {
                client.DownloadFile(url, filePath);
                Image imageFile = Image.FromFile(filePath);
                using (MemoryStream m = new MemoryStream())
                {
                    imageFile.Save(m, System.Drawing.Imaging.ImageFormat.Png);
                    byte[] imageBytes = m.ToArray();
                    base64String = Convert.ToBase64String(imageBytes);
                }
            }
            return new ActionReturn()
            {
                Id = fileName,
                Status = true,
                Message = base64String
            };
        }

        private byte[] GetStream(Stream stream)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                stream.CopyTo(ms);
                return ms.ToArray();
            }
        }
    }
}
