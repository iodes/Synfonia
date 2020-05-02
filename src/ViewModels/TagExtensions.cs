﻿using System;
using System.IO;
using System.Reactive.Linq;
using Avalonia.Media.Imaging;
using System.Linq;

namespace Symphony.ViewModels
{
    public static class TagExtensions
    {
        public static IBitmap LoadAlbumCover(this TagLib.Tag tag)
        {
            var cover = tag.Pictures.FirstOrDefault(x => x.Type == TagLib.PictureType.FrontCover);

            if (cover != null)
            {
                using (var ms = new MemoryStream(cover.Data.Data))
                {
                    try
                    {
                        return new Bitmap(ms);
                    }
                    catch (Exception)
                    {
                        return null;
                    }
                }
            }

            return null;
        }

    }
}
