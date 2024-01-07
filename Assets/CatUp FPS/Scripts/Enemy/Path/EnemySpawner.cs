using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CatUp
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField]
        private Path[] paths;

        [SerializeField]
        private GameObject enemy;

        [SerializeField]
        private Transform parent;

        private List<GameObject> machines;

        [SerializeField]
        private List<EnemySpawnerZone> enemySpawnerZones;

        public void Start()
        {
            foreach (EnemySpawnerZone zone in enemySpawnerZones)
            {
                zone.spawn.AddListener(Spawn);
                zone.deSpawn.AddListener(DeSpawn);
            }

            machines = new List<GameObject>();
        }

        public void Spawn()
        {
            foreach (Path path in paths)
            {
                GameObject spawned = Instantiate(original: enemy, parent: parent, position: path.Points[0].position, rotation: path.Points[0].rotation);
                spawned.GetComponent<SkeletonMachine>().path = path;
                machines.Add(spawned);
                spawned.GetComponent<Health>().death.AddListener(DeSpawn);
            }
        }

        private void DeSpawn()
        {
            foreach (GameObject picked in machines)
            {
                DeSpawn(picked, true);
            }
        }

        private void DeSpawn(GameObject gameObject, bool deSpawnImmediately)
        {
            float despawnTime = deSpawnImmediately ? 0f : 10f;

            StartCoroutine(DeSpawn());

            IEnumerator DeSpawn()
            {
                yield return new WaitForSeconds(despawnTime);

                machines.Remove(gameObject);
                Destroy(gameObject);

            }
        }

        private void DeSpawn(GameObject gameObject)
        {
            DeSpawn(gameObject, false);
        }
    }

}