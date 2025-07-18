using UnityEngine;
using UnityEngine.AI;

public class TestMonster : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject target;
    public float speed = 5;
    private void Start()
    {
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        GameObject targetObj = GameObject.Find("Player");
        agent.destination = targetObj.transform.position;
        
        agent.speed = speed;    
    }
    
}
