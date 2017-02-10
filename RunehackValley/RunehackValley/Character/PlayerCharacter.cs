
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
        private CharSpace charSpace;

        // Animations
        private readonly Animations anims;
        private string facing = "Down";
        private bool IsMoving => hDir != HorizontalDirection.None || vDir != VerticalDirection.None;
        private string AnimState => $"{facing}-{IsMoving}";

        public PlayerCharacter(CharSpace charSpace)
        {
            anims = new PlayerCharacterAnimations();
            this.charSpace = charSpace;
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
            screenPositionOffset = charSpace.GetOffsetAfterMove(new Movement(distance, hDir, vDir).GetDelta());
        }
        
        public void Draw(SpriteBatch sprites)
        {
            sprites.Draw(anims.CurrentFrame, new Rectangle((int)screenPositionOffset.X, (int)screenPositionOffset.Y + 64, 64, 128), Color.White);
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
