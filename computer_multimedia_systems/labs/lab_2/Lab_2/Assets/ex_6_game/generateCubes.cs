using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generateCubes : MonoBehaviour
{
	public GameObject greenCubePrefab;
	public int numberOfCubes = 5;
	public GameObject plane;

	void Start()
	{
		for (int i = 0; i < numberOfCubes; i++)
		{
			GenerateCube();
		}
	}

	void GenerateCube()
	{
		Renderer planeRenderer = plane.GetComponent<Renderer>();

		float minX = planeRenderer.bounds.min.x;
		float maxX = planeRenderer.bounds.max.x;
		float minY = planeRenderer.bounds.min.y;
		float maxY = planeRenderer.bounds.max.y;
		float minZ = planeRenderer.bounds.min.z;
		float maxZ = planeRenderer.bounds.max.z;

		Vector3 position;

		do
		{
			float xPos = Random.Range(minX, maxX);
			float yPos = Random.Range(minY, maxY);
			float zPos = Random.Range(minZ, maxZ);

			position = new Vector3(xPos, yPos, zPos);
		}
		while (!IsPositionInsidePlane(position));

		GameObject cube = Instantiate(greenCubePrefab, position, Quaternion.identity);
	}

	bool IsPositionInsidePlane(Vector3 position)
	{
		RaycastHit hit;
		if (Physics.Raycast(position, Vector3.down, out hit)) //Raycast, который стреляет лучем вниз от указанной позиции position.
		{
			return hit.collider.gameObject == plane;
		}
		return false;
	}
}
