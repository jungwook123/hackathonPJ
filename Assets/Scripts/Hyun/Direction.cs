using System;
using UnityEngine;

public class Direction : MonoBehaviour
{
    public GameObject target;

    private void Start()
    {
        Invoke("test",2f);
    }

    private void test()
    {
        target = GameObject.FindGameObjectWithTag("Respawn");
    }

    private void Update()
    {
        if(target == null) return;
        Vector3 direction = target.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
