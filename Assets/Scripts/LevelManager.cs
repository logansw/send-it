using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        Debug.Log("Route chosen: " + route.name);
        if (CurrentRoute != null) { CurrentRoute.Disable(); }
        CurrentRoute = route;
        CurrentRoute.Enable();
        SpawnPosition = route.RouteStart.transform.position;
    }
}