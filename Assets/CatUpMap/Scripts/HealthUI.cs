using CatUp;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    [SerializeField]
    private GameObject[] Hearts;

    [SerializeField]
    private PlayerHealth playerHealth;

    public void Start()
    {
        playerHealth.getDamage.AddListener(GetDamage);
    }

    private void GetDamage()
    {
        foreach (GameObject heart in Hearts)
        {
            heart.SetActive(false);
        }

        for (int i = 0; i < playerHealth.Health; i++)
        {
            Hearts[i].SetActive(true);
        }
    }
}
