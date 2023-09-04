using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeButton : MonoBehaviour
{
    public GameObject[] unit_prefab;

    private GameObject[] NextUnit;
    private GameObject currentUnit;
    private MersenneAlgorithm.RandomMersenne Mer;
    // Start is called before the first frame update
    void Start()
    {
        Object[] loadedPrefabs = Resources.LoadAll("SPUM/SPUM_Units", typeof(GameObject));
        unit_prefab = new GameObject[loadedPrefabs.Length];
        for (int i = 0; i < loadedPrefabs.Length; i++)
        {
            unit_prefab[i] = (GameObject)loadedPrefabs[i];
        }
        /*int seed = (int)System.DateTime.Now.Ticks;
        Mer = new MersenneAlgorithm.RandomMersenne((uint)seed);
        int randomNum = Mer.IRandom(0, 100);
        Debug.Log("RanNum = " + randomNum);*/
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePosition2D = new Vector2(mousePosition.x, mousePosition.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePosition2D, Vector2.zero);

            if (hit.collider != null && hit.collider.gameObject.tag == "Player")
            {
               currentUnit = hit.collider.gameObject;
            }
        }
    }
    public void OnClickChange()
    {
        if (currentUnit == null)
            return;
        int Rating = currentUnit.GetComponent<UnitAction>().Key;
        switch (Rating) {
            case 1:
                Changes(50, 2);
                break;
            case 2:
                Changes(10, 3);
                break;
            case 3:
                Changes(1, 4);
                break;
            case 4:
                Changes(1, 0);
                break;
        }



        

    }

    private void Changes(int value, int nextKey)
    {
        NextUnit = new GameObject[3];
        int num = 0;

        int seed = (int)System.DateTime.Now.Ticks;
        Mer = new MersenneAlgorithm.RandomMersenne((uint)seed);
        int randomNum = Mer.IRandom(0, 101);
        if (randomNum < value)
        {
            foreach (var target in unit_prefab)
            {
                if (target.GetComponent<UnitAction>().Key == nextKey)
                {
                    NextUnit[num] = target;
                    num++;
                }
            }
            int ran = Random.Range(0, 3);
            Vector2 vec = new Vector2(currentUnit.transform.position.x, currentUnit.transform.position.y);
            Destroy(currentUnit);
            currentUnit = (GameObject)Instantiate(NextUnit[ran], vec, Quaternion.identity);
            currentUnit.transform.SetParent(null);
        }
        else
        {
            Destroy(currentUnit);
        }
    }
}
