using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Transform movePoint;
    Transform cur;

    public LayerMask whatStopsMovement;
    public LayerMask pickupLayer;

    public Animator anim;

    public int seed;
    public GameObject root;

    // Start is called before the first frame update
    void Start()
    {
        movePoint.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

        if (seed > 0 && Input.GetKeyDown("l"))
        {
            Spawn();
            seed -= 1;
        }

        if (Vector3.Distance(transform.position, movePoint.position) <= 0.05f)
        {
            Debug.Log("1");
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
            {
                Debug.Log("2");
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), 0.2f, whatStopsMovement))
                {
                    Debug.Log("3");
                    movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                }
            } else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f) 
            {
                Debug.Log("4");
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f), 0.2f, whatStopsMovement))
                {
                    Debug.Log("5");
                    movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
                }
            }

            anim.SetBool("moving", false);
        }
        else
        {
            anim.SetBool("moving", true);
        }
    }

    void Spawn()
    {
        Instantiate(root, movePoint.position, Quaternion.identity);
    }
}
