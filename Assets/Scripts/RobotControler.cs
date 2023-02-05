using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class RobotControler : MonoBehaviour
{
    public Transform[] waypoints;
    public float moveSpeed = 2f;
    public int waypointIndex = 0;
    // Start is called before the first frame update
    public LineRenderer lr;
    public Transform rayPos;
    void Start()
    {
        transform.position = waypoints[waypointIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

   void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, waypoints[waypointIndex].transform.position, moveSpeed * Time.deltaTime);
        
        if (transform.position == waypoints[waypointIndex].transform.position) 
            waypointIndex += 1;
        if (waypointIndex == waypoints.Length)
            waypointIndex = 0;

        RaycastHit2D hitInfo = Physics2D.Raycast(rayPos.position, waypoints[waypointIndex].transform.position);
       
         if (hitInfo.collider.CompareTag("Player"))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
         

    }


}
