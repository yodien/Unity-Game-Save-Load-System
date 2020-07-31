using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class information_controller : MonoBehaviour
{
    public Button BackButton; 

    [SerializeField] private event_data events;

    // Start is called before the first frame update
    void Start()
    {
        BackButton = GameObject.Find("BackButton").GetComponent<Button>();
        BackButton.onClick.AddListener(go_back);


        events.print_events();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void go_back(){
        SceneManager.LoadScene("waypoint_panel");
    }
}
