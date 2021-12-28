using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenScript : MonoBehaviour
{
    public float maxOxygen = 100f;
    public float currOxygen = 100f;
    public bool isDead = false;
    public bool consumeOxygen = true;
    public float displayOxygen = 100f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(displayOxygen <= 0)
        {
            isDead = true;
        }

        if (consumeOxygen && !isDead)
        {
            currOxygen -= 2 * Time.deltaTime;
            displayOxygen = Mathf.RoundToInt(currOxygen);
            Debug.Log(displayOxygen);
        }


    }
}
