
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RunehackValley.Engine;
using RunehackValley.MonoGame;

namespace RunehackValley.Character
{
    public class PlayerCharacter : IGameObject
    {
        private float moveSpeed = 0.2f;
        private Texture2D sprite;
        private HorizontalDirection hDir = HorizontalDirection.None;
        private VerticalDirection vDir = VerticalDirection.None;
        private Vector2 screenPositionOffset = new Vector2(200, 200);
        private CharSpace charSpace;

        public PlayerCharacter(CharSpace charSpace)
        {
            this.charSpace = charSpace;
        }

        public void LoadContent()
        {
            sprite = new LoadedTexture("Sprites/Character/nami-d1").Get();
        }

        public void UnloadContent()
        {
            sprite?.Dispose();
        }

        public void Update(GameTime deltaTime)
        {
            var distance = new Distance(deltaTime.ElapsedGameTime.Milliseconds, moveSpeed);
            screenPositionOffset = charSpace.GetOffsetAfterMove(new Movement(distance, hDir, vDir).GetDelta());
        }
        
        public void Draw(SpriteBatch sprites)
        {
            sprites.Draw(sprite, new Rectangle((int)screenPositionOffset.X, (int)screenPositionOffset.Y + 64, 64, 128), Color.White);
        }

        public void IssueCommand(HorizontalDirection dir)
        {
            hDir = dir;
        }

        public void IssueCommand(VerticalDirection dir)
        {
            vDir = dir;
        }
    }
}
