using UnityEngine;

namespace CatUp
{
    public class DestroyablePlatform : MonoBehaviour
    {
        [SerializeField]
        private DestroyablePlatform connected;

        [SerializeField]
        private string interactWithTag;

        [Tooltip("If platform collide this tag, platform will stop")]
        [SerializeField]
        private string stopTag;

        [SerializeField]
        private AudioSource destroySound;

        [SerializeField]
        private BoxCollider disableAfterTrigger;

        public bool isActive { get; private set; } = false;
        public bool wasInitialized { get; private set; } = false;

        private void Start()
        {
            if(connected.wasInitialized)
            {
                isActive = connected.isActive ? false : true;
            }
            else
            {
                isActive = Random.value < 0.5f;
                wasInitialized = true;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.tag == interactWithTag && isActive)
            {
                destroySound.Play();

                GetComponent<Rigidbody>().isKinematic = false;
                disableAfterTrigger.enabled = false;
            }

            if(other.tag == stopTag)
            {
                Destroy(GetComponent<Rigidbody>());
            }
        }
    }

}