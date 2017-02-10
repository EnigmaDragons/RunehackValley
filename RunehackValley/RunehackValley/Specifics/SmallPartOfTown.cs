using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RunehackValley.Engine;
using RunehackValley.MonoGame;

namespace RunehackValley.Specifics
{
    public class SmallPartOfTown : IGameView
    {
        private Texture2D mapTexture;

        public void LoadContent()
        {
            mapTexture = new LoadedTexture("Farm.png").Get();
        }

        public void UnloadContent()
        {
            mapTexture.Dispose();
        }

        public void Update(GameTime deltaTime)
        {
        }

        public void Draw(SpriteBatch sprites)
        {
            sprites.Draw(mapTexture, new Rectangle(+6, +10, 23 * 16 + 12, 17 * 16 + 6), Color.White);
        }
    }
}
