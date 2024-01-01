namespace CatUp
{
    public class WeaponClip
    {
        private int maxBulletsInClip = 4;

        public int Backpack { get; private set; } = 2;

        private int currentBullets;
        public int CurrentBullets
        {
            get
            {
                return currentBullets;
            }
            set
            {
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
            Backpack += CurrentBullets;

            int loadCount = Backpack > maxBulletsInClip ? maxBulletsInClip : Backpack;

            CurrentBullets = loadCount;

            Backpack -= loadCount;

        }

        public void AddBullets(int bullets)
        {
            Backpack += bullets;
        }
    }

}