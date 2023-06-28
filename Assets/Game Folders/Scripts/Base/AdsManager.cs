using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour , IUnityAdsInitializationListener , IUnityAdsLoadListener , IUnityAdsShowListener
{
    [SerializeField] private string GameID;
    [SerializeField] private bool testMode = false;
    [SerializeField] private string InterstitialUnit = "Interstitial_Android";
    [SerializeField] private string BannerUnit = "Banner_Android";

    [SerializeField] private BannerOptions bannerOpsi;

    private void Awake()
    {
        if (!Advertisement.isInitialized && Advertisement.isSupported)
        {
            Advertisement.Initialize(GameID, testMode, this);
        }
    }

    public void OnInitializationComplete()
    {
        Debug.Log("Unity Ads Initialize!");
        RequestBanner();
    }

    public void RequestInterstitial()
    {
        Advertisement.Load(InterstitialUnit ,this);
        //Advertisement.Show(InterstitialUnit , this);
    }

    private void RequestBanner()
    {
        Advertisement.Load(BannerUnit ,this);
        //Advertisement.Banner.Show(BannerUnit , bannerOpsi);
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log("ADS ERROR!!!!!!");
    }

    public void OnUnityAdsAdLoaded(string placementId)
    {
        Debug.Log($"ads load : {placementId}");
        Advertisement.Show(placementId , this);
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        Debug.Log("ADS ERROR!!!!!!");
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
    }

    public void OnUnityAdsShowStart(string placementId)
    {
    }

    public void OnUnityAdsShowClick(string placementId)
    {
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
    }
}
