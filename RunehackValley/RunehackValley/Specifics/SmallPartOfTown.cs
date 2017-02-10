using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using RunehackValley.Engine;
using RunehackValley.MonoGame;

namespace RunehackValley.Specifics
{
    public class SmallPartOfTown : IGameView
    {
        private Texture2D mapTexture;
        private Song backgroundTrack;

        public void LoadContent()
        {
            mapTexture = new LoadedTexture("Farm.png").Get();
            backgroundTrack = new LoadedSong("FarmMusic").Get();
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Play(backgroundTrack);
        }

        public void UnloadContent()
        {
            mapTexture.Dispose();
            backgroundTrack.Dispose();
        }

        public void Update(GameTime deltaTime)
        {
        }

        public void Draw(SpriteBatch sprites)
        {
            sprites.Draw(mapTexture, new Rectangle(0, 0, 1408, 1088), Color.White);
        }
    }
}
