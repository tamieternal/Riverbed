using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMove : MonoBehaviour
{
    public GameObject player;
    public float ratio;

    private void Update()
    {
        Vector3 temp = new Vector3(player.transform.position.x / ratio, transform.position.y, transform.position.z);
        transform.position = temp;
    }
}
