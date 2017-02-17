using UnityEditor;
using UnityEngine;
using System.Collections.Generic;

[InitializeOnLoad]
public class ConstantsWindow : EditorWindow
{
    Color col = Color.white;

    int removeIndex;
    List<Color> colorList = Constants.colorList;

    static ConstantsWindow()
    {
        Constants.colorList.Add(Color.magenta);
    }

    [MenuItem("Window/Constants Window")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(ConstantsWindow));
    }
    
    void OnGUI()
    {
        
        removeIndex = Constants.colorList.Count - 1;
        GUILayout.Label("Color List", EditorStyles.boldLabel);


        col = EditorGUILayout.ColorField("Select Color", col);

        if (GUILayout.Button("Add New Color"))
        {
            colorList.Add(col);
        }
        
        for (int i = 0; i < colorList.Count; i++)
        {
            colorList[i] = EditorGUILayout.ColorField("Color List " + i, colorList[i]);
            
        }

        GUILayout.BeginHorizontal();
        removeIndex = EditorGUILayout.IntField(removeIndex, GUILayout.ExpandWidth(false));
        if (GUILayout.Button("Remove", GUILayout.ExpandWidth(false)))
        {
            colorList.RemoveAt(removeIndex);
        }
        GUILayout.EndHorizontal();

        /*
        groupEnabled = EditorGUILayout.BeginToggleGroup("Optional Settings", groupEnabled);
        myBool = EditorGUILayout.Toggle("Toggle", myBool);
        myFloat = EditorGUILayout.Slider("Slider", myFloat, -3, 3);
        EditorGUILayout.EndToggleGroup();
        */
    }
}