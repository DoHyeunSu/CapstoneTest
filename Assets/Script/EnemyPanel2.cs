using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPanel2 : MonoBehaviour
{
    public GameObject gam;
    // Start is called before the first frame update
    void Start()
    {
        
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
                    gam.SetActive(true);
                }
            }
        }
    }
}
