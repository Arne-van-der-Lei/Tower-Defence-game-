using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(HexGenerator))]
public class Generator : Editor {

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (GUILayout.Button("Generate hex"))
        {
            HexGenerator maze = (HexGenerator)target;
            maze.Generate();
        }

        if (GUILayout.Button("Get Path"))
        {
            HexGenerator maze = (HexGenerator)target;
            //maze.GetPath();
        }
    }
}
