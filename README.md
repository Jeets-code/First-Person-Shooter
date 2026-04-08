# Shooter Game

## Overview

This is a **first-person shooter game** built with Unity. The game features combat mechanics where players battle enemies using various weapons, manage health, dodge attacks, and progress through multiple scenes. The project includes a full game flow with a main menu, gameplay, pause system, and score tracking.

## Languages & Technologies

- **C# 8.0+** - Core game logic and mechanics
- **Unity 2020.3 LTS or later** - Game engine
- **HLSL/ShaderLab** - Graphics and materials
- **TextMesh Pro** - UI text rendering

## Key Features

### Player Mechanics
- **Shooting System** - Fire weapons with cooldown and ammo management
- **Health System** - Manage player health with damage tracking
- **Dodge Mechanics** - Avoid incoming attacks with dodge ability
- **Camera Control** - Free look camera for aiming and movement
- **Weapon Switching** - Switch between different weapons

### Enemy Mechanics
- **Enemy AI** - Enemies detect and attack the player
- **Enemy Health** - Track enemy health and defeat
- **Attack System** - Enemies shoot at the player within range
- **Animations** - Soldier character animations for movement and attacks

### Game Management
- **Main Menu** - Start game or load scenes
- **Pause System** - Pause and resume gameplay
- **Score Manager** - Track player score
- **Scene Navigation** - Transition between game scenes
- **Audio Management** - Background music and sound effects

## Project Structure

```
Assets/
├── Scripts/
│   ├── Player/
│   │   ├── PlayerShooting.cs        # Weapon firing, ammo, and damage logic
│   │   ├── PlayerHealth.cs          # Player health and damage system
│   │   ├── DodgeScript.cs           # Dodge/evasion mechanics
│   │   └── CameraController.cs      # Camera movement and aiming
│   ├── EnemyAttack.cs               # Enemy attack behavior
│   ├── EnemyHealth.cs               # Enemy health and defeat logic
│   ├── WeaponSwitching.cs           # Weapon switching system
│   ├── Managers/
│   │   ├── ScoreManager.cs          # Score tracking
│   │   ├── PauseManager.cs          # Pause/resume functionality
│   │   ├── StartManager.cs          # Game initialization
│   │   └── MainMenuLoader.cs        # Menu scene loading
│   └── Audio/
│       └── Audio management scripts
├── Scenes/                          # Game level scenes
├── Animations/                      # Character controllers and animations
├── Materials/                       # Game textures and materials
├── Audio/                          # Music and sound effects
└── Environment/                    # Environmental assets
```

## How to Run

### Prerequisites
- **Unity 2020.3 LTS** or later installed
- Microsoft Visual Studio 2019+ (for script editing, optional)

### Steps to Run the Game

1. **Open the Project**
   - Open Unity Hub
   - Click "Add project from disk"
   - Navigate to the `First Person Shooter` folder
   - Click "Open"

2. **Load the Main Scene**
   - In the Project window, go to `Assets/Scenes/`
   - Double-click the main menu or starting scene to open it

3. **Play the Game**
   - Press the **Play button** (▶) in the Unity Editor toolbar
   - Or press **Ctrl + P** (Windows) / **Cmd + P** (Mac)

4. **Build and Run**
   - Go to **File** > **Build Settings**
   - Add scenes to the build (drag from Scenes folder)
   - Select your target platform (PC, Mac, WebGL, etc.)
   - Click **Build** and choose an output folder
   - Run the generated executable

## Controls

| Action | Input |
|--------|-------|
| Move | WASD or Arrow Keys |
| Look Around | Mouse Movement |
| Shoot | Left Mouse Button / LMB |
| Switch Weapon | E or Number Keys |
| Dodge | Space |
| Pause | Esc or P |

## Game Mechanics

### Health & Damage
- Player starts with default health
- Enemy attacks deal damage when in range
- Player can be healed through pickup items or health stations
- Defeating enemies grants score points

### Weapon System
- Multiple weapons available with different fire rates
- Limited ammo per magazine
- Press E to switch weapons
- Ammo displays on UI

### Enemy AI
- Enemies patrol until player is detected
- Enemies attack when player is within range (50 units)
- Enemies have health and can be defeated
- Variety of enemy types with different behaviors

## Building from Source

### Requirements
- Visual Studio Code or Visual Studio 2019+
- .NET Framework 4.7.1+

### Compilation
The project uses Unity's built-in C# compilation. Scripts are automatically compiled when you open the project in Unity Editor.

To manually compile:
1. Open the `.sln` file in Visual Studio
2. Build the solution (Ctrl + Shift + B)

## Troubleshooting

### Game Won't Run
- Ensure all assets are imported (check console for errors)
- Verify scenes are added to Build Settings
- Check that the main scene is set as the Starting Scene

### Missing Assets
- Right-click in Assets folder and select **Reimport All**
- Close and reopen the project

### Script Compilation Errors
- Ensure Visual Studio intellisense is updated: Right-click project > **Generate C# project files**
- Restart Unity Editor

## Credits

Assets sourced from:
- Low Poly Soldiers
- Toon Soldiers
- EasyRoads3D
- TextMesh Pro

## License

This is an educational assignment project. Check with your instructor for usage and distribution guidelines.

---

**Last Updated**: April 2026  
**Game Engine**: Unity  
**Language**: C#
