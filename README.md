# PepsiMan Runner — Unity Endless Runner Game

PepsiMan Runner is a simplified 3-lane endless runner game developed in Unity 3D.  
The project was created to practice core Unity game development concepts including:
player movement, obstacle spawning, UI score tracking, collision detection, and scene management.

---

## 🎯 Project Goal

The goal of this project is to design and implement a basic PepsiMan-style runner game using Unity 3D.
Through this project, I learned how to:
- Move a character forward automatically
- Switch lanes using keyboard input
- Spawn obstacles randomly in multiple lanes
- Detect collisions and trigger a Game Over state
- Display current and best score using UI
- Save high scores using `PlayerPrefs`
- Restart the game after losing

---

## 🎮 Gameplay

| Feature | Description |
|---------|-------------|
| Forward Movement | Player runs forward automatically at constant speed |
| Lane Switching | A/D or Arrow Keys allow switching between 3 lanes |
| Obstacle System | Obstacles appear in random lanes at random distances |
| Score | Increases over time while running |
| Best Score | Saved and displayed using PlayerPrefs |
| Game Over | Triggered when colliding with obstacles |
| Restart | Game restarts through a UI button |

The game world contains **three parallel lanes** (left, middle, right).  
Obstacles are generated continuously ahead of the player at distances between **4 and 7 units**, ensuring varied gameplay.

---

## 🕹 Controls

| Key | Action |
|-----|--------|
| A / Left Arrow  | Move Left |
| D / Right Arrow | Move Right |

Movement is lane-based, meaning the player always snaps to one of three fixed x-positions.

---

## 🧩 UI Features

The game includes the following UI elements:
- **Current Score** — increases continuously
- **Best Score** — highest recorded score, saved with `PlayerPrefs`
- **Game Over Panel** — appears after collision
- **Restart Button** — reloads the scene

---

## 📁 Project Structure
Assets/
├── Models/ # player model and model files
├── Prefabs/ # obstacle prefab
├── Materials/ # base materials and textures
├── Scripts/ # PlayerController, ObstacleSpawner, CameraFollow
├── TextMesh Pro/ # UI text rendering support
├── Scenes/Main.unity # main game scene
└── Readme.md # project documentation

---

## 📌 Technical Implementation

| System | Technology Used |
|--------|-----------------|
| Movement | Transform + lane positions |
| Input | Unity Input System (Keyboard) |
| Obstacles | Instantiate() with random lane index |
| Collision | `OnTriggerEnter()` with Obstacle tag |
| Persistence | `PlayerPrefs.SetFloat()` / `PlayerPrefs.GetFloat()` |
| UI | Canvas + TextMeshPro |

---

### 🎬 Animation System

The player character uses Unity's Animator system for movement animations.
All animation states are controlled via the `Animator Controller` located in:

``Assets/PlayerController.controller``

| State | Trigger / Condition | Description |
|--------|---------------------|-------------|
| `Run` | Default state | Character running forward continuously |


