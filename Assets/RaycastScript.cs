using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastScript : MonoBehaviour
{
    [Header("Assignables")]
    [Range(3f, 50f)]
    [SerializeField] private float mineRange = 20f;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Mine();
        }
    }

    private void Mine()
    {
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, mineRange))
        {
            if (hit.transform.CompareTag("Ore"))
            {
                Debug.Log("Currently mining ore " + hit.transform.name + ".");
            }
            else if (hit.transform.CompareTag("Plant"))
            {
                Debug.Log("Currently mining plant " + hit.transform.name + ".");
            }
            else if (hit.transform.CompareTag("SoftRock"))
            {
                Debug.Log("Currently mining soft rock " + hit.transform.name + ".");
            }
        }
    }
}