using UnityEngine;

namespace CatUp
{
    public class DisableAfterInteract : MonoBehaviour
    {
        [SerializeField]
        private new Collider collider;

        [SerializeField]
        private new string tag;

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == tag)
            {
                collider.enabled = false;
            }
        }
    }

}