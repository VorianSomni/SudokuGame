using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using TMPro;

public class AdsManager : MonoBehaviour
{
    [SerializeField] string _androidGameId;
    [SerializeField] string _iOSGameId;
    //[SerializeField] bool _testMode = true;
    [SerializeField] public bool ShouldCallAds = true;
    private string _gameId;
    
    public void StartThisScript()
    {
        Debug.Log("After awake");
    }

    public void LoadAds()
    {
        return;
    }

    
    public void ShowRestartAd()
    {
        return;
    }

    public void ShowHelpAds()
    {
        return;
    }

    public void ShowWinAd()
    {
        return;
    }


    IEnumerator TurnAdHelpButtonOn()
    {
        yield return null;
    }
    

    public void TestInternetConnection()
    {
        StartCoroutine(TestInternet());
    }

    IEnumerator TestInternet()
    {
        UnityWebRequest request = new UnityWebRequest("https://duckduckgo.com");
        yield return request.SendWebRequest();

        if (request.error != null)
        {
            yield return null;
        }
        else
        {
            yield return null;
        }
    }


    public IEnumerator IbuyedNoAdsSoTurnAdHelpButtonOff()
    {
        yield return null;
    }

}
