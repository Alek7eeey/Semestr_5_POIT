using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ex_5_trigger : MonoBehaviour
{
	public float scaleFactor = 1.50f;


	void OnTriggerEnter(Collider other)
	{
		GameObject objectsWithTag = GameObject.FindGameObjectWithTag("Sphere");
			// �������� ��������� Transform ��� ���������� ��������
			Transform objTransform = objectsWithTag.transform;

			// ��������� ������ �����
			objTransform.localScale *= 1.5f;
		
	}

	void OnTriggerExit(Collider other)
	{
		GameObject objectsWithTag = GameObject.FindGameObjectWithTag("Sphere");
		// �������� ��������� Transform ��� ���������� ��������
		Transform objTransform = objectsWithTag.transform;

		// ��������� ������ �����
		objTransform.localScale /= 1.5f;
	}
}
