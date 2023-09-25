using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;

/*
ECS or MVC conception is applied on the small game
Firstly, entities and their states are defined as the game model.
And then, give some components/controls which can modify the game model.
The end, system handler OnGUI called by game circle provides a game UI view.
*/
public class NewBehaviourScript : MonoBehaviour {

    // Entities and their states / Model
    public GameObject cube;
    private static int count;
    private GUIStyle counterStyle;
    private List<GameObject> ress;

    // System Handlers
    void Start ()
    {
        ress = new List<GameObject>();
        Init();
        counterStyle = new GUIStyle();
        counterStyle.fontSize = 20;
        counterStyle.normal.textColor = new Color(0f / 256f, 256f / 256f, 256f / 256f, 256f / 256f);
    }

    // View to render entities / models
    // Here! you cannot modify model directly, use components/controls to do it
    void OnGUI() {
        GUI.Label(new Rect(Screen.width/2 - 100, Screen.height - 60, 300, 300), "Number of cubes: "+count.ToString(), counterStyle);
        if (GUI.Button(new Rect(Screen.width/2, Screen.height - 30, 100, 30), "Restart")) Init();
        if (GUI.Button(new Rect(Screen.width/2 - 100, Screen.height - 30, 100, 30), "Put Cube")) PutCube();
    }

    // Components /controls
    void Init() {
        count = 0;
        Debug.Log(ress.Count);
        if (ress.Count != 0)
        {
            foreach(GameObject o in ress)
            {
                GameObject.Destroy(o);
            }

            ress.Clear();
        }
    }

    void PutCube() {
        count++;
        ress.Add(Instantiate(cube, new Vector3(Random.Range(-10f, 10f), Random.Range(2f, 10f), Random.Range(-8f, 10f)),transform.rotation));
    }

}