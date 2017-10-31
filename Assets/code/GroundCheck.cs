using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour {

    public Player player;


    void Start()
    {
        player = gameObject.GetComponentInParent<Player>();
        Debug.Log("start");
    }
    void OnTriggerEnter2D(Collider2D colz)
    {
        player.grounded = true;
        Debug.Log("true-enter2D");
    }

    void OnTriggerStay2D(Collider2D col)
    {
        player.grounded = true;
        Debug.Log("true-stay2D");
    }
   
    void OnTriggerExit2D(Collider2D col)
    {
        player.grounded = false;
        Debug.Log("false-exit2D");
    }
}
