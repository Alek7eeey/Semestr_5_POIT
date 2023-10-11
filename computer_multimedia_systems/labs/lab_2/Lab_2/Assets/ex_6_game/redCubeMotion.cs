using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class redCubeMotion : MonoBehaviour
{
	public float speed = 5.0f;
	private Vector3 initialPosition;


	void Start()
	{
		initialPosition = transform.position;
	}

	private void OnCollisionEnter(Collision collision)
	{
		// Проверяем, столкновение с полом или стеной
		if (collision.gameObject.CompareTag("Bort"))
		{
			speed = -speed;
		}

	}


	void Update()
	{
		transform.Translate(Vector3.forward * speed * Time.deltaTime);

		// Проверка столкновения с объектом с тегом "Bort"
		/* RaycastHit hit;
		 if (Physics.Raycast(transform.position, transform.forward, out hit, 1.0f))
		 {
			 if (hit.collider.CompareTag("Bort"))
			 {
				 Debug.Log("");
				 speed = -speed;
			 }
		 }*/
	}
}
