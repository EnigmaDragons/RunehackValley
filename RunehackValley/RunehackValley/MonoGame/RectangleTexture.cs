using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RunehackValley.Engine;

namespace RunehackValley.MonoGame
{
    public class RectangleTexture
    {
        private readonly int _width;
        private readonly int _height;
        private readonly Color _color;
        private readonly GraphicsDevice _device;

        public RectangleTexture(int width, int height, Color color)
        {
            _width = width;
            _height = height;
            _color = color;
            _device = new GraphicsDeviceInstance().Get();
        }

        public Texture2D Create()
        {
            var data = new Color[_width * _height];
            for (var i = 0; i < data.Length; ++i)
                data[i] = _color;

            var texture = new Texture2D(_device, _width, _height);
            texture.SetData(data);
            return texture;
        }
    }
}
