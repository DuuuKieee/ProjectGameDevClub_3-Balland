using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public int numEnemy = 0;
    static public int room;

    [SerializeField] GameObject arrow1, arrow2, goal;
    GameObject player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        arrow1.transform.localScale = Vector3.zero;
        arrow2.transform.localScale = Vector3.zero;
        goal.transform.localScale = Vector3.zero;
    }
    // Start is called before the first frame update
    void Start()
    {
        room = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K)) print("room: " + room);
        if (Input.GetKeyDown(KeyCode.L)) NextLevel();
        if (Input.GetKeyDown(KeyCode.J)) print(SceneManager.GetActiveScene().buildIndex);

        if (numEnemy <= 0 && arrow1.transform.localScale == Vector3.zero && room == 1)
        {
            NextRoom(arrow1);
        }
        if (numEnemy <= 0 && arrow2.transform.localScale == Vector3.zero && room == 2)
        {
            NextRoom(arrow2);
        }
        if (numEnemy <= 0 && goal.transform.localScale == Vector3.zero && room == 3)
        {
            goal.SetActive(true);
            NextRoom(goal);
        }
    }
   
    void NextRoom(GameObject arrow)
    {
        Time.timeScale = 0.01f;
        arrow.transform.localScale = Vector3.one;
        CameraController.targetObj = arrow;
        StartCoroutine(TargetPlayer(2));
    }
    
    IEnumerator TargetPlayer(float sec)
    {
        yield return new WaitForSecondsRealtime(sec);
        Time.timeScale = 1;
        CameraController.targetObj = player;
    }

    public static void NextLevel()
    {
        if (Level.level == 2)
        {
            Level.level = 1;
            SceneManager.LoadScene(0);
        }
        else
        {
            Level.level++;
            SceneManager.LoadScene(0);
        }
    }

    public static void Restart(bool isGoal)
    {
        if (isGoal)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
