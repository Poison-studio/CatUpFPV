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

        [SerializeField]
        private float refreshTime;


        private float timer;

        public void OnTriggerEnter(Collider other)
        {
            if (wasDetected) return;

            if (other.tag == interactWithTag)
            {
                machine.TriggerTransition(transitionToState);
                machine.data.target = other.transform;
                wasDetected = true;
                timer = refreshTime;
            }
        }

        public void Update()
        {
            if(wasDetected)
            {
                timer -= refreshTime;
                if(timer < 0)
                {
                    wasDetected = false;
                }
            }    
        }
    }
}