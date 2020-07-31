using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class savingconfirm : MonoBehaviour
{

    /////////////
    [SerializeField] private spaceship_data ship_data;
    [SerializeField] private shop_data item_data;
    public GameObject health_upgrade;
    public GameObject damage_upgrade;
    public GameObject speed_upgrade;
    public GameObject shield_upgrade;
    ////////////////////////////////////////

    string path = "";
    string savepath = "";
    public InputField inputfield;
    public InputField testing;
    public GameObject Panelsave;
    // Start is called before the first frame update
    void Start()
    {
        Panelsave = GameObject.Find("savepanel");
        Panelsave.SetActive(false);
    }

    public void OpenFolder()
    {
        savepath = EditorUtility.OpenFolderPanel("Overwrite with path name ", "", "");
    }

    public void SavebtnClicked()
    {
        path = savepath;
        inputfield = GameObject.Find("inputfilename").GetComponent<InputField>();
        testing = GameObject.Find("mysaveinputpath").GetComponent<InputField>();


        Regex rx = new Regex(@"^([0-9]|\w)+$");


        if (savepath != null && inputfield.text != "" && inputfield.text != null && rx.IsMatch(inputfield.text))
        {
            path = path + "/" + inputfield.text + ".json";
            testing.text = path;
            Panelsave.SetActive(true);
        }
    }

    public void savecancel()
    {
        Panelsave.SetActive(false);
    }

    public void ChangeToScene()
    {
        SceneManager.LoadScene("myscene");
    }

    public void saveconfirm()
    {
        spaceshipdata hola = new spaceshipdata();
        hola.name = ship_data.ship.name;
        hola.level = ship_data.ship.level;
        hola.hp = ship_data.ship.cur_HP;
        hola.exp = ship_data.ship.cur_exp;
        hola.speed = ship_data.ship.speed;
        hola.shield = ship_data.ship.shield;
        hola.weaponCount = 0;
        hola.weaponList = new List<weaponList>();
        hola.past_WPList = new List<past_WPList>();
        hola.current_WP = 0;
        hola.consumables_count = 0;
        hola.consumables_List = new List<consumables_List>();
        hola.balance = ship_data.money;
        hola.max_hp = ship_data.ship.max_HP;
        hola.damage = ship_data.ship.damage;
        hola.max_exp = ship_data.ship.max_exp;


        string json = JsonUtility.ToJson(hola);
        FileStream fileStream = new FileStream(path, FileMode.Create);
        using (StreamWriter writer = new StreamWriter(fileStream))
        {
            writer.Write(json);
        }

        Panelsave.SetActive(false);
    }
}
