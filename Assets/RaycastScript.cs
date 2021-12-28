using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastScript : MonoBehaviour
{

    public Transform Cam;
    public float range = 20f;
    private float mining;

    void Start()
    {
        
    }

    void Update()
    {
        mining = Input.GetAxis("Fire1");

        if(mining >= 0)
        {
            shootRay();
        }
    }

    private void shootRay()
    {
        RaycastHit hit;
        if(Physics.Raycast(Cam.position, Cam.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
        }
    }
}
