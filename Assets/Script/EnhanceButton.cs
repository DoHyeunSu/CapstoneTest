using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnhanceButton : MonoBehaviour
{
    private GameObject clickedObject;
    private int atk_V;
    private int currentLevel = 0;
    private float[] successRates = { 0.8f, 0.6f, 0.4f };

    Text atkText;
    Text rankText;
    // Start is called before the first frame update
    void Start()
    {
        atkText = GameObject.Find("AtkText").GetComponent<Text>();
        rankText = GameObject.Find("RankText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // ���콺 ���� ��ư Ŭ�� ����
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePosition2D = new Vector2(mousePosition.x, mousePosition.y);

            RaycastHit2D[] hits = Physics2D.RaycastAll(mousePosition2D, Vector2.zero);
            foreach(var hit in hits)
            {
                if (hit.collider != null && hit.collider.gameObject.tag == "Player")
                {
                    clickedObject = hit.collider.gameObject;
                    Debug.Log(clickedObject);
                }
            }
            /*RaycastHit2D hit = Physics2D.Raycast(mousePosition2D, Vector2.zero);
            if (hit.collider != null && hit.collider.gameObject.tag=="Player")
            {
                clickedObject = hit.collider.gameObject;
                Debug.Log(clickedObject);
            }*/
        }
        TextDisplay();

    }
    public void EnhanceClick()
    {
        if (clickedObject == null)
            return;
        atk_V = clickedObject.GetComponent<UnitAction>().AtkValue;
        if (currentLevel < successRates.Length)
        {
            float randomValue = Random.value;
            if (randomValue < successRates[currentLevel])
            {
                atk_V += 5;
                currentLevel++;
                clickedObject.GetComponent<UnitAction>().AtkValue = atk_V;
            }
            else
            {
                Debug.Log("��ȭ����");
            }
        }
        else
        {
            Debug.Log("�ִ� ����");
        }
    }

    public void TextDisplay()
    {
        if (clickedObject == null)
            return;
        string atk = "���ݷ� : " + clickedObject.GetComponent<UnitAction>().AtkValue;
        string rank = "��ũ : " + clickedObject.GetComponent<UnitAction>().Rating;
        atkText.text = atk;
        rankText.text = rank;
    }
}
