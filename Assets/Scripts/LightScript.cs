using System.Collections.Generic;
using UnityEngine;

public class LightScript : MonoBehaviour
{
    private List<Light> nightLights;
    private List<Light> dayLights;
    private bool isNight;

    private void Start()
    {
        nightLights = new List<Light>();
        dayLights = new List<Light>();
        foreach (var gameObject in GameObject.FindGameObjectsWithTag("NightLight")) nightLights.Add(gameObject.GetComponent<Light>());
        foreach (var gameObject in GameObject.FindGameObjectsWithTag("DayLight")) dayLights.Add(gameObject.GetComponent<Light>());
        GameState.isNight = nightLights[0].isActiveAndEnabled;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            GameState.isNight = !GameState.isNight;
            DynamicGI.UpdateEnvironment();
            foreach (var nightLight in nightLights) nightLight.enabled = GameState.isNight;
            foreach (var dayLight in dayLights) dayLight.enabled = !GameState.isNight;
        }
    }
}