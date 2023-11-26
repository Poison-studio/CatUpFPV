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
                if (e.keyCode == KeyCode.O)
                {
                    //Debug.Log("Attached" + Selection.activeObject);
                    //Selection.activeGameObject.transform.parent = parent.transform;

                    Object[] objects = Selection.objects;
                    GameObject[] gameObjects = new GameObject[objects.Length];

                    for (int i = 0; i < objects.Length; i++)
                    {
                        gameObjects[i] = objects[i] as GameObject;
                    }

                    for (int i = 0; i < objects.Length; i++)
                    {
                        gameObjects[i].transform.parent = parent.transform;
                    }

                    Debug.Log(Selection.objects.Length);
                    EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
                }
                if (e.keyCode == KeyCode.U)
                {
                    Debug.Log("Disabled" + Selection.activeObject);
                    Selection.activeGameObject.SetActive(false);
                    EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
                }
                if (e.keyCode == KeyCode.I)
                {
                    Debug.Log("Enabled" + Selection.activeObject);
                    Selection.activeGameObject.SetActive(true);
                    EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
                }
            }
        };
    }
}