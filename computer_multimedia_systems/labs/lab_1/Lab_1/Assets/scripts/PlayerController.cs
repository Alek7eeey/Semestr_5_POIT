using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(3 * Vector3.up, ForceMode.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            Renderer renderer = rb.GetComponent<Renderer>();

            _ = renderer.material.color == Color.blue ? renderer.material.color = Color.white : renderer.material.color = Color.blue;
        }

        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
        rb.AddForce (movement * speed);
    }
}
