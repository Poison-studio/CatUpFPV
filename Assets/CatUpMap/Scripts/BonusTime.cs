using UnityEngine;

namespace CatUp
{
    public class BonusTime : MonoBehaviour
    {
        [SerializeField]
        private float bonusTime;

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                FindObjectOfType<ScoreManager>().AddScore(bonusTime);
                Destroy(gameObject);
            }
        }
    }

}