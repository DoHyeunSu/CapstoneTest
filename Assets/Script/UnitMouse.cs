using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMouse : MonoBehaviour
{
    private bool isDragging = false;
    private Collider2D currentCollider;
    public UnitPanel Pm;
    // Start is called before the first frame update
    void Start()
    {
        Pm = GameObject.Find("UnitPanel").GetComponent<UnitPanel>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Pm.GetismoveUnit())
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D[] hits = Physics2D.RaycastAll(mousePosition, Vector2.zero);
                foreach(RaycastHit2D hit in hits)
                {
                    if (hit.collider == null)
                        return;
                    if (hit.collider.tag == "Player")
                    {
                        currentCollider = hit.collider;
                        isDragging = true;
                        currentCollider.gameObject.transform.SetParent(null);
                    }
                }
                //���콺 ���� ��ư Ŭ����
                /*Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
                if (hit.collider == null)
                    return;
                if (hit.collider.tag == "Player")
                {
                    currentCollider = hit.collider;
                    isDragging = true;
                    currentCollider.gameObject.transform.SetParent(null);
                }*/
            }
            else if (Input.GetMouseButtonUp(0))
            {
                // ���콺 ���� ��ư�� ������ ��
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 vec = new Vector2(mousePosition.x, mousePosition.y);
                if (currentCollider != null)
                    currentCollider.transform.position = vec;
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
