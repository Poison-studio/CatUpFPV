using UnityEngine;

namespace CatUp
{
    public class Path : MonoBehaviour
    {
        [SerializeField]
        private Transform[] points;

        public Transform[] Points => points;
    }

}