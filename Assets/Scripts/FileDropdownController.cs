using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileDropdownController : MonoBehaviour {

    public GameObject canvas;
    public GameObject canvas2;

	public void PlaySimulation()
    {
        canvas.SetActive(false);
        canvas2.SetActive(true);

        GameObject obj1 = GameObject.Find("player");
        GameObject obj2 = GameObject.Find("floor");
        GameObject obj3 = GameObject.Find("circle");
        if (obj1 != null)
            for (int i = 0; i < obj1.transform.childCount; i++)
                obj1.transform.GetChild(i).GetComponent<SpriteRenderer>().enabled = true;
        if (obj2 != null)
            obj2.GetComponent<SpriteRenderer>().enabled = true;

        if (obj3 != null)
            obj3.GetComponent<SpriteRenderer>().enabled = true;

        if (obj1 == null)
            return;
        if(obj1.GetComponent<Rigidbody2D>() != null)
            obj1.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
    }

    public void BuildGame()
    {
        canvas.SetActive(false);

        GameObject obj1 = GameObject.Find("player");
        GameObject obj2 = GameObject.Find("floor");
        GameObject obj3 = GameObject.Find("circle");
        if (obj1 != null)
            for (int i = 0; i < obj1.transform.childCount; i++)
                obj1.transform.GetChild(i).GetComponent<SpriteRenderer>().enabled = true;
        if (obj2 != null)
            obj2.GetComponent<SpriteRenderer>().enabled = true;

        if (obj3 != null)
            obj3.GetComponent<SpriteRenderer>().enabled = true;

        if (obj1 == null)
            return;

        if (obj1.GetComponent<Rigidbody2D>() != null)
            obj1.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
    }

    public void StopSimulation()
    {
        canvas2.SetActive(false);
        canvas.SetActive(true);

        

        GameObject obj1 = GameObject.Find("player");
        GameObject obj2 = GameObject.Find("floor");
        GameObject obj3 = GameObject.Find("circle");

        if (obj1 != null)
            if (obj1.GetComponent<Rigidbody2D>() != null)
            {
              obj1.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
              obj1.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            }

        if (obj1 != null)
            for (int i = 0; i < obj1.transform.childCount; i++)
                obj1.transform.GetChild(i).GetComponent<SpriteRenderer>().enabled = false;
        if (obj2 != null)
            obj2.GetComponent<SpriteRenderer>().enabled = false;
        if (obj3 != null)
            obj3.GetComponent<SpriteRenderer>().enabled = false;


    }

}
