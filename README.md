<b>Unity Transform Randomizer 🎲</b>

A small Unity Editor tool for quickly randomizing the Y rotation and uniform scale of selected GameObjects.

This tool is designed for level artists, technical artists, and anyone who needs to break up repetitive object placement directly inside the Unity Editor.

<b>✨ Features</b>

Randomize the Y rotation from 0° to 360°

Randomize uniform scale using a configurable minimum and maximum

Works on multiple selected GameObjects

Uses Unity's Undo system, so changes can be reverted with Ctrl + Z

Simple editor window with no runtime setup required

Accessible from Unity's Tools menu

<b>🖼️ Screenshots</b>

Transform Randomizer Window
<img width="1486" height="877" alt="Screenshot 2026-09-23 230945" src="https://github.com/user-attachments/assets/b1dd42b9-9f52-4948-a0f0-5402d6cf0654" />

The editor window provides controls for:

Min Scale

Max Scale

Randomize Selected

Unity Tools Menu

<img width="353" height="112" alt="Screenshot 2026-09-23 230855" src="https://github.com/user-attachments/assets/e010984e-b567-467d-99b4-763cfc6413c9" />

Open the tool from:

Tools → Transform Randomizer

<b>🚀 Installation</b>

Copy TransformRandomizer.cs into your Unity project.

Place it inside an Editor folder, for example:

Assets/
└── Editor/
    └── TransformRandomizer.cs

Return to Unity and allow the script to compile.

Select one or more GameObjects in the Scene.

Open:

Tools → Transform Randomizer

<b>🎮 How to Use</b>

Select the GameObjects you want to randomize.

Open the Transform Randomizer window.

Set the scale range.

Example:

Min Scale: 0.8
Max Scale: 1.2

Click Randomize Selected.

For every selected object, the tool:

Generates a random Y rotation between 0° and 360°

Generates a random uniform scale between the configured minimum and maximum

Applies the changes to the selected object's transform

<b>🔄 Example</b>

If you have several repeated props:

Tree
Tree
Tree
Tree
Tree

you can select them all and randomize them to create natural variation:

Tree → Random Y rotation + random uniform scale
Tree → Random Y rotation + random uniform scale
Tree → Random Y rotation + random uniform scale
Tree → Random Y rotation + random uniform scale
Tree → Random Y rotation + random uniform scale

This is useful for environments containing repeated assets such as:

Trees

Rocks

Crates

Grass

Props

Decorative objects

Modular environment pieces

<b>🧩 How It Works</b>

The tool is implemented as a Unity EditorWindow.

1. Open the Editor Window

The menu item:

[MenuItem("Tools/Transform Randomizer")]

adds the tool to Unity's top menu.

2. Configure Scale

The window exposes two editable values:

minScale = EditorGUILayout.FloatField("Min Scale", minScale);
maxScale = EditorGUILayout.FloatField("Max Scale", maxScale);

3. Process Selected Objects

The tool reads the current Unity selection:

Selection.transforms

and loops through every selected Transform.

4. Preserve Undo Support

Before modifying an object, the tool registers the change with Unity:

Undo.RecordObject(target, "Randomize Transform");

This allows the artist to undo the operation with Ctrl + Z.

5. Randomize Rotation

Only the Y axis is randomized:

float randomY = Random.Range(0f, 360f);

target.rotation = Quaternion.Euler(
    target.eulerAngles.x,
    randomY,
    target.eulerAngles.z
);

The existing X and Z rotation values are preserved.

6. Randomize Uniform Scale

A random scale value is generated and applied equally to X, Y, and Z:

float randomScale = Random.Range(minScale, maxScale);
target.localScale = Vector3.one * randomScale;

<b>⚠️ Notes</b>

This is an Editor tool, not a runtime component.

The script requires:

using UnityEditor;

If no GameObjects are selected, the tool displays a warning in the Unity Console.

The current implementation randomizes Y rotation and uniform scale only.

Scale values should be chosen carefully. For example, setting Min Scale greater than Max Scale may produce undesirable results.

<b>📁 Suggested Repository Structure</b>

Unity-Transform-Randomizer/
├── README.md
├── TransformRandomizer.cs
└── images/
    ├── randomizer-window.png
    └── toolbar-menu.png

<b>🛠️ Requirements</b>

Unity

C#

Unity Editor API

No external packages are required.
