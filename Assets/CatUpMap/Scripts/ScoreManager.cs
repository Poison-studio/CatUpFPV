using CatUp;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
    [SerializeField]
    private Image background;

    private float freezeTimer;
    private float score;
    public float Score
    {
        get
        {
            return score;
        }
        private set
        {
            score = value > 0 ? value : 0;
        }
    }


    private void Start()
    {
        freezeTimer = 0;
        Score = 0;
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>().death.AddListener(OnPlayerDeath);
    }

    private void OnPlayerDeath()
    {
        SubstractScore(deathPenalty);
    }

    public void SubstractScore(float value)
    {
        Score += value;
        penaltyText.text = "Штраф " + value.ToString() + " секунд";
        penaltyText.color = Color.red;
        fadeOutDuration = 3;
        StartCoroutine(FadeOut());
    }

    public void AddScore(float value)
    {
        Score -= value;
        penaltyText.text = " Бонусное время : " + value.ToString();
        penaltyText.color = Color.green;
        fadeOutDuration = 3;
        StartCoroutine(FadeOut());
    }

    private void Update()
    {
        freezeTimer -= Time.deltaTime;
        if (freezeTimer > 0) return;

        Score += Time.deltaTime;
        scoreText.text = Score.ToString("N1");
    }

    private IEnumerator FadeOut()
    {
        float currentTime = 0f;
        while (currentTime < fadeOutDuration)
        {
            float alpha = Mathf.Lerp(1f, 0f, currentTime / fadeOutDuration);
            if(alpha > .95)
            {
                background.color = new Color(255, 255, 255, 255);
            }
            else if(alpha < .05)
            {
                background.color = new Color(255, 255, 255, 0);
            }

            if (alpha > .95)
            {
                penaltyText.color = new Color(penaltyText.color.r, penaltyText.color.g, penaltyText.color.b,255);
            }
            else if (alpha < .05)
            {
                penaltyText.color = new Color(penaltyText.color.r, penaltyText.color.g, penaltyText.color.b, 0);
            }

            currentTime += Time.deltaTime;
            yield return null;
        }
        yield break;
    }

    public void FreezeScore(float freezeTime)
    {
        if (freezeTime == 0) return;

        freezeTimer = freezeTime;
        penaltyText.color = new Color32(88, 160, 241, 255);
        penaltyText.text = " Время заморожено ";
        fadeOutDuration = 3;
        StartCoroutine(FadeOut());
    }



}
