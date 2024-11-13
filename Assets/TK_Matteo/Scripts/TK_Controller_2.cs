using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TK_Controller_2 : MonoBehaviour
{
    [Header("UI")]
    [Header("Feed Me!")]
    [Header("--------------------------------------")]
    [Header("TELEKINETIC POWERS")]
    public string cameraTag = "MainCamera";
    public string textTag = "TagText";

    [Header("Tk Pull")]
    [Tooltip("List of layers interactable with the TK pull")]
    public LayerMask layersTkPull;
    [Tooltip("Tag used to interact with TK Pull lv1")]
    public string tagLv1 = "lv1Obj";
    [Tooltip("Tag used to interact with TK Pull lv2")]
    public string tagLv2 = "lv2Obj";
    [Tooltip("Tag used to interact with TK Pull lv3")]
    public string tagLv3 = "lv3Obj";

    [Header("Debris")]
    [Tooltip("Tag used to identify instantiated debris (objects with this tag are destroyed after a given amount of time once released into the world)")]
    public string debrisTag = "Debris";
    [Tooltip("Layer used to identify instantiated debris")]
    public string debrisLayer = "Debris";

    [Header("Shield")]
    [Tooltip("Tag used to identify shield pieces (objects with this tag are destroyed after a given amount of time once released into the world)")]
    public string shieldPieceTag = "Debris";
    [Tooltip("Layer used to identify shield pieces")]
    public string shieldPieceLayer = "ShieldPiece";

    [Tooltip("Tag used to identify the shield collider")]
    public string shieldColliderTag = "ShieldCollider";
    [Tooltip("Layer used to identify the shield collider")]
    public string shieldColliderLayer = "ShieldCol";

    [Header("Levitate")]
    [Tooltip("List of Layers considered as ground")]
    public LayerMask groundLayers;

    [Header("Models")]
    [Tooltip("Model to instantiate (the prefab has to be located in the Resources folder)")]
    public string debrisModel = "Debris";
    [Tooltip("Model to instantiate (the prefab has to be located in the Resources folder)")]
    public string shieldPieceModel = "DebrisS";
    [Tooltip("Model to instantiate (the prefab has to be located in the Resources folder)")]
    public string shieldColliderModel = "ShieldCollider";

    [Header("Tk Pull")]
    [Header("Levels")]
    [Header("--------------------------------------")]
    [Tooltip("Basic TK pull")]
    public bool forcePullLv1 = false;
    [Tooltip("Enhance TK pull")]
    public bool forcePullLv2 = false;
    [Tooltip("Further enhance TK pull")]
    public bool forcePullLv3 = false;
    [Header("Shield")]
    [Tooltip("Basic shield")]
    public bool shieldLv1 = false;
    [Tooltip("Enhance shield")]
    public bool shieldLv2 = false;
    [Header("Levitate")]
    [Tooltip("Basic levitate")]
    public bool levitateLv1 = false;
    [Tooltip("Enhance levitate")]
    public bool levitateLv2 = false;

    [Header("Telekinetic Pull Parameters")]
    [Header("--------------------------------------")]
    [Tooltip("Max pull range")]
    public float maxRange = 30f;
    [Tooltip("Force applied to the target to move it " +
             "from its position to its floating location")]
    public float tkPullForce = 20f;
    [Tooltip("Force applied to throw the held object")]
    public float throwForce = 70f;
    [Tooltip("Held object's drag")]
    public float heldObjDrag = 7f;

    [Header("Debris")]
    [Tooltip("Debris life span once released in the game world")]
    public float debrisLifespan = 2.0f;

    [Header("Shield Parameters")]
    [Header("--------------------------------------")]
    [Tooltip("Force applied to the target to move it " +
             "from its position to its floating location")]
    public float shieldPullForce = 10f;
    [Tooltip("Force applied to throw the shield pieces")]
    public float shieldThrowForce = 50f;
    [Tooltip("Shield's drag")]
    public float shieldDrag = 5f;

    [Header("Shield Pieces")]
    [Tooltip("Number of pieces to instatiate")]
    public int numShieldPieces = 200;
    [Tooltip("Number of columns to build the grid")]
    public int numOfColumns = 20;
    [Tooltip("Horizontal space between two pieces")]
    public float horizontalSpacing = 0.1f;
    [Tooltip("Vertical space between two pieces")]
    public float verticalSpacing = 0.1f;
    [Tooltip("Shield piece life span once released in the game world")]
    public float shieldPiecesLifeSpan = 2.0f;

    [Header("Shield Pieces Chaos Movement")]
    [Tooltip("Min x Oscillation Range")]
    public float xMin = -1;
    [Tooltip("Max x oscillation range")]
    public float xMax = 1;
    [Header("Chaos Movement Y Oscillation Range")]
    [Tooltip("Min y oscillation range")]
    public float yMin = -1;
    [Tooltip("Max y oscillation range")]
    public float yMax = 1;
    [Header("Chaos Movement Z Oscillation Range")]
    [Tooltip("Min z oscillation range")]
    public float zMin = -1;
    [Tooltip("Max z oscillation range")]
    public float zMax = 1;

    [Header("Levitate Parameters")]
    [Header("--------------------------------------")]
    [Tooltip("Distance from the ground to be considered 'grounded'")]
    public float groundTolerance = 1f;

    [Header("Level 1")]
    [Tooltip("Ascent speed Level 1")]
    public float speedUpLv1 = 20;
    [Tooltip("Descent speed Level 1")]
    public float speedDownLv1 = 10;
    [Tooltip("How long is possible to float mid-air Level 1")]
    public float floatTimeLv1 = 3f;
    [Tooltip("Maximum floating height")]
    public float maxHLv1 = 20f;

    [Header("Level 2")]
    [Tooltip("Ascent speed Level 2")]
    public float speedUpLv2 = 30;
    [Tooltip("Descent speed Level 2")]
    public float speedDownLv2 = 15;
    [Tooltip("How long is possible to float mid-air Level 2")]
    public float floatTimeLv2 = 5f;
    [Tooltip("Increased max floating height")]
    public float maxHLv2 = 30f;

    [Header("Coordinates Editing")]
    [Header("--------------------------------------")]

    [Tooltip("Enable/Disable runtime editig")]
    public bool runtimeEditing = true;

    [Header("Held Object Floating Position Level 1")]
    [Tooltip("X coordinate of the position")]
    public float xPosLv1 = 2.15f;
    [Tooltip("Y coordinate of the position")]
    public float yPosLv1 = 2.25f;
    [Tooltip("Z coordinate of the position")]
    public float zPosLv1 = 3.2f;

    [Header("Held Object Floating Position Level 2")]
    [Tooltip("X coordinate of the position")]
    public float xPosLv2 = 2;
    [Tooltip("Y coordinate of the position")]
    public float yPosLv2 = 2.4f;
    [Tooltip("Z coordinate of the position")]
    public float zPosLv2 = 4.35f;

    [Header("Held Object Floating Position Level 3")]
    [Tooltip("X coordinate of the position")]
    public float xPosLv3 = 2.7f;
    [Tooltip("Y coordinate of the position")]
    public float yPosLv3 = 2.85f;
    [Tooltip("Z coordinate of the position")]
    public float zPosLv3 = 5.65f;

    [Header("Debris Floating Position")]
    [Tooltip("X coordinate of the position")]
    public float xPosDebris = 1.6f;
    [Tooltip("Y coordinate of the position")]
    public float yPosDebris = 2.4f;
    [Tooltip("Z coordinate of the position")]
    public float zPosDebris = 2.7f;

    [Header("Debris Spawn Position Offset")]
    [Tooltip("X offset from the camera")]
    public float xOffsetDebris = 6f;
    [Tooltip("Y offset from the camera")]
    public float yOffsetDebris = 2f;
    [Tooltip("Z offset from the camera")]
    public float zOffsetDebris = 8f;

    [Header("Shield Origin Location")]
    [Tooltip("X coordinate of the origin")]
    public float xShieldPos = -0.7f;
    [Tooltip("Y coordinate of the origin")]
    public float yShieldPos = 0.8f;
    [Tooltip("Z coordinate of the origin")]
    public float zShieldPos = 2;

    [Header("Shield Collider Offset")]
    [Tooltip("X offset from the player")]
    public float xOffsetShield = 0f;
    [Tooltip("Y offset from the player")]
    public float yOffsetShield = 2f;
    [Tooltip("Z offset from the player")]
    public float zOffsetShield = 2f;
    
    private Camera playerCam;
    //private Rigidbody playerRb;
    //private Collider playerCollider;
    private GameObject heldObject;
    private bool shieldActive;
    private bool levitate;
    private GameObject heldObjPos;
    private GameObject heldObjPosM;
    private GameObject heldObjPosL;
    private GameObject heldDebrisPos;
    private GameObject shieldOrigin;
    private GameObject shieldCol;
    private List<GameObject> spawnedObjsList = new List<GameObject>();
    private List<GameObject> gridPosList = new List<GameObject>();
    private float currentH;
    private float airborne;
    private float relMaxH;
    public enum LevitateState 
    {
        Grounded,
        Jump,
        Ascent,
        Float,
        Descent
    };
    private LevitateState currentLevitateState;
    private Text displayTagText;

    //public LayerMask enemyLayers;

    void Awake()
    {
        heldObjPos = InstantiateHeldPosition(xPosLv1, yPosLv1, zPosLv1);
        heldObjPosM = InstantiateHeldPosition(xPosLv2, yPosLv2, zPosLv3);
        heldObjPosL = InstantiateHeldPosition(xPosLv3, yPosLv3, zPosLv3);
        heldDebrisPos = InstantiateHeldPosition(xPosDebris, yPosDebris, zPosDebris);
        shieldOrigin = InstantiateShieldGrid(shieldOrigin, gridPosList, numShieldPieces, xShieldPos, yShieldPos, zShieldPos, 
                                             numOfColumns, horizontalSpacing, verticalSpacing);
      
        playerCam = GameObject.FindGameObjectWithTag(cameraTag).GetComponent<Camera>();
        shieldCol = InstantiateShieldCollider(shieldColliderModel, xOffsetShield, yOffsetShield, zOffsetShield, shieldColliderTag, shieldColliderLayer);
        displayTagText = GameObject.FindGameObjectWithTag(textTag).GetComponent<Text>();
    }

    void Start()
    {
        heldObject = null;
        shieldActive = false;
        shieldCol.GetComponent<Collider>().enabled = false;
        levitate = false;

        // Physic
        Physics.IgnoreLayerCollision(LayerMask.NameToLayer(shieldPieceLayer), LayerMask.NameToLayer(shieldColliderLayer), true);
    }

    private void FixedUpdate()
    {
        // Tools
        Debug.DrawRay(playerCam.transform.position, playerCam.transform.forward * maxRange, Color.red);
        TagPrinter(playerCam, displayTagText);

        // Runtime Editable Variables
        if (runtimeEditing)
        {
            UpdateHeldPosition(heldObjPos, xPosLv1, yPosLv1, zPosLv1);
            UpdateHeldPosition(heldObjPosM, xPosLv2, yPosLv2, zPosLv2);
            UpdateHeldPosition(heldObjPosL, xPosLv3, yPosLv3, zPosLv3);
            UpdateHeldPosition(heldDebrisPos, xPosDebris, yPosDebris, zPosDebris);
            foreach (GameObject obj in gridPosList)
            {
                UpdateHeldPosition(obj,
                                   xShieldPos + horizontalSpacing * (gridPosList.IndexOf(obj) % numOfColumns),
                                   yShieldPos + verticalSpacing * (gridPosList.IndexOf(obj) / numOfColumns),
                                   zShieldPos);
            }
            UpdateShieldColliderPosition(shieldCol, xOffsetShield, yOffsetShield, zOffsetShield);
        }

        // TK Pull
        if (heldObject != null)
        {
            if (heldObject.CompareTag(tagLv2))
            {
                MoveHeldObject(heldObject, heldObjPosM, tkPullForce);
            }
            else if (heldObject.CompareTag(tagLv3))
            {
                MoveHeldObject(heldObject, heldObjPosL, tkPullForce);
            }
            else if (heldObject.CompareTag(tagLv1))
            {
                MoveHeldObject(heldObject, heldObjPos, tkPullForce);
            }
            else
            {
                MoveHeldObject(heldObject, heldDebrisPos, tkPullForce);
            }
        }

        //Shield
        if (shieldActive)
        {
            foreach (GameObject pos in gridPosList)
            {
                pos.transform.position = ChaosMovement(pos.transform, xMin, xMax, yMin, yMax, zMin, zMax).position;
            }

            MoveShield(spawnedObjsList, gridPosList, shieldOrigin, shieldPullForce);
        }

        //Levitate
        currentH = transform.position.y;

        if (currentLevitateState == LevitateState.Ascent)
        {
            if (levitateLv2)
            {
                currentLevitateState = LevitateUp(currentH, relMaxH, floatTimeLv2, speedUpLv2, currentLevitateState);
            }
            else
            {
                currentLevitateState = LevitateUp(currentH, relMaxH, floatTimeLv1, speedUpLv1, currentLevitateState);
            }
        }
        else if(currentLevitateState == LevitateState.Float)
        {
            currentLevitateState = FloatMidAir(airborne, currentLevitateState);
        }
        else if(currentLevitateState == LevitateState.Descent)
        {
            if (levitateLv2)
            {
                currentLevitateState = LevitateDown(airborne, speedDownLv2, groundTolerance, groundLayers, currentLevitateState);
            }
            else
            {
                currentLevitateState = LevitateDown(airborne, speedDownLv1, groundTolerance, groundLayers, currentLevitateState);
            }
        }
        else
        {
            currentLevitateState = IsGrounded(groundTolerance, groundLayers);
        }
    }

    //Buttons
    public void OnGrab()
    {
        if (!shieldActive && forcePullLv1)
        {
            var ray = new Ray(playerCam.transform.position, playerCam.transform.forward);
            RaycastHit hit;

            var hitTarget = Physics.Raycast(ray, out hit, maxRange, layersTkPull);


            if (hitTarget && heldObject == null)
            {
                if ((forcePullLv3 && (hit.transform.CompareTag(tagLv3) || hit.transform.CompareTag(tagLv2))) ||
                   (forcePullLv2 && hit.transform.CompareTag(tagLv2)) ||
                    hit.transform.CompareTag(tagLv1))
                {
                    heldObject = PickUpObject(hit.transform.gameObject, heldObjDrag);
                }
            }
            else if (!hitTarget && heldObject == null)
            {
                heldObject = InstantiateDebris(playerCam, heldObjDrag, debrisModel, debrisTag, shieldPieceLayer, xOffsetDebris, yOffsetDebris, zOffsetDebris);
            }
            else if (heldObject != null)
            {
                heldObject = DropHeldObject(heldObject, debrisLifespan, debrisTag);
            }
        }
    }

    public void OnFire()
    {
        if (heldObject != null)
        {
            heldObject = ThrowObject(heldObject, playerCam, throwForce, debrisLifespan, debrisTag);
        }
        else if (shieldActive && shieldLv2)
        {
            shieldCol.GetComponent<Collider>().enabled = false;

            foreach (GameObject obj in spawnedObjsList)
            {
                heldObject = ThrowObject(obj, playerCam , shieldThrowForce, debrisLifespan, shieldPieceTag);
            }

            
            shieldActive = false;
            spawnedObjsList.Clear();
        }
    }

    public void OnShield()
    {
        if (heldObject == null && shieldLv1)
        {
           shieldActive = Shield(shieldActive, numShieldPieces, spawnedObjsList, shieldOrigin, shieldCol,
                                 shieldDrag, shieldPiecesLifeSpan);
        }
    }

    public void OnLevitate()
    {
        if (!levitate && levitateLv1) 
        {
            if (currentLevitateState == LevitateState.Float)
            {
                airborne = Time.time;
            }
            else if (currentLevitateState == LevitateState.Grounded) 
            {
                currentLevitateState = LevitateState.Ascent;

                if (levitateLv2)
                {
                    relMaxH = transform.position.y + maxHLv2;
                }
                else
                {
                    relMaxH = transform.position.y + maxHLv1;
                }   
            }
            levitate = true;
        }
        else if (levitate && levitateLv1)
        {
            if (currentLevitateState == LevitateState.Ascent)
            {
                currentLevitateState = LevitateState.Float;

                if (levitateLv2)
                {
                    airborne = Time.time + floatTimeLv2;
                }
                else
                {
                    airborne = Time.time + floatTimeLv1;
                }
            }
            levitate = false;
        }    
    }

    // Functions

    // Force Pull
    public void MoveHeldObject(GameObject grabbedObj, GameObject floatPos, float pullForce)
    {
        if (Vector3.Distance(grabbedObj.transform.position, floatPos.transform.position) > 0.1f)
        {
            Vector3 moveDir = (floatPos.transform.position - grabbedObj.transform.position);
            grabbedObj.GetComponent<Rigidbody>().AddForce(moveDir * pullForce);
        }
    }
    public GameObject PickUpObject(GameObject obj, float drag)
    {
        Rigidbody objRb = obj.GetComponent<Rigidbody>();
        objRb.useGravity = false;
        objRb.drag = drag;

        return obj;
    }
    public GameObject DropHeldObject(GameObject obj, float delay, string tag)
    {
        if (obj.CompareTag(tag))
        {
            DestroyInstance(obj, delay);
        }

        Rigidbody objRig = obj.GetComponent<Rigidbody>();
        objRig.useGravity = true;
        objRig.drag = 0;
        objRig.transform.parent = null;

        return null;
    }
    public GameObject ThrowObject(GameObject obj, Camera cam, float force, float delay, string tag)
    {
       
        if (obj.CompareTag(tag))
        {
            DestroyInstance(obj, delay);
        }

        Rigidbody objRb = obj.GetComponent<Rigidbody>();
        objRb.useGravity = true;
        objRb.drag = 0;

        
        var ray = new Ray(cam.transform.position, cam.transform.forward);
        Vector3 moveDir = ray.direction.normalized;

        obj.GetComponent<Rigidbody>().AddForce(throwForce * moveDir, ForceMode.Impulse);

        return null;
    }
    public GameObject InstantiateDebris(Camera cam, float drag, string model, string tagName, string layerName, float x, float y, float z)
    {
        Vector3 spawnPosition;
        Quaternion randomRotation;
        GameObject instance;

        spawnPosition = new Vector3(x, y, z);

        randomRotation = new Quaternion(Random.Range(0, 180),
                                        Random.Range(0, 180),
                                        Random.Range(0, 180),
                                        Random.Range(0, 180));

        instance = Instantiate(Resources.Load(model) as GameObject, 
                               cam.transform.position + cam.transform.TransformPoint(spawnPosition),
                               cam.transform.rotation * randomRotation);

        if (instance.tag != tagName) 
        {
            instance.tag = tagName;
        }

        if (instance.layer != LayerMask.NameToLayer(layerName)) 
        {
            instance.layer = LayerMask.NameToLayer(layerName);
        }
        
        Rigidbody instanceRb = instance.GetComponent<Rigidbody>();
        instanceRb.useGravity = true;
        instanceRb.drag = drag;

        return instance;
    }
    public void DestroyInstance(GameObject obj, float delay)
    {
        Destroy(obj, delay);
    }
    public GameObject InstantiateHeldPosition(float x, float y, float z)
    {
        GameObject emptyObj;
        GameObject obj;
        Vector3 position;

        emptyObj = new GameObject("HeldObjPos");
        position = transform.TransformPoint(x, y, z);
        obj = Instantiate(emptyObj, 
                          position, 
                          transform.rotation, 
                          transform);
        Destroy(emptyObj);

        return obj;
    }
    public void UpdateHeldPosition(GameObject obj, float x, float y, float z)
    {
        obj.transform.position = transform.TransformPoint(x, y, z);
    }

    // Shield
    public bool Shield(bool active, int maxSpawn, List<GameObject> listObj, GameObject floatPos, GameObject collider, float drag, float delay) 
    {
        if (!active)
        {
            for (int i = 0; i < maxSpawn; i++)
            {
                GameObject spawnedObj;

                spawnedObj = InstantiateDebris(playerCam, drag, shieldPieceModel, shieldPieceTag, shieldPieceLayer, xOffsetDebris, yOffsetDebris, zOffsetDebris);
                spawnedObj.GetComponent<Rigidbody>().useGravity = false;
                spawnedObj.GetComponent<Rigidbody>().drag = drag;
                
                listObj.Add(spawnedObj);
            }

            collider.GetComponent<Collider>().enabled = true;
            active = true;
            
        }
        else
        {
            foreach (GameObject obj in spawnedObjsList)
            {
                obj.GetComponent<Rigidbody>().useGravity = true;
                obj.GetComponent<Rigidbody>().drag = 0;
                DestroyInstance(obj, delay);
            }

            collider.GetComponent<Collider>().enabled = false;
            active = false;
            listObj.Clear();
        }

        return active;
    }
    public void MoveShield(List<GameObject> listObj, List<GameObject> listPos, GameObject floatPos, float pullForce)
    {
        foreach (GameObject obj in listObj)
        {
            if (Vector3.Distance(obj.transform.position, listPos[listObj.IndexOf(obj)].transform.position) > 0.1f)
            {
                Vector3 moveDir = listPos[listObj.IndexOf(obj)].transform.position - obj.transform.position;
                obj.GetComponent<Rigidbody>().AddForce(moveDir * pullForce);
            }
        }
    }
    public GameObject InstantiateShieldGrid(GameObject origin, List<GameObject> list, int numPieces, float x, float y, float z, int col, float hDist, float vDist)
    {
        for (int i = 0; i < numPieces; i++)
        {
            origin = InstantiateHeldPosition(x + hDist * (i % col), y + vDist * (i / col), z);

            list.Add(origin);
        }
        return origin;
    }
    public GameObject InstantiateShieldCollider(string model, float x, float y, float z, string tagName, string layerName)
    {
        GameObject instance;
        Vector3 pos;

        pos = transform.TransformPoint(x, y, z);

        instance = Instantiate(Resources.Load(model) as GameObject,
                               pos,
                               transform.rotation, 
                               transform);

        if(instance.tag != tagName)
        {
            instance.tag = tagName;
        }
        
        if (instance.layer != LayerMask.NameToLayer(layerName))
        {
            instance.layer = LayerMask.NameToLayer(layerName);
        }
       
        return instance;
    }
    public void UpdateShieldColliderPosition(GameObject obj, float x, float y, float z)
    {
        obj.transform.position = transform.TransformPoint(x, y, z);
    }
    public Transform ChaosMovement(Transform pos, float minX, float maxX, float minY, float maxY, float minZ, float maxZ)
    {
        pos.transform.position = pos.transform.position + new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), Random.Range(minZ, maxZ));

        return pos.transform;
    }

    // Levitate
    public LevitateState LevitateUp(float curH, float mxH, float floatT, float speedU, LevitateState state) 
    {
        if (curH >= mxH)  
        {
            airborne = Time.time + floatT;
            state = LevitateState.Float;
        }
        else
        {
            transform.Translate(speedU * Time.deltaTime * Vector3.up);
        }
        
        return state;
    }
    public LevitateState FloatMidAir(float airB, LevitateState state)
    {
        transform.Translate(0.1f * Time.deltaTime * Vector3.down);

        if (Time.time >= airB) 
        {
            state = LevitateState.Descent;
        }
        return state;
    }
    public LevitateState LevitateDown(float airB, float speedD, float tolerance, LayerMask layers, LevitateState state)
    {
        if (Time.time >= airB)
        {
            transform.Translate(speedD * Time.deltaTime * Vector3.down);
        }
        if (Physics.CheckSphere(transform.position, tolerance, layers))
        {
            state = LevitateState.Grounded;
        }
        return state;
    }
    public LevitateState IsGrounded(float tolerance, LayerMask layers)
    {
        LevitateState state;

        if (Physics.CheckSphere(transform.position, tolerance, layers))
        {
            state = LevitateState.Grounded;
        }
        else
        {
            state = LevitateState.Jump;
        }

        return state;
    }

    // Tools
    public void TagPrinter(Camera cam, Text text)
    {
        var ray = new Ray(cam.transform.position, cam.transform.forward);
        RaycastHit hit;

        var hitTarget = Physics.Raycast(ray, out hit, Mathf.Infinity);

        if (hitTarget)
        {
            text.text = hit.collider.tag;
        }
    }
}
