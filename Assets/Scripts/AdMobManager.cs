/*Banner & interstitial Ads*/
using System;
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class AdMobManager : MonoBehaviour{
  private BannerView bannerView;
  private InterstitialAd interstitial;
  bool show = false;

  public void Start(){
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
  }

  void Update(){
    if (show == false){
      if (this.interstitial.IsLoaded()){
        this.interstitial.Show(); //show the ad
        Debug.Log("inter ad showed ________");
        show = true;
      }
    }
  }

  private void RequestBanner(){
    #if UNITY_ANDROID
      string adUnitId = "ca-app-pub-3940256099942544/6300978111"; //test
    #elif UNITY_IPHONE
      string adUnitId = "ca-app-pub-2153044413134440~8143107307";
    #else
      string adUnitId = "unexpected_platform";
    #endif

    // Clean up banner ad before creating a new one.
    if (this.bannerView != null){
      this.bannerView.Destroy();
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

  public void RequestInterstitial(){
    #if UNITY_ANDROID
      string adUnitId = "ca-app-pub-3940256099942544/1033173712"; //test
    #elif UNITY_IPHONE
      string adUnitId = "ca-app-pub-3940256099942544/4411468910";
    #else
      string adUnitId = "unexpected_platform";
    #endif

    // Clean up interstitial ad before creating a new one.
    if (this.interstitial != null){
      this.interstitial.Destroy();
      Debug.Log("inter ad Destroy ________");
    }

    // Initialize an InterstitialAd.
    this.interstitial = new InterstitialAd(adUnitId);
    // Create an empty ad request.
    AdRequest RequestInterstitial = new AdRequest.Builder()
      .AddTestDevice("65C2444A09CFD273")  //Samsung S6 edge
      .Build();

    // Load the interstitial with the request.
    this.interstitial.LoadAd(RequestInterstitial);
    Debug.Log("inter ad load ________");

    // Called when the ad is closed. synext: Subscribed += calling function
    this.interstitial.OnAdClosed += HandleOnAdClosed;
  }

  public void HandleOnAdClosed(object sender, EventArgs args){
    show = false;
    Debug.Log("inter ad closed ________");
  }
}
