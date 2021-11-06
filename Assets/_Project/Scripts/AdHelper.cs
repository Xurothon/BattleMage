using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class AdHelper : MonoBehaviour, IUnityAdsListener
{
    public event UnityAction AddPowerPercentFinised;
    [SerializeField] private Button _boostPowerPercent;
    private string _placementLevelComplete = "LevelComplete";
    private string _placementaddPowerPercent = "addPowerPercent";

    public void OnUnityAdsDidError(string message) { }

    public void OnUnityAdsDidStart(string placementId) { }

    public void OnUnityAdsReady(string placementId) { }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (placementId == _placementaddPowerPercent)
        {
            if (showResult == ShowResult.Finished)
            {
                DataWorker.Instance.UpdatePowerPercentAfterVideoFinised();
                AddPowerPercentFinised?.Invoke();
                Helpers.Instance.LevelLoader.LoadNextLevel();
            }
        }
    }

    public void OnDestroy()
    {
        Advertisement.RemoveListener(this);
    }

    public void ShowLevelCompleteAd()
    {
        ShowPlacement(_placementLevelComplete);
    }

    private void ShowPlacement(string placementName)
    {
        if (Advertisement.IsReady(placementName))
            Advertisement.Show(placementName);
    }

    private void Start()
    {
        _boostPowerPercent.onClick.AddListener(() => ShowPlacement(_placementaddPowerPercent));
        Advertisement.AddListener(this);
        if (Advertisement.isSupported)
            Advertisement.Initialize("4209967", false);
    }
}
