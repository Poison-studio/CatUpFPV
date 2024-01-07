using UnityEngine.Events;

namespace CatUp
{
    public class WeaponClip
    {
        public UnityEvent<int> changeBackPackValue = new UnityEvent<int>();
        public UnityEvent<int> changeCurrentBullets = new UnityEvent<int>();

        private int maxBulletsInClip = 4;

        private int backPack;
        public int BackPack
        {
            get
            {
                return backPack;
            }
            private set
            {
                changeBackPackValue.Invoke(value);
                backPack = value;
            }
        }

        private int currentBullets;
        public int CurrentBullets
        {
            get
            {
                return currentBullets;
            }
            set
            {
                changeCurrentBullets.Invoke(value);
                currentBullets = value;
                if (currentBullets < 0) currentBullets = 0;
            }
        }

        public WeaponClip()
        {
            currentBullets = maxBulletsInClip;
        }

        public void Reload()
        {
            BackPack += CurrentBullets;

            int loadCount = BackPack > maxBulletsInClip ? maxBulletsInClip : BackPack;

            CurrentBullets = loadCount;

            BackPack -= loadCount;

        }

        public void AddBullets(int bullets)
        {
            BackPack += bullets;
        }
    }

}