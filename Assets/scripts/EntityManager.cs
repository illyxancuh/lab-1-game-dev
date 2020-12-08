using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityManager : MonoBehaviour
{
    [SerializeField] private int maxHp;
    private int hp;

    void Start()
    {
        hp = maxHp;
    }

    public void changeHp(int change)
    {
        print(hp);
        hp += change;
        print(hp);
        print(change);
        if (hp > maxHp)
        {
            hp = maxHp;
        }
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}