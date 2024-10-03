using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Splashscreen : MonoBehaviour
{
    // Start is called before the first frame update
    public string NextScene;
    public int waitTime;
    void Awake()
    {
        DontDestroyOnLoad(this);
    }


    private void Start()
    {
        StartCoroutine(WaitTime());
    }

    IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(NextScene);
    }
}
