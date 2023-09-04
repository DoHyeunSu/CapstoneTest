using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitPanel : MonoBehaviour
{
    public GameObject[] unit_prefab;
    public GameObject[] unit;
    public string CodeName;

    private Vector2 vec1, vec2;
    private bool ismove;
    private float movespeed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        unit = new GameObject[20];
        InitUnit();

        vec1 = this.transform.position;
        vec2 = new Vector2(this.transform.position.x, this.transform.position.y + 5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (ismove)
            transform.position = Vector2.MoveTowards(transform.position, vec2, movespeed * Time.deltaTime);
        else
            transform.position = Vector2.MoveTowards(transform.position, vec1, movespeed * Time.deltaTime);
    }
    private void InitUnit()
    {
        Object[] loadedPrefabs = Resources.LoadAll("SPUM/SPUM_Units", typeof(GameObject));
        unit_prefab = new GameObject[loadedPrefabs.Length];
        for(int i = 0; i < loadedPrefabs.Length; i++)
        {
            unit_prefab[i] = (GameObject)loadedPrefabs[i];
        }
        /*for (int i = 0; i < unit_prefab.Length; i++)
        {
            unit[i] = (GameObject)Instantiate(unit_prefab[i], new Vector3(this.transform.position.x + i - 7.5f, this.transform.position.y - 0.5f, 100f), Quaternion.identity);
            unit[i].transform.SetParent(this.transform);
        }*/
    }
    public void OnClickUnitPanel()
    {
        ismove = !ismove;
    }
    public bool GetismoveUnit()
    {
        return ismove;
    }
    public void SetUnit(int num, string name)
    {
        foreach(var target in unit_prefab)
        {
            if (target.gameObject.GetComponent<UnitInformation>().GetName() == name)
            {
                unit[num] = (GameObject)Instantiate(target, new Vector3(this.transform.position.x + num - 7.5f, this.transform.position.y - 0.5f, 100f), Quaternion.identity);
                unit[num].transform.SetParent(this.transform);
            }
        }
        

    }
}
