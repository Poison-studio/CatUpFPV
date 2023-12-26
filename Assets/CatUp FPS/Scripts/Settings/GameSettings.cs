using UnityEngine;

namespace CatUp
{
    public class GameSettings : MonoBehaviour
    {
        [SerializeField]
        private CrosshairMode crosshairMode;

        [SerializeField]
        private GameObject StaticCrosshair;

        [SerializeField]
        private GameObject ActiveCrosshair;

        public void Start()
        {
            if(crosshairMode == CrosshairMode.Static)
            {
                StaticCrosshair.SetActive(true);
                ActiveCrosshair.SetActive(false);
            }
            else if(crosshairMode == CrosshairMode.Active)
            {
                StaticCrosshair.SetActive(false);
                ActiveCrosshair.SetActive(true);
            }
        }
    }

    public enum CrosshairMode
    {
        Static,
        Active
    }
}