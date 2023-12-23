using Hertzole.GoldPlayer;
using Tayx.Graphy;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CatUp
{
    public class UIHandler : MonoBehaviour
    {
        [SerializeField]
        private GameObject UIMenu;
        [SerializeField]
        private GameObject UIMenuButton;
        [SerializeField]
        private GameObject UIEndGameScreen;
        [SerializeField]
        private GameObject UIDeathScreen;
        [SerializeField]
        private GameObject UIHealth;

        public void Start()
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        public void StopGame()
        {
            SetupSceneUI(true,false,false,false,false);

            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
            Time.timeScale = 0;

            FindObjectOfType<GoldPlayerController>().enabled = false;
        }

        public void ResumeGame()
        {
            SetupSceneUI(false,true,false,false,true);

            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;

            FindObjectOfType<GoldPlayerController>().enabled = true;
            Time.timeScale = 1;
        }

        public void EndGame()
        {
            SetupSceneUI(false,false,false,true,false);

            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
        }

        public void RestartGame()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void Update()
        {
            if(Input.GetKeyDown(KeyCode.F) && (!UIEndGameScreen.activeSelf && !UIDeathScreen.activeSelf))
            {
                StopGame();
            }
        }

        public void DisableStatistics()
        {
            FindObjectOfType<GraphyManager>(true).gameObject.SetActive(false);
        }

        public void EnableStatistics()
        {
            FindObjectOfType<GraphyManager>(true).gameObject.SetActive(true);
        }

        private void OnPlayerDeath()
        {
            SetupSceneUI(false,false,true,false,false);

            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
        }

        private void SetupSceneUI(bool menu, bool menuButton, bool deathScreen, bool endGameScreen,bool health)
        {
            UIDeathScreen.SetActive(deathScreen);
            UIMenu.SetActive(menu);
            UIMenuButton.SetActive(menuButton);
            UIEndGameScreen.SetActive(endGameScreen);
            UIHealth.SetActive(health);
        }

    }

}