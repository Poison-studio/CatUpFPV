using UnityEngine;

public class BonusTime : MonoBehaviour
{
    [SerializeField]
    private float bonusTime;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            FindObjectOfType<ScoreManager>().AddScore(bonusTime);
            gameObject.SetActive(false);
        }
    }
}
