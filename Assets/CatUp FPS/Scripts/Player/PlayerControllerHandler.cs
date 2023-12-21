using Hertzole.GoldPlayer;
using UnityEngine;

namespace CatUp
{
    public class PlayerControllerHandler : MonoBehaviour
    {
        [SerializeField]
        private GoldPlayerController controller;

        public void Start()
        {
            FindObjectOfType<PlayerHealth>().death.AddListener(OnPlayerDeath);
        }

        private void OnPlayerDeath()
        {
            controller.enabled = false;
        }
    }

}
