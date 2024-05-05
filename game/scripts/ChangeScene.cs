using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    // Þessi aðferð er kallað þegar hluturinn er smelltur á til að fara í annan senu
    public void MoveToScene(int sceneID)
    {
        // Hleður inn valinni senu með hjálp SceneManager
        SceneManager.LoadScene(sceneID);
    }
}
