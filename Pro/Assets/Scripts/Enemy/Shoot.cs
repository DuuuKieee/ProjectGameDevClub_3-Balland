using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Shoot : MonoBehaviour
{
    public float Range;
    Transform Target;
    bool Detected = false;
    Vector2 Direction;
    public GameObject Gun;
    public GameObject bullet;
    public float FireRate;
    float nextTimeToFire = 0;
    public Transform Shootpoint;
    public float Force;

    Animator anim;
    
    // Start is called before the first frame update
    void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Player").transform;
        anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        Vector2 targetPos = Target.position;
        Direction = targetPos - (Vector2)transform.position;
        RaycastHit2D rayInfo = Physics2D.Raycast(transform.position,Direction,Range);
        if (rayInfo)
        {
            if(rayInfo.collider.gameObject.tag == "Player")
            {
                if (Detected == false)
                {
                    Detected = true;
                }
            }
            else
            {
                if (Detected == true)
                {
                    Detected = false;
                }
            }
        }
        if (Detected)
        {
            Gun.transform.up = Direction;
            if(Time.time > nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1 / FireRate;
                shoot();
            }
        }
    }
    void shoot()
    {
        anim.Play("Shot");
        GameObject BulletIns = Instantiate(bullet, Shootpoint.position, Quaternion.identity);
        
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, Range);
    }
}