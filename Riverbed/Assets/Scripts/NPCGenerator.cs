using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCGenerator : MonoBehaviour
{
    public List<GameObject> NPCPrefabs;

    [Header("Range of spawn field")]
    public int minXPos = -32;
    public int maxXPos = 20;
    public int minYPos = -6;
    public int maxYPos = 1;

    public List<GameObject> ActiveNPCs;//使われた
    public List<GameObject> InactiveNPCs;//使われてない
    public List<GameObject> ActiveNPCInstances;//今出現している
    public List<GameObject> InactiveNPCInstances;//出現して非アクティブになった


    private bool AnyNPCGetInactive = false;
    private GameObject deactiveNow;//今消えたNPC
    

    // Start is called before the first frame update
    void Start()
    {
        InactiveNPCs = new List<GameObject>(NPCPrefabs);
        for (int i = 0; i < 3; i++)
        {
            int index = Random.Range(0, InactiveNPCs.Count);
            ActiveNPCs.Add(InactiveNPCs[index]);
            InactiveNPCs.Remove(InactiveNPCs[index]);
        }

        foreach (var NPC in ActiveNPCs)
        {
            GameObject NPCgo = Instantiate(NPC);
            ActiveNPCInstances.Add(NPCgo);
            NPCgo.transform.position = new Vector3(Random.Range(minXPos, maxXPos), Random.Range(minYPos, maxYPos), 0);
            if (ChooseRandomAb(1) > 0)
                NPC.GetComponent<NPCMove>().walkToRight = true;
            else
                NPC.GetComponent<NPCMove>().walkToRight = false;

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (AnyNPCGetInactive)
        {
            InactiveNPCInstances.Add(deactiveNow);
            ActiveNPCInstances.Remove(deactiveNow);

            

            if (InactiveNPCs.Count > 0)
            {
                int index = Random.Range(0, InactiveNPCs.Count);
                GameObject go = Instantiate(InactiveNPCs[index]);
                go.transform.position = new Vector3(ChooseRandomAb(33), Random.Range(minYPos, maxYPos), 0);
                if (go.transform.position.x < 0)
                {
                    go.GetComponent<NPCMove>().walkToRight = true;
                }
                else
                {
                    go.GetComponent<NPCMove>().walkToRight = false;
                }
                InactiveNPCs.Remove(InactiveNPCs[index]);
                ActiveNPCInstances.Add(go);
            }
            else
            {
                int index = Random.Range(0, InactiveNPCInstances.Count);
                GameObject go = InactiveNPCInstances[index];
                go.transform.position = new Vector3(ChooseRandomAb(33), Random.Range(minYPos, maxYPos), 0);
                if (go.transform.position.x < 0)
                {
                    go.GetComponent<NPCMove>().walkToRight = true;
                }
                else
                {
                    go.GetComponent<NPCMove>().walkToRight = false;
                }
                go.SetActive(true);

                InactiveNPCInstances.Remove(go);
                ActiveNPCInstances.Add(go);
            }

            AnyNPCGetInactive = false;
            deactiveNow = null;
        }


        
    }

    //=====================================================
    private int ChooseRandomAb(int value)
    {
        int i = Random.Range(0, 2);
        if (i == 0)
            return -value;
        else
            return value;        
    }


    
    public void GetInactiveNPC(GameObject go)
    {
        AnyNPCGetInactive = true;
        deactiveNow = go;
    }

    //======================================================
    public static NPCGenerator instance = null;

    public static NPCGenerator get()
    {
        if (NPCGenerator.instance == null)
        {
            GameObject go = GameObject.Find("GameManager");
            if (go != null)
            {
                NPCGenerator.instance = go.GetComponent<NPCGenerator>();
            }
            else
            {
                Debug.LogError("Can't find game object \"GameManager\".");
            }
        }

        return (NPCGenerator.instance);
    }

}
