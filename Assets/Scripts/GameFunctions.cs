using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class will have all functions to create the game, within GamePix.
/// </summary>
public class GameFunctions : MonoBehaviour
{
    private CodeManager code;
    private DialogManager dialogManager;

    private float pixelFactor = 8f;
    private float colorFactor = 255f;
    private float gravityFactor = -9.81f;

    private float velX = 0;
    private float velY = 0;
    private float jumpForce = 0;

    private KeyCode left;
    private KeyCode right;
    private KeyCode up;
    private KeyCode down;
    private KeyCode jump;

    public GameObject planeX;
    public GameObject planeY;
    public GameObject square;
    public GameObject circle;
    public GameObject circleFill;
    public GameObject r;

    private string col1 = "";
    private string col2 = "";
    private string col3 = "";

    private bool invoked = false;

    private void Awake()
    {
        code = FindObjectOfType<CodeManager>();
        dialogManager = FindObjectOfType<DialogManager>();
    }
    private void Update()
    {
        GameObject obj = GameObject.Find("player");
        if (obj == null)
            return;

        if (Input.GetKey(left))
            obj.transform.Translate(-velX * Time.deltaTime, 0, 0);
        else if (Input.GetKey(right))
            obj.transform.Translate(velX * Time.deltaTime, 0, 0);
        else if (Input.GetKey(up))
            obj.transform.Translate(0, velY * Time.deltaTime, 0);
        else if (Input.GetKey(down))
            obj.transform.Translate(0, -velY * Time.deltaTime, 0);
        if (Input.GetKey(jump))
            obj.GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpForce;
    }
    public void CreateBody(string varName, int childsCount)
    {
        GameObject obj;

        if (childsCount != 0)
            obj = new GameObject();
        else
            obj = Instantiate(square, Vector2.zero, Quaternion.identity);

        obj.name = varName;
        obj.transform.localScale = Vector3.one;
        obj.transform.position = Vector3.zero;

        for(int i = 0; i < childsCount; i++)
        {
            GameObject objChild = Instantiate(square, obj.transform);
            objChild.name = "child " + (i + 1);
            objChild.transform.localScale = Vector3.one;
            objChild.transform.localPosition = Vector3.zero;
        }

        for (int i = 0; i < obj.transform.childCount; i++)
            obj.transform.GetChild(i).GetComponent<SpriteRenderer>().enabled = false;
        code.CodeSentence("'Body " + varName + " " + childsCount.ToString());
        dialogManager.DialogSentence("You have just created a body named: " + varName + " with " + childsCount.ToString() + " childs.", "<color=cyan>Excelent:   </color>", 6);
    }

    public void CreatePlaneX(string varName, float yPosition)
    {
        GameObject obj = Instantiate(planeX, new Vector3(0, yPosition, 0), Quaternion.identity);
        obj.name = varName;

        obj.GetComponent<SpriteRenderer>().enabled = false;

        code.CodeSentence("'PlaneX " + varName + " " + yPosition.ToString());
        dialogManager.DialogSentence("You have just created a body named: " + varName + " at y = "+ yPosition.ToString(), "<color=cyan>Nice:   </color>", 1);
    }

    public void CreatePlaneY(string varName, float xPosition)
    {
        GameObject obj = Instantiate(planeY, new Vector3(xPosition, 0, 0), Quaternion.identity);
        obj.name = varName;

        obj.GetComponent<SpriteRenderer>().enabled = false;

        code.CodeSentence("'PlaneY " + varName + " " + xPosition.ToString());
        dialogManager.DialogSentence("You have just created a body named: " + varName + " at x = " + xPosition.ToString(), "<color=cyan>Good Job:   </color>", 1);
    }

    public void CreateSquare(string varName, float width)
    {
        GameObject obj = Instantiate(square, Vector3.zero, Quaternion.identity);
        obj.name = varName;
        obj.transform.localScale = new Vector2(width, width);

        obj.GetComponent<SpriteRenderer>().enabled = false;

        code.CodeSentence("'Square " + varName + " " + width.ToString());
        dialogManager.DialogSentence("You have just created a square named: " + varName + " with a size of " + width.ToString() + " units pixels", "<color=cyan>Good Job:   </color>", 1);
    }

    public void CreateCircle(string varName, float radious)
    {
        GameObject obj = Instantiate(circle, Vector2.zero, Quaternion.identity);
        obj.name = varName;
        obj.transform.localScale = new Vector2(radious, radious);

        obj.GetComponent<SpriteRenderer>().enabled = false;

        code.CodeSentence("'Circle " + varName + " " + radious.ToString());
        dialogManager.DialogSentence("You have just created a circle named: " + varName + " with a radious of " + radious.ToString() + " units pixels", "<color=cyan>Nice:   </color>", 6);
    }

    public void CreateCircleFill(string varName, float radious)
    {
        GameObject obj = Instantiate(circleFill, Vector2.zero, Quaternion.identity);
        obj.name = varName;
        obj.transform.localScale = new Vector2(radious, radious);

        obj.GetComponent<SpriteRenderer>().enabled = false;

        code.CodeSentence("'CircleFill " + varName + " " + radious.ToString());
        dialogManager.DialogSentence("You have just created a circle filled named: " + varName + " with a radious of " + radious.ToString() + " units pixels", "<color=cyan>Nice:   </color>", 1);
    }

    public void SetPosition(string varName, float x, float y)
    {
        GameObject obj = GameObject.Find(varName);
        if (obj == null)
        {
            // OBJECT WITH NAME IN VARNAME DOESN'T EXISTS
            return;
        }
        obj.transform.position = new Vector2(x/pixelFactor, y/pixelFactor);
        code.CodeSentence("~SetPosition " + varName + " " + x.ToString() + " " + y.ToString());
        dialogManager.DialogSentence("You have just set a new position to object: " + varName + " at x = " + x.ToString() + ", y = " + y.ToString(), "<color=cyan>Perfect:   </color>", 6);
    }

    public void SetLocalPosition(string varName, int child, float localX, float localY)
    {
        GameObject obj = GameObject.Find(varName);
        if (obj == null)
        {
            // OBJECT WITH NAME IN VARNAME DOESN'T EXISTS
            return;
        }
        obj.transform.GetChild(child).localPosition = new Vector2(localX/pixelFactor, localY/pixelFactor);
        code.CodeSentence("~SetLocalPosition " + varName + " " + child.ToString() + " " + localX.ToString() + " " + localY.ToString());
        dialogManager.DialogSentence("You have just set a new local position to child: " + child.ToString() + " of object: " + varName + " at x = " + localX.ToString() + ", y = " + localY.ToString(), "<color=cyan>Perfect:   </color>", 6);
    }

    public void ColorAll(string varName, Color color)
    {
        GameObject obj = GameObject.Find(varName);
        if(obj == null)
        {
            // OBJECT WITH NAME IN VARNAME DOESN'T EXISTS
            return;
        }
        int childCount = obj.transform.childCount;
        for(int i = 0; i < childCount; i++)
        {
            obj.transform.GetChild(i).GetComponent<SpriteRenderer>().color = color;
        }
        code.CodeSentence("~ColorAll " + varName + " " + color.ToString());
        dialogManager.DialogSentence("You have just change the color of object: " + varName, "<color=cyan>Nice:   </color>",1);
    }

    public void ColorChild(string varName, int child, Color color)
    {
        GameObject obj = GameObject.Find(varName);
        if(obj == null)
        {
            // OBJECT WITH NAME IN VARNAME DOESN'T EXISTS
            return;
        }
        obj.transform.GetChild(child).GetComponent<SpriteRenderer>().color = color;
        code.CodeSentence("~ColorChild " + varName + " " + child.ToString() + " " + color.ToString());
        dialogManager.DialogSentence("You have just change the color of child: " + child.ToString() + " of object: " + varName, "<color=cyan>Nice:   </color>", 1);
    }

    public void Gravity(string varName, float gravity)
    {
        GameObject obj = GameObject.Find(varName);
        if(obj == null)
        {
            // OBJECT WITH NAME IN VARNAME DOESN'T EXISTS
            return;
        }
        if (obj.GetComponent<Rigidbody2D>() == null)
            obj.AddComponent<Rigidbody2D>();

        obj.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        obj.GetComponent<Rigidbody2D>().gravityScale = (gravity / gravityFactor);
        code.CodeSentence("~Gravity " + varName + " " + gravity.ToString());
        dialogManager.DialogSentence("You have just add a gravity of: " + gravity.ToString() + " to object" + varName, "<color=cyan>Neet:   </color>", 6);
    }

    public void BoxCollider(string varName, bool collide)
    {
        GameObject obj = GameObject.Find(varName);
        if(obj == null)
        {
            // OBJECT WITH NAME IN VARNAME DOESN'T EXISTS
            return;
        }

        int childCount = obj.transform.childCount;

        if (childCount > 0)
        {
            for(int i = 0; i < childCount; i++)
            {
                obj.transform.GetChild(i).GetComponent<BoxCollider2D>().enabled = collide;
            }
        }
        else
        {
            if (obj.GetComponent<BoxCollider2D>() == null)
                obj.AddComponent<BoxCollider2D>();
            obj.GetComponent<BoxCollider2D>().enabled = collide;
        }
        code.CodeSentence("~BoxCollider " + varName + " " + collide.ToString());
        dialogManager.DialogSentence("You have just set the box collider of object: " + varName + " to " + collide.ToString(), "<color=cyan>Neet:   </color>", 1);
    }

    public void CircleCollider(string varName, bool collide)
    {
        GameObject obj = GameObject.Find(varName);
        if (obj == null)
        {
            // OBJECT WITH NAME IN VARNAME DOESN'T EXISTS
            return;
        }

        if (obj.GetComponent<CircleCollider2D>() == null)
            obj.AddComponent<CircleCollider2D>();
        obj.GetComponent<CircleCollider2D>().enabled = collide;
        code.CodeSentence("~CircleCollider " + varName + " " + collide.ToString());
        dialogManager.DialogSentence("You have just set the circle collider of object: " + varName + " to " + collide.ToString(), "<color=cyan>Nice:   </color>", 1);
    }

    public void SpeedX(string varName, float velocityX, KeyCode left, KeyCode right)
    {
        GameObject obj = GameObject.Find(varName);
        if(obj == null)
        {
            // OBJECT WITH NAME VARNAME DOESN'T EXISTS.
            return;
        }
        else if(obj.name == "player")
        {
            velX = velocityX;
            this.left = left;
            this.right = right;
        }

        code.CodeSentence("~SpeedX " + varName + " " + velocityX.ToString() + " " + left.ToString() + " " + right.ToString());
        dialogManager.DialogSentence("You have just set the speed X of object: " + varName + " to " + velocityX.ToString() + " and can be control with keys " + left.ToString() + "-" + right.ToString(), "<color=cyan>Excelent:   </color>", 6);
    }

    public void SpeedY(string varName, float velocityY, KeyCode up, KeyCode down)
    {
        GameObject obj = GameObject.Find(varName);
        if(obj == null)
        {
            // OBJECT WITH NAME VARNAME DOESN'T EXISTS.
            return;
        }
        else if(obj.name == "player")
        {
            velY = velocityY;
            this.up = up;
            this.down = down;
        }

        code.CodeSentence("~SpeedY " + varName + " " + velocityY.ToString() + " " + up.ToString() + " " + down.ToString());
        dialogManager.DialogSentence("You have just set the speed Y of object: " + varName + " to " + velocityY.ToString() + " and can be control with keys " + up.ToString() + "-" + down.ToString(), "<color=cyan>Excelent:   </color>", 6);
    }

    public void SpeedXLoop(string varName, float velocityX)
    {
        GameObject obj = GameObject.Find(varName);
        if (obj == null)
        {
            // OBJECT WITH NAME VARNAME DOESN'T EXISTS.
            return;
        }
        code.CodeSentence("~SpeedXLoop " + varName + " " + velocityX.ToString());
        dialogManager.DialogSentence("You have just set the speed X of object: " + varName + " to " + velocityX.ToString(), "<color=cyan>Excelent:   </color>", 1);
    }

    public void SpeedYLoop(string varName, float velocityY)
    {
        GameObject obj = GameObject.Find(varName);
        if(obj == null)
        {
            // OBJECT WITH NAME VARNAME DOESN'T EXISTS. 
            return;
        }



        code.CodeSentence("~SpeedYLoop " + varName + " " + velocityY.ToString());
        dialogManager.DialogSentence("You have just set the speed Y of object: " + varName + " to " + velocityY.ToString(), "<color=cyan>Good Job:   </color>", 6);
    }

    public void Jumpforce(string varName, float force, KeyCode jump)
    {
        GameObject obj = GameObject.Find(varName);
        if (obj == null)
        {
            // OBJECT WITH NAME VARNAME DOESN'T EXISTS.
            return;
        }
        else if (obj.name == "player")
        {
            jumpForce = force;
            this.jump = jump;
        }

        code.CodeSentence("~Jumpforce " + varName + " " + force.ToString() + " " + jump.ToString());
        dialogManager.DialogSentence("You have just set the jumpforce of object: " + varName + " to " + force.ToString() + " with the key "  + jump.ToString(), "<color=cyan>Perfect:   </color>", 1);
    }   

    public void Destroy(string varName)
    {
        GameObject obj = GameObject.Find(varName);
        if(obj == null)
        {
            // OBJECT WITH NAME IN VARNAME DOESN'T EXISTS
            return;
        }
        Destroy(obj);
        code.CodeSentence("~Destroy " + varName);
        dialogManager.DialogSentence("You have just Destroyed object: " + varName, "<color=cyan>Great:   </color>", 6);
    }

    public void MakeInvisible(string varName, bool invisible)
    {
        GameObject obj = GameObject.Find(varName);
        if(obj == null)
        {
            // OBJECT WITH NAME IN VARNAME DOESN'T EXIST
            return;
        }

        if(obj.GetComponent<SpriteRenderer>() == null)
        {
            // OBJECT DOESN'T HAVE PIXELS IN IT.
            return;
        }

        obj.GetComponent<SpriteRenderer>().enabled = invisible;
        code.CodeSentence("~MakeInvisible " + varName + " " + invisible.ToString());
        dialogManager.DialogSentence("You have just set the invisibility of object: " + varName + " to " + invisible.ToString(), "<color=cyan>Excelent:   </color>", 1);
    }

    public void RainInstantiate(string varName, int maxLeft, float maxRight, float time)
    {
        InvokeRepeating("rain", 28, time);

        code.CodeSentence("'RainInstantiate " + varName + " " + maxLeft.ToString() + " " + maxRight.ToString() + " " + time.ToString());
        dialogManager.DialogSentence("You have just create a Rain of objects called: " + varName + "with random X position between: " + maxLeft.ToString() + " " + maxRight.ToString() + " for every " +time.ToString()+ " seconds." + " <color=cyan> Excelent:   </color> ", 1);
    }

    public void rain()
    {
        float num = Random.Range(-9, 9);

        Instantiate(r, new Vector3(num, 5.2f, 0), Quaternion.identity);
    }

    public void DestroyInCollision(string firstObj, string secondObj, int which)
    {
        // check collision
        code.CodeSentence("~DestroyInCollision " + firstObj + " " + secondObj + " " + which.ToString());
        dialogManager.DialogSentence("You have just set the DestroyInCollision for objects: " + firstObj + "-" + secondObj + " <color=cyan>Excelent:   </color> ", 1);
    }

    public void Helpcfn()
    {
        code.CodeSentence("~Helpcfn");
        dialogManager.DialogSentence("All the creative funcions are: 'Body  'PlaneX  'PlaneY  'Square  'Circle  'CircleFill  'RainInstantiate", "<color=lime>Help:   </color>", 0);
    }
    
    public void Helpnfn()
    {
        code.CodeSentence("~Helpnfn");
        dialogManager.DialogSentence("All the normal functions are: ~SetPosition  ~SetLocalPosition  ~ColorAll  ~ColorChild  " + 
            "~Gravity  ~BoxCollider  ~CircleCollider  ~SpeedX  ~SpeedXLoop  ~SpeedY  ~SpeedYLoop  ~Jumpforce  ~Destroy  ~MakeInvisible  ~DestroyInCollision", "<color=lime>Help:   </color>", 0);
    }
}
