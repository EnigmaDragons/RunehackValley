using Microsoft.Xna.Framework.Graphics;

namespace RunehackValley.Engine
{
    public class GraphicsDeviceInstance
    {
        public GraphicsDevice Get()
        {
            return new GameInstance().Graphics;
        }
    }
}
