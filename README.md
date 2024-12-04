README

UI Animation and Popup Management System

This Unity project implements a robust and reusable system for animating UI elements and managing popup interactions using `DOTween`. The system consists of three scripts:

1. TweenAnimation.cs
2. Popup.cs
3. PopupManager.cs

---

1.TweenAnimation.cs
This script handles the animation in the start of UI elements using DOTween. It supports scaling, movement, or both, based on the specified `ETweenType`.

- Key Features:
  - Animate on `Start()` (optional via `animateOnStart`).
  - Tween movement (`TweenMove`) and scaling (`TweenScale`) of UI elements.
  - Configurable properties for target position, scale, and duration.

- How It Works:
  The script animates the `RectTransform` component attached to the GameObject. Animation settings are customizable in the Unity Inspector.

---

2.Popup.cs
This script is used to define a popup UI element. It stores the starting position of the popup for animation purposes.

- Key Features:
  - Maintains the `RectTransform` of the popup.
  - Captures the starting anchored position (`startPos`) for smooth closing animations.

---

3.PopupManager.cs
This script manages multiple popups and their interactions. It ensures only one popup is active at a time and supports opening and closing with smooth animations.

- Key Features:
  - Popups are opened/closed with animations using DOTween.
  - Prevents overlapping animations by using state flags (openingPanel, closingPanel).
  - Ensures popups close when clicking outside their bounds.
  - Detects and manages input interactions with Unity’s EventSystem.

- How It Works:
  - Uses DOTween to animate the opening (`OpenPopup`) and closing (`ClosePopup`) of popups.
  - Listens for mouse or touch inputs to detect clicks outside the popup, closing it when necessary.

---

Testing the Solution

1.Project Setup:
   - Use any Lts version of unity to open the project

2.Testing Popups:
   - Start the game and clik on the buttons on the left side of the screen.
   - Click outside an open popup to ensure it closes automatically.

---


Customization

- Adjust tween settings in the Inspector or via script:
  - Duration, easing type, target position, and scale for animations.
- Add more `Popup` objects to `PopupManager` to handle additional UI layers.

---
