using UnityEngine;

public class BeeSpawner : MonoBehaviour
{
    public GameObject beePrefab;
    public int numberOfBees;
    public float spawnRadius;
    public float maxBeeHeight;

    void Start()
    {
        for (int i = 0; i < numberOfBees; i++)
        {
            SpawnBee();
        }
    }

    void SpawnBee()
    {
        Vector3 randomDirection = Random.insideUnitSphere.normalized * spawnRadius;
        Vector3 spawnPosition = transform.position + randomDirection;
        spawnPosition.y = Mathf.Clamp(spawnPosition.y, transform.position.y, transform.position.y + maxBeeHeight); // Ограничение высоты
        Quaternion randomRotation = Quaternion.Euler(0, Random.Range(0, 360), 0); // Вращение только вокруг оси Y

        GameObject newBee = Instantiate(beePrefab, spawnPosition, randomRotation);
    }
}
