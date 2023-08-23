using System;
using System.Drawing;
using System.Collections.Generic;
using OpenTK.Graphics.OpenGL4;
using CellLifeApp.FieldClasses;

namespace CellLifeApp_0._3.DrawingClasses
{
    class TextureArray : IDisposable
    {
        public static readonly Type[] types = new Type[]
        {
            typeof(Cell),
            typeof(LeafletCell),
            typeof(AntenaCell),
            typeof(RootCell),
            typeof(WoodXCell),
            typeof(WoodTCell),
            typeof(WoodVCell),
            typeof(WoodICell),
            typeof(SingleHeadCell),
            typeof(ColonialHeadCell),
            typeof(SingleSeedCell),
            typeof(ColonialSeedCell),
            //"NoTexture",
            //"OrganicToxic",
            //"ChargeToxic",
            //"AllToxic",
            //"OrganicModeToxic",
            //"ChargeModeToxic"
        };
        public static readonly Dictionary<Type, string> ImagesFileNames = new Dictionary<Type, string>
        {
            [typeof(Cell)] = @"Assets/Textures/empty.png",
            [typeof(LeafletCell)] = @"Assets/Textures/leaflet.png",
            [typeof(AntenaCell)] = @"Assets/Textures/antena.png",
            [typeof(RootCell)] = @"Assets/Textures/root.png",
            [typeof(WoodXCell)] = @"Assets/Textures/woodX.png",
            [typeof(WoodTCell)] = @"Assets/Textures/woodT.png",
            [typeof(WoodVCell)] = @"Assets/Textures/woodV.png",
            [typeof(WoodICell)] = @"Assets/Textures/woodI.png",
            [typeof(SingleHeadCell)] = @"Assets/Textures/headO.png",
            [typeof(ColonialHeadCell)] = @"Assets/Textures/headQ.png",
            [typeof(SingleSeedCell)] = @"Assets/Textures/seedO.png",
            [typeof(ColonialSeedCell)] = @"Assets/Textures/seedQ.png",
            //["NoTexture"] = @"Assets/Textures/notexture.png",
            //["OrganicToxic"] = @"Assets/Textures/organictoxic.png",
            //["ChargeToxic"] = @"Assets/Textures/chargetoxic.png",
            //["AllToxic"] = @"Assets/Textures/alltoxic.png",
            //["OrganicModeToxic"] = @"Assets/Textures/organicmodetoxic.png",
            //["ChargeModeToxic"] = @"Assets/Textures/chargemodetoxic.png"
        };
        private Dictionary<Type, int> _textures = new Dictionary<Type, int>();
        public int this[Type type] { get { return _textures[type]; } }

        public TextureArray()
        {
            foreach (Type type in types)
                _textures.Add(type, InitTextures(ImagesFileNames[type]));
        }

        private int InitTextures(string filename)
        {
            int width, height;
            var data = LoadTexture(filename, out width, out height);
            int texture;
            GL.CreateTextures(TextureTarget.Texture2D, 1, out texture);
            GL.TextureStorage2D(
                texture,
                1,                           // levels of mipmapping
                SizedInternalFormat.Rgba32f, // format of texture
                width,
                height);

            GL.BindTexture(TextureTarget.Texture2D, texture);
            GL.TextureSubImage2D(texture,
                0,                  // this is level 0
                0,                  // x offset
                0,                  // y offset
                width,
                height,
                PixelFormat.Rgba,
                PixelType.Float,
                data);
            return texture;
            // data not needed from here on, OpenGL has the data
        }
        private float[] LoadTexture(string filename, out int width, out int height)
        {
            float[] r;
            using (var bmp = (Bitmap)System.Drawing.Image.FromFile(filename))
            {
                width = bmp.Width;
                height = bmp.Height;
                r = new float[width * height * 4];
                int index = 0;
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        var pixel = bmp.GetPixel(x, y);
                        r[index++] = pixel.R / 255f;
                        r[index++] = pixel.G / 255f;
                        r[index++] = pixel.B / 255f;
                        r[index++] = pixel.A / 255f;
                    }
                }
            }
            return r;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private void Dispose(bool isDispose)
        {
            if (isDispose)
            {
                foreach (var type in types)
                {
                    if (_textures.ContainsKey(type))
                        GL.DeleteTexture(_textures[type]);
                }
            }
        }
    }
}
