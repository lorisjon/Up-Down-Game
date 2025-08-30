![C#](https://img.shields.io/badge/C%23-B33A3A?style=for-the-badge&logo=csharp&logoColor=white)
![Game](https://img.shields.io/badge/Game-3A5DAE?style=for-the-badge)


# Up-Down-Game

![Gameplay GIF](assets/updown-gameplay.gif)

**A fast-paced reflex game where your goal is simple:**  
Move between the top and bottom bars to score points – and dodge everything in your way.

---

## Gameplay Overview

You control a ball that automatically moves up or down. Your job is to:
- Switch directions by pressing `Space` or clicking.
- Touch the **active bar** (blue) to score points.
- Avoid the **obstacles** (red squares) flying in from both sides.

Each successful touch:
- Increases your score.
- Deactivates the bar you touched (turns grey).
- Forces you to move toward the **opposite** bar to keep scoring.

---

## Tutorial

Not sure how the game works? Here's a quick walkthrough:

![Tutorial GIF](assets/tutorial.gif)

This short tutorial shows how to:
- Start the game
- Switch direction at the right moment
- Score points
- Avoid obstacles

---

## Features

- Smooth and responsive 2D controls  
- Dynamic difficulty: speed and obstacle count increase as you play  
- Random obstacle sizes and spawn sides  
- Local **highscore system**  
- **Level system** with background color changes  
- **Sound effects and background music**  
- Game Over screen with restart option  
- Built-in tutorial to onboard new players  

---

## Screenshots

### Game Start
<img src="assets/start.png" alt="Gamestart screenshot" width="70%"/>
<!-- ![Gamestart screenshot](assets/start.png)
 -->

 
### In Action
<img src="assets/action.png" alt="In Action screenshot" width="70%"/>


### Game Over
<img src="assets/gameover.png" alt="Game Over screenshot" width="70%"/>



---

## Download

You can download and try the game right away:

➡ [Download Installer (.exe)](downloads/up_down_game_Installer.exe)

---

## Built With

- **C#**  
- **Windows Forms / WinForms**  
- Custom logic, no external game engines

> This was one of my **first real game projects** – built from scratch as a challenge and a learning experience.

---

## Fun to Watch, Fun to Play

If you just want to get a quick feel for the game, check out the GIFs above.  
It's simple to understand – but tricky to master!

---

## Folder Structure

Up-Down-Game/<br/>
├── assets/ # Gameplay GIFs and screenshots<br/>
│   ├── updown-gameplay.gif<br/>
│   ├── tutorial.gif<br/>
│   ├── start.png<br/>
│   ├── action.png<br/>
│   └── gameover.png<br/>
├── downloads/ # Installer for the game<br/>
│   └── UpDownGameInstaller.exe<br/>
├── GameProjectFiles/ # All relevant code and resources<br/>
├── Up Down Game.sln # Solution file<br/>
└── README.md # This file
