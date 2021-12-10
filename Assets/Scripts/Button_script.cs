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
            " Auricular táctico estándar de los militares Ratnik rusos. Este auricular reduce notablemente las frecuencias altas y medias y aumenta las bajas además reduce ligeramente el sonido ambiente y la intensidad de los disparos propios. También aumenta la intensidad de los pasos de los alrededores. Este conjunto de características lo convierte en un headset algo incómodo en combate cercano pero que ayuda a situar con facilidad pasos y disparos distantes. ",
            " Estos auriculares disminuyen notablemente frecuencias graves y ruidos de impulso, así como el sonido ambiente, además permiten oír con gran claridad pasos y conversaciones enemigas próximas gracias a su interacción con las frecuencias medias. ",
            " Estos auriculares con protección auditiva mejorada destacan en su capacidad para oír pasos a larga distancia en superficies duras y conversaciones con mayor claridad.También reduce en gran medida la potencia sonora de los disparos. " };

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
