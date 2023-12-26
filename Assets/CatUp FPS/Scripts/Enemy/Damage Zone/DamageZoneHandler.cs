using UnityEngine;

namespace CatUp
{
    public class DamageZoneHandler : MonoBehaviour
    {
        [SerializeField]
        private GameObject damageZone;

        public void EnableDamageZone() => damageZone.SetActive(true);

        public void DisableDamageZone() => damageZone.SetActive(false);
    }

}