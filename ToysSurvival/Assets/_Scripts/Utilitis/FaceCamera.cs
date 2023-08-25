using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCamera : MonoBehaviour
{
    public GameObject player;
    private void Update()
    {
        if (player == null) return;
        transform.position = new Vector3(player.transform.position.x,transform.position.y, player.transform.position.z);
        Vector3 lookDir = Camera.main.transform.position - transform.position;
        transform.rotation = Quaternion.LookRotation(lookDir, Vector3.up);
    }
}
