﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using CellLifeApp.FieldClasses;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace CellLifeApp.PrintingClasses
{
    class FieldPrinter
    {
        public struct Position
        {
            public float X { get; set; }
            public float Y { get; set; }
            public Position(float x, float y)
            {
                X = x;
                Y = y;
            }
        }
        private Field field;
        private PictureBox screen;
        private TextureArray textures;
        private Graphics graphics;
        public Position camPos = new Position(50.5f, 50.5f);
        private Position LUFieldPoint, RDFieldPoint;
        private int resolution, camSpeed = 1;
        private const float camMoveConst = 0.1f;
        private Pen selectionPen = Pens.Aqua;
        private FileStream fs;
        private BinaryFormatter bf = new BinaryFormatter();
        public int CamSpeed { get { return camSpeed; } set { camSpeed = value; } }
        public string CamMode { get { return textures.CamMode; } set { textures.CamMode = value; } }

        public FieldPrinter(Field field, PictureBox screen, int resolution, int camSpeed = 10, string mode = "Default")
        {
            this.camSpeed = camSpeed;
            this.screen = screen;
            this.field = field;
            //CreateTextures();
            LoadTextures();
            CamMode = mode;
            SetCellResolution(resolution);
            screen.Image = new Bitmap(screen.Width, screen.Height);
            graphics = Graphics.FromImage(screen.Image);
        }

        public void SetCellResolution(int resolution)
        {
            textures.Resolution = resolution;
            resolution = (int)Math.Pow(2, resolution);
            this.resolution = resolution;
            CamUpdate();
            //GC.Collect(2, GCCollectionMode.Forced);
        }
        public void PrintField()
        {
            graphics.Clear(Color.Gray);
            for (int y = (int)LUFieldPoint.Y - 1; y < RDFieldPoint.Y + 1; y++)
                for (int x = (int)LUFieldPoint.X - 1; x < RDFieldPoint.X + 1; x++)
                    graphics.DrawImage(textures[field[x, y]],
                        (int)((x - LUFieldPoint.X) * resolution),
                        (int)((y - LUFieldPoint.Y) * resolution));
            graphics.DrawRectangle(selectionPen, 
                (int)(((int)camPos.X - LUFieldPoint.X) * resolution), 
                (int)(((int)camPos.Y - LUFieldPoint.Y) * resolution), 
                resolution, resolution);
            screen.Refresh();
        }
        public void CamMove(Direct direct)
        {
            switch (direct)
            {
                case Direct.Up:
                    camPos.Y -= camMoveConst * camSpeed;
                    if (camPos.Y < 0)
                        camPos.Y += field.Rows;
                    break;
                case Direct.Right:
                    camPos.X += camMoveConst * camSpeed;
                    if (camPos.X > field.Cols)
                        camPos.X %= field.Cols;
                    break;
                case Direct.Down:
                    camPos.Y += camMoveConst * camSpeed;
                    if (camPos.Y > field.Rows)
                        camPos.Y %= field.Rows;
                    break;
                case Direct.Left:
                    camPos.X -= camMoveConst * camSpeed;
                    if (camPos.X < 0)
                        camPos.X += field.Cols;
                    break;
                default:
                    break;
            }
            CamUpdate();
        }
        private void CamUpdate()
        {
            camPos.X = (float)Math.Round(camPos.X, 3);
            camPos.Y = (float)Math.Round(camPos.Y, 3);
            LUFieldPoint = new Position(
                camPos.X - (float)screen.Width / resolution / 2,
                camPos.Y - (float)screen.Height / resolution / 2);
            RDFieldPoint = new Position(
                camPos.X + (float)screen.Width / resolution / 2,
                camPos.Y + (float)screen.Height / resolution / 2);
        }
        private void LoadTextures()
        {
            fs = new FileStream("TextureArray.bin", FileMode.Open);
            textures = (TextureArray)bf.Deserialize(fs);
            fs.Close();
            textures.SaveImages();
        }
        private void CreateTextures()
        {
            textures = new TextureArray();
            fs = new FileStream("TextureArray.bin", FileMode.Create);
            bf.Serialize(fs, textures);
        }
    }
}
