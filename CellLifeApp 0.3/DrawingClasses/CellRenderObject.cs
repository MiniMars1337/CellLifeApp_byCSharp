using System;
using System.Collections.Generic;
using System.Text;
using OpenTK.Graphics.OpenGL4;

namespace CellLifeApp_0._3.DrawingClasses
{
    class CellRenderObject : IDisposable
    {
        public readonly int _program;
        public readonly int _vertexArray;
        public readonly int _buffer;
        public readonly int _verticeCount;
        public readonly int _texture;

        public CellRenderObject(int program, TexturedVertex[] vertices, int texture)
        {
            _program = program;
            _verticeCount = vertices.Length;
            _texture = texture;
            this._vertexArray = GL.GenVertexArray();
            this._buffer = GL.GenBuffer();
            GL.BindVertexArray(this._vertexArray);
            GL.BindBuffer(BufferTarget.ArrayBuffer, this._buffer);

            GL.NamedBufferStorage(
                _buffer,
                TexturedVertex.Size * vertices.Length,        // the size needed by this buffer
                vertices,                           // data to initialize with
                BufferStorageFlags.MapWriteBit);    // at this point we will only write to the buffer

            GL.VertexArrayAttribBinding(_vertexArray, 0, 0);
            GL.EnableVertexArrayAttrib(_vertexArray, 0);
            GL.VertexArrayAttribFormat(
                _vertexArray,
                0,                      // attribute index, from the shader location = 0
                2,                      // size of attribute, vec4
                VertexAttribType.Float, // contains floats
                false,                  // does not need to be normalized as it is already, floats ignore this flag anyway
                0);                     // relative offset, first item

            GL.VertexArrayAttribBinding(_vertexArray, 1, 0);
            GL.EnableVertexArrayAttrib(_vertexArray, 1);
            GL.VertexArrayAttribFormat(
                _vertexArray,
                1,                      // attribute index, from the shader location = 1
                2,                      // size of attribute, vec2
                VertexAttribType.Float, // contains floats
                false,                  // does not need to be normalized as it is already, floats ignore this flag anyway
                8);                     // relative offset after a vec4

            // link the vertex array and buffer and provide the stride as size of Vertex
            GL.VertexArrayVertexBuffer(_vertexArray, 0, _buffer, IntPtr.Zero, TexturedVertex.Size);
        }

        public void Bind(int texture)
        {
            GL.UseProgram(_program);
            GL.BindVertexArray(_vertexArray);
            GL.BindTexture(TextureTarget.Texture2D, texture);
        }
        public void Bind()
        {
            //GL.UseProgram(_program);
            GL.BindVertexArray(_vertexArray);
            GL.BindTexture(TextureTarget.Texture2D, _texture);
        }
        public virtual void Render()
        {
            GL.DrawArrays(PrimitiveType.Quads, 0, _verticeCount);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public void Dispose(bool disposing)
        {
            if (disposing)
            {
                GL.DeleteVertexArray(_vertexArray);
                GL.DeleteBuffer(_buffer);
            }
        }
    }
}
