using Microsoft.Xna.Framework;

namespace RunehackValley.Character
{
    public sealed class Distance
    {
        private readonly int _deltaTimeMs;
        private readonly float _moveSpeed;

        public Distance(GameTime deltaTime, float moveSpeed)
            : this(deltaTime.ElapsedGameTime.Milliseconds, moveSpeed) { }

        public Distance(int deltaTimeMs, float moveSpeed)
        {
            _deltaTimeMs = deltaTimeMs;
            _moveSpeed = moveSpeed;
        }

        public float Get()
        {
            return _deltaTimeMs * _moveSpeed;
        }
    }
}
