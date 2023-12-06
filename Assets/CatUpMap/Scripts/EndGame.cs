using Cinemachine;
using Hertzole.GoldPlayer;
using UnityEngine;

namespace CatUp
{
    public class EndGame : MonoBehaviour
    {
        [SerializeField]
        private ParticleSystem[] winEffect;

        [SerializeField]
        private GameObject mesh;

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
            GameObject.FindObjectOfType<GoldPlayerController>().enabled = false;
            cart.SetActive(true);
            VirtualCamera.SetActive(false);
            FindObjectOfType<UIHandler>().EndGame();
            Destroy(mesh);
        }
    }
}
