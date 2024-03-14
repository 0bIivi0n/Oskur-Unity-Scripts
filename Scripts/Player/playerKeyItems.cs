using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerKeyItems : MonoBehaviour
{

    [SerializeField]
    private bool hasSquareKey = false;
    [SerializeField]
    private bool hasRestaurantKey = false;
    [SerializeField]
    private bool hasMeetingRoomKey = false;
    [SerializeField]
    private bool hasBackOfficeKey = false;
    [SerializeField]
    private bool hasElevatorKey = false;



    public bool GetSquareKey() {
        return hasSquareKey;
    }

    public void SetSquareKey(bool state) {
        hasSquareKey = state;
    }

    public bool GetRestaurantKey() {
        return hasRestaurantKey;
    }

    public void SetRestaurantKey(bool state) {
        hasRestaurantKey = state;
    }

    public bool GetMeetingRoomKey() {
        return hasMeetingRoomKey;
    }

    public void SetMeetingRoomKey(bool state) {
        hasMeetingRoomKey = state;
    }

    public bool GetBackOfficeKey() {
        return hasBackOfficeKey;
    }

    public void SetBackOfficeKey(bool state) {
        hasBackOfficeKey = state;
    }

    public bool GetBackdoorKey() {
        return hasElevatorKey;
    }

    public void SetBackdoorKey(bool state) {
        hasElevatorKey = state;
    }
}
