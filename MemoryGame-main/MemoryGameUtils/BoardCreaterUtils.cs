using System;
using System.Net;
using System.Collections.Generic;
using System.Drawing;
using B20_Ex05_01.MemoryGameUtils;

namespace B20_Ex05_01.UIFolder
{
    internal class BoardCreaterUtils
    {
        private const string k_RandomURL = "https://picsum.photos/80";

        internal static Cell<Image>[,] CreateImageBoard(int i_Columns, int i_Rows)
        {
            Cell<Image>[,] imageMatrix = new Cell<Image>[i_Columns, i_Rows];
            Image image, randomImage;
            Random randomIndex = new Random();
            List<Image> images = new List<Image>(i_Columns * i_Rows);

            for (int i = 0; i < images.Capacity / 2; i++)
            { 
                image = loadImage();
                images.Add(image);
                images.Add(image);
            }

            for (int i = 0; i < images.Capacity; i++)
            {
                randomImage = images[randomIndex.Next(images.Count)];
                imageMatrix[(i % i_Columns), (i / i_Columns)].Value = randomImage;
                imageMatrix[(i % i_Columns), (i / i_Columns)].Index = i;
                images.Remove(randomImage);
            }

            return imageMatrix;
        }

        private static Image loadImage()
        {
            WebRequest webRequest;
            WebResponse webResponse;
            Bitmap bitmap;

            webRequest = WebRequest.Create(k_RandomURL);
            webResponse = webRequest.GetResponse();
            System.IO.Stream responseStream = webResponse.GetResponseStream();
            bitmap = new Bitmap(responseStream);
            responseStream.Dispose();
            return bitmap;
        }

        internal static string SingleOrPloural(int i_Sum)
        {
            string singleOrPloural = "s";

            if (i_Sum == 1)
            {
                singleOrPloural = "(s)";
            }

            return singleOrPloural;
        }
    }
}
