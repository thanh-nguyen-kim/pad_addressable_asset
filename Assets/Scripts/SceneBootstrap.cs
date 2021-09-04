using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
public class SceneBootstrap : MonoBehaviour
{
    private void Start(){
        Addressables.LoadSceneAsync("Menu");
    }
}
