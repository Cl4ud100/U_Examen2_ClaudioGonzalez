using System;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private NavMeshAgent agent;
    //array para los waypoints
    [SerializeField] private Transform[] waypoints;
    private int currentWaypointsIndex = 0;

    //distancia minima para cambiar el waypoint
    [SerializeField] private float waypointThreshold = 1f;

    private Transform playerTransform;
    //configuracion del daño, deteccion, rango de ataque y cooldown del enemigo
    [SerializeField] private float detectionRange = 18f;
    [SerializeField] private float attackRange = 2f;
    [SerializeField] private int damageAmount = 10;
    [SerializeField] private float attackCooldown = 1f;
    private float lastAttackTime;
    //estados del enemigo
    private enum EnemyState
    {
        Patrol,Chase,Attack
    }
    //variable del estado actual del enemigo
    private EnemyState currentState = EnemyState.Patrol;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerTransform = player.transform;
        }
        else
        {
            Debug.LogError("Jugador no encontrado, favor de colocar tag correspondiente al game object");
        }

        MoveToNextWaypoint();
    }

   
    void Update()
    {
        //switch para cambiar el estado del enemigo, en caso de deteccion, alejamiento o ataque al jugador
        switch (currentState)
        {
            case EnemyState.Patrol:
                Patrol();
                if (Vector3.Distance(transform.position,playerTransform.position) <= detectionRange)
                {
                    currentState = EnemyState.Chase;
                }
                break;
            case EnemyState.Chase:
                ChasePlayer();
                if (Vector3.Distance(transform.position,playerTransform.position)> detectionRange)
                {
                    currentState = EnemyState.Patrol;
                    MoveToNextWaypoint();
                }
                else if (Vector3.Distance(transform.position, playerTransform.position) <= attackRange)
                {
                    currentState = EnemyState.Attack;
                }
                break;
            case EnemyState.Attack:
                AttackPlayer();
                if (Vector3.Distance(transform.position,playerTransform.position) > attackRange)
                {
                    currentState = EnemyState.Chase;
                }
                break;
        }
    }

    //funcion de patrullaje del enemigo
    private void Patrol()
    {
        if (agent.remainingDistance < waypointThreshold)
        {
            MoveToNextWaypoint();
        }
    }
    //funcion para 
    private void MoveToNextWaypoint()
    {
        if (waypoints.Length == 0)
            return;
        agent.SetDestination(waypoints[currentWaypointsIndex].position);
        currentWaypointsIndex = (currentWaypointsIndex + 1) % waypoints.Length;
    }

    private void ChasePlayer()
    {
        agent.SetDestination(playerTransform.position);
    }

    private void AttackPlayer()
    {
        agent.SetDestination(transform.position);

        Vector3 direction = (playerTransform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation,lookRotation,Time.deltaTime*5f);

        if (Time.time - lastAttackTime >= attackCooldown)
        {
            GameManage.instance.decreasedHealth(damageAmount);
            Debug.Log("Te han atacado, corre");

            lastAttackTime = Time.time;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position,detectionRange);
        
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,attackRange);
    }
}
