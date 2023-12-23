using System.Collections.Generic;
using UnityEngine;

namespace CatUp
{
    public class EnemyHandler : MonoBehaviour
    {
        [SerializeField]
        private PlayerAccessPoint playerAccessPoint;

        private List<Machine> enemies;

        private void Start()
        {
            playerAccessPoint.PlayerDeath.AddListener(OnPlayerDeath);
        }

        private void OnPlayerDeath()
        {
            foreach (Machine enemy in enemies)
            {
                enemy.TriggerTransition("Idle");
            }
        }


        private void SpawnEnemy()
        {

        }
    }

}