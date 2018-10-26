using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using UnityEngine;

public class GameLoader
    : MonoBehaviour {

    private GameSystems gameSystems = null;
    private void Start()
    {
        gameSystems = new GameSystems();
        //LoadSynchronously();
        LoadAsynchronously();
    }
    private void LoadAsynchronously()
    {
        this.StartCoroutine(LoadAsyncRoutine());
    }

    private IEnumerator LoadAsyncRoutine()
    {
        Stopwatch watch = new Stopwatch();
        watch.Start();
        GameObject screenManagerPrefab = Resources.Load("ScreenManager") as GameObject;
        ScreenManager screeManager = GameObject.Instantiate(screenManagerPrefab).GetComponent<ScreenManager>();

        gameSystems.Register(screeManager);

        screeManager.PushScreen("LoadingScreen");


        int pendingManager = 0;
        AudioManager audioManager = new AudioManager();
        gameSystems.Register(audioManager);
        pendingManager += 1;
        Task.Run(() => { audioManager.Initialize(); }).ContinueWith((Task t) => { pendingManager -= 1; });


        AchieveManager achievementManager = new AchieveManager();
        gameSystems.Register(achievementManager);
        pendingManager += 1;
        Task.Run(() => { achievementManager.Initialize(); }).ContinueWith((Task t) => { pendingManager -= 1; }); 


        while(pendingManager != 0)
        {
            yield return null;
        }

        watch.Stop();
        UnityEngine.Debug.Log("Loading AsyncRoutine took " + watch.ElapsedMilliseconds + "ms");

        screeManager.PopScreen();
        screeManager.PushScreen("LandingScreen");
        yield break;
    }

    private void LoadSynchronously()
    {
        Stopwatch watch = new Stopwatch();
        watch.Start();

        

        AudioManager audioManager = new AudioManager();
        gameSystems.Register(audioManager);
        audioManager.Initialize();

        AchieveManager achievementManager = new AchieveManager();
        gameSystems.Register(achievementManager);
        achievementManager.Initialize();


        GameObject screenManagerPrefab = Resources.Load("ScreenManager") as GameObject;
        ScreenManager screeManager = GameObject.Instantiate(screenManagerPrefab).GetComponent<ScreenManager>();

        gameSystems.Register(screeManager);

        watch.Stop();
        UnityEngine.Debug.Log("Loading Synchronously took " + watch.ElapsedMilliseconds + "ms");
    }
}
