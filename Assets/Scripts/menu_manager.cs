using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class menu_manager : MonoBehaviour
{
    public Headsets headsets_script_;
    public void Clicked(string name)
    {
        switch (name)
        {
            case "Button":
                headsets_script_.SelectedHeadset(0);
                break;

            case "Button 1":
                headsets_script_.SelectedHeadset(1);
                break;

            case "Button 2":
                headsets_script_.SelectedHeadset(2);
                break;

            default:
                break;
        }
    }
}
