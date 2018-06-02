using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class TMHelpDialogue : EditorWindow
{
    Vector2 scroll;
    Texture example, example2;
    GUIStyle style = new GUIStyle(EditorStyles.largeLabel);
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(TMHelpDialogue));
    }
    private void Awake()
    {
        style.fontSize = 18;
        example = (Texture)Resources.Load("ExampleSettings", typeof(Texture));
        example2 = (Texture)Resources.Load("ExampleSettings2", typeof(Texture));
    }
    private void OnGUI()
    {
        scroll = GUILayout.BeginScrollView(scroll);
        GUILayout.Label("Template Manager", style);
            EditorGUILayout.Separator();
            GUILayout.Label("Template Manager is a tool that can be used to view script templates you have installed \n" +
                            "as well as adding or deleting your own. This tool is designed to save you the effort of \n" +
                            "manually creating your own templates as well as a host of other useful functions.", EditorStyles.wordWrappedLabel);
            EditorGUILayout.Separator();

        GUILayout.Label("How to format your template script", style);
            GUILayout.Label("Make your template script like you would any other script. \n" +
                        "Replace each instance where you would use the main method's name with '#SCRIPTNAME#'.", EditorStyles.wordWrappedLabel);
        EditorGUILayout.Separator();

        GUILayout.Label("Fields", style);
            GUILayout.Label("Script", EditorStyles.largeLabel);
            GUILayout.Label("Place the script you want to be added as a new template in this field.", EditorStyles.wordWrappedLabel);
            EditorGUILayout.Separator();

            GUILayout.Label("Menu Location", EditorStyles.largeLabel);
            GUILayout.Label("This field will determine where you can find your script. The format is \n" +
                            "'Folder__Name' or just 'Name'. You must have two underscores between your folder and name.", EditorStyles.wordWrappedLabel);
            GUILayout.BeginHorizontal();
                GUILayout.Label("Example: CustomFolder__EditorScript", EditorStyles.helpBox);
                GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
            EditorGUILayout.Separator();

            GUILayout.Label("Default Name", EditorStyles.largeLabel);
            GUILayout.Label("This is the default name that scripts following this template will take.", EditorStyles.wordWrappedLabel);
            GUILayout.BeginHorizontal();
                GUILayout.Label("Example: NewEditorScript", EditorStyles.helpBox);
                GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
            EditorGUILayout.Separator();

            GUILayout.Label("Extension", EditorStyles.largeLabel);
            GUILayout.Label("The extension the file should have when it is created.", EditorStyles.wordWrappedLabel);
            GUILayout.BeginHorizontal();
                GUILayout.Label("Example: cs", EditorStyles.helpBox);
                GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
            EditorGUILayout.Separator();

            GUILayout.Label("Menu Order", EditorStyles.largeLabel);
            GUILayout.Label("This integer will determine the order your template will appear in the create asset menu. \n" +
                            "(Unity's own assets occupy spaces 1-1000 but duplicates are allowed.)", EditorStyles.wordWrappedLabel);
            GUILayout.BeginHorizontal();
                GUILayout.Label("Example: 200", EditorStyles.helpBox);
                GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
            EditorGUILayout.Separator();

            GUILayout.Label("Example Settings", EditorStyles.largeLabel);
            GUILayout.Box(example);
        GUILayout.Box(example2);
        GUILayout.EndScrollView();
    }
}