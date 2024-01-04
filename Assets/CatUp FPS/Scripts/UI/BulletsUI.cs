using TMPro;
using UnityEngine;

namespace CatUp
{
    public class BulletsUI : MonoBehaviour
    {
        [SerializeField]
        private WeaponHandler weaponHandler;

        [SerializeField]
        private TextMeshProUGUI bullets;

        float backPackValue;
        float currentValue;

        public void Start()
        {
            weaponHandler = FindObjectOfType<WeaponHandler>();

            backPackValue = weaponHandler.ShotgunBullets.BackPack;
            currentValue = weaponHandler.ShotgunBullets.CurrentBullets;

            weaponHandler.ShotgunBullets.changeBackPackValue.AddListener(ChangeBackPack);
            weaponHandler.ShotgunBullets.changeCurrentBullets.AddListener(ChangeCurrentBullets);

            ReDraw();
        }

        private void ChangeBackPack(int newValue)
        {
            backPackValue = newValue;
            ReDraw();
        }

        private void ChangeCurrentBullets(int newValue)
        {
            currentValue = newValue;
            ReDraw();
        }


        public void ReDraw()
        {
            bullets.text = currentValue + " | " + backPackValue;
        }
    }

}