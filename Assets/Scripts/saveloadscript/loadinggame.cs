using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class loadinggame : MonoBehaviour
{
    /////////////
    [SerializeField] private spaceship_data ship_data;
    [SerializeField] private shop_data item_data;
    public GameObject health_upgrade;
    public GameObject damage_upgrade;
    public GameObject speed_upgrade;
    public GameObject shield_upgrade;
    ////////////////////////////////////////

    public InputField inputfield;
    public GameObject Panel;
    // Start is called before the first frame update
    void Start()
    {
        Panel = GameObject.Find("Panel");
        Panel.SetActive(false);
    }

    // Update is called once per frame
    /*void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }*/

    public void ChangeToScene()
    {
        SceneManager.LoadScene("loadgamescene");
        ///System.Diagnostics.Process p = new System.Diagnostics.Process();
        ///p.StartInfo = new System.Diagnostics.ProcessStartInfo("explorer.exe");
        ///_ = p.Start();
    }

    public void ChangeToScene1()
    {
        SceneManager.LoadScene("savegamescene");
        ///System.Diagnostics.Process p = new System.Diagnostics.Process();
        ///p.StartInfo = new System.Diagnostics.ProcessStartInfo("explorer.exe");
        ///_ = p.Start();
    }

    public void quitgame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        //Application.Quit();
    }

    public void newgame()
    {
        Panel.SetActive(true);
    }
    public void cancelnewgame()
    {
        Panel.SetActive(false);
    }
    public void confirmnewgame()
    {
        //enter next scene
        inputfield = GameObject.Find("InputField").GetComponent<InputField>();
        print(inputfield.text);
        string shipname = inputfield.text;

        // init ship_data
        int HP = 100;
        int speed = 5;
        int money = 100;
        ship_data.init3(HP, speed, money, shipname);

        // Init all shop item data
        int cost_inc_per_level = 5;
        int val_inc_per_level = 10;
        item_data.init(cost_inc_per_level, val_inc_per_level);

        Sprite health_upgrade_img = health_upgrade.GetComponent<SpriteRenderer>().sprite;
        Sprite damage_upgrade_img = damage_upgrade.GetComponent<SpriteRenderer>().sprite;
        Sprite speed_upgrade_img = speed_upgrade.GetComponent<SpriteRenderer>().sprite;
        Sprite shield_upgrade_img = shield_upgrade.GetComponent<SpriteRenderer>().sprite;

        string name = "Health Upgrade";
        string type = "Health";
        int level = 1;
        int cost = 10;
        int val = 5;

        this.item_data.add_upgrade(name, type, level, cost, val, health_upgrade_img);

        name = "Damage Upgrade";
        type = "Damage";
        level = 1;
        cost = 15;
        val = 5;

        this.item_data.add_upgrade(name, type, level, cost, val, damage_upgrade_img);

        name = "Shield Upgrade";
        type = "Shield";
        level = 1;
        cost = 10;
        val = 5;

        this.item_data.add_upgrade(name, type, level, cost, val, shield_upgrade_img);

        name = "Speed Upgrade";
        type = "Speed";
        level = 1;
        cost = 5;
        val = 5;

        this.item_data.add_upgrade(name, type, level, cost, val, speed_upgrade_img);

        SceneManager.LoadScene("waypoint_panel");
    }
}
