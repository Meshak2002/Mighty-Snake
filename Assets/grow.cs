using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class grow : MonoBehaviour
{
    // Start is called before the first frame update
    public tailcontrol t;
    public move m;
    public Text score, sc, hi;
    public GameObject over, con;
    private int n, h;
    public ad add;
    public bool enemy;
    private void Start()
    {
        if (enemy == false)
        {
            con.GetComponent<AudioSource>().Play(1);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Food"))
        {
            if (enemy == false)
            {
                this.gameObject.GetComponent<AudioSource>().time = 0.05f;
                this.gameObject.GetComponent<AudioSource>().Play(1);
            }
            if (m != null)
            {
                m.speed += 0.2f;
            }
            collision.gameObject.GetComponent<diamond>().triged();
            if (enemy == false)
            {
                t.addTail();
            }
            if (enemy == true)
            {
                if (this.transform.childCount < 14f)
                {
                    t.addTail();
                }
            }
        }
        if (collision.CompareTag("Enemy"))
        {
            if (this.transform.childCount > collision.transform.childCount)
            {
                collision.gameObject.GetComponent<AudioSource>().time=0.13f;
                collision.gameObject.GetComponent<AudioSource>().Play(1);
                collision.gameObject.GetComponent<tailcontrol>().triged();
            }
            else
            {
                con.GetComponent<AudioSource>().Stop();
                over.SetActive(true);
                con.SetActive(false);
                m.enabled = false;
                add.ShowInterstitial();
            }
        }
        
            if (collision.CompareTag("Obstacles"))
            {
                if (enemy == false)
                {
                    collision.gameObject.GetComponent<AudioSource>().time = 0.12f;
                    collision.gameObject.GetComponent<AudioSource>().Play(1);
                }
                con.GetComponent<AudioSource>().Stop();
                over.SetActive(true);
                con.SetActive(false);
                m.enabled = false;
                add.ShowInterstitial();
            }
            if (collision.CompareTag("Colorc"))
            {
                if (enemy == false)
                {
                    for (int i = 2; i <= this.gameObject.transform.childCount - 1; i++)
                    {
                        this.gameObject.transform.GetChild(i).GetComponent<SpriteRenderer>().color = collision.gameObject.GetComponent<SpriteRenderer>().color;
                    }

                    collision.gameObject.GetComponent<AudioSource>().time = 0.14f;
                    collision.gameObject.GetComponent<AudioSource>().Play(1);

                    collision.gameObject.GetComponent<capsule>().triged();
                }
            }
        
        }
        public void Update()
        {
        if (enemy == false)
        {
            n = this.transform.childCount - 3;
            score.text = n.ToString();
            sc.text = n.ToString();
            h = PlayerPrefs.GetInt("Hiscore");
            if (n > h)
            {
                h = n;
                PlayerPrefs.SetInt("Hiscore", n);
            }
            hi.text = h.ToString();
        }
        }
        public void onclk()
        {
            SceneManager.LoadScene(0);
        }
    }
