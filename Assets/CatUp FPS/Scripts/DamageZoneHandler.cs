using UnityEngine;

namespace CatUp
{
    public class DamageZoneHandler : MonoBehaviour
    {
        [SerializeField]
        private GameObject[] damageZones;

        public void EnableDamageZone()
        {
            foreach (GameObject picked in damageZones)
            {
                picked.SetActive(true);
            }
        }

        public void DisableDamageZone()
        {
            foreach (GameObject picked in damageZones)
            {
                picked.SetActive(false);
            }
        }


    }

}