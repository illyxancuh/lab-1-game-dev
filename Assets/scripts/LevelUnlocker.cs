using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUnlocker : MonoBehaviour
{
    [SerializeField] private bool ismenu;
    [SerializeField] private GameObject portal;
    [SerializeField] private int forUnlock;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("level") >= forUnlock && ismenu)
        {
            portal.SetActive(true);
        }
        else if(ismenu == false && PlayerPrefs.GetInt("level")<=forUnlock)
        {
            PlayerPrefs.SetInt("level", forUnlock);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
