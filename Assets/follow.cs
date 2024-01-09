using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public float speed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(player.transform.position.x,player.transform.position.y,-10), speed*Time.deltaTime);
     
        
    }
}
