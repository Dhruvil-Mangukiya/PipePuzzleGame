using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class AdsBanner : MonoBehaviour
{
  [SerializeField] Button _loadBannerButton;
  [SerializeField] Button _showBannerButton;

  [SerializeField] BannerPosition _bannerPosition = BannerPosition.BOTTOM_CENTER;

  [SerializeField] string _androidAdUnitId = "Banner_Android";
  // [SerializeField] string _iOSAdUnitId = "Banner_iOS";
  string _adUnitId = null;

  void Start()
  {
#if UNITY_IOS
    _adUnitId = _iOSAdUnitId;
#elif UNITY_ANDROID
    _adUnitId = _androidAdUnitId;
#endif

    _showBannerButton.interactable = false;

    Advertisement.Banner.SetPosition(_bannerPosition);

    _loadBannerButton.onClick.AddListener(LoadBanner);
    _loadBannerButton.interactable = true;
  }

  public void LoadBanner()
  {
    BannerLoadOptions options = new BannerLoadOptions
    {
      loadCallback = OnBannerLoaded,
      errorCallback = OnBannerError
    };

    // Load the Ad Unit with banner content:
    Advertisement.Banner.Load(_adUnitId, options);
  }

  void OnBannerLoaded()
  {
    Debug.Log("Banner loaded");

    _showBannerButton.onClick.AddListener(ShowBannerAd);

    _showBannerButton.interactable = true;
  }

  void OnBannerError(string message)
  {
    Debug.Log($"Banner Error: {message}");
  }

  void ShowBannerAd()
  {
    BannerOptions options = new BannerOptions
    {
      clickCallback = OnBannerClicked,
      hideCallback = OnBannerHidden,
      showCallback = OnBannerShown
    };

    Advertisement.Banner.Show(_adUnitId, options);
  }

  void HideBannerAd()
  {
    // Hide the banner:
    Advertisement.Banner.Hide();
  }

  void OnBannerClicked() { }
  void OnBannerShown() { }
  void OnBannerHidden() { }

  void OnDestroy()
  {
    _loadBannerButton.onClick.RemoveAllListeners();
    _showBannerButton.onClick.RemoveAllListeners();
    //   _hideBannerButton.onClick.RemoveAllListeners();
  }
}
