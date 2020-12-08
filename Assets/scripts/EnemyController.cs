
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyController : MonoBehaviour
{
    [SerializeField] public Transform player;
    [SerializeField] private GameObject trigger;
    [SerializeField] private float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;
    private bool find;

    void Start()
    {
        find = false;
        rb = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (trigger.GetComponent<PlayerCheck>().finded)
        {
            Vector3 direction = new Vector3(player.position.x - transform.position.x, 0, 0);
            direction.Normalize();
            movement = direction;
        }
    }
    private void FixedUpdate()
    {
        moveCharacter(movement);
    }
    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }
}