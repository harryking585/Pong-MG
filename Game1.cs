using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pong;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    public static int ScreenWidth;
    public static int ScreenHeight;
    public static Random Random;
    Vector2 test_position;

    Texture2D p1_bumper;
    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    // Create memory-only objects
    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        ScreenWidth = _graphics.PreferredBackBufferWidth;
        ScreenHeight = _graphics.PreferredBackBufferHeight;
        Random = new Random();

        test_position = new Vector2(30,30);
        
        base.Initialize();
    }

    // Load and create file-related objects
    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        p1_bumper = Content.Load<Texture2D>("bumper");
        // TODO: use this.Content to load your game content here
    }

    // Game logic
    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here

        base.Update(gameTime);
    }

    // Drawing logic
    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here
        _spriteBatch.Begin();

        _spriteBatch.Draw(p1_bumper, test_position, Color.White);
        
        base.Draw(gameTime);
    }
}
