using Hertzole.GoldPlayer;
using UnityEngine;
using UnityEngine.AI;

namespace CatUp
{
    public class EnemyHealth : Health
    {
        [SerializeField]
        private GameObject[] disableQueue;

        [SerializeField]
        private GameObject[] enableQueue;

        [SerializeField]
        private Machine machine;

        [SerializeField]
        private AudioClip deathSound;

        [SerializeField]
        private AudioPlayer audioPlayer;

        [SerializeField]
        private float volume;

        [SerializeField]
        private float pitch;

        [SerializeField]
        private GameObject damageZone;

        [SerializeField]
        private GameObject detectTarget;

        protected override void OnDeath()
        {
            audioPlayer.Play(volume, pitch, deathSound);

            machine.Stop();

            GetComponent<Animator>().enabled = false;

            GetComponent<NavMeshAgent>().isStopped = true;
            GetComponent<NavMeshAgent>().enabled = false;

            GetComponent<BoxCollider>().enabled = false;

            damageZone.SetActive(false);
            detectTarget.SetActive(false);

            foreach (GameObject picked in disableQueue)
            {
                picked.GetComponent<SkinnedMeshRenderer>().enabled = false;
            }

            foreach (GameObject picked in enableQueue)
            {
                picked.GetComponent<MeshRenderer>().enabled = true;
                picked.AddComponent<Rigidbody>();
                float forceValue = 80;
                picked.GetComponent<Rigidbody>().AddForce((transform.position - FindObjectOfType<GoldPlayerController>().gameObject.transform.position).normalized * forceValue * Random.Range(3, 6));
                picked.GetComponent<Rigidbody>().AddTorque(new Vector3(Random.Range(0,2), Random.Range(0, 2), Random.Range(0, 2)));
            }
        }

        protected override void OnGetDamage()
        {

        }
    }
}
