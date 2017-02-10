using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RunehackValley.Character;
using RunehackValley.Engine;
using RunehackValley.MonoGame;

namespace RunehackValley.Views
{
    public class PlayerMoveTestView : IGameView
    {
        private readonly KeyboardController controller;
        private readonly PlayerCharacter playerChar;

        public PlayerMoveTestView()
        {
            playerChar = new PlayerCharacter();
            controller = new KeyboardController(playerChar);
        }

        public void LoadContent()
        {
            playerChar.LoadContent();
        }

        public void UnloadContent()
        {
            playerChar.UnloadContent();
        }

        public void Update(GameTime deltaTime)
        {
            playerChar.Update(deltaTime);
            controller.Update(deltaTime);
        }

        public void Draw(SpriteBatch sprites)
        {
            new ViewBackgroundColor(Color.Black).Draw();
            playerChar.Draw(sprites);
        }
    }
}
