using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace eZeljeznice.Web.Helper
{
    public class ImageUpload
    {
        public static byte[] GetImageFromFileUpload(HttpPostedFileBase file)
        {



            byte[] byteImage = null;
            BinaryReader reader = new BinaryReader(file.InputStream);
            byteImage = reader.ReadBytes((int)file.ContentLength);
       
            return byteImage;
        }
    }
}