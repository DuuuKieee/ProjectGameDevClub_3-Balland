using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chia2Enemy : Enemy
{
    public float stoppingDistance;
    public bool dash = false;
    public float speed;
    public float dashspeed;
    public int vitrispawn = 1;
    public float flipsize;
    public GameObject quaicon;
    private bool isDead;
    public bool isPhanThan;

    private Transform target;
    //public Transform spawnpoint;
    //public Transform spawnpoint2;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        //spawnpoint = GameObject.FindGameObjectWithTag("Spawnpoint1").GetComponent<Transform>();
        //spawnpoint2 = GameObject.FindGameObjectWithTag("Spawnpoint2").GetComponent<Transform>();
        anim = gameObject.GetComponent<Animator>();
    
    }

    void Update()
    {
        //if(Vector2.Distance(transform.position, target.position) > stoppingDistance)
        // {
        //transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        // }
        if (HP <= 1 && isPhanThan)
        {
            isPhanThan = false;
            //anim.SetBool("isDead", true);
            anim.Play("Die");
            Invoke("Dead", 0.5f);
        }
        else
        {
            if (Vector2.Distance(transform.position, target.position) < stoppingDistance)
            {
                //Bo chay ra xa Target
                rb.velocity = (transform.position - target.position).normalized * speed;
            }
            if (transform.position.x > target.position.x)
            {
                gameObject.transform.localScale = new Vector3(flipsize, flipsize, 1);
            }
            else if (transform.position.x < target.position.x)
            {
                gameObject.transform.localScale = new Vector3(-flipsize, flipsize, 1);
            }
        }
        

    }
    void Dead()
    {
        print("Phan than");
        //Destroy(gameObject, 5);
        Instantiate(quaicon, transform.position - Vector3.right*1.2f, Quaternion.identity);
        Instantiate(quaicon, transform.position - Vector3.left*1.2f, Quaternion.identity);
        Destroy(gameObject);
    }
}