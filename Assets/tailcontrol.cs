using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tailcontrol : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform tail;
    public float circlediam, dist;
    public List<Transform> tails;
    public List<Vector2> pos;
    void Start()
    {
        pos.Add(tail.position);
    }

    // Update is called once per frame
    void Update()
    {
        dist = ((Vector2)tail.position - pos[0]).magnitude;
        if (dist > circlediam)
        {
            Vector2 dir = ((Vector2)tail.position - pos[0]).normalized;
            pos.Insert(0, pos[0] + dir * circlediam);
            pos.RemoveAt(pos.Count - 1);
            dist -= circlediam;
        }
        for (int i = 0; i < tails.Count; i++)
        {
            tails[i].position = Vector2.Lerp(pos[i + 1], pos[i], dist / circlediam);
        }

    }
    public void addTail()
    {
        Transform ntail = Instantiate(tail, pos[pos.Count - 1], Quaternion.identity, transform);
        tails.Add(ntail);
        pos.Add(ntail.position);
    }
    public void triged()
    {
        for (int i = 0; i <= this.transform.childCount-1; i++)
        {
            this.transform.GetChild(i).GetComponent<SpriteRenderer>().enabled = false;
            this.GetComponent<CircleCollider2D>().enabled = false;
            this.GetComponent<enemy_MOVement>().enabled = false;
        }
        StartCoroutine(wait());
    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(30);
        for (int i = 0; i <= this.transform.childCount-1; i++)
        {
            this.transform.GetChild(i).GetComponent<SpriteRenderer>().enabled = true;
            this.GetComponent<CircleCollider2D>().enabled = true;
            this.GetComponent<enemy_MOVement>().enabled = true;
        }
    }
}
