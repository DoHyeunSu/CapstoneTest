using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundText : MonoBehaviour
{
    // Start is called before the first frame update
    private string roundText;
    private Text text;
    private int num;
    private RectTransform textTransform;
    private bool ismove;
    private Vector2 trs;
    private float times = 0f;

    public float moveSpeed = 2f;
    void Start()
    {
        text = this.transform.gameObject.GetComponent<Text>();
        num = 0;//GameObject.Find("StartPos").GetComponent<SpawnEnemy>().roundNum;
        roundText = "Round " + num.ToString();
        textTransform = GetComponent<RectTransform>();
        trs = new Vector2(transform.position.x, transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        text.text = roundText;
        if (ismove)
        {
            times += Time.deltaTime;
            if(times>2 && times < 3)
            {
                textTransform.position = Vector2.zero;
            }
            Vector3 newPosition = textTransform.position + Vector3.right * moveSpeed * Time.deltaTime;
            textTransform.position = newPosition;
            if (times > 5)
            {
                times = 0f;
                ismove = !ismove;
            }
        }
        else
            textTransform.position = trs;
        
    }
    public void RightText() 
    {
        num++;
        roundText = "Round " + num.ToString();
        ismove = !ismove;
    }

}
