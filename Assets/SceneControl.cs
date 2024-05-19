using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{
    // public static SceneControl instance;
    // Start is called before the first frame update
    void Start()
    {
       
    }
    private void Awake()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void NextLv()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void LoadScene(string name) {
        SceneManager.LoadScene(name);
    }
}
