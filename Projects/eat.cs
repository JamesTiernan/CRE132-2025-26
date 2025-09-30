using System;
using System.Collections.Generic;
using Raylib_cs;
using static Raylib_cs.Raylib;
using System.Numerics;

const int windowWidth = 1080;
const int windowHeight = 720;

Vector2 playerPos = new Vector2(windowWidth/2,windowHeight/2);

public int textVelX = Raylib.GetRandomValue(-12,12);
public int textVelY = Raylib.GetRandomValue(-12,12);

Vector2 foodPos = new Vector2(Raylib.GetRandomValue(0,windowWidth),Raylib.GetRandomValue(0,windowHeight));

public float playerSize = 10;
public float playerSpeed = 5;

public int score = 0;

Raylib.InitWindow(windowWidth,windowHeight,"James' Window");
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
    textVelX = (Raylib.IsKeyDown(KeyboardKey.D) - Raylib.IsKeyDown(KeyboardKey.A)) * (int)playerSpeed;
    textVelY = (Raylib.IsKeyDown(KeyboardKey.S) - Raylib.IsKeyDown(KeyboardKey.W)) * (int)playerSpeed;
    playerPos.X += textVelX;
    playerPos.Y += textVelY;

    Vector2 pointA = foodPos;
    Vector2 pointB = playerPos;

    float distance = Raymath.Vector2Distance(pointA,pointB);
    if (distance - 7 < playerSize) {
        playerSize += 3;
        playerSpeed += 0.5f;
        score += 1;
        foodPos.X = Raylib.GetRandomValue(0,windowWidth);
        foodPos.Y = Raylib.GetRandomValue(0,windowHeight);
    }
    //Raylib.DrawText("dist:" + distance, 0, 0, 60, Color.DarkGreen);

    Raylib.ClearBackground(Color.Orange);

    

    DrawCircle((int)playerPos.X, (int)playerPos.Y, playerSize, Color.White);
    DrawCircle((int)foodPos.X, (int)foodPos.Y, 15, Color.Red);
    Raylib.DrawText("Score:"+score,screenWidth /2,0,30,Color.Black);
}