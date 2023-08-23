using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using ManagedCuda.NPP;


namespace ALProject.Drawings
{
    class DrawingField
    {
        PictureBox screen;
        Field field;
        Graphics screenGraphics;
        TextureMass textures = new TextureMass();
        int newTextureRes, defTextureRes;

        Image visibleSector;
        Graphics sectorGraphics;

        public DrawingField(PictureBox screen, Field field, int resolution)
        {
            this.screen = screen;
            this.field = field;
            defTextureRes = textures.Resolution;
            SetNewCellResolution(resolution);
            ScreenUpdate();
        }

        public void ScreenUpdate()
        {
            screen.Image = new Bitmap(screen.Width, screen.Height);
            screenGraphics = Graphics.FromImage(screen.Image);
            visibleSector = new Bitmap(defTextureRes * screen.Width / newTextureRes, defTextureRes * screen.Height / newTextureRes);
            sectorGraphics = Graphics.FromImage(visibleSector);
        }
        public void SetNewCellResolution(int resolution)
        {
            newTextureRes = resolution;
            visibleSector = new Bitmap(defTextureRes * screen.Width / newTextureRes, defTextureRes * screen.Height / newTextureRes);
            sectorGraphics = Graphics.FromImage(visibleSector);
        }
        public void PrintField()
        {
            sectorGraphics.Clear(Color.Black);
            for (int i = 0; i * defTextureRes < visibleSector.Height; i++)
            {
                for (int j = 0; j * defTextureRes < visibleSector.Width; j++)
                {
                    sectorGraphics.DrawImage(textures.GetTexture(field[i % field.Rows, j % field.Cols]),
                        j * defTextureRes, i * defTextureRes);
                }
            }
            screenGraphics.DrawImage(visibleSector, 0, 0, screen.Width, screen.Height);
            screen.Refresh();
        }
    }
}