using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LandingScreen: MonoBehaviour {

    [SerializeField]
    private Button starGameButton = null;
    [SerializeField]
    private Button LeaderBoardButton = null;
    private void Start()
    {
        starGameButton.onClick.AddListener(starButtonClickCallBack);
    }
    private void OnDestory()
    {
        starGameButton.onClick.RemoveListener(starButtonClickCallBack);
    }

    private void starButtonClickCallBack()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
    }

    public void OpenSettingScreen()
    {
        ScreenManager.Instance().PushScreen("Setting");
    }

    public void OpenLeaderBoard()
    {
        ScreenManager.Instance().PushScreen("LeaderBoard");
    }
}
