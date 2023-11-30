using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PurchaseManager : MonoBehaviour
{
    private int purchasedAdRemoval = 0; // 広告非表示を課金済みかどうかのフラグ
    public GameObject purchaseMenu; // 課金メニューのUIオブジェクトをアサイン

    private void Start()
    {
        //この部分でcsvから読み取る
        //広告表示クラスにも同じのあるよ
        purchasedAdRemoval = PlayerPrefs.GetInt("KakinData");
        //

        if (purchasedAdRemoval != 0)
        {
            this.gameObject.SetActive(false);
        }
        ClosePurchaseMenu();
    }

    public void OpenPurchaseMenu()
    {
        Time.timeScale = 0.0f;

        // 課金メニューを表示する
        purchaseMenu.SetActive(true);
    }

    public void ClosePurchaseMenu()
    {
        Time.timeScale = 1.0f;

        // 課金メニューを非表示にする
        purchaseMenu.SetActive(false);
    }

    public void PurchaseProduct()
    {
        // 課金処理を実行（例：広告非表示を購入）
        if (purchasedAdRemoval == 0)
        {


            purchasedAdRemoval = 1; // 広告非表示を課金済みとする
            SavePlayerData(); // プレイヤーデータを保存
            ClosePurchaseMenu(); // 課金メニューを閉じる
            this.gameObject.SetActive(false);


        }
        else
        {
            // 購入失敗時の処理
            ClosePurchaseMenu();
            this.gameObject.SetActive(false);
        }
    }


    private void SavePlayerData()
    {
        // プレイヤーデータを保存するロジックを実装する
        // 例：PlayerPrefsやファイルセーブなどを使用してデータを永続化する

        //この部分でcsvに書き込む
        PlayerPrefs.SetInt("KakinData", purchasedAdRemoval);

    }


    public void ReSetKakinn()
    {
        purchasedAdRemoval = 0;
        SavePlayerData();
        this.gameObject.SetActive(true);
    }
}
