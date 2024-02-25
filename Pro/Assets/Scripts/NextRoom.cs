using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextRoom : MonoBehaviour
{
    GameObject gameController, cameraObj;
    [SerializeField] GameObject enemyNextRoom, wallObj;

    [SerializeField] Collider2D coll;
    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController");
        cameraObj = GameObject.FindGameObjectWithTag("MainCamera");
        //coll = gameObject.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (coll.isTrigger == false && gameController.GetComponent<GameController>().numEnemy <= 0) coll.isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (gameController.GetComponent<GameController>().numEnemy <= 0)
            {
                GameController.room++;
                cameraObj.GetComponent<CameraController>().minY += 20;
                cameraObj.GetComponent<CameraController>().maxY += 20;
                enemyNextRoom.SetActive(true);
                Instantiate(wallObj, transform.position - new Vector3(0, 1.5f, 0), Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }
}
