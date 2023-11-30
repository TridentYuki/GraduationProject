using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Text;

public class RenkNums : MonoBehaviour
{
    private const int NUMS = 8;

    //  ランキングを表示するてきすと
    [SerializeField] Text[] rankingTexts = new Text[NUMS];

    //  ファイル名
    private string csvName = @"/ranking.csv";
    //  data入れる
    private List<string> csvData = new List<string>();


    // Start is called before the first frame update
    void Start()
    {
        Load();
        int index = 0;
        foreach (string rank in csvData)
        {
            int minute = int.Parse(rank) / 60;
            int second = int.Parse(rank) % 60;

            rankingTexts[index].text = minute.ToString("00") + ":" + ((int)second).ToString("00");
            index++;
        }

        for (int i = index; i < NUMS; i++)
        {
            rankingTexts[i].text = "0";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Load()
    {
        //  CSVをパス指定して取ってくる
        StreamReader sr = new StreamReader(Application.persistentDataPath + csvName
            , Encoding.GetEncoding("utf-8"));

        // 末尾まで繰り返す
        while (!sr.EndOfStream)
        {
            // CSVファイルの一行を読み込む
            string line = sr.ReadLine();
            // 読み込んだ一行をカンマ毎に分けて配列に格納する
            string[] values = line.Split(',');

            // 配列からリストに格納する
            csvData.AddRange(values);
        }

        sr.Close();
    }

}
