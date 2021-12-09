using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WanderingAI : MonoBehaviour
{
    public float wanderRadius;
    public float wanderTimer;

    private Transform target;
    private NavMeshAgent agent;
    private float timer;
    private bool active = true;

    [SerializeField]
    private float dest_margin = 0.1f;

    // Use this for initialization
    void OnEnable()
    {
        agent = GetComponent<NavMeshAgent>();
        timer = wanderTimer;
    }

    private void Start()
    {
        transform.position = RandomNavSphere(transform.position, 2, -1);
    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (active && (IsNear(agent.destination) || timer >= wanderTimer)) {
            Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
            agent.SetDestination(newPos);
            timer = 0;

        } 
    }

    private bool IsNear (Vector3 dest)
    {
        Vector3 p = transform.position;
        Vector3 d = dest;
        Vector3 dist = d - p;

        if (dist.x <= dest_margin  && dist.z <= dest_margin && dist.y <= dest_margin)
        {
            return true;
        }
        return false;
    }
    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;

        randDirection += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

        return navHit.position;
    }

    public void setActive(bool b) {
        active = b;
    }
}
