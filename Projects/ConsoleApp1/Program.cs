// Your customized window code goes here!
using System;
using System.Collections.Generic;
using Raylib_cs;
using static Raylib_cs.Raylib;
using System.Numerics;
public class Test
{
    const int windowWidth = 1080;
    const int windowHeight = 720;

    Vector2 playerPos = new Vector2(windowWidth / 2, windowHeight / 2);

    public float playerVelX = 0f;
    public float playerVelY = 0f;

    Vector2 foodPos = new Vector2(Raylib.GetRandomValue(0, windowWidth), Raylib.GetRandomValue(0, windowHeight));

    public float playerSize = 10;
    public float playerSpeed = 5;

    public int score = 0;

    Raylib.InitWindow(windowWidth, windowHeight,"James' Window");
    Raylib.SetTargetFPS(30);

    while (!Raylib.WindowShouldClose()) 
    {
        Raylib.BeginDrawing();

        playerMovement();

        Raylib.EndDrawing();
    }

    Raylib.CloseWindow();
        
    void playerMovement()
    {
        playerVelX = (Raylib.IsKeyDown(KeyboardKey.D) - Raylib.IsKeyDown(KeyboardKey.A)) * (int)playerSpeed;
        playerVelY = (Raylib.IsKeyDown(KeyboardKey.S) - Raylib.IsKeyDown(KeyboardKey.W)) * (int)playerSpeed;
        playerPos.X += playerVelX;
        playerPos.Y += playerVelY;

        Vector2 pointA = foodPos;
        Vector2 pointB = playerPos;

        float distance = Raymath.Vector2Distance(pointA,pointB);
        if (distance - 7 < playerSize) 
        {
            playerSize += 3;
            playerSpeed += 0.5f;
            score += 1;
            foodPos.X = Raylib.GetRandomValue(0,windowWidth);
            foodPos.Y = Raylib.GetRandomValue(0,windowHeight);
        }
        Raylib.DrawText("dist:" + distance, 0, 0, 60, Color.DarkGreen);

        Raylib.ClearBackground(Color.Orange);

        

        DrawCircle((int)playerPos.X, (int)playerPos.Y, playerSize, Color.White);
        DrawCircle((int)foodPos.X, (int)foodPos.Y, 15, Color.Red);
        Raylib.DrawText("Score:"+score,screenWidth /2,0,30,Color.Black);
    }
}

// using Raylib_cs;

// // Window dimensions
// const int screenWidth = 800;
// const int screenHeight = 600;

// // Initialization
// Raylib.InitWindow(screenWidth, screenHeight, "My First Game Window");
// Raylib.SetTargetFPS(60); // Set our game to run at 60 frames-per-second

// // Main game loop
// while (!Raylib.WindowShouldClose()) // Detect window close button or ESC key
// {
//     // Drawing
//     Raylib.BeginDrawing();

//     Raylib.ClearBackground(Color.White); // Clear the background to a light grey

//     Raylib.DrawText("My First Raylib Window!", 190, 200, 20, Color.Black);

//     Raylib.EndDrawing();
// }

// // De-Initialization
// Raylib.CloseWindow();