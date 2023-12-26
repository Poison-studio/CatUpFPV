using UnityEngine;

namespace CatUp
{
    public class PathSelector : MonoBehaviour
    {
        [SerializeField]
        private int pathID;

        [SerializeField]
        private PathManager pathManager;

        public Path GetPath() => pathManager.GetPath(pathID);

        private void OnValidate()
        {
            pathManager ??= FindObjectOfType<PathManager>();
        }
    }
}
