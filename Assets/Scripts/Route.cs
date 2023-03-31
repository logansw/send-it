using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// (Blob component)
/// Route object. Manages holds that make up the route, enabling and disabling them.
/// Initializes holds, records solve time, contains basic identifying information
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
    private System.DateTime _startTime;
    private List<Holdable> Holds;

    public void Awake() {
        for (int i = 0; i < transform.childCount; i++) {
            GameObject child = transform.GetChild(i).gameObject;
            Holds.Add(child.GetComponent<Holdable>());
            if (child.name == "Start") {
                RouteStart = child.AddComponent<RouteStart>();
                RouteStart.Initialize(this);
            }
        }
        for (int i = 0; i < Holds.Count; i++) {
            Holds[i].SetColor(_routeColor);
        }
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
}