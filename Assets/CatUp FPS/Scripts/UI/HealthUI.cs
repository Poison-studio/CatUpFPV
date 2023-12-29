using UnityEngine;

namespace CatUp
{
    public class HealthUI : MonoBehaviour
    {
        [SerializeField]
        private GameObject[] Hearts;

        public void SetHealth(int remainHealth)
        {
            foreach (GameObject heart in Hearts)
            {
                heart.SetActive(false);
            }

            for (int i = 0; i < remainHealth - 1; i++)
            {
                Hearts[i].SetActive(true);
            }
        }
    }

}