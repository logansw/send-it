using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// (Blob component)
/// Route object. Manages holds that make up the route, enabling and disabling them.
/// Initializes holds, records solve time, contains basic identifying information
/// (e.g. name, difficulty).
/// </summary>
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
    public List<Obstacle> Obstacles;
    public RouteStart RouteStart;
    public ColorGrade RouteColor;
    public int Difficulty;
    public System.TimeSpan BestTime;
    private System.DateTime _startTime;

    public void Awake() {
        InitializeHolds();
        // Initialize best time
        BestTime = System.TimeSpan.MaxValue;
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

    private void InitializeHolds() 
    {
        for (int i = 0; i < transform.childCount; i++) {
            GameObject child = transform.GetChild(i).gameObject;
            if (child.GetComponent<Holdable>() != null) {
                Holds.Add(child.GetComponent<Holdable>());
            }
            if (child.name == "Start") {
                RouteStart = child.AddComponent<RouteStart>();
                RouteStart.Initialize(this);
            }
        }
        for (int i = 0; i < Holds.Count; i++) {
            Holds[i].SetColor(RouteColor);
        }
    }

    private void InitializeObstacles()
    {
        for (int i = 0; i < transform.childCount; i++) {
            GameObject child = transform.GetChild(i).gameObject;
            if (child.GetComponent<Obstacle>() != null) {
                Obstacles.Add(child.GetComponent<Obstacle>());
            }
        }
        for (int i = 0; i < Obstacles.Count; i++) {
            Obstacles[i].SetColor(RouteColor);
        }
    }
}
