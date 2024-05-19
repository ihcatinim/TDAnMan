using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finishpoint : MonoBehaviour
{
    public SceneControl scene;
    public enemy checke;
    public controllUi controllui;
    private void OnTriggerEnter2D(Collider2D co)
    {
        if(co.CompareTag("Player") && checke.defeated1 == 5) {
            scene.NextLv();
        }
        if (co.CompareTag("Player") && checke.defeated1!=5)
        {
            controllui.Requiment(); 
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        scene = GetComponent<SceneControl>();
        checke = GetComponent<enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
