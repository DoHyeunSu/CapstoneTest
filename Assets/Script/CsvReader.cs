using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CsvReader : MonoBehaviour
{
    public TextAsset csvFile;

    string csvText;
    string[] lines;
    string[] header;
    List<Dictionary<int, Data_Units>> stats = new List<Dictionary<int, Data_Units>>();//여기에 모든 Unit들의 데이터 저장
    // Start is called before the first frame update
    void Start()
    {
        csvText = csvFile.text;

        lines = csvText.Split('\n');

        header = lines[0].Split(',');

        for (int i = 1; i < lines.Length; i++)
        {
            string[] values = lines[i].Split(',');
            if (values.Length == 0 || values[0] == "") continue;
            Dictionary<int, Data_Units> dictionary = new Dictionary<int, Data_Units>();
            Data_Units unit = new Data_Units();

            for (int j = 0; j < values.Length; j++)
            {
                string value = values[j].Trim();
                if (j == 0)
                {
                    int key;
                    if (int.TryParse(value, out key))
                        unit.Key = key;
                }
                else if (j == 1)
                    unit.Name = value;
                else if (j == 2)
                {
                    int attack;
                    if (int.TryParse(value, out attack))
                        unit.Attack = attack;
                }
                else if (j == 3)
                {
                    int attackspeed;
                    if (int.TryParse(value, out attackspeed))
                        unit.AttackSpeed = attackspeed;
                }
                else if (j == 4)
                {
                    int maxhp;
                    if (int.TryParse(value, out maxhp))
                        unit.MaxHp = maxhp;
                }
                else if (j == 5)
                {
                    int hp;
                    if (int.TryParse(value, out hp))
                        unit.Hp = hp;
                }
                else if (j == 6)
                {
                    unit.Rating = value;
                }
            }
            dictionary[unit.Key] = unit;
            //Debug.Log(dictionary[unit.Key].Name);
            stats.Add(dictionary);
        }
    }
    public Data_Units GetData(int key)
    {
        foreach (var dic in stats)
        {
            if (dic.ContainsKey(key))
            {
                return dic[key];
            }
        }
        return null;
    }
}
