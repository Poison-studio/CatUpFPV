using UnityEngine;

namespace CatUp
{
    [RequireComponent(typeof(BoxCollider))]
    public class TriggerZone : MonoBehaviour
    {
        [SerializeField]
        private Machine[] machines;

        private string trigger = "TargetDetected";

        private void OnTriggerEnter(Collider other)
        {
            if(other.tag == "Player")
            {
                Trigger(other);
            }
        }

        public void Trigger(Collider other)
        {
            foreach (Machine machine in machines)
            {
                machine.data.target = other.transform;
                machine.TriggerTransition(trigger);
            }
        }
    }

}