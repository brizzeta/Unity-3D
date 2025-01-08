using UnityEngine;
using UnityEngine.InputSystem;

public class KeyPointCollectScript : MonoBehaviour
{
    private KeyPointScript parentScript;   // ~ local state

    void Start()
    {
        parentScript = this
            .transform
            .parent
            .GetComponent<KeyPointScript>();
        parentScript.isKeyGot = false;
    }

    void Update()
    {
        this.transform.Rotate(120.0f * Time.deltaTime, 0, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            parentScript.isKeyGot = true;
            Destroy(this.gameObject);
        }
    }
}
