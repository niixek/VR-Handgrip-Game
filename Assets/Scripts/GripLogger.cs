using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GripLogger : MonoBehaviour
{

    string filename = "";
    string filepath = "";
    private float startTime;
    TextWriter tw;
    int frameBuffer = 2;
    int frameCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        filepath = Application.dataPath + "/GripLogs/";
        string time = System.DateTime.UtcNow.ToLocalTime().ToString("yyyy-dd-M_HH-mm-ss");
        filename = "VR-Handgrip-Game_" + time +".csv";

        startTime = Time.time;

        tw = new StreamWriter(filepath + filename, false);
        tw.WriteLine("Left Grip, Right Grip, Time");

        //Debug.Log(filepath + filename);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(filepath + filename);
        
        if (frameCounter % frameBuffer == 0)
        {
            WriteCSV();
        }
        frameCounter++;
    }

    public void WriteCSV()
    {
        tw.WriteLine(_GlobalVariables.leftForce.ToString() + "," + _GlobalVariables.rightForce.ToString() + "," + (Time.time - startTime));
    }

    private void OnApplicationQuit()
    {
        tw.Close();
        Debug.Log("Closed");
    }


}
