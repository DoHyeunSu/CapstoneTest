using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckFinish : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.gameObject.GetComponent<EnemyStat>().EnemyKey == 103)
        {
            Debug.Log("마지막 몬스터 닿음 : " + GameObject.Find("Canvas").GetComponent<EndText>().Finish);
            GameObject.Find("Canvas").GetComponent<EndText>().Finish = false;
        }
    }
}
