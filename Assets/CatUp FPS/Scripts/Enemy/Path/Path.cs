using UnityEngine;

namespace CatUp
{
    public class Path : MonoBehaviour
    {
        [SerializeField]
        private int id;

        public int ID => id;

        [SerializeField]
        private Transform[] points;

        public Transform[] Points => points;
    }

}