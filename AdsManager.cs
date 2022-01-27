using UnityEngine;
using UnityEngine.Advertisements;
using System.Collections;

public class AdsManager : MonoBehaviour, IUnityAdsListener
{
    public GameObject Botato;
    public LiveSystem livescr;
    private void Start() {
        Advertisement.Initialize("4577486");
        Advertisement.AddListener(this);
        Botato = GameObject.FindGameObjectWithTag("Botato");
        livescr = Botato.GetComponent<LiveSystem>();
    }
    private void Update() {
    
    }

    public void PlayAd()
    {
        if(Advertisement.IsReady("Interstitial_Android"))
        {
            Advertisement.Show("Interstitial_Android");
        }
    }

    public void PlayRewardedAds()
    {
        if(Advertisement.IsReady("Rewarded_Android"))
        {
            Advertisement.Show("Rewarded_Android");
        } else { Debug.Log("Ad is not ready") ;}
    }
    public void showbanner()
    {
        if(Advertisement.IsReady("Banner_Android"))
        {
            Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
            Time.timeScale = 0f;
            Advertisement.Show("Banner_Android");
            Advertisement.Banner.Show("Banner_Android");
        } 
        else{ StartCoroutine(RepeatShowBanner()); }

    }
    IEnumerator RepeatShowBanner()
    {
        yield return new WaitForSeconds(1f);
        showbanner();
    }
    public void OnUnityAdsReady(string placementId)
    {
        Debug.Log("Ad ready");
    }

    public void OnUnityAdsDidError(string message)
    {
        Debug.Log("Ad error");
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        Debug.Log("Ad started");
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if(placementId == "Rewarded_Android" && showResult == ShowResult.Finished)
        {
            Debug.Log("Success");
            livescr.livesRemaining += 5;
        }
    }
}
