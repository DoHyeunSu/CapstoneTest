using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelMove : MonoBehaviour
{
    public GameObject Tile;
    public GameObject[] tiles;
    private float movespeed = 5f;
    private bool ismove = false;
    private Vector2 vec1, vec2;
    // Start is called before the first frame update
    void Start()
    {
        vec1 = this.transform.position;
        vec2 = new Vector2(this.transform.position.x, this.transform.position.y + 2f);
        tiles=new GameObject[20];
        for(int i = 0; i < 15; i++)
        {
            tiles[i] = (GameObject)Instantiate(Tile, new Vector3(this.transform.position.x + i - 7, this.transform.position.y, 100f), Quaternion.identity);
            tiles[i].transform.SetParent(this.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (ismove)
        {
            transform.position = Vector2.MoveTowards(transform.position, vec2, movespeed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, vec1, movespeed * Time.deltaTime);
        }
    }
    public void OnClick()
    {
        ismove = !ismove;
    }
    public bool Getismove()
    {
        return ismove;
    }
}
