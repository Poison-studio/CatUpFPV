namespace CatUp
{
    public class ShootInfo
    {
        public ShootImpact shootImpact;
        public Weapon weapon;

        public ShootInfo(ShootImpact shootImpact, Weapon weapon)
        {
            this.shootImpact = shootImpact;
            this.weapon = weapon;
        }

    }
}