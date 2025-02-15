using UnityEngine;
using UnityEngine.UI;

public class KeyPointIndicatorScript : MonoBehaviour
{
    [SerializeField] 
    private float keyTimeout = 5.0f;
    private float activeTime;
    private Image indicator;
    private GameObject content;
    private KeyPointScript parentScript;

    void Start()
    {
        parentScript = transform.parent.GetComponent<KeyPointScript>();
        parentScript.isInTime = true;
        indicator = transform.Find("Content/Indicator").gameObject.GetComponent<Image>();
        content = transform.Find("Content").gameObject;
        content.SetActive(false);
    }
    void Update()
    {
        if (content.activeInHierarchy)
        {
            activeTime += Time.deltaTime * (GameState.difficutly switch
            {
                GameState.GameDifficulty.Easy => 0.5f,
                GameState.GameDifficulty.Hard => 1.5f,
                _ => 1.0f
            });
            if (activeTime >= keyTimeout)
            {
                parentScript.isInTime = false;
                gameObject.SetActive(false);
            }
            else
            {
                indicator.fillAmount = (keyTimeout - activeTime) / keyTimeout;
                indicator.color = new Color(1 - indicator.fillAmount, indicator.fillAmount, 0.2f, 0.5f);
            }
        }
        if (parentScript.isKeyGot) Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player" && !content.activeInHierarchy)
        {
            content.SetActive(true);
            activeTime = 0.0f;
        }
    }
}
