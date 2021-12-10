using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using FMODUnity;
public class Headsets : MonoBehaviour
{
    [SerializeField]
    private int N_headsets = 0;

    public string[] headsets_paths;
    public Image headphones_icon;
    public Text text;
    private bool [] has_headset;
    private string[] texts = {"GSSh-01", "Com Tac_2", "XCELL_500BT"};

    private FMOD.Studio.EventInstance headset_;

    private bool menu = false;

    public AutomaticGunScriptLPFP gun;
    public FPSControllerLPFP.FpsControllerLPFP player;
    public GameObject menu_canvas;

    void Awake()
    {
        has_headset = new bool[N_headsets];
        for (int i = 0; i < N_headsets; i++)
        {
            has_headset[i] = false;
        }
        NoHeadset();
        menu_canvas.SetActive(false);
    }

    void Update()
    {
        ProcessInput();
    }

    private void ProcessInput()
    {

        if (Input.GetKeyDown(KeyCode.H))    //Headset menu
        {
            if (menu)   // Cerrar menú
            {
                CloseMenu();
            }
            else        // Abrir menú
            {
                OpenMenu();
            }

        }
    }

    private void Unequip(bool none)
    {
        int i = 0;
        while (i < N_headsets)
        {
            has_headset[i] = false;
            i++;
        }
        headset_.stop(0);

        if (none) NoHeadset();
    }

    private void SetEquipped(int headset)
    {
        Unequip(false);
        has_headset[headset] = true;

        headset_ = FMODUnity.RuntimeManager.CreateInstance(headsets_paths[headset]);
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(headset_, this.transform);
        headset_.start();
        headset_.release();
        headphones_icon.enabled = true;
        text.text = texts[headset];
        text.enabled = true;
    }

    private void NoHeadset()
    {
        headset_ = FMODUnity.RuntimeManager.CreateInstance("snapshot:/Outside");
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(headset_, this.transform);
        headset_.start();
        headset_.release();
        headphones_icon.enabled = false;
        text.enabled = false;
    }

    public void EnteredBuilding()
    {
        int i = WichEquipped();
        if(i != -1) SetEquipped(i);
    }

    public void SelectedHeadset (int id)
    {
        if (WichEquipped() == id) Unequip(true);
        else SetEquipped(id);

        CloseMenu();
    }

    private void CloseMenu()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        player.pause = false;
        gun.pause = false;
        menu = false;
        menu_canvas.SetActive(false);
    }

    private void OpenMenu()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        player.pause = true;
        gun.pause = true;
        menu = true;
        menu_canvas.SetActive(true);
    }

    private int WichEquipped()
    {
        int i = 0;
        while (i < N_headsets && has_headset[i] == false)
        {
            i++;
        }

        if (i == N_headsets) return -1;
        else return i;
    }
}
