using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ALProject.Drawings
{

    class CellTexture
    {
        private Image[] _textures = new Image[4];
        public TextureNames TextureName { get; }
        public Image this[byte i] { get { return _textures[i]; } }

        public static Image RotateTexture(Image image, RotateFlipType direct)
        {
            var res = (Image)image.Clone();
            res.RotateFlip(direct);
            return res;
        }
        private void LoadTexture(string filename)
        {
            _textures[0] = Image.FromFile(filename);
            for (int i = 1; i < 4; i++)
                _textures[i] = RotateTexture(_textures[0], (RotateFlipType)i);
        }
        public CellTexture(TextureNames name)
        {
            TextureName = name;
            LoadTexture(TextureMass.FileNames[(int)TextureName]);
        }
    }

    class TextureMass
    {
        public readonly static string[] FileNames = new string[] {
            "Textures/empty.png",
            "Textures/leaflet.png",
            "Textures/antena.png",
            "Textures/root.png",
            "Textures/woodX.png",
            "Textures/woodT.png",
            "Textures/woodV.png",
            "Textures/woodI.png",
            "Textures/headO.png",
            "Textures/headQ.png",
            "Textures/seedO.png",
            "Textures/seedQ.png",
            "Textures/notexture.png" };
        private CellTexture[] textures;
        public int Resolution { get; private set; }

        private void LoadTextures()
        {
            textures = new CellTexture[FileNames.Length];
            for (int i = 0; i < textures.Length; i++)
                textures[i] = new CellTexture((TextureNames)i);
            Resolution = textures[0][0].Width;
        }
        public Image GetTexture(Cell cell)
        {
            for (int i = 0; i < textures.Length; i++)
            {
                if (cell.TextureName == textures[i].TextureName)
                    return textures[i][cell.Direction];
            }
            return null;
        }
        public TextureMass()
        {
            LoadTextures();
        }
    }
}
