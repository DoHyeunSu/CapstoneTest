using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitInformation : MonoBehaviour
{
    public string name;
    public float rarityWeight;
    public int EnhanceCoin = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public string GetName()
    {
        return name;
    }
    public float GetRarityWeight()
    {
        return rarityWeight;
    }
}
