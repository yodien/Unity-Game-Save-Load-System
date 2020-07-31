using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Event
{
    private string name;
    private string event_type;
    private string context;

    public Event(string name, string event_type, string context){
        this.name = name;
        this.event_type = event_type;
        this.context = context;
    }

    public string get_name(){
        return this.name;
    }

    public string get_event_type(){
        return this.event_type;
    }

    public string get_context(){
        return this.context;
    }
}