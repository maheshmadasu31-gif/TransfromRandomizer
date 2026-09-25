using UnityEngine;
using UnityEditor;

public class TransformRandomizer : EditorWindow
{
    private float minScale = 0.8f;
    private float maxScale = 1.2f;

    // 1. Adds a clickable option to Unity's top toolbar menu
    [MenuItem("Tools/Transform Randomizer")]
    public static void ShowWindow()
    {
        // Opens the window or brings it into focus if already open
        GetWindow<TransformRandomizer>("Randomizer");
    }

    // 2. Draws the UI inside the window
    private void OnGUI()
    {
        GUILayout.Label("Randomize Selected Objects", EditorStyles.boldLabel);

        // UI inputs for scale range
        minScale = EditorGUILayout.FloatField("Min Scale", minScale);
        maxScale = EditorGUILayout.FloatField("Max Scale", maxScale);

        GUILayout.Space(10);

        // Button to execute the logic
        if (GUILayout.Button("Randomize Selected"))
        {
            RandomizeSelected();
        }
    }

    // 3. The actual logic
    private void RandomizeSelected()
    {
        // Check if the user has selected anything
        if (Selection.transforms.Length == 0)
        {
            Debug.LogWarning("Please select at least one GameObject in the scene.");
            return;
        }

        // Loop through every object the artist currently has selected
        foreach (Transform target in Selection.transforms)
        {
            // CRITICAL: Registers this change with Unity's Undo system (Ctrl+Z)
            Undo.RecordObject(target, "Randomize Transform");

            // 1. Randomize Y rotation (0 to 360 degrees) while keeping X and Z flat
            float randomY = Random.Range(0f, 360f);
            target.rotation = Quaternion.Euler(target.eulerAngles.x, randomY, target.eulerAngles.z);

            // 2. Randomize uniform scale
            float randomScale = Random.Range(minScale, maxScale);
            target.localScale = Vector3.one * randomScale;
        }
    }
}