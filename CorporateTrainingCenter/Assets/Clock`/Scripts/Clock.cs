using UnityEngine;
using System.Collections;

public class Clock : MonoBehaviour
{
    //-----------------------------------------------------------------------------------------------------------------------------------------
    //-----------------------------------------------------------------------------------------------------------------------------------------
    //-----------------------------------------------------------------------------------------------------------------------------------------
    //
    //  Simple Clock Script / Andre "AEG" B�rger / VIS-Games 2012
    //
    //-----------------------------------------------------------------------------------------------------------------------------------------
    //-----------------------------------------------------------------------------------------------------------------------------------------
    //-----------------------------------------------------------------------------------------------------------------------------------------

    //-- set start time 00:00
    public int minutes = 0;
    public int hour = 0;

    //-- time speed factor
    public float clockSpeed = 1.0f;     // 1.0f = realtime, < 1.0f = slower, > 1.0f = faster

    //-- internal vars
    int seconds;
    float msecs;
    GameObject pointerSeconds;
    GameObject pointerMinutes;
    GameObject pointerHours;
    //-----------------------------------------------------------------------------------------------------------------------------------------
    //-----------------------------------------------------------------------------------------------------------------------------------------
    //-----------------------------------------------------------------------------------------------------------------------------------------
    void Start()
    {
        Transform pSeconds = transform.Find("rotation_axis_pointer_seconds");
        Transform pMinutes = transform.Find("rotation_axis_pointer_minutes");
        Transform pHours = transform.Find("rotation_axis_pointer_hour");

        if (pSeconds)
            pointerSeconds = pSeconds.gameObject;
        if (pMinutes)
            pointerMinutes = pMinutes.gameObject;
        if (pHours)
            pointerHours = pHours.gameObject;

        minutes = System.DateTime.Now.Minute;
        hour = System.DateTime.Now.Hour;
        seconds = System.DateTime.Now.Second;
        msecs = 0.0f;
    }
    //-----------------------------------------------------------------------------------------------------------------------------------------
    //-----------------------------------------------------------------------------------------------------------------------------------------
    //-----------------------------------------------------------------------------------------------------------------------------------------
    void Update()
    {
        ////-- calculate time
        //msecs += Time.deltaTime * clockSpeed;
        //if(msecs >= 1.0f)
        //{
        //    msecs -= 1.0f;
        //    seconds++;
        //    if(seconds >= 60)
        //    {
        //        seconds = 0;
        //        minutes++;
        //        if(minutes > 60)
        //        {
        //            minutes = 0;
        //            hour++;
        //            if(hour >= 24)
        //                hour = 0;
        //        }
        //    }
        //}

        minutes = System.DateTime.Now.Minute;
        hour = System.DateTime.Now.Hour;
        seconds = System.DateTime.Now.Second;

        //-- calculate pointer angles
        float rotationSeconds = (360.0f / 60.0f) * seconds;
        float rotationMinutes = (360.0f / 60.0f) * minutes;
        float rotationHours = ((360.0f / 12.0f) * hour) + ((360.0f / (60.0f * 12.0f)) * minutes);

        //-- draw pointers
        if (pointerSeconds)
            pointerSeconds.transform.localEulerAngles = new Vector3(0.0f, 0.0f, rotationSeconds);

        if (pointerMinutes)
            pointerMinutes.transform.localEulerAngles = new Vector3(0.0f, 0.0f, rotationMinutes);

        if (pointerHours)
            pointerHours.transform.localEulerAngles = new Vector3(0.0f, 0.0f, rotationHours);

    }
    //-----------------------------------------------------------------------------------------------------------------------------------------
    //-----------------------------------------------------------------------------------------------------------------------------------------
    //-----------------------------------------------------------------------------------------------------------------------------------------
}
