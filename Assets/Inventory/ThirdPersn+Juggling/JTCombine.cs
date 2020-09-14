using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class JTCombine : MonoBehaviour
{
    public GameObject Drumstick;
    public GameObject Gongong;

    public GameObject Combine(JTItem a, JTItem b)
    {
        //Returns gameobject created byt the items, null if they can't be combined.
        Debug.Log(a.name);
        Debug.Log(b.name);
        switch (a.name)
        {
            //Drumstick
            case "Stick":
                switch (b.name)
                {
                    case "MushroomHead":
                        return Drumstick;
                }
                break;
            case "MushroomHead":
                switch (b.name)
                {
                    case "Stick":
                        return Drumstick;
                }
                break;

            //Gongong
            case "Rope":
                switch (b.name)
                {
                    case "BronzeDisc":
                        return Gongong;
                }
                break;
            case "BronzeDisc":
                switch (b.name)
                {
                    case "Rope":
                        return Gongong;
                }
                break;

            //GAME OVER
            case "Gongong(Clone)":
                switch (b.name)
                {
                    case "Drumstick(Clone)":
                        SceneManager.LoadScene(1);
                        break;
                }
                break;
            case "Drumstick(Clone)":
                switch (b.name)
                {
                    case "Gongong(Clone)":
                        SceneManager.LoadScene(1);
                        break;
                }
                break;
        }
        return null;
    }
}
