using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallaxcontroler : MonoBehaviour
{
    public Transform cam;
    Vector3 camstartpos;
    float distance;

    GameObject[] backgrounds;
    Material[] mat;
    float[] bkgspeed;

    float farthestbgr;
    [Range(0.01f, 0.05f)]
    public float parallaxspeed;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.transform;
        camstartpos = cam.position;
        int backcount = transform.childCount;
        mat = new Material[backcount];
        bkgspeed = new float[backcount];
        backgrounds = new GameObject[backcount];


        for(int i = 0; i < backcount; i++)
        {
            backgrounds[i] = transform.GetChild(i).gameObject;
            mat[i] = backgrounds[i].GetComponent<Renderer>().material;  
        }
        void BackSpeedCalculate(int backcount)
        {
            for(int i = 0;i < backcount;i++)
            {
                if ((backgrounds[i].transform.position.z - cam.position.z) > farthestbgr)
                {
                    farthestbgr = backgrounds[i].transform.position.z;  
                }
            }
            for (int i = 0; i < backcount; i++)
            {
                bkgspeed[i] = 1 - (backgrounds[i].transform.position.z - cam.position.z);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        distance = cam.position.x - camstartpos.x;
        transform.position =new Vector3(cam.position.x,cam.position.y,0);
        for (int i = 0;i<backgrounds.Length ; i++) {
            float speed = bkgspeed[i]*parallaxspeed;
            mat[i].SetTextureOffset("_MainTex",new Vector2(distance,0)*speed);    
        
        }
    }
}
