using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class LightScript : MonoBehaviour
{
    // Start is called before the first frame update
    public SpriteRenderer sr;
    public Sprite r1;
    public Sprite r2;
    public Sprite r3;
    public Sprite r4;
    public Sprite r5;
    public Sprite g;
    public float count;
    int loade = 0;
    int spritecount = 0;
    bool fadeout=true;
    void Start()
    {
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (loade==0)
        {
            load();
        }
        else
        {
            r();
        }
    }

    void load()
    {
        count = Mathf.Lerp(count, 10, Time.deltaTime);
        if (count > 8)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
            loade = 1;
            count = 0;
        }
    }
    
    void r()
    {
        count = Mathf.Lerp(count, 15, Time.deltaTime);
        if (count > 8)
        {
            if (spritecount==0)
            {
                sr.sprite = r1;
                count = 0;
                spritecount++;
                return;
            }
            if (spritecount==1)
            {
                sr.sprite = r2;
                count = 0;
                spritecount++;
                return;
            }
            if (spritecount == 2)
            {
                sr.sprite = r3;
                count = 0;
                spritecount++;
                return;
            }
            if (spritecount == 3)
            {
                sr.sprite = r4;
                count = 0;
                spritecount++;
                return;
            }
            if (spritecount == 4)
            {
                sr.sprite = r5;
                count = 0;
                spritecount++;
                return;
            }
            if (spritecount == 5)
            {
                sr.sprite = g;
                count = 0;
                spritecount++;
                return;
            }
            if (fadeout)
            {

                if (spritecount == 6)
                {
                    Color colour = this.GetComponent<Renderer>().material.color;
                    float fade = colour.a - (3 * Time.deltaTime);
                    colour = new Color(colour.r, colour.g, colour.b, fade);
                    this.GetComponent<Renderer>().material.color = colour;
                    if (colour.a <= 0)
                    {
                        fadeout = false;
                    }
                }
            }

        }
    }
}
