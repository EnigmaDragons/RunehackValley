
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RunehackValley.Engine;
using RunehackValley.Graphics;

namespace RunehackValley.Character
{
    public class PlayerCharacter : IGameObject
    {
        // Movement
        private float moveSpeed = 0.12f;
        private HorizontalDirection hDir = HorizontalDirection.None;
        private VerticalDirection vDir = VerticalDirection.None;

        // Render Location
        private Vector2 screenPositionOffset = new Vector2(200, 200);

        // Animations
        private readonly Animations anims;
        private string facing = "Down";
        private bool IsMoving => hDir != HorizontalDirection.None || vDir != VerticalDirection.None;
        private string AnimState => $"{facing}-{IsMoving}";

        public PlayerCharacter()
        {
            anims = new PlayerCharacterAnimations();
        }

        public void LoadContent()
        {
            anims.LoadContent();
        }

        public void UnloadContent()
        {
            anims.UnloadContent();
        }

        public void Update(GameTime deltaTime)
        {
            anims.Update(deltaTime);
            var distance = new Distance(deltaTime.ElapsedGameTime.Milliseconds, moveSpeed);
            screenPositionOffset = Vector2.Add(new Movement(distance, hDir, vDir).GetDelta(), screenPositionOffset);
        }
        
        public void Draw(SpriteBatch sprites)
        {
            sprites.Draw(anims.CurrentFrame, screenPositionOffset);
        }

        public void IssueCommand(HorizontalDirection dir)
        {
            hDir = dir;

            if (!dir.Equals(HorizontalDirection.None))
                facing = dir.ToString();

            UpdateAnimState();
        }

        public void IssueCommand(VerticalDirection dir)
        {
            vDir = dir;

            if (!dir.Equals(VerticalDirection.None))
                facing = dir.ToString();

            UpdateAnimState();
        }

        private void UpdateAnimState()
        {
            anims.SetState(AnimState);
        }
    }
}
