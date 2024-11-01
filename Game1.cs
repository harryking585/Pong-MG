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
    Vector2 p1_position, p2_position;
    Texture2D p1_bumper, p2_bumper;

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

        p1_position = new Vector2(30 ,30);
        p2_position = new Vector2(ScreenWidth - 30,30);
        
        base.Initialize();
    }

    // Load and create file-related objects
    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        p1_bumper = Content.Load<Texture2D>("bumper");
        p2_bumper = Content.Load<Texture2D>("bumper");
        // TODO: use this.Content to load your game content here
    }

    // Game logic
    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here
        KeyboardState state = Keyboard.GetState();
        // ws for p1 controls, ok for p2 controls
        // *** P1 Controls ***
        if(state.IsKeyDown(Keys.W)){    // w
            p1_position.Y -= 1;
        }
        else if(state.IsKeyDown(Keys.S)){ // s
            p1_position.Y += 1;
        }
        // *** P2 Controls ***
        if(state.IsKeyDown(Keys.O)){ // o
            p2_position.Y -= 1;
        }
        else if(state.IsKeyDown(Keys.K)){  // k
            p2_position.Y += 1;
        }
        base.Update(gameTime);
    }

    // Drawing logic
    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);

        // TODO: Add your drawing code here
        _spriteBatch.Begin();

        _spriteBatch.Draw(p1_bumper, p1_position, Color.White);
        _spriteBatch.Draw(p2_bumper, p2_position, Color.White);

        _spriteBatch.End();
        base.Draw(gameTime);
    }
}
