using Hertzole.GoldPlayer;
using UnityEngine;
using UnityEngine.AI;

namespace CatUp
{
    public class DestroyMe : MonoBehaviour
    {
        [SerializeField]
        private GameObject[] disableSchedule;

        [SerializeField]
        private GameObject[] enableSchedule;

        [SerializeField]
        private AudioSource deathSound;

        public void Destroy()
        {
            deathSound.Play();

            Destroy(GetComponent<Animator>());
            Destroy(GetComponent<NavMeshAgent>());
            Destroy(GetComponent<BoxCollider>());
            Destroy(GetComponent<FollowTarget>());

            foreach (GameObject picked in disableSchedule)
            {
                picked.GetComponent<SkinnedMeshRenderer>().enabled = false;
            }

            foreach (GameObject picked in enableSchedule)
            {
                picked.GetComponent<MeshRenderer>().enabled = true;
                picked.AddComponent<Rigidbody>();
                picked.GetComponent<Rigidbody>().AddForce((transform.position - FindObjectOfType<GoldPlayerController>().gameObject.transform.position) * 100);
            }
        }
    }

}
