using UnityEngine;
using UnityEngine.AI;

namespace CatUp
{
    public class TeleportCreatureModule : MonoBehaviour
    {
        [SerializeField]
        private FollowTarget followTargetScript;

        public void OnCollisionEnter(Collision collision)
        {
            Destroy(GetComponent<Rigidbody>());

            GetComponent<NavMeshAgent>().enabled = true;

            followTargetScript.SetupTarget(GameObject.FindWithTag("Player").transform);

            Destroy(this);
        }
    }
}