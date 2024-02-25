using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandEnemy : Enemy
{
    public float stoppingDistance;
    public bool dash = false;
    public float speed;
    public float dashspeed;
    public float flipsize;


    private Transform target;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
         if (transform.position.x > target.position.x)
        {
            if(Vector2.Distance(transform.position, target.position) > stoppingDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, dashspeed * Time.deltaTime);
            }
            gameObject.transform.localScale = new Vector3(-flipsize, flipsize, 1);
        }
        else if (transform.position.x < target.position.x)
        {
            gameObject.transform.localScale = new Vector3(flipsize, flipsize, 1);
            if(Vector2.Distance(transform.position, target.position) > stoppingDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, dashspeed * Time.deltaTime);
            }
        }
       // else if(Vector2.Distance(transform.position, target.position) > stoppingDistance)
      //  {
        //transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
       // }
        else if(Vector2.Distance(transform.position, target.position) < stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, dashspeed * Time.deltaTime);
        }
    

    }
   // void Dash()
   // {
    //        transform.position = Vector2.MoveTowards(transform.position, target.position, dashspeed * Time.deltaTime);

   // }
}