using CatUp;
using System.Collections;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private float deathPenalty;
    [SerializeField]
    private float fadeOutDuration;

    [SerializeField]
    private TextMeshProUGUI scoreText;
    [SerializeField]
    private TextMeshProUGUI penaltyText;

    private float score;
    private float Score
    {
        get
        {
            return score;
        }
        set
        {
            score = value > 0 ? value : 0;
        }
    }


    private void Start()
    {
        Score = 0;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Health>().death.AddListener(OnPlayerDeath);
    }

    private void OnPlayerDeath()
    {
        SubstractScore(deathPenalty);
    }

    public void SubstractScore(float value)
    {
        Score += value;
        penaltyText.text = "+ " + value.ToString() + " second penalty";
        penaltyText.color = Color.red;
        StartCoroutine(FadeOut());
    }

    public void AddScore(float value)
    {
        Score -= value;
        penaltyText.text = " bonus time: " + value.ToString();
        penaltyText.color = Color.green;
        StartCoroutine(FadeOut());
    }

    private void Update()
    {
        Score += Time.deltaTime;
        scoreText.text = Score.ToString("N1");
    }

    private IEnumerator FadeOut()
    {
        float currentTime = 0f;
        while (currentTime < fadeOutDuration)
        {
            float alpha = Mathf.Lerp(1f, 0f, currentTime / fadeOutDuration);
            penaltyText.color = new Color(penaltyText.color.r, penaltyText.color.g, penaltyText.color.b, alpha);
            currentTime += Time.deltaTime;
            yield return null;
        }
        yield break;
    }



}
