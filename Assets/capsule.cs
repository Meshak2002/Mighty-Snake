using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class capsule : MonoBehaviour
{
    public void triged()
    {
        this.GetComponent<SpriteRenderer>().enabled = false;
        this.GetComponent<CapsuleCollider2D>().enabled = false;
        StartCoroutine(wait());
    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(30);
        this.GetComponent<SpriteRenderer>().enabled = true;
        this.GetComponent<CapsuleCollider2D>().enabled = true;
    }
}
