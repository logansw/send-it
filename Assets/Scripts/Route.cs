using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// (Blob component)
/// Route object. Manages _holds that make up the route, enabling and disabling them.
/// Initializes _holds, records solve time, contains basic identifying information
/// (e.g. name, difficulty).
/// </summary>
///
/// Attach Route.cs to the parent object (containing all Holdable objects). Give the
/// parent object a name to name the route and assign it a color. Rename the starting
/// hold to "Start", and rename the final hold to "Top". Finally, drag the Route into
/// LevelManager.
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
    [SerializeField] private ColorGrade _routeColor;
    [HideInInspector] public RouteStart RouteStart;
    [HideInInspector] public System.TimeSpan BestTime;
    public List<Obstacle> Obstacles;
    public int Difficulty;
    private System.DateTime _startTime;
    public List<Holdable> _holds;

    public void Awake() {
        InitializeHolds();
        InitializeObstacles();
        // Initialize best time
        BestTime = System.TimeSpan.MaxValue;
    }

    public void Start() {
        DisableHolds();
        DisableObstacles();
    }

    public void EnableHolds() {
        for (int i = 0; i < _holds.Count; i++) {
            _holds[i].Enable();
        }
    }

    public void DisableHolds() {
        for (int i = 0; i < _holds.Count; i++) {
            if (_holds[i].name != "Start") {
                _holds[i].Disable();
            }
        }
    }

    public void EnableObstacles() {
        for (int i = 0; i < Obstacles.Count; i++) {
            Obstacles[i].Enable();
        }
    }

    public void DisableObstacles() {
        for (int i = 0; i < Obstacles.Count; i++) {
            Obstacles[i].Disable();
        }
    }

    private void InitializeHolds() 
    {
        for (int i = 0; i < transform.childCount; i++) {
            GameObject child = transform.GetChild(i).gameObject;
            if (child.GetComponent<Holdable>() != null) {
                _holds.Add(child.GetComponent<Holdable>());
            }
            if (child.name == "Start") {
                RouteStart = child.AddComponent<RouteStart>();
                RouteStart.Initialize(this);
            }
        }
        for (int i = 0; i < _holds.Count; i++) {
            _holds[i].Initialize(_routeColor);
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
    }
}