using UnityEngine;

namespace CatUp
{
    public class PathManager : MonoBehaviour
    {
        private Path[] paths;

        public Path GetPath(int pathID)
        {
            foreach (Path path in paths)
            {
                if(path.ID == pathID)
                {
                    return path;
                }
            }

            throw new System.Exception("Такого пути нет");
        }

        private void OnValidate()
        {
            paths ??= FindObjectsOfType<Path>();
        }
    }
}
