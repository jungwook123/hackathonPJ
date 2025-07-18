using UnityEngine;
using UnityEngine.AI;

public class TestMonster : MonoBehaviour
{
    public NavMeshAgent agent;
    public float speed = 5f;
    public float wanderRadius = 10f;
    public float wanderInterval = 3f;
    public float detectionRange = 16f;

    private GameObject target;
    private float wanderTimer;

    private Vector3 lastKnownPlayerPos;
    private bool chasingPlayer = false;
    private bool goingToLastKnown = false;

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
        if (GameManager.Instance.gameState == GameState.Ongoing)
        {
           Wander();
        }
        else if (GameManager.Instance.gameState == GameState.Onrunning)
        {
            float dist = Vector3.Distance(transform.position, target.transform.position);

            if (dist <= detectionRange)
            {
                chasingPlayer = true;
                goingToLastKnown = false;
                lastKnownPlayerPos = target.transform.position;
                agent.SetDestination(lastKnownPlayerPos);
            }
            else if (chasingPlayer)
            {
                chasingPlayer = false;
                goingToLastKnown = true;
                agent.SetDestination(lastKnownPlayerPos);
            }
            else if (goingToLastKnown)
            {
                if (agent.remainingDistance <= 0.5f)
                {
                    goingToLastKnown = false;
                }
            }
            else
            {
                Wander();
            }
        }
    }

    void Wander()
    {
        wanderTimer += Time.deltaTime;

        if (wanderTimer >= wanderInterval || agent.remainingDistance <= 0.5f)
        {
            float x = Random.Range(-10f, 10f);
            float y = Random.Range(-10f, 10f);
            Vector3 randomDestination = transform.position +new Vector3(x, y, 0f);

            agent.SetDestination(randomDestination);
            wanderTimer = 0f;
        }
    }

    void ChasePlayer()
    {
        if (target != null)
        {
            agent.SetDestination(target.transform.position);
        }
    }
}
