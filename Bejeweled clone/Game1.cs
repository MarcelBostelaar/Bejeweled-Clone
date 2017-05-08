using Bejeweled_clone.Input;
using Bejeweled_clone.Model;
using Bejeweled_clone.Model.RandomJewelGenerators;
using Bejeweled_clone.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Bejeweled_clone
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        IPlayBoard board;
        StateManager stateManager;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            graphics.PreferredBackBufferWidth = 740;
            graphics.PreferredBackBufferHeight = 740;
            IsMouseVisible = true;
            graphics.ApplyChanges();
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            NormalTile.Sprite = Content.Load<Texture2D>("TilePlaceholder");
            JewelGeneratingTile.Sprite = NormalTile.Sprite;
            //Model.Jewels.Jewel.NoGem = Content.Load<Texture2D>("NoGem");
            Model.Jewels.Jewel.NormalRedGem = Content.Load<Texture2D>("RedGem");
            Model.Jewels.Jewel.NormalBlueGem = Content.Load<Texture2D>("BlueGem");
            Model.Jewels.Jewel.NormalYellowGem = Content.Load<Texture2D>("YellowGem");
            Model.Jewels.Jewel.NormalPurpleGem = Content.Load<Texture2D>("PurpleGem");
            Model.Jewels.Jewel.NormalGreenGem = Content.Load<Texture2D>("GreenGem");
            Model.Jewels.Jewel.NormalOrangeGem = Content.Load<Texture2D>("OrangeGem");
            Animation.ClearingAnimation.ClearingSprite = Content.Load<Texture2D>("ClearingAnimation");
            JewelGeneratingTile.randomJewelGenerator = new SimpleJewelGenerator();
            board = new SimpleBoard(GraphicsDevice, spriteBatch, 10, 10);
            var wrapper = new ClickableTextureTargetWrapper(board.BoardTexture);
            board.BoardTexture.Position = new Vector2(0);
            board.BoardTexture.Size = new Vector2(1);
            wrapper.drawWidth = 700;
            wrapper.drawHeight = 700;
            wrapper.drawPosition = new Point(20);
            stateManager = new StateManager();
            stateManager.PushState(new DropCalculation(board, stateManager, wrapper), new GameTime());
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            MouseUtils.Update();

            // TODO: Add your update logic here
            stateManager.Update(gameTime);
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            stateManager.Draw(gameTime, spriteBatch, GraphicsDevice);
            base.Draw(gameTime);
        }
    }
}
