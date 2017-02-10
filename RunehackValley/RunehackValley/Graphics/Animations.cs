using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RunehackValley.Engine;

namespace RunehackValley.Graphics
{
    public class Animations : IGameObject
    {
        private readonly Dictionary<string, Animation> _states;

        private string _currentState;

        public Animations(Dictionary<string, Animation> states, string initialState)
        {
            _states = states;
            _currentState = initialState;
        }

        private Animation CurrentAnimation => _states[_currentState];

        public Texture2D CurrentFrame => CurrentAnimation.CurrentFrame;

        public void SetState(string stateId)
        {
            if (_currentState.Equals(stateId))
                return;

            _currentState = stateId;
        }

        public void LoadContent()
        {
            foreach (var anim in _states.Values)
                anim.LoadContent();
        }

        public void UnloadContent()
        {
            foreach (var anim in _states.Values)
                anim.UnloadContent();
        }

        public void Update(GameTime deltaTime)
        {
            CurrentAnimation.Update(deltaTime);
        }

        public void Draw(SpriteBatch sprites)
        {
        }
    }
}
