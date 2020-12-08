using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupeableItem : MonoBehaviour
{
    [SerializeField] private int damage;
    private PlayerController entity;
    private void OnTriggerEnter2D(Collider2D info)
    {
        entity = info.GetComponent<PlayerController>();
        if (entity != null)
        {
            entity.changeHp(damage);
        }
        Destroy(gameObject);
    }
}
