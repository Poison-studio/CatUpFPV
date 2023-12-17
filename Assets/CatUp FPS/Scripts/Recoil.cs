using UnityEngine;

namespace CatUp
{
    public class Recoil : MonoBehaviour
    {
        //Rotation
        private Vector3 currentRotation;
        private Vector3 targetRotation;

        //Recoil
        [SerializeField] private float recoilX;
        [SerializeField] private float recoilY;
        [SerializeField] private float recoilZ;

        //Settings
        [SerializeField] private float snappines;
        [SerializeField] private float returnSpeed;

        void Update()
        {
            targetRotation = Vector3.Lerp(targetRotation, Vector3.zero, returnSpeed * Time.deltaTime);
            currentRotation = Vector3.Slerp(currentRotation, targetRotation, snappines * Time.fixedDeltaTime);
            transform.localRotation = Quaternion.Euler(currentRotation);
        }

        public void ApplyRecoil()
        {
            targetRotation += new Vector3(Random.Range(-recoilX, recoilX), Random.Range(-recoilY, recoilY), Random.Range(-recoilZ, recoilZ));
        }
    }

}