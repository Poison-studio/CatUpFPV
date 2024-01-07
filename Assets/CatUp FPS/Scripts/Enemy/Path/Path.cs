using UnityEngine;

namespace CatUp
{
    public class Path : MonoBehaviour
    {
        [SerializeField]
        private Transform[] points;

        public Transform[] Points
        {
            get { return points; }
            set { points = value; }
        }

        public void OnDrawGizmos()
        {
            if (points.Length <= 1) return;

            for (int i = 0; i < points.Length - 1; i++)
            {
                Gizmos.color = Color.blue;
                Gizmos.DrawLine(points[i].position, points[i+1].position);
            }
        }
    }

}