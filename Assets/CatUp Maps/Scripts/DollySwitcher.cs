using UnityEngine;

namespace CatUp
{
    public class DollySwitcher : MonoBehaviour
    {
        [SerializeField]
        private string interactWithTag;

        [SerializeField]
        private GameObject enable;

        [SerializeField]
        private GameObject disable;

        public void OnTriggerEnter(Collider other)
        {
            if (other.tag == interactWithTag)
            {
                enable.SetActive(true);
                disable.SetActive(false);

                GetComponent<BoxCollider>().enabled = false;
            }
        }
    }

}