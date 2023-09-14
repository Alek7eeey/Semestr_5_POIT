using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeGenerator : MonoBehaviour
{
    MeshRenderer render;
    // Start is called before the first frame update
    void Start()
    {
       render = gameObject.GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float minX = render.bounds.min.x;
        float maxX = render.bounds.max.x;
        float minZ = render.bounds.min.z;
        float maxZ = render.bounds.max.z;

        float newX = Random.Range(minX, maxX);
        float newZ = Random.Range(minZ, maxZ);
        float newY = gameObject.transform.position.y + Random.Range(5, 15);

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) { 
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.position = new Vector3(newX, newZ, newY);
            Renderer renderer = cube.GetComponent<Renderer>();
            renderer.material.color = Random.ColorHSV();

            cube.AddComponent<Rigidbody>();
        }

    }
}
