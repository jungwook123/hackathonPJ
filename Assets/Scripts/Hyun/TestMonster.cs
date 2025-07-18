using UnityEngine;
using UnityEngine.AI;

public class TestMonster : MonoBehaviour
{
    public NavMeshAgent agent;
    public float speed = 5f;
    public float wanderRadius = 10f;
    public float wanderInterval = 3f;

    private GameObject target;
    private float wanderTimer;
    
    void Start()
    {
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        agent.speed = speed;

        target = GameObject.Find("Player");
        wanderTimer = wanderInterval;
    }

    void Update()
    {
        switch (GameManager.Instance.gameState)
        {
            case GameState.Ongoing:
                Wander();
                break;

            case GameState.InBank:
                Idle();
                break;

            case GameState.Onrunning:
                ChasePlayer();
                break;
        }
    }

    void Wander()
    {
        wanderTimer += Time.deltaTime;

        if (wanderTimer >= wanderInterval || agent.remainingDistance <= 0.5f)
        {
            Vector2 randomCircle = Random.insideUnitCircle * wanderRadius;
            Vector3 randomDestination = new Vector3(transform.position.x + randomCircle.x, transform.position.y + randomCircle.y, 0);
            agent.SetDestination(randomDestination);
            wanderTimer = 0f;
        }
    }

    void Idle()
    {
        agent.SetDestination(transform.position); // 현재 위치를 목적지로 해서 멈추게 함
    }

    void ChasePlayer()
    {
        if (target != null)
            agent.SetDestination(target.transform.position);
    }
}