using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndroidFunctions : MonoBehaviour {

    public void ShowToastMessage(string message)
    {
        AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");

        AndroidJavaObject unityActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");

        unityActivity.Call("runOnUiThread",new AndroidJavaRunnable(()=> {
            Debug.Log("Running on UI thread");

            AndroidJavaObject applicationContext = unityActivity.Call<AndroidJavaObject>("getApplicationContext");

            AndroidJavaClass toastClass = new AndroidJavaClass("android.widget.Toast");

            AndroidJavaObject javaString = new AndroidJavaObject("java.lang.String",message);

            AndroidJavaObject toastInstance = toastClass.CallStatic<AndroidJavaObject>("makeText",applicationContext,message,toastClass.GetStatic<int>("LENGTH_SHORT"));

            toastInstance.Call("show");
        }));
    }
    public void ShowStaticHelloWorldLog()
    {
        // Get java class from my plugin
        AndroidJavaClass androidLibraryUtility =
            new AndroidJavaClass("com.a389248.androidutility.UtilityBridgeMain");

        // Call static function
        androidLibraryUtility.CallStatic("HelloWorld");
    }


}
