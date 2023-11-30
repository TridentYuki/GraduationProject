using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using System.Text;

public class RankingCSV : MonoBehaviour
{
    private const int NUMS = 8;

    //  ファイル名
    private string csvName = @"/ranking.csv";
    //  data入れる
    private List<string> csvData = new List<string>();

    //  タイマーのスクリプト
    [SerializeField] Timer timerScript;

    // Start is called before the first frame update
    void Start()
    {
        if (File.Exists(Application.persistentDataPath + csvName) == false)
        {
            int[] nums = new int[NUMS];

            Array.Fill(nums, 0);

            Save(nums);
        }
        Load();
    }

    // Update is called once per frame
    void Update()
    {     
    }

    public void SaveRanking()
    {
        GlobalValue.time = (int)timerScript.second + timerScript.minute * 60;

        RankingSave(GlobalValue.time);
    }

    private void Save(int[] nums)
    {
        StreamWriter sw;

        //  ファイル名、上書(false)・追記(true)、文字コード
        sw = new StreamWriter(Application.persistentDataPath + csvName, false,
            Encoding.GetEncoding("utf-8"));


        //  一個ずつ文字型に変換して保存
        for (int i = 0; i < nums.Length; i++)
        {
            sw.WriteLine(nums[i]);
        }

        //  終わって閉じる
        sw.Flush();
        sw.Close();
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

    private void RankingSave(int score)
    {
        int index = 0;

        //  スコアを挿入
        foreach(string rank in csvData)
        {
            int rankToFloat = int.Parse(rank);

            //  スコアが小さかったらindexを増やして次へ
            if (score < rankToFloat)
            {
                index++;
                continue;
            }
            //  大きかったら挿入
            else
            {
                csvData.Insert(index, score.ToString());
                break;
            }
        }

        //  はみ出た部分を消す
        csvData.RemoveRange(NUMS, csvData.Count - NUMS);

        index = 0;

        int[] rankNumbers = new int[NUMS];

        //  変換していれる
        foreach(string rank in csvData)
        {
            rankNumbers[index] = int.Parse(rank);
            index++;
        }

        // CSVに書き込む
        Save(rankNumbers);
    }
}
