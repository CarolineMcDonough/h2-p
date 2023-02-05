using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootControl : MonoBehaviour
{
    public RobotControler Robot;
    public float robotSpeed = 2f;
    Coroutine wait = null;

    void OnTriggerExit2D(Collider2D collision)
    {
        if(wait == null)
        {
            wait = StartCoroutine(Wait());
        }
        wait = null;
    }

    public IEnumerator Wait()
    {
        Robot.moveSpeed = 0f;
        yield return new WaitForSecondsRealtime(5);
        Robot.moveSpeed = robotSpeed;
        Destroy(this.gameObject);
    }
}
