using UnityEngine;

namespace CatUp
{
    public class EndGameCup : MonoBehaviour
    {
        [SerializeField]
        private string interactWithTag;

        [SerializeField]
        private ParticleSystem[] pickupParticles;

        [SerializeField]
        private GameObject[] objectsToDisable;

        [SerializeField]
        private GameObject[] objectsToEnable;

        [Tooltip("Следует ли выключить объект, который попал в зону")]
        [SerializeField]
        private bool disableTriggerObject;

        public void OnTriggerEnter(Collider other)
        {
            foreach (ParticleSystem picked in pickupParticles)
            {
                picked.Emit(20);
            }

            foreach (GameObject objectToDisable in objectsToDisable)
            {
                objectToDisable.SetActive(false);
            }

            if(disableTriggerObject)
            {
                other.gameObject.SetActive(false);
            }

            foreach (GameObject objectToEnable in objectsToEnable)
            {
                objectToEnable.SetActive(true);
            }

            gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
