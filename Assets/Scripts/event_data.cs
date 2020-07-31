using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "event_data", menuName = "event_data")]
public class event_data : ScriptableObject
{
    private List<Event> events = null;

    public void init(){
        this.events = new List<Event>();
    }

    public void add_event(string name, string event_type, string context){
        Event new_event = new Event(name, event_type, context);
        this.events.Add(new_event);
    }

    public void print_events(){
        foreach (var evn in this.events)
        {
            Debug.Log(evn.get_name());
            Debug.Log(evn.get_event_type());
            Debug.Log(evn.get_context());
        }
    }
}




