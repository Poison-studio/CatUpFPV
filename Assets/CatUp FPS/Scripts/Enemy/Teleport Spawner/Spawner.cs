using Hertzole.GoldPlayer;
using Unity.VisualScripting;
using UnityEngine;

namespace CatUp
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField]
        private GameObject skeletonPrefab;

        [SerializeField]
        private Transform spawnPosition;

        void Start()
        {

        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.M))
            {
                GameObject enemy = Instantiate(skeletonPrefab, spawnPosition);
                enemy.transform.parent = null;
                enemy.AddComponent<TeleportCreatureModule>();
            }

            if (Input.GetKeyDown(KeyCode.K))
            {

                //FollowTarget[] targets = FindObjectsOfType<FollowTarget>();

                //foreach(FollowTarget target in targets)
                //{
                //    //target.SetupTarget(FindObjectOfType<GoldPlayerController>().transform);
                //    //target.Follow();
                //}


            }
        }

    }

}