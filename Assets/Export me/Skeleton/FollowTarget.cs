using UnityEngine;
using UnityEngine.AI;

namespace CatUp
{
    public class FollowTarget : MonoBehaviour
    {
        [SerializeField]
        private NavMeshAgent meshAgent;

        [SerializeField]
        private Transform target;

        public void SetupTarget(Transform target)
        {
            this.target = target;
        }

        private void Update()
        {
            if (target == null) return;

            meshAgent.SetDestination(target.position);
        }
    }

}