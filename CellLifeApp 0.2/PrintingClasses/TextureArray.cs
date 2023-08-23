using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using CellLifeApp.FieldClasses;

namespace CellLifeApp.PrintingClasses
{
    [Serializable]
    class TextureArray
    {
        public static readonly string[] types = new string[]
        {
            "Cell",
            "LeafletCell",
            "AntenaCell",
            "RootCell",
            "WoodXCell",
            "WoodTCell",
            "WoodVCell",
            "WoodICell",
            "SingleHeadCell",
            "ColonialHeadCell",
            "SingleSeedCell",
            "ColonialSeedCell",
            "NoTexture",
            "OrganicToxic",
            "ChargeToxic",
            "AllToxic",
            "OrganicModeToxic",
            "ChargeModeToxic"
        };
        public static readonly string[] rotatebleTypes = new string[]
        {
            "LeafletCell",
            "AntenaCell",
            "RootCell",
            "WoodTCell",
            "WoodVCell",
            "WoodICell",
            "SingleHeadCell",
            "ColonialHeadCell",
            "SingleSeedCell",
            "ColonialSeedCell",
        };
        public static readonly string[] gradientableTypes = new string[]
        {
            "Cell",
            "LeafletCell",
            "AntenaCell",
            "RootCell",
            "WoodXCell",
            "WoodTCell",
            "WoodVCell",
            "WoodICell",
            "SingleHeadCell",
            "ColonialHeadCell",
            "SingleSeedCell",
            "ColonialSeedCell",
        };
        private Dictionary<string, Image[]> SizedTextures;
        private Dictionary<string, Image[,]> SizedRotatedTextures;
        private Dictionary<string, Image[,]> SizedGradientTextures;
        private Dictionary<string, Image[,,]> SizedRotatedGradientTextures;
        private const int maxResolution = 9; // 2^(9-1) = 256 , максимальный размер текстурки будет 256*256 пикселей
        private const int precision = 20;
        private const int range = Cell.toxicLevel / precision;
        public string CamMode { get; set; }
        public int Resolution { get; set; }
        public virtual Image this[Cell cell]
        {
            get
            {
                if (CamMode == "Default")
                    return GetDefaultImage(cell);
                else
                    return GetModedImage(cell);
            }
        }

        public TextureArray()
        {
            Dictionary<string, string> ImagesFileNames = new Dictionary<string, string>
            {
                ["Cell"] = "Textures/empty.png",
                ["LeafletCell"] = "Textures/leaflet.png",
                ["AntenaCell"] = "Textures/antena.png",
                ["RootCell"] = "Textures/root.png",
                ["WoodXCell"] = "Textures/woodX.png",
                ["WoodTCell"] = "Textures/woodT.png",
                ["WoodVCell"] = "Textures/woodV.png",
                ["WoodICell"] = "Textures/woodI.png",
                ["SingleHeadCell"] = "Textures/headO.png",
                ["ColonialHeadCell"] = "Textures/headQ.png",
                ["SingleSeedCell"] = "Textures/seedO.png",
                ["ColonialSeedCell"] = "Textures/seedQ.png",
                ["NoTexture"] = "Textures/notexture.png",
                ["OrganicToxic"] = "Textures/organictoxic.png",
                ["ChargeToxic"] = "Textures/chargetoxic.png",
                ["AllToxic"] = "Textures/alltoxic.png",
                ["OrganicModeToxic"] = "Textures/organicmodetoxic.png",
                ["ChargeModeToxic"] = "Textures/chargemodetoxic.png"
            };
            Dictionary<string, Image> defaultTextures = new Dictionary<string, Image>();
            SizedTextures = new Dictionary<string, Image[]>();
            SizedRotatedTextures = new Dictionary<string, Image[,]>();
            SizedGradientTextures = new Dictionary<string, Image[,]>();
            SizedRotatedGradientTextures = new Dictionary<string, Image[,,]>();
            foreach (string type in types)
            {
                defaultTextures.Add(type, Image.FromFile(ImagesFileNames[type]));
                SizedTextures.Add(type, new Image[maxResolution]);
                if (!rotatebleTypes.Contains(type) && gradientableTypes.Contains(type))
                    SizedGradientTextures.Add(type, new Image[maxResolution, precision - 1]);
                if (rotatebleTypes.Contains(type))
                    SizedRotatedTextures.Add(type, new Image[maxResolution, 4]);
                if (rotatebleTypes.Contains(type) && gradientableTypes.Contains(type))
                    SizedRotatedGradientTextures.Add(type, new Image[maxResolution, 4, precision - 1]);
                for (int i = 0; i < maxResolution; i++)
                {
                    int resolution = (int)Math.Pow(2, i);
                    SizedTextures[type][i] = ResizeImage(defaultTextures[type], resolution);
                    Image GetGradientImage(Image image, int gradient)
                    {
                        Bitmap bitmap = new Bitmap(SizedTextures[type][i]);
                        int a = gradient * range * 255 / Cell.toxicLevel;
                        for (int x = 0; x < bitmap.Width; x++)
                        {
                            for (int y = 0; y < bitmap.Height; y++)
                            {
                                Color c = bitmap.GetPixel(x, y);
                                int R = c.R, G = c.G, B = c.B;
                                R -= a;
                                G -= a;
                                B -= a;
                                if (R < 0) { R = 0; }
                                if (G < 0) { G = 0; }
                                if (B < 0) { B = 0; }
                                bitmap.SetPixel(x, y, Color.FromArgb(R, G, B));
                            }
                        }
                        return bitmap;
                    }
                    if (gradientableTypes.Contains(type) && !rotatebleTypes.Contains(type))
                        for (int k = 0; k < precision - 1; k++)
                            SizedGradientTextures[type][i, k] = GetGradientImage(SizedTextures[type][i], k + 1);
                    if (rotatebleTypes.Contains(type))
                        for (int j = 0; j < 4; j++)
                        {
                            SizedRotatedTextures[type][i, j] = (Image)SizedTextures[type][i].Clone();
                            SizedRotatedTextures[type][i, j].RotateFlip((RotateFlipType)j);
                        }
                    if (rotatebleTypes.Contains(type) && gradientableTypes.Contains(type))
                        for (int j = 0; j < 4; j++)
                        {
                            for (int k = 0; k < precision - 1; k++)
                            {
                                SizedRotatedGradientTextures[type][i, j, k] = GetGradientImage(SizedTextures[type][i], k + 1);
                                SizedRotatedGradientTextures[type][i, j, k].RotateFlip((RotateFlipType)j);
                            }
                        }
                }
            }
        }
        private Image GetDefaultImage(Cell cell)
        {
            if (cell == null)
                return SizedTextures["NoTexture"][Resolution];
            if (cell.Organic >= Cell.toxicLevel)
                return SizedTextures["OrganicToxic"][Resolution];
            if (cell.Charge >= Cell.toxicLevel)
                return SizedTextures["ChargeToxic"][Resolution];
            if (cell.Organic >= Cell.toxicLevel && cell.Charge >= Cell.toxicLevel)
                return SizedTextures["AllToxic"][Resolution];
            if (!rotatebleTypes.Contains(cell.GetType().Name) && gradientableTypes.Contains(cell.GetType().Name))
                return SizedTextures[cell.GetType().Name][Resolution];
            return SizedRotatedTextures[cell.GetType().Name][Resolution, (int)((IRotateble)cell).Direction];
        }
        private Image GetModedImage(Cell cell)
        {
            if (cell == null)
                return SizedTextures["NoTexture"][Resolution];
            int ItPrecision;
            string typeOfToxic;
            if (CamMode == "Organic")
            {
                ItPrecision = cell.Organic / range;
                typeOfToxic = "OrganicModeToxic";
            }
            else
            {
                ItPrecision = cell.Charge / range;
                typeOfToxic = "ChargeModeToxic";
            }
            if (ItPrecision == 0)
                return GetDefaultImage(cell);
            if (ItPrecision >= precision)
                return SizedTextures[typeOfToxic][Resolution];
            if (gradientableTypes.Contains(cell.GetType().Name) && !rotatebleTypes.Contains(cell.GetType().Name))
                return SizedGradientTextures[cell.GetType().Name][Resolution, ItPrecision - 1];
            return SizedRotatedGradientTextures[cell.GetType().Name][Resolution, (int)((IRotateble)cell).Direction, ItPrecision - 1];
        }
        public static Bitmap ResizeImage(Image image, int resolution)
        {
            int width = resolution, height = resolution;
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);
            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);
            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }
            return destImage;
        }

        public void SaveImages()
        {
            //SizedTextures["ColonialSeedCell"][0].Save(@"newTextures\seedQ1.png");
            //SizedTextures["ColonialSeedCell"][1].Save(@"newTextures\seedQ2.png");
            //SizedTextures["ColonialSeedCell"][2].Save(@"newTextures\seedQ4.png");
            //SizedTextures["ColonialSeedCell"][3].Save(@"newTextures\seedQ8.png");
            //SizedTextures["ColonialSeedCell"][4].Save(@"newTextures\seedQ16.png");
            //SizedTextures["ColonialSeedCell"][5].Save(@"newTextures\seedQ32.png");
            //SizedTextures["ColonialSeedCell"][6].Save(@"newTextures\seedQ64.png");
            //SizedTextures["ColonialSeedCell"][7].Save(@"newTextures\seedQ128.png");
            SizedTextures["ColonialSeedCell"][8].Save(@"newTextures\seedQ256.png");
        }
    }
}
