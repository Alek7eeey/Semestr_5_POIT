using UnityEngine;

public class Bee : MonoBehaviour
{
    public float chaseDistance = 10f;
    public float fieldOfView = 60f;
    public float minSpeed = 1f;
    public float maxSpeed = 5f;

    private Transform player;
    private float currentSpeed;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        currentSpeed = Random.Range(minSpeed, maxSpeed);
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        
        if(distanceToPlayer<0.1f)
        {
            Debug.Log("Игрок проиграл!");
            #if UNITY_EDITOR
                        UnityEditor.EditorApplication.isPlaying = false;
            #else
                                Application.Quit();
            #endif
        }

        if (distanceToPlayer < chaseDistance)
        {
            Vector3 directionToPlayer = (player.position - transform.position).normalized;
            float angle = Vector3.Angle(transform.forward, directionToPlayer);

            if (angle < fieldOfView * 0.5f)
            {
                transform.LookAt(player);
                transform.position += transform.forward * currentSpeed * Time.deltaTime;
            }
        }
        else
        {
            float distanceToSun = Vector3.Distance(transform.position, Vector3.zero);
            float speedMultiplier = Mathf.Clamp01(distanceToSun / chaseDistance);
            currentSpeed = Mathf.Lerp(maxSpeed, minSpeed, speedMultiplier);
        }
    }
}
