# Sample FPS made with Unity with New Input System for Windows Subsystem for Android
This project is a First Person Shooter game developed in Unity to showcase how to use the new Unity Input System to handle different input in an Android app for Windows Subsystem for Android. The game is designed to work with touch controls on the screen, mouse, keyboard and gamepad.

The project was adapted starting from the [Unity FPS Template](https://learn.unity.com/project/fps-template)

The game is built with Unity version 2021.3.19f1 and the [Unity Input System](https://docs.unity3d.com/Manual/com.unity.inputsystem.html) version 1.5.0.

## Installation
1. Clone the repository.
```bash
git clone https://github.com/giolaq/WSA-FPS-Sample
```
2. Open the project in Unity.

3. Open the MainScene scene located in Assets/FPS/Scenes.

4. Build the game for the Android platform.

5. Install the built apk on your Windows Subsystem for Android device.

## How to Play
Move your character using the on-screen touch controle, the WASD keys or a connected gamepad controller.
Aim by using right joystick on the screen pr the right stick of the gamepad controller
Shoot your weapon by clicking the left button of the mouse, the CTRL on your keyboard or the right trigger of the connected controller.

## Supported inputs
To check the other supported commands and input devices open the [GamepadControls.inputaction](https://github.com/giolaq/WSA-FPS-Sample/blob/main/Assets/FPS/Scripts/Controls/GamepadControls.inputactions) asset
