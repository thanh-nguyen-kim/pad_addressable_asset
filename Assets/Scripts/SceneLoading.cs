using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
public class SceneLoading : MonoBehaviour
{
    public string sceneName;
    public DownloadPanel downloadPanelPrefab;
    public void OnClick()
    {
        StartCoroutine(HandleLoadAsync());
    }
    private IEnumerator HandleLoadAsync()
    {
        bool isCached = false;
        var asyncTask = Khepri.AssetDelivery.AddressablesAssetDelivery.GetDownloadSizeAsync(sceneName);
        while (!asyncTask.IsDone) yield return null;
        isCached = (asyncTask.Status == UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationStatus.Succeeded && asyncTask.Result == 0);
        if (!isCached)
            downloadPanelPrefab.Spawn(sceneName, LoadScene);
        else
            LoadScene();
    }
    public void LoadScene()
    {
        Addressables.LoadSceneAsync(sceneName);
    }
}
