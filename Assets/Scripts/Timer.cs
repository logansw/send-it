using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// Tracks passage of time
/// </summary>
public class Timer : MonoBehaviour
{
    private DateTime _startTime;
    private bool _timerActive;
    private Route _activeRoute;
    public UIManager UIManager;

    private void OnEnable() {
        RouteStart.e_OnRouteSelected += StartTimer;
    }

    private void OnDisable() {
        RouteStart.e_OnRouteSelected -= StartTimer;
    }

    private void Update() {
        if (_timerActive) {
            TimeSpan difference = GetTimeSinceStart();
            UIManager.SetCurrentTime($"{difference.Minutes}:{difference.Seconds.ToString("D2")}:{difference.Milliseconds.ToString("D3")}");
        }
    }

    public void StartTimer(Route route) {
        if (route != _activeRoute) {
            CancelTimer();
        }
        _activeRoute = route;
        _startTime = DateTime.Now;
        _timerActive = true;
    }

    public TimeSpan GetTimeSinceStart() {
        DateTime finishTime = DateTime.Now;
        TimeSpan difference = finishTime.Subtract(_startTime);
        return difference;
    }

    public void EndTimer() {
        TimeSpan finalTime = GetTimeSinceStart();
        Route route = GameManager.s_CurrentRoute;
        if (finalTime < route.BestTime) {
            route.BestTime = finalTime;
            UIManager.SetBestTime($"{finalTime.Minutes}:{finalTime.Seconds.ToString("D2")}:{finalTime.Milliseconds.ToString("D3")}");
        }
        _timerActive = false;
    }

    public void CancelTimer() {
        _timerActive = false;
    }
}
