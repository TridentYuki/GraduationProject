using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Text;

public class RenkNums : MonoBehaviour
{
    private const int NUMS = 8;

    //  �����L���O��\������Ă�����
    [SerializeField] Text[] rankingTexts = new Text[NUMS];

    //  �t�@�C����
    private string csvName = @"/ranking.csv";
    //  data�����
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

}
