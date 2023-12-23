using UnityEngine;

namespace CatUp
{
    [RequireComponent(typeof(Patrol))]
    public class PathPoints : MonoBehaviour
    {
        [SerializeField]
        private Transform[] pathPoints;

        private EnemyController enemyController;

        public Transform[] GetPathPoints()
        {
            return pathPoints;
        }

        public void Start()
        {

        }
    }

}
