using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChangerScrip : MonoBehaviour
{
    [SerializeField] private int scene;

    private void OnTriggerEnter2D(Collider2D info)
    {
        SceneManager.LoadScene(scene);
    }
}
