using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private GameObject slime;
    private Transform slimeballpos;

    private void FixedUpdate()
    {
        slimeballpos = GetComponent<Transform>();
    }
    private void OnTriggerEnter2D(Collider2D info)
    {
        EntityManager enemy = info.GetComponent<EntityManager>();
        if (enemy != null)
            enemy.changeHp(_damage);
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        if (!LevelManager.Instanse.onRestart)
        {
            Instantiate(slime, transform.position, Quaternion.identity);
        }
    }
}