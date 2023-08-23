using System;
using System.Drawing;
using System.IO;
using System.Collections.Generic;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common.Input;
using OpenTK.Windowing.GraphicsLibraryFramework;

using CellLifeApp_0._3.DrawingClasses;
using CellLifeApp.FieldClasses;

namespace CellLifeApp_0._3
{
    class AppWindow : GameWindow
    {
        private readonly string _title;
        private double _frameTime;
        private float _fieldTime;
        private bool _isFieldUpdates = false;
        private KeyboardState _oldState;
        private float _camSpeed = 1.0f;
        private float _time;
        private int _fps;
        private Vector2 _position = new Vector2(0);
        private float _scale = 0.1f;
        private Matrix4 _projectionMatrix;
        private Matrix4 _modelViewMatrix;

        private float _fov = 90f;

        private Field _field;
        private TextureArray _textureArray;
        private FieldPrinter _printer;

        public AppWindow(NativeWindowSettings windowSettings) 
            : base(GameWindowSettings.Default, windowSettings)
        {
            // вывод в кансоль некоторой информации
            Console.WriteLine(GL.GetString(StringName.Version));
            Console.WriteLine(GL.GetString(StringName.Vendor));
            Console.WriteLine(GL.GetString(StringName.Renderer));
            Console.WriteLine(GL.GetString(StringName.ShadingLanguageVersion));

            // загрузка иконки
            byte[] iconData = LoadByteDataTexture(@"Icon.png", out int iconWidth, out int iconHeight);
            OpenTK.Windowing.Common.Input.Image image = new OpenTK.Windowing.Common.Input.Image(iconWidth, iconHeight, iconData);
            Icon = new WindowIcon(image);

            // включим вертикальную синхронизацию кадров
            VSync = VSyncMode.Off;
            // оставим курсор видимым
            CursorVisible = true;
            // в заголовке указываем версию приложения
            _title += "CellLifeApp V0.3: OpenGL Version: " + GL.GetString(StringName.Version);
        }

        protected override void OnLoad()
        {
            Console.Write("OnLoad ..."); // показываем, что началась загрузка
            base.OnLoad();

            GL.ClearColor(Color4.Aquamarine); // цвет заднего фона

            _field = new Field();
            //_field.TestPattern0();
            _field.SetFieldSize(100, 100);
            _field.SetClearField();

            _textureArray = new TextureArray();

            _printer = new FieldPrinter(_field, _textureArray);
            CreateProjection();
            CreateModelViewMat();

            _fieldTime = 1f;

            // отключаем отображение задних граней
            GL.Enable(EnableCap.CullFace);
            GL.CullFace(CullFaceMode.Back);
            //GL.PolygonMode(MaterialFace.Front, PolygonMode.Line);
            //GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Line);
            GL.PatchParameter(PatchParameterInt.PatchVertices, 3);
            GL.PointSize(3);
            GL.Enable(EnableCap.DepthTest);

            Console.WriteLine(" done"); // показываем, что загрузка закончилась
        }

        protected override void OnResize(ResizeEventArgs e)
        {
            base.OnResize(e);
            GL.Viewport(0, 0, Size.X, Size.Y);
            CreateProjection();
        }

        protected override void OnUpdateFrame(FrameEventArgs args)
        {
            _time += (float)args.Time;
            _frameTime += (float)args.Time;
            _fps++;

            if (_frameTime >= 1.0f)
            {
                _frameTime = 0.0f;
                _fps = 0;
            }
            Title = $"{_title}: (Vsync: {VSync}) FPS: {(int)(1/args.Time)}, X:{_position.X}, Y:{_position.Y}, Z:{_scale}";

            if (_isFieldUpdates && _time >= _fieldTime)
            {
                _field.UpdateField();
                _time = 0.0f;
            }

            HandleKeboard(args.Time);

            base.OnUpdateFrame(args);
        }

        protected override void OnRenderFrame(FrameEventArgs args)
        {
            base.OnRenderFrame(args);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            _printer.Draw(_projectionMatrix, _modelViewMatrix);

            SwapBuffers();
        }

        protected override void OnUnload()
        {
            Console.WriteLine("Window closing called");

            _printer.Dispose();
            _textureArray.Dispose();

            base.OnUnload();
        }

        //-------------------------------------------------------------------------
        // Check Pressed Keys
        private void HandleKeboard(double time)
        {
            var key = KeyboardState;

            if (key.IsKeyDown(Keys.Escape))
                Close();
            var keyState = KeyboardState;

            if (keyState.IsKeyDown(Keys.Escape))
            {
                Close();
            }
            if (keyState.IsKeyDown(Keys.M))
            {
                GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Point);
            }
            if (keyState.IsKeyDown(Keys.Comma))
            {
                GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Line);
            }
            if (keyState.IsKeyDown(Keys.Period))
            {
                GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Fill);
            }

            if (keyState.IsKeyDown(Keys.Space) && _oldState.IsKeyDown(Keys.Space))
            {
                _isFieldUpdates = !_isFieldUpdates;
            }
            if (keyState.IsKeyDown(Keys.J))
            {
                _fov = 40f;
                CreateProjection();
            }
            if (keyState.IsKeyDown(Keys.K))
            {
                _fov = 50f;
                CreateProjection();
            }
            if (keyState.IsKeyDown(Keys.L))
            {
                _fov = 60f;
                CreateProjection();
            }
            if (keyState.IsKeyDown(Keys.Semicolon))
            {
                _fov = 90f;
                CreateProjection();
            }

            if (keyState.IsKeyDown(Keys.Equal))
            {
                _scale += _camSpeed / 100 * (float)time;
                CreateModelViewMat();
            }
            if (keyState.IsKeyDown(Keys.Minus))
            {
                _scale -= _camSpeed / 100 * (float)time;
                if (_scale < 0.001f)
                    _scale = 0.001f;
                CreateModelViewMat();
            }
            if (keyState.IsKeyDown(Keys.A))
            {
                _position.X += _camSpeed * (float)time;
                CreateModelViewMat();
            }
            if (keyState.IsKeyDown(Keys.D))
            {
                _position.X -= _camSpeed * (float)time;
                CreateModelViewMat();
            }
            if (keyState.IsKeyDown(Keys.S))
            {
                _position.Y += _camSpeed * (float)time;
                CreateModelViewMat();
            }
            if (keyState.IsKeyDown(Keys.W))
            {
                _position.Y -= _camSpeed * (float)time;
                CreateModelViewMat();
            }
            _oldState = keyState;
        }
        private void CreateProjection()
        {
            var aspectRatio = (float)Size.X / Size.Y;
            _projectionMatrix = Matrix4.CreatePerspectiveFieldOfView(
                _fov * ((float)Math.PI / 180f), // field of view angle, in radians
                aspectRatio,                // current window aspect ratio
                0.1f,                       // near plane
                4000f);                     // far plane
        }
        private void CreateModelViewMat()
        {
            _modelViewMatrix = Matrix4.CreateScale(_scale);
            _modelViewMatrix = _modelViewMatrix * Matrix4.CreateTranslation(_position.X, _position.Y, 0f);
        }

        private byte[] LoadByteDataTexture(string filename, out int width, out int height)
        {
            byte[] r;
            using (var bmp = (Bitmap)System.Drawing.Image.FromFile(filename))
            {
                width = bmp.Width;
                height = bmp.Height;
                r = new byte[width * height * 4];
                int index = 0;
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        var pixel = bmp.GetPixel(x, y);
                        r[index++] = pixel.R;
                        r[index++] = pixel.G;
                        r[index++] = pixel.B;
                        r[index++] = pixel.A;
                    }
                }
            }
            return r;
        }
    }
}
