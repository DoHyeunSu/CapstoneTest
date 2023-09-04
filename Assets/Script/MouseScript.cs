using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MouseScript : MonoBehaviour
{
    private bool isDragging = false;
    private Collider2D currentCollider;
    public PanelMove Pm;
    // Start is called before the first frame update
    void Start()
    {
        Pm = GameObject.Find("Panel").GetComponent<PanelMove>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Pm.Getismove())
        {
            if (Input.GetMouseButtonDown(0))
            {
                // 마우스 왼쪽 버튼을 눌렀을 때
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
                if (hit.collider == null)
                    return;
                if (hit.collider.tag == "Wall")
                {
                    // 클릭한 위치에 콜라이더가 있는 경우
                    currentCollider = hit.collider;
                    isDragging = true;
                    currentCollider.gameObject.transform.SetParent(null);
                }
            }
            else if (Input.GetMouseButtonUp(0))
            {
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 vec = new Vector2((int)Math.Round(mousePosition.x, 0), (int)Math.Round(mousePosition.y, 0));
                //Vector2 vec = new Vector2((int)mousePosition.x, (int)mousePosition.y);
                if (currentCollider != null)
                    currentCollider.transform.position = vec;
                // 마우스 왼쪽 버튼을 놓았을 때
                isDragging = false;
                currentCollider = null;

            }

            if (isDragging && currentCollider != null)
            {
                // 콜라이더를 드래그 중인 경우
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePosition.z = 0f;
                currentCollider.transform.position = mousePosition;
            }
        }
    }

}
