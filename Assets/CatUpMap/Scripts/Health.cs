using UnityEngine;
using UnityEngine.Events;

namespace CatUp
{
    public class Health : MonoBehaviour
    {
        public UnityEvent death;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Death Zone")
            {
                Debug.Log("Death");
                death.Invoke();
            }
        }
    }

}