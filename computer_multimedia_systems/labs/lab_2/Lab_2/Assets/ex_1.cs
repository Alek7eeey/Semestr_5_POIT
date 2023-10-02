using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ex_1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

	void OnCollisionEnter(Collision collision)
	{
        if (collision.gameObject.name == "Plane")
        {
			Debug.Log("Hit with plane");
		}
        else
        {
            Debug.Log("Hit with wall");
        }
	}

	// Update is called once per frame
	void Update()
    {
        
    }
}
