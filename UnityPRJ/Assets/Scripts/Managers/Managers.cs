using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    static Managers s_instance;
    static Managers Instance { get { Init(); return s_instance; } }

    InputManager _input = new InputManager();
    public static InputManager Input { get { return Instance._input; } }

    static void Init()
    {
        string gobjName = "@Managers";
        if (s_instance == null)
        {
            GameObject gobj = GameObject.Find(gobjName);
            if(gobj == null)
            {
                gobj = new GameObject { name = gobjName };
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
        _input.OnUpdate();
    }

}
