using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FertControl : MonoBehaviour
{
    public PlayerController Player;

    void OnTriggerEnter2D(Collider2D collision)
    {
        //Player.seed += 1;
        Destroy(this.gameObject);
    }
}
