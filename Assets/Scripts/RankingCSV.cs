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

    //  �t�@�C����
    private string csvName = @"/ranking.csv";
    //  data�����
    private List<string> csvData = new List<string>();

    //  �^�C�}�[�̃X�N���v�g
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

        //  �t�@�C�����A�㏑(false)�E�ǋL(true)�A�����R�[�h
        sw = new StreamWriter(Application.persistentDataPath + csvName, false,
            Encoding.GetEncoding("utf-8"));


        //  ��������^�ɕϊ����ĕۑ�
        for (int i = 0; i < nums.Length; i++)
        {
            sw.WriteLine(nums[i]);
        }

        //  �I����ĕ���
        sw.Flush();
        sw.Close();
    }

    private void Load()
    {
        //  CSV���p�X�w�肵�Ď���Ă���
        StreamReader sr = new StreamReader(Application.persistentDataPath + csvName
            , Encoding.GetEncoding("utf-8"));

        // �����܂ŌJ��Ԃ�
        while (!sr.EndOfStream)
        {
            // CSV�t�@�C���̈�s��ǂݍ���
            string line = sr.ReadLine();
            // �ǂݍ��񂾈�s���J���}���ɕ����Ĕz��Ɋi�[����
            string[] values = line.Split(',');

            // �z�񂩂烊�X�g�Ɋi�[����
            csvData.AddRange(values);
        }

        sr.Close();
    }

    private void RankingSave(int score)
    {
        int index = 0;

        //  �X�R�A��}��
        foreach(string rank in csvData)
        {
            int rankToFloat = int.Parse(rank);

            //  �X�R�A��������������index�𑝂₵�Ď���
            if (score < rankToFloat)
            {
                index++;
                continue;
            }
            //  �傫��������}��
            else
            {
                csvData.Insert(index, score.ToString());
                break;
            }
        }

        //  �͂ݏo������������
        csvData.RemoveRange(NUMS, csvData.Count - NUMS);

        index = 0;

        int[] rankNumbers = new int[NUMS];

        //  �ϊ����Ă����
        foreach(string rank in csvData)
        {
            rankNumbers[index] = int.Parse(rank);
            index++;
        }

        // CSV�ɏ�������
        Save(rankNumbers);
    }
}
