using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class start : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] g;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void clk()
    {
        foreach(GameObject h in g)
        {
            h.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}
