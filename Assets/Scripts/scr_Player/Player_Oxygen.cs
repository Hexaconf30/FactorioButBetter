using UnityEngine;
using TMPro;

public class Player_Oxygen : MonoBehaviour
{
    [Header("Assignables")]
    [SerializeField] private float oxygenConsumption = 4f;
    [SerializeField] private float oxygenRegeneration = 5f;
    [SerializeField] private float maxOxygen = 100f;
    [SerializeField] private TMP_Text txt_currOxygen;

    //public but hidden variables
    [HideInInspector] public bool isDead;
    [HideInInspector] public bool consumeOxygen = true;

    //private variables
    private float currOxygen = 100f;
    private float displayOxygen = 100f;

    private void Update()
    {
        currOxygen = Mathf.Clamp(currOxygen, 0, maxOxygen);
        displayOxygen = Mathf.RoundToInt(currOxygen);

        if (!isDead)
        {
            if (displayOxygen <= 0)
            {
                isDead = true;
            }

            if (consumeOxygen)
            {
                currOxygen -= oxygenConsumption * Time.deltaTime;

            }
            else if (!consumeOxygen)
            {
                currOxygen += oxygenRegeneration * Time.deltaTime;
            }

            txt_currOxygen.text = "Oxygen: " + displayOxygen + "%";
        }
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