# Pong Clone

A small Pong recreation developed in Unity 6.5 using C#.

The project was created as a gameplay programming exercise, focusing on player input, 2D physics, game-state management and a simple AI-controlled opponent.

## Demo
[Watch the gameplay demo](https://youtu.be/0iBygg5czPU)

## Technical Highlights
- Unity 6.5
- C#
- Unity 2D physics
- Unity Input System
- TextMesh Pro

## Features
- Player-controlled paddle
- AI-controlled opponent
- Ball movement and collision handling
- Score tracking
- Match reset behaviour

## Project Structure
The main gameplay scripts are located in `Assets/Scripts/`

Notable scripts include:
- `Ball.cs`: controls ball movement and collision behaviour
- `Paddle.cs`: Parent paddle class
- `PlayerPaddle.cs`: inherits from `Paddle`, handles player input and paddle movement
- `CPUPaddle.cs`: inherits from `Paddle`, controls the AI opponent
- `GameManager.cs`: manages scoring and match state

## Running the Project

Requirements:
- Unity 6.5

To run, clone the repository and open the project folder using Unity. Enter play mode directly through the engine.

