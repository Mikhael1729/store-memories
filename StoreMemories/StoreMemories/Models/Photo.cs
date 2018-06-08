using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.IO;
using Xamarin.Forms;

namespace StoreMemories.Models
{
    public class Photo : EntityBase
    {
        public byte[] ImageByte { get; set; }

        [NotMapped]
        public ImageSource ImageSource
        {
            get
            {
                try
                {
                    if (ImageByte == null)
                        return null;

                    var imageByteArray = ImageByte;

                    return ImageSource.FromStream(() => new MemoryStream(imageByteArray));
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e);
                    return null;
                }
            }
        }
    }
}
