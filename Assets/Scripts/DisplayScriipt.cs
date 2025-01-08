using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using Unity.VisualScripting;

public class DisplayScriipt : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI clock;
    private TextMeshProUGUI scoreTMP;
    private List<Image> keyImages = new();
    private float gameTime;

    private void Start()
    {
        gameTime = 0.0f;
        clock = transform.Find("Content/Background/ClockTMP").GetComponent<TextMeshProUGUI>();
        scoreTMP = transform.Find("Content/Background/ScoreTMP").GetComponent<TextMeshProUGUI>();
    }
    private void Update()
    {
        gameTime += Time.deltaTime;
        scoreTMP.text = GameState.score.ToString();
    }
    private void LateUpdate()
    {
        int hour = (int)gameTime / 3600, min = ((int)gameTime % 3600) / 60, sec = (int)gameTime % 60;
        clock.text = $"{hour:D2}:{min:D2}:{sec:D2}";
    }
}