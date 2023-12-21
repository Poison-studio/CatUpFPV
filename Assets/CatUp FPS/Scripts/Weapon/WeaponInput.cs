using UnityEngine;

namespace CatUp
{
    public class WeaponInput : MonoBehaviour
    {
        [SerializeField]
        private WeaponHandler weaponHandler;

        public void Update()
        {
            if(Input.GetMouseButtonDown(0))
            {
                weaponHandler.Shoot();
            }
            else if(Input.GetKeyDown(KeyCode.R))
            {
                weaponHandler.Reload();
            }
        }
    }

}