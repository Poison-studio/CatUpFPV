using UnityEngine;
using UnityEngine.Events;

namespace CatUp
{
    public class EnemySpawnerZone : MonoBehaviour
    {
        [SerializeField]
        private SpawnerZoneRegime regime;

        [SerializeField]
        private bool UseOnce;

        private bool wasUsed;

        [SerializeField]
        private EnemySpawner enemySpawner;

        public UnityEvent spawn;
        public UnityEvent deSpawn;

        private void Start()
        {
            wasUsed = false;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag != "Player") return;
            if(UseOnce && wasUsed) return;
            
            wasUsed = true;

            if (regime == SpawnerZoneRegime.Spawn)
            {
                spawn.Invoke();
            }
            else if(regime == SpawnerZoneRegime.Despawn)
            {
                deSpawn.Invoke();
            }
        }
    }

    public enum SpawnerZoneRegime
    {
        Spawn,
        Despawn
    }

}