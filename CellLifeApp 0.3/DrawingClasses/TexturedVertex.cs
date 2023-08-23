using OpenTK.Mathematics;

namespace CellLifeApp_0._3.DrawingClasses
{
    struct TexturedVertex
    {
        public const int Size = (2 + 2) * 4;
        private Vector2 position;
        private Vector2 textureCord;

        public TexturedVertex(float x, float y, float tx, float ty)
        {
            position = new Vector2(x, y);
            textureCord = new Vector2(tx, ty);
        }
    }
}
