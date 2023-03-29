using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// Manages content displayed through UI
/// </summary>
public class UIManager : MonoBehaviour
{
    public TMP_Text RouteName;
    public TMP_Text BestTime;
    public TMP_Text CurrentTime;

    public void OnEnable() {
        RouteStart.e_OnRouteSelected += SetRouteData;
    }

    public void OnDisable() {
        RouteStart.e_OnRouteSelected -= SetRouteData;
    }

    public void Start() {
        RouteName.text = "";
        BestTime.text = "";
        CurrentTime.text = "";
    }

    public void SetRouteData(Route route) {
        RouteName.text = route.gameObject.name;
        if (route.BestTime == System.TimeSpan.MaxValue) {
            BestTime.text = "";
        } else {
            SetBestTime($"{route.BestTime.Minutes}:{route.BestTime.Seconds.ToString("D2")}:{route.BestTime.Milliseconds.ToString("D3")}");
        }
    }

    public void SetBestTime(string time) {
        BestTime.text = time;
    }

    public void SetCurrentTime(string time) {
        CurrentTime.text = time;
    }
}
