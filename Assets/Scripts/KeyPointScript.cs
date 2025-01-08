using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyPointScript : MonoBehaviour
{
    [SerializeField]
    private string keyName = "1";

    public bool isInTime { get; set; }

    private bool _isKeyGot;
    public bool isKeyGot
    {
        get => _isKeyGot;
        set
        {
            _isKeyGot = value;
            if (value)
            {
                GameState.collectedKeys.Add(keyName, isInTime);
                GameState.TriggerEvent(keyName, new TriggerPayload()
                {
                    notification = $"Ключ \"{keyName}\" подобран " + (isInTime ? "воворемя" : "не вовремя"),
                    payload = isInTime
                });
                GameState.score += (isInTime ? 2 : 1) * (GameState.difficutly switch
                {
                    GameState.GameDifficulty.Easy => 1,
                    GameState.GameDifficulty.Hard => 3,
                    _ => 2
                });
            }
        }
    }
}
/* Д.З. Розмістити на ігровому полі декілька об'єктів типу "KeyPoint"
 * Реалізувати відмінність в імені ключа (keyName), а також у
 * відстані активації (розмір колайдера) та тривалості часу індикатора.
 * Переконатись, що їх робота незалежна.
 */
