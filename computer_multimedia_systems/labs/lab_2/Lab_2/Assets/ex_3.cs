using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ex_3 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.CompareTag("LowerCube"))
		{
			Destroy(collision.gameObject, .1f);
		}
	}
}
