using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Continue : MonoBehaviour
{
    public void on_continue_button(){
        SceneManager.LoadScene("waypoint_panel");
    }
}
