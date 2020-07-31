using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class backtosave : MonoBehaviour
{
    /// //
    [SerializeField] private spaceship_data ship_data;
    [SerializeField] private shop_data item_data;
    public GameObject health_upgrade;
    public GameObject damage_upgrade;
    public GameObject speed_upgrade;
    public GameObject shield_upgrade;

    /// /////////////////////////////////////////////////////////////////
    
    public void backtomain()
    {
        SceneManager.LoadScene("myscene");
    }
}
