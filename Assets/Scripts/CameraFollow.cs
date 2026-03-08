using System;
using UnityEngine;

public class CameraFollow: MonoBehaviour
{
    private Transform player;

    private Vector3 tempPos;

    [SerializeField]
    private float minX, maxX;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        tempPos = transform.position; //current position of the camera
        tempPos.x = player.position.x; // set player position x to the camera

        if (tempPos.x < minX)
            tempPos.x = minX;

        if (tempPos.x > maxX)
            tempPos.x = maxX;


        transform.position = tempPos;
    }
} // class


