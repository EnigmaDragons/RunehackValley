using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RunehackValley.Engine;
using RunehackValley.MonoGame;

namespace RunehackValley.Specifics
{
    public class Mailbox : IGameObject
    {
        private Texture2D texture;

        public void LoadContent()
        {
            texture = new LoadedTexture("Mailbox").Get();
        }

        public void UnloadContent()
        {
            texture.Dispose();
        }

        public void Update(GameTime deltaTime)
        {
        }

        public void Draw(SpriteBatch sprites)
        {
            sprites.Draw(texture, new Vector2(14 * 64, 4 * 64), Color.White);
        }
    }
}
