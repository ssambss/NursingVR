using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvaaLuukku : MonoBehaviour
{
    
    public string isTDopen = "n";
    public string isLDopen = "n";

    public GameObject luukkuBlood, LuukkuInfusion;

    public void AvaudutaanYhdessa()
    {
        if (gameObject.name == "Luukku")
        {
            if (isTDopen == "n")
            {
                GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -1);
                isTDopen = "o";
                StartCoroutine(stopDrawer());
            }
            else if (isTDopen == "y")
            {
                GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 1);
                isTDopen = "c";
                StartCoroutine(stopDrawer());
            }
        }

        if (gameObject.name == "LuukkuTwo")
        {
            if (isLDopen == "n")
            {
                GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -1);
                isLDopen = "o";
                StartCoroutine(stopDrawerTwo());
            }
            else if (isLDopen == "y")
            {
                GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 1);
                isLDopen = "c";
                StartCoroutine(stopDrawerTwo());
            }
        }
    }

    IEnumerator stopDrawer()
    {
        yield return new WaitForSeconds(2);
        if (isTDopen == "o")
        {
            isTDopen = "y";
        }
        if (isTDopen == "c")
        {
            isTDopen = "n";
        }
    }

    IEnumerator stopDrawerTwo()
    {
        yield return new WaitForSeconds(2);
        if (isLDopen == "o")
        {
            isLDopen = "y";
        }
        if (isLDopen == "c")
        {
            isLDopen = "n";
        }
    }

    //[SerializeField] private Animator avaaLuukku;

    //[SerializeField] private string onAuki = "onAuki";
    //[SerializeField] private string onKiinni = "onKiinni";
    //public bool kiinni;
    //public Transform luukkuAsento;

    /*public void LuukkuAnimaatio()
    {
        if (kiinni == false)
        {
            avaaLuukku.Play(onAuki, 0, 0.0f);
            kiinni = true;
        }
        else
        {
            avaaLuukku.Play(onKiinni, 0, 0.0f);
        }
        
    }*/

    /*public void LuukkuAnimaatioKiinni()
    {
        avaaLuukku.Play(onKiinni, 0, 0.0f);
    }*/

}
