using UnityEngine;

namespace CatUp
{
    public class ShotgunShells : MonoBehaviour
    {
        [SerializeField]
        private Weapon weapon;

        [SerializeField]
        private GameObject[] shells;

        private void Start()
        {
            weapon.wasFire.AddListener(OnShoot);
            weapon.reload.AddListener(OnReload);
        }

        private void OnShoot(ShootInfo shootInfo)
        {
            foreach (GameObject shell in shells)
            {
                shell.SetActive(false);
            }

            for(int i = 0; i < shootInfo.weapon.WeaponClip.CurrentBullets; i++)
            {
                shells[i].SetActive(true);
            }    
        }

        private void OnReload(WeaponClip weaponClip)
        {
            foreach (GameObject shell in shells)
            {
                shell.SetActive(false);
            }

            for (int i = 0; i < weaponClip.CurrentBullets; i++)
            {
                shells[i].SetActive(true);
            }
        }
    }

}