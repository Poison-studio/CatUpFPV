using System;

namespace CatUp
{
    [Serializable]
    public class ShootImpact
    {
        public float cameraShakeFrequency;
        public float cameraShakeMagnitude;
        public float cameraShakeDuration;

        public float cameraRecoilAmount;
        public float cameraRecoilTime;

        public float weaponRecoilX;
        public float weaponRecoilY;
        public float weaponRecoilZ;

        public ShootImpact(float cameraShakeFrequency, float cameraShakeMagnitude, float cameraShakeDuration, float cameraRecoilAmount, float cameraRecoilTime, float weaponRecoilX, float weaponRecoilY, float weaponRecoilZ)
        {
            this.cameraShakeFrequency = cameraShakeFrequency;
            this.cameraShakeMagnitude = cameraShakeMagnitude;
            this.cameraShakeDuration = cameraShakeDuration;

            this.cameraRecoilAmount = cameraRecoilAmount;
            this.cameraRecoilTime = cameraRecoilTime;

            this.weaponRecoilX = weaponRecoilX;
            this.weaponRecoilY = weaponRecoilY;
            this.weaponRecoilZ = weaponRecoilZ;
        }
    }

}