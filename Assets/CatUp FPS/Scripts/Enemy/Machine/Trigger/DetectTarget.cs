using UnityEngine;

namespace CatUp
{
    public class DetectTarget : MonoBehaviour
    {
        [SerializeField]
        private string interactWithTag;

        [SerializeField]
        private Machine machine;

        private string transitionToState = "TargetDetected";

        private bool wasDetected = false;

        public void OnTriggerEnter(Collider other)
        {
            if (wasDetected) return;

            if (other.tag == interactWithTag)
            {
                machine.TriggerTransition(transitionToState);
                machine.machineData.target = other.transform;
                wasDetected = true;
            }
        }
    }
}