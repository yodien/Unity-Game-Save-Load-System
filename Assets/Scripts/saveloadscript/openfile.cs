using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class openfile : MonoBehaviour
{
    /// //
    [SerializeField] private spaceship_data ship_data;
    [SerializeField] private shop_data item_data;
    public GameObject health_upgrade;
    public GameObject damage_upgrade;
    public GameObject speed_upgrade;
    public GameObject shield_upgrade;
    /// /////////////////////////////////////////////////////////////////

    string path = "";
    //string savepath = "";
    public InputField inputfield;
    //public InputField testing;

    public GameObject Panelload;
    //public GameObject Panelsave;
    // Start is called before the first frame update
    void Start()
    {
        Panelload = GameObject.Find("loadpanel");
        Panelload.SetActive(false);

       // Panelsave = GameObject.Find("savepanel");
        //Panelsave.SetActive(false);
    }

    // Update is called once per frame
    /*void Update()
    {
        
    }*/
    
    /*public void OpenFolder()
    {
        savepath = EditorUtility.OpenFolderPanel("Overwrite with path name ", "", "");
    }*/

    public void OpenExplore()
    {
        path = EditorUtility.OpenFilePanel("Overwrite with path name ", "", "");
        GetFilePathh();
    } 

    void GetFilePathh()
    {
        if (path != null)
        {
            UpdatePath();
        }
    }

    void UpdatePath()
    {
        inputfield = GameObject.Find("myloadinputpath").GetComponent<InputField>();
        inputfield.text = path;
    }

    public void ChangeToScene()
    {
        SceneManager.LoadScene("myscene");
    }

    /*public void SavebtnClicked()
    {
        path = savepath;
        inputfield = GameObject.Find("inputfilename").GetComponent<InputField>();
        testing = GameObject.Find("mysaveinputpath").GetComponent<InputField>();


        Regex rx = new Regex(@"^([0-9]|\w)+$");


        if (savepath!= null && inputfield.text!="" && inputfield.text != null && rx.IsMatch(inputfield.text))
        {
            path = path + "/" + inputfield.text + ".json";
            testing.text = path;
            Panelsave.SetActive(true);
        }
    }*/

    public void loadbtnclicked()
    {
        if (inputfield.text != null && inputfield.text != "")
        {
            Panelload.SetActive(true);
        }
        
    }

    public void loadcancel()
    {
        Panelload.SetActive(false);
    }

    public void loadconfirm()
    {
        //to waypoint scene here-----should replace this comment with the changeScene code
        spaceshipdata shipdata = new spaceshipdata();
        using (StreamReader reader = new StreamReader(path))
        {
            string json = reader.ReadToEnd();
            JsonUtility.FromJsonOverwrite(json, shipdata);
        }
        print(shipdata.max_hp);
        print(shipdata.hp);
        print(shipdata.speed);
        print(shipdata.shield);
        print(shipdata.level);
        print(shipdata.exp);
        print(shipdata.max_exp);
        print(shipdata.damage);
        print(shipdata.name);
        print(shipdata.balance);
        ////////////////////////////////////////////
        ship_data.init2(shipdata.max_hp, shipdata.hp, shipdata.speed, shipdata.shield, shipdata.level, shipdata.exp, shipdata.max_exp, shipdata.damage, shipdata.name, shipdata.balance);
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
