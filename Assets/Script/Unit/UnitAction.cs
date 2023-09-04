using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitAction : MonoBehaviour
{
    public EnemyStat e_stat;
    public CsvReader csv;

    private SPUM_Prefabs _prefabs;
    private Animator _ani;
    private Collider2D Range;
    private Vector2 size;
    public int AtkValue;
    public string Rating;
    public int Key;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        _prefabs = this.gameObject.GetComponent<SPUM_Prefabs>();
        _ani = transform.GetChild(0).GetComponent<Animator>();
        Range = transform.GetChild(1).GetComponent<BoxCollider2D>();
        csv = GameObject.Find("GameManager").GetComponent<CsvReader>();
        AtkValue = csv.GetData(Key).Attack;
        Rating = csv.GetData(Key).Rating;
        size = new Vector2(4.5f, 4f);
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D[] other = Physics2D.OverlapBoxAll(Range.transform.position, size, 0f, LayerMask.GetMask("Enemy"));
        if (other.Length == 0 || other==null)
        {
            _ani.SetBool("atk", false);
        }
        else
        {
            foreach (Collider2D target in other)
            {
                e_stat = target.transform.GetComponent<EnemyStat>();
                _ani.SetBool("atk", true);
                AttackTest();
            }
        }
        
    }
    private void AttackTest()
    {
        timer += Time.deltaTime;
        if (timer >= 0.75f)
        {
            e_stat.DamageEnemy(AtkValue);
            timer = 0f;
        }
    }
}
