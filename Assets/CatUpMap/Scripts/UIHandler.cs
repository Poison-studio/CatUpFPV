using Hertzole.GoldPlayer;
using Tayx.Graphy;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CatUp
{
    public class UIHandler : MonoBehaviour
    {
        [SerializeField]
        private GameObject UIMenu;
        [SerializeField]
        private GameObject UIButton;
        [SerializeField]
        private GameObject UIScore;
        [SerializeField]
        private GameObject EndGameScreen;


        [SerializeField]
        private TextMeshProUGUI record;
        [SerializeField]
        private TextMeshProUGUI record2;

        public void Start()
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        public void StopGame()
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
            Time.timeScale = 0;
            FindObjectOfType<GoldPlayerController>().enabled = false;
            UIButton.SetActive(false);
            UIMenu.SetActive(true);
            UIScore.SetActive(false);
        }

        public void ResumeGame()
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            FindObjectOfType<GoldPlayerController>().enabled = true;
            UIButton.SetActive(true);
            UIScore.SetActive(true);
            UIMenu.SetActive(false);
            Time.timeScale = 1;
        }

        public void EndGame()
        {
            record.text = "Лучшее время : " + FindObjectOfType<ScoreManager>().Score.ToString() + " секунд";
            record2.text = "Текущий забег : " + FindObjectOfType<ScoreManager>().Score.ToString() + " секунд";
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
            UIButton.SetActive(false);
            UIScore.SetActive(false);
            UIMenu.SetActive(false);
            EndGameScreen.SetActive(true);
        }

        public void RestartGame()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void Update()
        {
            if(Input.GetKeyDown(KeyCode.F) && !EndGameScreen.activeSelf)
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

    }

}