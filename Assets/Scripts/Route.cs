using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Route : MonoBehaviour
{
    public enum ColorGrade {
        Yellow,
        Red,
        Green,
        Purple,
        Orange,
        Black,
        Blue,
        Pink,
        White
    }
    public List<Holdable> Holds;
    public RouteStart RouteStart;
    public ColorGrade RouteColor;
    public int Difficulty;
    public float BestTime;

    public void Awake() {
        Debug.Log(gameObject.name);
        for (int i = 0; i < transform.childCount; i++) {
            GameObject child = transform.GetChild(i).gameObject;
            Holds.Add(child.GetComponent<Holdable>());
            if (child.name == "Start") {
                RouteStart = child.AddComponent<RouteStart>();
                RouteStart.Initialize(this);
            }
        }
        for (int i = 0; i < Holds.Count; i++) {
            Holds[i].SetColor(RouteColor);
        }
        BestTime = 0;
    }

    public void Start() {
        Disable();
    }

    public void Enable() {
        for (int i = 0; i < Holds.Count; i++) {
            Holds[i].Enable();
        }
    }

    public void Disable() {
        for (int i = 0; i < Holds.Count; i++) {
            if (Holds[i].name != "Start") {
                Holds[i].Disable();
            }
        }
    }
}
