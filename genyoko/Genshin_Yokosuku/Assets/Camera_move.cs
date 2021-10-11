using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_move : MonoBehaviour
{
    public GameObject player;

    void Start()
    {
    }

    void Update()
    {

        Vector3 playerPos = player.transform.position;

        //カメラとプレイヤーの位置を同じにする
        transform.position = new Vector3(playerPos.x+7, 0, -10);
    }
}