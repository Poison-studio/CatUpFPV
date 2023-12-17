//using Hertzole.GoldPlayer;
using UnityEngine;

namespace CatUp
{
    public class EndGame : MonoBehaviour
    {
        [SerializeField]
        private ParticleSystem[] winEffect;

        [SerializeField]
        private GameObject cup;

        [SerializeField]
        private GameObject cart;

        [SerializeField]
        private GameObject VirtualCamera;

        public void OnTriggerEnter(Collider other)
        {
            foreach (ParticleSystem picked in winEffect)
            {
                picked.Emit(20);
            }

            gameObject.GetComponent<BoxCollider>().enabled = false;

            GameObject.FindObjectOfType<CheckPointManager>().enabled = false;
            //GameObject.FindObjectOfType<GoldPlayerController>().enabled = false;
            VirtualCamera.SetActive(false);

            cart.SetActive(true);

            //FindObjectOfType<UIHandler>().EndGame();

            cup.SetActive(false);
        }
    }
}
