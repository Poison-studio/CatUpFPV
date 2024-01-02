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
            else if(Input.GetKeyDown(KeyCode.Alpha2))
            {
                weaponHandler.SwapWeapon(1);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                weaponHandler.SwapWeapon(0);
            }


        }
    }

}