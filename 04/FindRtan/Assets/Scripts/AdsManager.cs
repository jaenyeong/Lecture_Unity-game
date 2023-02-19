using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour
{
    public static AdsManager I;

    string adType;
    string gameId;

    private const string iOSId = "5171288";
    private const string AndroidId = "5171289";

    void Awake()
    {
        bool isIPhone = Application.platform == RuntimePlatform.IPhonePlayer;

        adType = isIPhone ? "Rewarded_iOS" : "Rewarded_Android";
        gameId = isIPhone ? iOSId : AndroidId;

        //Advertisement.Initialize(gameId, true);
    }

    public void ShowRewardAd()
    {
        // 4.3 이상 버전에서는 IsReady() 함수가 없어져 사용할 수 없음
        //if (Advertisement.IsReady())
        //{
        //    ShowOptions options = new ShowOptions { resultCallback = ResultAds };
        //    Advertisement.Show(adType, options);
        //}

        //Advertisement.Show(adType);
    }

    //void ResultAds(ShowResult result)
    //{
    //    switch (result)
    //    {
    //        case ShowResult.Failed:
    //            Debug.LogError("광고 보기에 실패했습니다.");
    //            break;
    //        case ShowResult.Skipped:
    //            Debug.Log("광고를 스킵했습니다.");
    //            break;
    //        case ShowResult.Finished:
    //            // 광고 보기 보상 기능 
    //            GameManager.I.ReGame();
    //            break;
    //    }
    //}
}
