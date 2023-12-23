using UnityEngine;

namespace CatUp
{
    public class PathPoints : MonoBehaviour
    {
        [SerializeField]
        private Transform[] pathPoints;

        public Transform[] GetPathPoints()
        {
            return pathPoints;
        }
    }

}
