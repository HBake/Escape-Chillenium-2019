using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform Player;
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(Player.position.x, Player.position.y + 1);
    }
}
