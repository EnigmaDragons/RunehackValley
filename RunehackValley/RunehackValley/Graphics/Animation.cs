using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RunehackValley.Engine;
using RunehackValley.MonoGame;

namespace RunehackValley.Graphics
{
    public class Animation : IGameObject
    {
        private readonly List<Texture2D> _sprites = new List<Texture2D>();
        private readonly List<string> _spriteNames;
        private readonly int _msPerFrame;

        private int _currentFrame = 0;
        private int _msForCurrentFrame;

        public Animation(string sprite) 
            : this(0, sprite) { }

        public Animation(int msPerFrame, params string[] spriteNames)
        {
            _msPerFrame = msPerFrame;
            _spriteNames = spriteNames.ToList();
        }

        public void LoadContent()
        {
            _spriteNames.ForEach(x => _sprites.Add(new LoadedTexture(x).Get()));
        }

        public void UnloadContent()
        {
            _sprites.ForEach(x => x.Dispose());
        }

        public void Update(GameTime deltaTime)
        {
            _msForCurrentFrame += deltaTime.ElapsedGameTime.Milliseconds;
            UpdateCurrentFrame();
        }

        public void Reset()
        {
            _msForCurrentFrame = 0;
            _currentFrame = 0;
        }

        private void UpdateCurrentFrame()
        {
            if (_msForCurrentFrame < _msPerFrame)
                return;

            if (_currentFrame + 1 == _sprites.Count)
                _currentFrame = 0;
            else
                _currentFrame += 1;

            _msForCurrentFrame = 0;
        }

        public Texture2D CurrentFrame => _sprites[_currentFrame];

        public void Draw(SpriteBatch sprites)
        {
        }
    }
}
