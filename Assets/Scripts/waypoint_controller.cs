using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class waypoint_controller : MonoBehaviour
{
    public Button ShipDataButton;
    public Button InstructionsButton;
    public Button MapButton;

    [SerializeField] private event_data events;

    // Start is called before the first frame update
    void Start()
    {
        //DontDestroyOnLoad(gameObject);
        ShipDataButton = GameObject.Find("ShipDataButton").GetComponent<Button>();
        InstructionsButton = GameObject.Find("InstructionsButton").GetComponent<Button>();
        MapButton = GameObject.Find("MapButton").GetComponent<Button>();
        ShipDataButton.onClick.AddListener(open_ship_data);
        InstructionsButton.onClick.AddListener(open_instructions);
        MapButton.onClick.AddListener(open_map);

        events.init();
        events.add_event("Raid", "Battle", "Space Priates are attacking the ship. Defeat Them!");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Go to Ship data Scene
    void open_ship_data(){
        SceneManager.LoadScene("ship_specs");
    }

    // Go to Instructions scene
    void open_instructions(){
        SceneManager.LoadScene("ship_specs");
    }

    // Go to Map Scene
    void open_map(){
        SceneManager.LoadScene("map_screen");
    }


}
