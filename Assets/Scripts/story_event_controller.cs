using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class story_event_controller : MonoBehaviour
{

    public Button ClaimRewardsButton;

    // Start is called before the first frame update
    void Start()
    {
        ClaimRewardsButton = GameObject.Find("ClaimRewardsButton").GetComponent<Button>();
        ClaimRewardsButton.onClick.AddListener(on_claim_rewards);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void on_claim_rewards(){

        //TODO: Update ship data to reflect rewards

        //return to waypoint panel
        SceneManager.LoadScene("waypoint_panel");
    }
}
