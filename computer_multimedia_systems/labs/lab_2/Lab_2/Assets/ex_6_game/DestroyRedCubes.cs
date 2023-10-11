using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyRedCubes : MonoBehaviour
{

	private void OnTriggerEnter(Collider other)
	{
		// ���������, ����� �� ����� � �������
		if (other.CompareTag("Sphere"))
		{
			// ������� ��� ������� ���� � �����
			GameObject[] redCubes = GameObject.FindGameObjectsWithTag("RedCube");

			// ���������� ������� ����
			foreach (GameObject redCube in redCubes)
			{
				Destroy(redCube);
			}
		}
	}
}
