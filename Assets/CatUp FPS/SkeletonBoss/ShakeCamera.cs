using Hertzole.GoldPlayer;
using UnityEngine;

namespace CatUp
{
    public class ShakeCamera : MonoBehaviour
    {
        [SerializeField]
        private GoldPlayerController controller;

        float shakeValue;

        private bool shake;

        public void Shake()
        {
            if (!shake) return;

            controller.Camera.CameraShake(shakeValue, shakeValue, 2);
        }

        public void Update()
        {
            if(Vector3.Distance(transform.position, controller.transform.position) < 100)
            {
                shakeValue = 1 / Vector3.Distance(transform.position, controller.transform.position) * 40;
                shake = true;
            }
            else
            {
                shake= false;
            }
        }
    }

}