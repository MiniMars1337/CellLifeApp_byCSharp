using System;
using System.Collections.Generic;
using System.Text;
using OpenTK.Mathematics;
using OpenTK.Graphics.OpenGL4;

using CellLifeApp.FieldClasses;

namespace CellLifeApp_0._3.DrawingClasses
{
    class FieldPrinter : IDisposable
    {
        private Field field;
        private TextureArray textures;
        private ShaderProgram _shaderProgram;
        private CellRenderObject[,] cellRenders;

        public FieldPrinter(Field field, TextureArray textures)
        {
            this.field = field;
            this.textures = textures;

            _shaderProgram = new ShaderProgram();
            _shaderProgram.AddShader(ShaderType.VertexShader, @"Assets\Shaders\textureVertexShader.vert");
            _shaderProgram.AddShader(ShaderType.FragmentShader, @"Assets\Shaders\textureFragmentShader.frag");
            _shaderProgram.Link();

            cellRenders = new CellRenderObject[field.Cols, field.Rows];
            for (int y = 0; y < field.Rows; y++)
                for (int x = 0; x < field.Cols; x++)
                    cellRenders[x, y] = new CellRenderObject(_shaderProgram.Id, CreateCellSquare(x, y, 128), textures[typeof(LeafletCell)]);
        }

        public void Draw(Matrix4 projection, Matrix4 modelView)
        {
            //GL.UniformMatrix4(20, false, ref projection);
            GL.UniformMatrix4(21, false, ref modelView);
            GL.UseProgram(_shaderProgram.Id);
            for (int y = 0; y < field.Rows; y++)
            {
                for (int x = 0; x < field.Cols; x++)
                {
                    //cellRenders[x, y].Bind(textures[field[x, y].GetType()]);
                    //cellRenders[x, y].Bind(textures[typeof(LeafletCell)]);
                    cellRenders[x, y].Bind();
                    cellRenders[x, y].Render();
                }
            }
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
                GL.BindVertexArray(0);
                GL.DeleteProgram(_shaderProgram.Id);
            }
        }

        private TexturedVertex[] CreateCellSquare(float x, float y, int w)
        {
            x *= 2;
            y *= 2;
            TexturedVertex[] vertices = {
                new TexturedVertex(x-1,y+1, 0, 0),
                new TexturedVertex(x-1,y-1, 0, w),
             //   new TexturedVertex(x+1,y-1, w, w),
                new TexturedVertex(x+1,y-1, w, w),
                new TexturedVertex(x+1,y+1, w, 0),
             //   new TexturedVertex(x-1,y+1, 0, 0),
            };
            return vertices;
        }
    }
}
