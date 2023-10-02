using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ex_2_AddForce : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public float forceAmount = 100f;

	void OnCollisionEnter(Collision collision)
	{
		Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
		if (rb != null)
		{
			rb.AddForce(transform.right * forceAmount, ForceMode.Impulse);
		}
	}
}
