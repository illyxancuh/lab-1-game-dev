using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScripts : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float speed;
    private Transform cam;
    void Start()
    {
        cam = GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        cam.position = Vector3.MoveTowards(cam.position, new Vector3(player.position.x, cam.position.y, -10), speed*Vector2.Distance(cam.position,player.position)/speed*Time.deltaTime);
    }
}
