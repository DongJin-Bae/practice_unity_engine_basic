using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    static Managers s_instance;
    public static Managers Instance
    {
        get
        {
            Init();
            return s_instance;
        }
    }

    static void Init()
    {
        if(s_instance == null)
        {
            GameObject gobj = GameObject.Find("@Managers");
            if(gobj == null)
            {
                gobj = new GameObject { name = "@Managers" };
                gobj.AddComponent<Managers>();
            }

            DontDestroyOnLoad(gobj);
            s_instance = gobj.GetComponent<Managers>();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
