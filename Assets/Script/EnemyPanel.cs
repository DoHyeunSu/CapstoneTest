using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyPanel : MonoBehaviour
{
    int hp;
    private GameObject obj;
    public GameObject TextObject, ImageObject;
    // Start is called before the first frame update
    void Start()
    {
        obj = new GameObject();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 마우스 왼쪽 버튼 클릭 검출
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePosition2D = new Vector2(mousePosition.x, mousePosition.y);

            RaycastHit2D[] hits = Physics2D.RaycastAll(mousePosition2D, Vector2.zero);
            foreach (var hit in hits)
            {
                if (hit.collider != null && hit.collider.gameObject.tag == "Enemy")
                {
                    obj = hit.transform.gameObject;
                }
            }
        }
        try
        {
            if (obj.tag == "Enemy" /*&& obj != null*/)
                TextObject.GetComponent<Text>().text = "HP : " + obj.GetComponent<EnemyStat>().returnHP();

            if (obj == null || obj.GetComponent<EnemyStat>().returnHP() < 0)
            {
                gameObject.SetActive(false);
                Debug.Log("false");
            }
        }
        catch
        {
            TextObject.GetComponent<Text>().text = "오류 더블 클릭하시오";
        }
    }
}
