using UnityEngine;
using UnityEngine.Advertisements;
using GoogleMobileAds.Api;
using System.Net.Http.Headers;

public class AdsInitializer : MonoBehaviour
{
    [SerializeField] RewardedAdsButton rewardedAdsButton;
    

    public void InitializeAds()
    {
        MobileAds.Initialize((InitializationStatus initStatus) =>
        {
            // This callback is called once the MobileAds SDK is initialized.
            print("GoogleAds foi Inicializado");
            
            GetComponent<BannerAdExample>().CreateBannerView();
            GetComponent<RewardedAdsButton>().LoadRewardedAd();
            
        });
        
    }
    
}