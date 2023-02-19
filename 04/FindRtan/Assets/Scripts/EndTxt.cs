using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTxt : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReStart()
    {
        // 광고를 붙이면서 메인씬을 리로드하는 것을 게임매니저에게 위임
        SceneManager.LoadScene("MainScene");

        //AdsManager.I.ShowRewardAd();
    }
}
