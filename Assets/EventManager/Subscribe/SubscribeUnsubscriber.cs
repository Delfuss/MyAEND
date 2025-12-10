using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SubscribeUnsubscriber
{

    public static void Subscribe(string EventName,Action FunctionName)
    {

        // suscribo al evento al diccionario

        EventsTypes.EventSubscribe(EventName,FunctionName);

    }


    public static void Unsubscribe(string EventName,Action FunctionName)
    {

        // desuscribo al evento al diccionario
        EventsTypes.EventUnSubscribe(EventName, FunctionName);


    }
}
   

