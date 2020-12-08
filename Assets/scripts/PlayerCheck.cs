using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheck : MonoBehaviour
{
    public bool finded = false;

    private void OnTriggerEnter2D(Collider2D info)
    {
        if (info.GetComponent<PlayerController>() != null)
        {
            finded = true;
        }
    }
}
