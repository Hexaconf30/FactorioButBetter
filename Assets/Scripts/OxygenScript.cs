using UnityEngine;
using UnityEngine.UI;

public class OxygenScript : MonoBehaviour
{
    public float maxOxygen = 100f;
    public float currOxygen = 100f;
    public float displayOxygen = 100f;
    public float oxygenConsumption = 4f;
    public float oxygenRegeneration = 5f;

    public bool isDead = false;
    public bool consumeOxygen = true;

    public Text oxygenText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currOxygen = Mathf.Clamp(currOxygen, 0, maxOxygen);
        displayOxygen = Mathf.RoundToInt(currOxygen);

        if (displayOxygen <= 0)
        {
            isDead = true;
        }



        if (consumeOxygen && !isDead)
        {
            currOxygen -= oxygenConsumption * Time.deltaTime;

        }else if(!consumeOxygen && !isDead)
        {
            currOxygen += oxygenRegeneration * Time.deltaTime;
        }

        oxygenText.text = "Oxygen: " + displayOxygen +"%";

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "OxyField")
        {
            consumeOxygen = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "OxyField")
        {
            consumeOxygen = true;
        }
    }
}
