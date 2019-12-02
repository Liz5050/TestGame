using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void OnHandler(object sender);
public class Event {
    //public event EventHandler<EventArgs> OnHandler; //定义一个委托类型的事件  
    //public delegate void InformHandle(object sender);
    public void DoHandler()
    {
        //OnHandler(this, new EventArgs());
    }
}

public class EventManager {

    public static Dictionary<EventEnum,MyList<OnHandler>> EventDict = new Dictionary<EventEnum, MyList<OnHandler>>();
    public static void Add(EventEnum type, OnHandler call)
    {
        MyList<OnHandler> list = EventDict[type];
        if (list == null)
        {
            list = new MyList<OnHandler>();
            EventDict[type] = list;
        }
        if(list.IndexOf(call) != -1)
        {
            OnHandler handler = new OnHandler(call);
            handler += call;
            list.Push(handler);
        }
        //Event evt = new Event();
        //evt.OnHandler += Call;
    }

    public static Dictionary<EventEnum, List<System.Action>> Evts = new Dictionary<EventEnum, List<System.Action>>();
    public static void Add2(EventEnum type,Action action)
    {
        List<Action> list;
        if (!Evts.ContainsKey(type))
        {
            list = new List<Action>();
            Evts.Add(type, list);
        }
        else
        {
            list = Evts[type];
        }
        list.Add(action);
        //if (Evts[type] == null)
        //{
        //    Evts[type] = new List<System.Action>();
        //}
        //if (Evts[type].IndexOf(action) == -1)
        //{
        //    Evts[type].Add(action);
        //}
    }

    public static void Remove(EventEnum type, Action action)
    {
        if (!Evts.ContainsKey(type)) return;
        List<Action> list = Evts[type];
        Debug.Log("移除前");
        Debug.Log(list.IndexOf(action));
        Debug.Log(list);
        list.Remove(action);
        Debug.Log("移除后");
        Debug.Log(list.IndexOf(action));
        Debug.Log(list);
    }

    public static void DispatchEvent(EventEnum type)
    {
        if (!Evts.ContainsKey(type)) return;

        List<Action> list = Evts[type];
        foreach(Action action in list)
        {
            action();
        }
    }
	
}
