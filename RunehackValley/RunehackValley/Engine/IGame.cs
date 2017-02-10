using Microsoft.Xna.Framework.Graphics;

namespace RunehackValley.Engine
{
    public interface IGame
    {
        T Load<T>(string resourceName);
        GraphicsDevice Graphics { get; }
    }
}
