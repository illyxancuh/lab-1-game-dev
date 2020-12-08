using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trapScript : MonoBehaviour
{
    [SerializeField] private int damage;
    private Animator anim;
    private PlayerController entity;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D info)
    {
        entity = info.GetComponent<PlayerController>();
        if (entity != null)
        {
            anim.SetBool("triggered", true);
            entity.changeHp(damage);
        }
    }

    private void OnTriggerExit2D()
    {
        anim.SetBool("triggered", false);
    }
}
