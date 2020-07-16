using UnityEngine;
using System.Collections;

/// <summary>
/// Activate or deactivate child screens on screen objects
/// </summary>
public class TVScreenActivatorNew : MonoBehaviour {

	//NOT USED GameObject activeScreen;
	public GameObject tvScreenWeb;
    public GameObject tvScreenNotLoaded;

    public bool onlyShowLoadingScreen = false;
    public bool disableDuringScripts = false;
	public bool onlyShowWhenPlaying = false;
#if UNITY_ENGAGE

    void FixedUpdate () {
        if(ENG_IGM_MovieSync.instance)
			CheckScreens();
	}

    void CheckScreens() {
        if (ENG_IGM_MovieSync.instance.screenTypeActive == ENG_IGM_MovieSync.instance.screenWeb || ENG_IGM_MovieSync.instance.loading4DResources)
        {
            if (onlyShowLoadingScreen)
            {
                OnlyShowLoadingScreenUpdate();
            }
            else if (disableDuringScripts)
            {
                DisableDuringScriptsUpdate();
            }
            else if (onlyShowWhenPlaying)
            {
                OnlyShowWhenPlayingUpdate();
            }
            else {
                ShowScreens();
            }
        }
        else {
            HideScreens();
        }
    }

    void OnlyShowLoadingScreenUpdate()
    {
        if (ENG_IGM_MovieSync.instance.loading4DResources || ENG_IGM_MovieSync.instance.movieLoadingTimer > 0)
        {
            ShowScreens();
        }
        else
        {
            HideScreens();
        }
    }

    void DisableDuringScriptsUpdate() {
        if (!ENG_IGM_MovieSync.instance.isVideoPlayerState || !(ENG_IGM_MovieSync.instance.maxTimerPlayState && ENG_IGM_MovieSync.instance.maxTimerLinkToVideoState) || ENG_IGM_MovieSync.instance.loading4DResources) {
            if (onlyShowWhenPlaying)
            {
                OnlyShowWhenPlayingUpdate();
            }
            else {
                ShowScreens();
            }
        }
        else {
            HideScreens();
        }
    }

    void OnlyShowWhenPlayingUpdate() {
        if (ENG_IGM_MovieSync.instance.videoPausedState == false || (ENG_IGM_MovieSync.instance.isVideoPlayerState && ENG_IGM_MovieSync.instance.isLiveVideo) || ENG_IGM_MovieSync.instance.loading4DResources || !ENG_IGM_MovieSync.instance.isVideoPlayerState)
        {
            ShowScreens();
        }
        else {
            HideScreens();
        }
    }

    void ShowScreens() {
        if (!tvScreenWeb.activeInHierarchy)
            tvScreenWeb.SetActive(true);

        if (tvScreenNotLoaded != null)
            if (tvScreenNotLoaded.activeInHierarchy)
                tvScreenNotLoaded.SetActive(false);
    }

    void HideScreens() {
        if (tvScreenWeb.activeInHierarchy)
            tvScreenWeb.SetActive(false);

        if (tvScreenNotLoaded != null)
            if (!tvScreenNotLoaded.activeInHierarchy)
                tvScreenNotLoaded.SetActive(true);
    }
#endif
}
