using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameLogic : MonoBehaviour
{
	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.CompareTag("greenCube"))
		{
			GameObject[] greenCubes = GameObject.FindGameObjectsWithTag("greenCube");
			foreach (GameObject greenCube in greenCubes)
			{
				Destroy(greenCube);
			}
		}

		if (collision.gameObject.CompareTag("RedCube"))
		{
			Destroy(gameObject);
		}
	}
}
