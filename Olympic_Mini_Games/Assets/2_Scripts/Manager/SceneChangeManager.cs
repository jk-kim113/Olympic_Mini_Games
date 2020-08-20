using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeManager : MonoBehaviour
{
    public enum eTypeScene
    {
        Start = 0,
        Home,
        Ingame
    }

    public enum eStateLoadding
    {
        none = 0,
        UnLoad,
        Load,
        Loading,
        LoadingDone,
        EndLoad
    }

    eTypeScene mCurrentScene;
    eTypeScene mPrevScene;
    eStateLoadding mLoadState;
    
    static SceneChangeManager mUniqueInstance;
    public static SceneChangeManager _instance { get { return mUniqueInstance; } }

    private void Awake()
    {
        mUniqueInstance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (mLoadState == eStateLoadding.EndLoad)
        {
            StopCoroutine("LoadingPrecess");
            mLoadState = eStateLoadding.none;
        }
    }

    IEnumerator LoadingPrecess(string sceneName)
    {
        mLoadState = eStateLoadding.Load;

        AsyncOperation asyncOp = SceneManager.LoadSceneAsync(sceneName);
        mLoadState = eStateLoadding.Loading;
        while (!asyncOp.isDone)
        {
            yield return null;
        }

        mLoadState = eStateLoadding.LoadingDone;
        yield return new WaitForSeconds(1f);
        mLoadState = eStateLoadding.EndLoad;
    }

    public void StartLoadIngameScene(string stageName)
    {
        mPrevScene = mCurrentScene;
        mCurrentScene = eTypeScene.Ingame;
        StartCoroutine(LoadingPrecess(stageName));
    }
}
