using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyRedCubes : MonoBehaviour
{

	private void OnTriggerEnter(Collider other)
	{
		// Проверяем, вошла ли сфера в триггер
		if (other.CompareTag("Sphere"))
		{
			// Находим все красные кубы в сцене
			GameObject[] redCubes = GameObject.FindGameObjectsWithTag("RedCube");

			// Уничтожаем красные кубы
			foreach (GameObject redCube in redCubes)
			{
				Destroy(redCube);
			}
		}
	}
}
