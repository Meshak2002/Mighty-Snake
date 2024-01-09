using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class ad : MonoBehaviour
{
    // Start is called before the first frame update
    private InterstitialAd interstitial_Ad;
    private RewardedAd rewardedAd;

    private string interstitial_Ad_ID;

    void Start()
    {
        interstitial_Ad_ID = "ca-app-pub-3940256099942544/1033173712";

        MobileAds.Initialize(initStatus => { });

        RequestInterstitial();

    }

    private void RequestInterstitial()
    {
        interstitial_Ad = new InterstitialAd(interstitial_Ad_ID);
        interstitial_Ad.OnAdLoaded += HandleOnAdLoaded;
        AdRequest request = new AdRequest.Builder().Build();
        interstitial_Ad.LoadAd(request);
    }

    public void ShowInterstitial()
    {
        if (interstitial_Ad.IsLoaded())
        {
            interstitial_Ad.Show();
            RequestInterstitial();
        }

    }
    public void HandleOnAdLoaded(object sender, EventArgs args)
    {

    }
}