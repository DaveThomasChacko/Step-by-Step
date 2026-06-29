using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageChange : MonoBehaviour
{
    [SerializeField] private bool isNorth;
    [SerializeField] private bool isSouth;
    [SerializeField] private bool isEast;
    [SerializeField] private bool isWest;
    [SerializeField] private GameObject Camera;
    [SerializeField] private GameObject Player;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Vector3 camPos = Camera.transform.position;
        Vector3 playerPos = Player.transform.position;


        if (isNorth)
        {
            camPos.y += 16;
            playerPos.y += 6;
            Debug.Log("Moved North");
        }
        if (isSouth)
        {
            camPos.y -= 16;
            playerPos.y -= 6;
            Debug.Log("Moved South");
        }
        if (isEast)
        {
            camPos.x += 24;
            playerPos.x += 9;
            Debug.Log("Moved East");
        }
        if (isWest)
        {
            camPos.x -= 24;
            playerPos.x -= 9;
            Debug.Log("Moved West");
        }


        Camera.transform.position = camPos;
        Player.transform.position = playerPos;

    }
}