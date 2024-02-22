using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode] //Allows for monoBehavior scripts to execute certain funtions in Edit Mode as well as Play Mode
public class FollowCamera : MonoBehaviour
{
    public GameObject player;
    public float pitch;
    public float yaw;
    public float distance;
    public float offset;

    void LateUpdate()
    {
        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0f);
        Vector3 direction = rotation * Vector3.forward;
        Camera.main.transform.position = new Vector3(player.transform.position.x - distance, player.transform.position.y + 5, player.transform.position.z - offset);
        Camera.main.transform.rotation = rotation;
    }


}
