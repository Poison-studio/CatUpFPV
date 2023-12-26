using UnityEngine;

namespace CatUp
{
    public class Point : MonoBehaviour
    {
        [SerializeField]
        private float drawRadius = 1f;

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, drawRadius);
        }
    }

}