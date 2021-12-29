using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Env_PlaceBuilding : MonoBehaviour
{
    [Header("Assignables")]
    [Range(1f, 5f)]
    [SerializeField] private float interactRange;
    [SerializeField] private Transform pos_heldBuilding;
    [SerializeField] private Transform thePlayer;
    [SerializeField] private Manager_UIReuse UIReuseScript;

    //public but hidden variables
    [HideInInspector] public bool isInteractable;

    //private variables
    private bool isMoving;
    private bool waitBeforeAllowingToPlace;
    private float distance;

    private void Start()
    {
        isInteractable = true;
    }

    private void Update()
    {
        if (isInteractable && !isMoving)
        {
            float distance = Vector3.Distance(gameObject.transform.position, thePlayer.transform.position);
        }

        if (isMoving)
        {
            gameObject.transform.position = pos_heldBuilding.position;

            if (!waitBeforeAllowingToPlace)
            {
                StartCoroutine(Wait());
            }

            if (Input.GetKeyDown(KeyCode.E) && waitBeforeAllowingToPlace)
            {
                Debug.Log("Placed down the building " + name + ".");
                waitBeforeAllowingToPlace = false;
                isMoving = false;
            }
        }
    }

    private void OnMouseOver()
    {
        if (isInteractable 
            && !isMoving
            && distance <= interactRange)
        {
            UIReuseScript.EnableInteractUI();
            UIReuseScript.txt_Interact.text = "Move building (E)";

            if (Input.GetKeyDown(KeyCode.E))
            {
                isMoving = true;
                Debug.Log("Moving the building " + name + ".");
            }
        }

        if (!isInteractable
            || isMoving
            || distance > interactRange)
        {
            UIReuseScript.DisableInteractUI();
        }
    }
    private void OnMouseExit()
    {
        UIReuseScript.DisableInteractUI();
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.1f);
        waitBeforeAllowingToPlace = true;
    }
}