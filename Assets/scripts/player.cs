using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.Mathematics;
using UnityEngine;

public class player : MonoBehaviour
{
    [SerializeField] private float movespeed;

    private float bounds = 4.5f;
    void Update()
    {
        move();
    }

    private void move()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");

        Vector2 playerPosition = transform.position;
        playerPosition.x = math.clamp(playerPosition.x + moveInput * movespeed * Time.deltaTime, -bounds, bounds);
        transform.position = playerPosition;
    }
}
