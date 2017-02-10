using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using RunehackValley.Character;
using RunehackValley.Engine;
using RunehackValley.MonoGame;
using RunehackValley.Specifics;

namespace RunehackValley.Views
{
    public class SmallPartOfTown : IGameView
    {
        private readonly KeyboardController controller;
        private readonly PlayerCharacter playerChar;
        private readonly Mailbox mailbox;
        private Texture2D mapTexture;
        private Song backgroundTrack;

        public SmallPartOfTown()
        {
            playerChar = new PlayerCharacter(new Map(new Vector2(64 * 8, 64 * 8)));
            controller = new KeyboardController(playerChar);
            mailbox = new Mailbox();
        }

        public void LoadContent()
        {
            mapTexture = new LoadedTexture("Farm.png").Get();
            backgroundTrack = new LoadedSong("FarmMusic").Get();
            playerChar.LoadContent();
            mailbox.LoadContent();
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Play(backgroundTrack);
        }

        public void UnloadContent()
        {
            mapTexture.Dispose();
            backgroundTrack.Dispose();
            playerChar.UnloadContent();
            mailbox.UnloadContent();
        }

        public void Update(GameTime deltaTime)
        {
            playerChar.Update(deltaTime);
            controller.Update(deltaTime);
            mailbox.Update(deltaTime);
        }

        public void Draw(SpriteBatch sprites)
        {
            new ViewBackgroundColor(Color.Black).Draw();
            sprites.Draw(mapTexture, new Rectangle(0, 0, 1408, 1088), Color.White);
            playerChar.Draw(sprites);
            mailbox.Draw(sprites);
        }
    }
}
