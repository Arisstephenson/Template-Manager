using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
public class TMTemplateInformation : EditorWindow 
{
    TMTemplateManager window;
    Vector2 scroll;
    private string contents;
    private string _path;
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(TMTemplateInformation));

    }

    public void Awake()
    {
        window = (TMTemplateManager)EditorWindow.GetWindow(typeof(TMTemplateManager)); //Manager window so we can refresh it after deleting.
    }

    public void ShowFile(string path) { //Essentially takes path, copies to another variable and adds file contents to another.
        contents = File.ReadAllText(path);
        _path = path;
    }

    private void OnGUI()
    {
        scroll = GUILayout.BeginScrollView(scroll);
        GUILayout.Box(contents, EditorStyles.helpBox);
        GUILayout.EndScrollView();
        GUILayout.FlexibleSpace();
        GUI.color = Color.red;
        if (GUILayout.Button("Delete", EditorStyles.miniButtonMid)) {
            if (EditorUtility.DisplayDialog("Delete Template", "Are you sure you want to delete this template?", "Yes", "No")) {
                File.Delete(_path);
                window.UpdateFiles(); //Here is where manager window is updated
                Close();
            }
        }
        GUI.color = Color.white;
    }
}
