using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

public class ReloadScene : MonoBehaviour
{
    public float delay = 1f;
    private float currentTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime > delay)
        {
            string sceneName = SceneManager.GetActiveScene().name;
            SceneLoader sceneScript = GetComponent<SceneLoader>();
            sceneScript.sceneName = sceneName;
            sceneScript.LoadScene();
        }
    }
}
