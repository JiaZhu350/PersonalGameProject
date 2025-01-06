using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerInteract : MonoBehaviour
{
    public bool interacting = false;
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            interacting = true;
        }
        else
        {
            interacting = false;
        }

    }
}
