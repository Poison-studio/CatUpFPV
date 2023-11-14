using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

[InitializeOnLoad]
public static class MyCustomEditor
{
    static GameObject parent;
    static MyCustomEditor()
    {
        SceneView.onSceneGUIDelegate += view =>
        {
            var e = Event.current;
            if (e != null && e.keyCode != KeyCode.None)
            {
                if (e.keyCode == KeyCode.P)
                {
                    Debug.Log("New Default Parent Selected" + Selection.activeObject);
                    parent = Selection.activeGameObject;
                    EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
                }
                if (e.keyCode == KeyCode.K)
                {
                    Debug.Log("Attached" + Selection.activeObject);
                    Selection.activeGameObject.transform.parent = parent.transform;
                    EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
                }
            }
        };
    }
}