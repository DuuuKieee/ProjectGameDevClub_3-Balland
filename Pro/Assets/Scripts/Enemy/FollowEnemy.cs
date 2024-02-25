using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowEnemy : Enemy
{
    public float stoppingDistance;
    public bool dash = false;
    public float speed;
    public float dashspeed;
    private Vector2 movement;
    public Vector3 dir;

    //private Animator anim;

    private Transform target;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        anim = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        if(Vector2.Distance(transform.position, target.position) > stoppingDistance)
        {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        else if(Vector2.Distance(transform.position, target.position) < stoppingDistance)
        {
            Dash();
        }
        dir = target.position - transform.position;
        movement = dir;

        anim.SetFloat("X", dir.x);
        anim.SetFloat("Y", dir.y);


    


    }
    void Dash()
    {
            transform.position = Vector2.MoveTowards(transform.position, target.position, dashspeed * Time.deltaTime);

    }
}