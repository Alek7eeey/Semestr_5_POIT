using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class twoCube : MonoBehaviour
{
    public GameObject player;

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, Time.deltaTime);
    }
}
