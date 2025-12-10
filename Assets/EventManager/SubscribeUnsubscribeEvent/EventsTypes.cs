using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public  static class EventsTypes
{
    public static Dictionary<string,Action> EventsList = new Dictionary<string,Action>();


  static public void EventSubscribe(string EventName,Action FunctionName)
  {
        if (EventsList.ContainsKey(EventName) == false)
        {           
            EventsList[EventName]= null;
        }

         EventsList[EventName] += FunctionName;
            
  }


    static public void EventUnSubscribe(string EventName, Action FunctionName)
    {
        if (EventsList.ContainsKey(EventName) == true)
        {
            EventsList[EventName] -= FunctionName;
        }
    }

    static public void InvokeEvent(string EventName)
    {
        if (EventsList.ContainsKey(EventName) == true)
        {
            EventsList[EventName]?.Invoke();
        }
    }
}


