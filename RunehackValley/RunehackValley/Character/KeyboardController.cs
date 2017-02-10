using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RunehackValley.Engine;

namespace RunehackValley.Character
{
    public class KeyboardController : IGameObject
    {
        private readonly PlayerCharacter _character;

        public KeyboardController(PlayerCharacter character)
        {
            _character = character;
        }
        
        public void LoadContent()
        {
        }

        public void UnloadContent()
        {
        }

        public void Update(GameTime deltaTime)
        {
            var ks = Keyboard.GetState();
            if (ks.IsKeyDown(Keys.W))
                _character.IssueCommand(VerticalDirection.Up);
            else if (ks.IsKeyDown(Keys.S))
                _character.IssueCommand(VerticalDirection.Down);
            else
                _character.IssueCommand(VerticalDirection.None);


            if (ks.IsKeyDown(Keys.A))
                _character.IssueCommand(HorizontalDirection.Left);
            else if (ks.IsKeyDown(Keys.D))
                _character.IssueCommand(HorizontalDirection.Right);
            else
                _character.IssueCommand(HorizontalDirection.None);
        }

        public void Draw(SpriteBatch sprites)
        {
        }
    }
}
