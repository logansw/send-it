using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouteStart : MonoBehaviour
{
    private Route _route;
    public delegate void OnRouteSelected(Route route);
    public static OnRouteSelected e_OnRouteSelected;

    public void Initialize(Route route) {
        this._route = route;
    }

    public void Begin() {
        if (e_OnRouteSelected != null) {
            e_OnRouteSelected(_route);
            GameManager.s_CurrentRoute = _route;
        }
    }
}
