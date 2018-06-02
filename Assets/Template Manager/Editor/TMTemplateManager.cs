using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
class TMTemplateManager : EditorWindow
{
    GUIStyle style = EditorStyles.miniButton;
    string[] files; //all templates in template folder
    string templatepath; //path to template folder
    List<string> paths = new List<string>(); //Badly named, this list holds all of the prettified names of the templates.
    Vector2 scroll;
    Object pendingScript;
    string menuLocation;
    string defaultName;
    string extension;
    int menuOrder;
    [MenuItem("Window/Script Templates")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(TMTemplateManager));
    }
    public void Awake()
    {
        UpdateFiles();
    }

    public void UpdateFiles() {
        templatepath = EvalPath(); //Finds the template folder in Unity program files.
        files = Directory.GetFiles(templatepath); //Retrieves all of the templates from template folder.
        paths = new List<string>(); //Clear this so we dont keep adding the same.
        foreach (string file in files)
        {

            string[] split = Path.GetFileName(file).Split('-');
            string[] split2 = split[split.Length - 1].Split('.'); //Prettifying for ease of use.
            paths.Add(split2[0] + '.' + split2[1]);
        }
    }

    void OnGUI()
    {
        scroll = EditorGUILayout.BeginScrollView(scroll);
        for (int i = 0; i < paths.Count; i++) {
            if (GUILayout.Button(paths[i], style)) { //Button for each template, opens info window on press
                TMTemplateInformation window = (TMTemplateInformation)EditorWindow.GetWindow(typeof(TMTemplateInformation));
                window.ShowFile(files[i]);
            }
        }
        EditorGUILayout.EndScrollView();

        GUILayout.BeginHorizontal();

            GUILayout.BeginVertical();
                GUILayout.Label("Script");
                GUILayout.Label("Menu Location");
                GUILayout.Label("Default name");
                GUILayout.Label("Extension");
                GUILayout.Label("Menu Order");
            GUILayout.EndVertical();

            GUILayout.BeginVertical();
                pendingScript = EditorGUILayout.ObjectField(pendingScript, typeof(MonoScript), false);
                menuLocation = GUILayout.TextField(menuLocation);
                defaultName = GUILayout.TextField(defaultName);
                extension = GUILayout.TextField(extension);
                menuOrder = EditorGUILayout.IntField(menuOrder);
            GUILayout.EndVertical();
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();
        if (GUILayout.Button("Open file location", EditorStyles.miniButton)) {
            EditorUtility.RevealInFinder(templatepath);
        }
        if (GUILayout.Button("Help?", EditorStyles.miniButton)) {
            TMHelpDialogue.ShowWindow();
        }
        GUILayout.EndHorizontal();

        if (GUILayout.Button("Add Script")) { //Formats the script template name into the way unity likes it.
            string scriptpath = Application.dataPath.Substring(0, Application.dataPath.Length - 6) + AssetDatabase.GetAssetPath(pendingScript);
            File.Copy(scriptpath, templatepath + '/' + menuOrder + '-' + menuLocation + '-' + defaultName + '.' + extension + ".txt");
            UpdateFiles();
        }
    }

    void OpenFileLocation(string file) { //Unused
        
        switch (Application.platform) {
            case RuntimePlatform.OSXEditor:
                System.Diagnostics.Process.Start("open", "-R " + file);
                return;
            default:
                return;
        }
    }
    string EvalPath() { //Finds script templates path
        return EditorApplication.applicationContentsPath + "/Resources/ScriptTemplates";
    }
}