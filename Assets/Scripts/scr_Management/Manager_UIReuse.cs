using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Manager_UIReuse : MonoBehaviour
{
    [Header("Interact")]
    public TMP_Text txt_Interact;
    public RawImage bgr_InteractBackground;

    public void EnableInteractUI()
    {
        bgr_InteractBackground.gameObject.SetActive(true);
    }
    public void DisableInteractUI()
    {
        txt_Interact.text = "";
        bgr_InteractBackground.gameObject.SetActive(false);
    }
}