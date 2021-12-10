using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class Button_script : MonoBehaviour
{
    public menu_manager manager;
    public GameObject selected;
    public Text description;
    public int id;

    private string [] descriptions;

    private void Awake()
    {
        descriptions = new string [] {
            " Auricular t�ctico est�ndar de los militares Ratnik rusos. Este auricular reduce notablemente las frecuencias altas y medias y aumenta las bajas adem�s reduce ligeramente el sonido ambiente y la intensidad de los disparos propios. Tambi�n aumenta la intensidad de los pasos de los alrededores. Este conjunto de caracter�sticas lo convierte en un headset algo inc�modo en combate cercano pero que ayuda a situar con facilidad pasos y disparos distantes. ",
            " Estos auriculares disminuyen notablemente frecuencias graves y ruidos de impulso, as� como el sonido ambiente, adem�s permiten o�r con gran claridad pasos y conversaciones enemigas pr�ximas gracias a su interacci�n con las frecuencias medias. ",
            " Estos auriculares con protecci�n auditiva mejorada destacan en su capacidad para o�r pasos a larga distancia en superficies duras y conversaciones con mayor claridad.Tambi�n reduce en gran medida la potencia sonora de los disparos. " };

        selected.SetActive(false);
    }
    public void Hover()
    {
        selected.SetActive(true);
        description.text = descriptions[id - 1];
    }
    public void StopHover()
    {
        selected.SetActive(false);
        description.text = " ";
    }
    public void Click()
    {
        manager.Clicked(this.name);
        selected.SetActive(false);
    }
}
