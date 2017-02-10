using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RunehackValley.Specifics;

namespace RunehackValley.Engine
{
    public class MainGame : Game, INavigator
    {
        private SpriteBatch _sprites;
        private IGameView _currentView;

        public MainGame(IGameView startingView)
        {
            new GraphicsDeviceManager(this);
            _currentView = startingView;
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            new GameInstance().SetGame(this);
            _currentView = new SmallPartOfTown();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _sprites = new SpriteBatch(GraphicsDevice);
            _currentView?.LoadContent();
        }

        protected override void UnloadContent()
        {
            Content.Unload();
            _currentView?.UnloadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            _currentView?.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            _sprites.Begin();
            _currentView?.Draw(_sprites);
            _sprites.End();
            base.Draw(gameTime);
        }

        public void NavigateTo(string viewName)
        {
            throw new System.Exception("No known views");
        }

        private void NavigateTo(IGameView view)
        {
            view.LoadContent();
            _currentView?.UnloadContent();
            _currentView = view;
        }
    }
}
