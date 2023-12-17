using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;

namespace CatUp
{
    public class FollowTarget : MonoBehaviour
    {
        [SerializeField]
        private NavMeshAgent meshAgent;

        [SerializeField]
        private Transform target;

        [SerializeField]
        private float attackRadius;

        [SerializeField]
        private Animator animator;

        [SerializeField]
        private float WalkSpeed;

        [SerializeField]
        private float AttackSpeed;

        private float speedMultiplier;

        [SerializeField]
        public bool afk;

        public void Start()
        {
            if(afk)
            {
                meshAgent.enabled = true;
            }
        }

        public void SetupTarget(Transform target)
        {
            afk = false;
            this.target = target;
            target.GetComponent<PlayerHealth>().death.AddListener(PlayerDeath);
        }

        private void PlayerDeath()
        {

            target = null;
            animator.SetTrigger("Death");
            meshAgent.speed = 0;
            meshAgent.enabled = false;
        }

        private void Update()
        {
            if (afk) return;
            if (target == null || !meshAgent.isOnNavMesh) return;

            if (Vector3.Distance(transform.position, target.position) < attackRadius)
            {
                animator.SetBool("Attack", true);
                speedMultiplier = Vector3.Distance(transform.position, target.position) / (AttackSpeed * 8f);
            }
            else
            {
                animator.SetBool("Attack", false);
            }

            if (animator.GetCurrentAnimatorStateInfo(0).IsName("Z_Run_InPlace"))
            {
                meshAgent.speed = WalkSpeed;
            }
            else if (animator.GetCurrentAnimatorStateInfo(0).IsName("Skeleton Attack"))
            {
                meshAgent.speed = AttackSpeed * speedMultiplier;
            }


            meshAgent.SetDestination(target.position);
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.tag == "Player")
            {
                Follow();
                target = other.gameObject.transform;
            }
        }

        public void Follow()
        {
            afk = false;
            animator.SetTrigger("Triggered");
        }

    }

}