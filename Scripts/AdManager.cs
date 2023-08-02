using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class AdManager : MonoBehaviour
{
    private BannerView bannerView;
    private InterstitialAd interstitial;
    private PlayerController playerControllerScript;
    private bool adShown = false;
    void Start()
    {
        MobileAds.Initialize(initstatus => {});
        this.RequestInterstitialAd();
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Update() 
    {
        if(playerControllerScript.gameOverAD == true)
        {
            if(adShown == false)
            {
                if(this.interstitial.IsLoaded())
                {
                    this.interstitial.Show();
                    adShown = true;
                }
            }
        }    
    }
    void RequestInterstitialAd()
    {
        string reklamID = "ca-app-pub-4512564738654491/9336634312";

        this.interstitial = new InterstitialAd(reklamID);

        AdRequest request = new AdRequest.Builder().Build();
        this.interstitial .LoadAd(request);
    }
}
