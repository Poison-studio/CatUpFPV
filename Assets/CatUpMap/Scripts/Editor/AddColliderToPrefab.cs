//using UnityEditor;
//using UnityEngine;

//public class AddColliderToPrefab : MonoBehaviour
//{
//    [MenuItem("Examples/Add BoxCollider to Prefab Asset")]
//    static void AddBoxColliderToPrefab()
//    {
//        Object[] objects = Selection.objects;
//        GameObject[] gameObjects = new GameObject[objects.Length];

//        for (int i = 0; i < objects.Length; i++)
//        {
//            gameObjects[i] = objects[i] as GameObject;
//        }

//        foreach (GameObject obj in objects)
//        {
//            string assetPath = AssetDatabase.GetAssetPath(obj);
//            GameObject contentsRoot = PrefabUtility.LoadPrefabContents(assetPath);

//            DestroyImmediate(contentsRoot.GetComponent<Collider>());
//            contentsRoot.AddComponent<MeshCollider>();
//            PrefabUtility.SaveAsPrefabAsset(contentsRoot, assetPath);
//            PrefabUtility.UnloadPrefabContents(contentsRoot);
//        }
//    }
//}
