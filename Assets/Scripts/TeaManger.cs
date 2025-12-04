using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeaManger : MonoBehaviour
{
    // Start is called before the first frame update
    private string[] teaNames = { "Black Tea", "Cinnamin tea", "Cozy Black Tea" };
    private int[] teaVals = { 1, 2, 3 };

    public string currentTea;
    public int currentVal;
    public int currentIter;

    public string getTeaName(int teaVal)
    {
        if (teaVal < teaVals.Length)
        {
            return teaNames[teaVal];
        }
        else
        {
            return null;
        }
    }
    //
    /// <summary>
    /// this acts like comments ?
    /// 
    /// </summary>
    

    // need to think of a way to check for special teas probably just have a array of just combo teas
    //let that be its own thing with own special values to check...
    public bool isCombine(int val)
    {
        foreach (int vals in teaVals) 
        {
            if (val == vals) 
            {
                return true;
            }
        }
        return false;
    }

    public int combineVals(int val, int currVal)
    {
        return val + currVal;
    }

    public void setCurrentTea(int val) 
    {
        setCurrentVal(val);
        for (int i = 0; i < teaVals.Length; i++)
        {
            if (teaVals[i] == val)
            {
                setCurrentIter(i);
            }
        }
        setCurrentTeaName(currentIter); 
    }



    public void setCurrentVal(int val) 
    {
        currentVal = val;
        
    }

    public void setCurrentIter(int iter) 
    {
        currentIter = iter;
    }
    public void setCurrentTeaName(int iter) 
    {
        currentTea = teaNames[iter];
    }

    public void Reset()
    {
        currentTea = "";
        currentVal = -1;
    }
}
