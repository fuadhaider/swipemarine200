using System;
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class AdMobManager : MonoBehaviour
{
    private BannerView bannerView;
    private InterstitialAd interstitial;
    // int score;
    bool show;

    public void Start()
    {
      Debug.Log("AdMobManager ________");
        #if UNITY_ANDROID
            string appId = "ca-app-pub-2153044413134440~9766631422";
        #elif UNITY_IPHONE
            string appId = "ca-app-pub-2153044413134440~8143107307";
        #else
            string appId = "unexpected_platform";
        #endif

        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(appId);
        Debug.Log("ad object started ________");

        this.RequestBanner();
        // this.RequestInterstitial();
    }

    void Update()
    {
      // score = PlayerPrefs.GetInt ("Score");
      // Debug.Log("Score ________" + score);
      // if ((score != 0) && (score % 3) == 0) {
      //   this.RequestInterstitial();
      // }

      // if (shown == false)
      // {
      //   ShowInterstitial();
      //   Debug.Log ("inter Not yet ________");
      // }
      //
      //  void ShowInterstitial()
      // {
      // if (this.interstitial.IsLoaded())
      // {
      //   this.interstitial.Show();
      //   Debug.Log("inter ad show ________");
      //   shown = true;
      // }
      // else
      // {
      //   Debug.Log ("Interstitial is not ready yet ________");
      // }

      // if (this.interstitial.IsLoaded()) {
      //   this.interstitial.Show();
      // }

      if (show == false) {
        if (this.interstitial.IsLoaded()) {
          this.interstitial.Show();
          show = true;
          Debug.Log("inter ad show ________");
        }
      }
      // else
      // {
      //     Debug.Log("inter ad not show ________");
      // }
    }

    private void RequestBanner()
    {
        #if UNITY_ANDROID
            string adUnitId = "ca-app-pub-3940256099942544/6300978111"; //test
        #elif UNITY_IPHONE
            string adUnitId = "ca-app-pub-2153044413134440~8143107307";
        #else
            string adUnitId = "unexpected_platform";
        #endif

        // Clean up banner ad before creating a new one.
        if (this.bannerView != null)
        {
            this.bannerView.Destroy();
            Debug.Log("Banner ad destroied ________");
        }

        // Create a 320x50 banner at the top of the screen.
        this.bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Top);
        // Create an empty ad request.
        // AdRequest request = new AdRequest.Builder().Build();
        // test
        AdRequest requestBanner = new AdRequest.Builder()
          .AddTestDevice("65C2444A09CFD273")  //Samsung S6 edge
          .Build();
        // Load the banner with the request.
        this.bannerView.LoadAd(requestBanner);
        Debug.Log("banner ad view ________");
    }

    public void RequestInterstitial()
    {
        #if UNITY_ANDROID
            string adUnitId = "ca-app-pub-3940256099942544/1033173712"; //test
        #elif UNITY_IPHONE
            string adUnitId = "ca-app-pub-3940256099942544/4411468910";
        #else
            string adUnitId = "unexpected_platform";
        #endif

        // Clean up interstitial ad before creating a new one.
        if (this.interstitial != null)
        {
            // this.interstitial.Destroy();
            // Debug.Log("inter ad Destroy ________");
        }
        // Initialize an InterstitialAd.
        this.interstitial = new InterstitialAd(adUnitId);
        // Create an empty ad request.
        AdRequest RequestInterstitial = new AdRequest.Builder()
          .AddTestDevice("65C2444A09CFD273")  //Samsung S6 edge
          .Build();

        // Time.timeScale = 0; // pausing everything apart from Update();
        // Load the interstitial with the request.
        this.interstitial.LoadAd(RequestInterstitial);
        // this.interstitial.show(); // to show the ad
        // if (this.interstitial.IsLoaded()) {
        //   this.interstitial.Show();
        // }
        Debug.Log("inter ad load ________");

        // Called when the ad is closed. synext: Subscribed += calling function
        this.interstitial.OnAdClosed += HandleOnAdClosed;
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        show = false;
        Debug.Log("inter ad closed ________");
    }
}
