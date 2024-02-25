using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyFish : Enemy
{
    public float speed;
    private float waitTime;
    public float startWaitTime;
    //public Transform[] moveSpots;
    public float flipsize;
    private bool isAttack;
    public GameObject atkzone;

    //private int randomSpot;
    private Vector2 randomPos, defaultPos;
    [SerializeField] float radius;
    
    void Start()
    {
        waitTime = startWaitTime;
        //randomSpot = Random.Range(0, moveSpots.Length);
        defaultPos = transform.position;
        randomPos.x = Random.Range(0, radius);
        randomPos.y = Random.Range(0, radius);
        anim = gameObject.GetComponent<Animator>();

    }

    
    void Update()
    {
        //transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);
        transform.position = Vector2.MoveTowards(transform.position, defaultPos+randomPos, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, /*moveSpots[randomSpot].position*/defaultPos + randomPos) < 0.2f)
        {
            if(waitTime <= 0)
            {
                //randomSpot = Random.Range(0, moveSpots.Length);
                randomPos.x = Random.Range(0, radius);
                randomPos.y = Random.Range(0, radius);
                waitTime = startWaitTime;
               anim.SetBool("isAttack", false);
                atkzone.SetActive(false);
                
            }
            else
            {
                atkzone.SetActive(true);

                waitTime -= Time.deltaTime;
            anim.SetBool("isAttack", true);
            }
        }
        if (transform.position.x < /*moveSpots[randomSpot].position.x*/(defaultPos + randomPos).x)
             {
                 gameObject.transform.localScale = new Vector3(flipsize, flipsize, 1);
             }
        else if (transform.position.x > /*moveSpots[randomSpot].position.x*/(defaultPos + randomPos).x)
        {
            gameObject.transform.localScale = new Vector3(-flipsize, flipsize, 1);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        randomPos.x = Random.Range(0, radius);
        randomPos.y = Random.Range(0, radius);
        waitTime = startWaitTime;
        anim.SetBool("isAttack", false);
        atkzone.SetActive(false);
    }

}
