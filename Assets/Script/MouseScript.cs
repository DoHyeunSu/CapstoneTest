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
                // ���콺 ���� ��ư�� ������ ��
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
                if (hit.collider == null)
                    return;
                if (hit.collider.tag == "Wall")
                {
                    // Ŭ���� ��ġ�� �ݶ��̴��� �ִ� ���
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
                // ���콺 ���� ��ư�� ������ ��
                isDragging = false;
                currentCollider = null;

            }

            if (isDragging && currentCollider != null)
            {
                // �ݶ��̴��� �巡�� ���� ���
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePosition.z = 0f;
                currentCollider.transform.position = mousePosition;
            }
        }
    }

}
