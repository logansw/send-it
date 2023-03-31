using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles level selection.
/// </summary>
public class LevelManager : MonoBehaviour
{
    public static Vector3 SpawnPosition;
    public delegate void OnRestart();
    public static OnRestart e_OnRestart;
    public List<Route> AllRoutes;
    public Route CurrentRoute;

    void OnEnable() {
        RouteStart.e_OnRouteSelected += ChooseRoute;
    }

    void OnDisable() {
        RouteStart.e_OnRouteSelected -= ChooseRoute;
    }

    public void Start() {
        e_OnRestart();
    }

    private void Update() {
        if (Input.GetKey(KeyCode.R)) {
            if (e_OnRestart != null) {
                e_OnRestart();
            }
        }
    }

    public void ChooseRoute(Route route) {
        if (CurrentRoute != null) { CurrentRoute.DisableHolds(); CurrentRoute.DisableObstacles(); }
        CurrentRoute = route;
        CurrentRoute.EnableHolds();
        CurrentRoute.EnableObstacles();
        SpawnPosition = route.RouteStart.transform.position;
    }
}