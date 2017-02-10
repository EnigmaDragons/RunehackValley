using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RunehackValley.Engine;

namespace RunehackValley.MonoGame
{
    public class ViewBackgroundColor
    {
        private readonly Color _color;
        private readonly GraphicsDevice _device;

        public ViewBackgroundColor(Color color)
        {
            _color = color;
            _device = new GraphicsDeviceInstance().Get();
        }

        public void Draw()
        {
            _device.Clear(_color);
        }
    }
}
