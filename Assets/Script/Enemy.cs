using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public A_StarNode gm;
    private int aa;
    private int[] GOx, GOy;
    int x = 1, y = 1;
    float speed = 2f;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<A_StarNode>();
        aa = gm.FinalNodeList.Count;
        GOx = new int[aa];
        GOy = new int[aa];
        for (int i = 0; i < aa; i++)
        {
            GOx[i] = gm.FinalNodeList[i].x;
            GOy[i] = gm.FinalNodeList[i].y;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Distance(x, y))
        {
            x++;
            y++;
        }
        else
        {
            this.transform.position = Vector2.MoveTowards(this.transform.position, new Vector2(GOx[x], GOy[y]), Time.deltaTime * speed);
        }

        if (this.transform.position.x == 6 && this.transform.position.y == 4)
        {
            Destroy(gameObject);
        }
    }
    bool Distance(int x, int y)
    {
        if (this.transform.position.x == GOx[x] && this.transform.position.y == GOy[y])
            return true;
        else
            return false;

    }
}
