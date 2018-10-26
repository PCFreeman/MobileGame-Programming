using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Canvas))]
public class LeaderBoard : MonoBehaviour {

    public void CloseScreen()
    {
        ScreenManager.Instance().PopScreen();
    }
}
