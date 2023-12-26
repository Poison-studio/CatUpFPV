using UnityEngine;
using UnityEngine.AI;

namespace CatUp
{
    public class TeleportCreatureModule : MonoBehaviour
    {
        private void Start()
        {
            gameObject.AddComponent<Rigidbody>();
            //gameObject.GetComponent<FollowTarget>().SetupTarget(GameObject.FindWithTag("Player").transform);
        }

        public void OnCollisionEnter(Collision collision)
        {
            Destroy(GetComponent<Rigidbody>());
            GetComponent<NavMeshAgent>().enabled = true;
            //gameObject.GetComponent<FollowTarget>().Follow();
            Destroy(this);
        }
    }
}