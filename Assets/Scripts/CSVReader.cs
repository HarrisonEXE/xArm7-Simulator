using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CSVReader : MonoBehaviour
{
    public static List<float[]> data = new List<float[]>();

    //void Start()
    //{
    //    ReadCSV();
    //}

    public static void ReadCSV(string path)
    {
        //reading file from location
        Debug.Log("Great Success!");
        StreamReader strReader = new StreamReader(path);
        bool endOfFile = false;

        strReader.ReadLine(); //get rid of header
        while (!endOfFile)
        {
            string data_String = strReader.ReadLine();
            if (data_String == null)
            {
                Debug.Log("Final Lenght: " + data.Count);
                endOfFile = true;
                break;
            }
            var data_values = data_String.Split(',');

            float[] temp = new float[63];
            for (int i = 1; i <= 63; i++)
            {
                temp[i - 1] = float.Parse(data_values[i]);
                //Debug.Log("Value:"+ i.ToString() + " " + data_values[i].ToString());
                //data.Add(float.Parse(data_values[i]));
            }
            data.Add(temp);

            //showing each rows
            //Debug.Log(j.ToString());
            //Debug.Log(data_values[0].ToString() + " " + data_values[1].ToString() + " " + data_values[2].ToString() + " " + data_values[3].ToString() + " " + data_values[4].ToString() + " " + data_values[5].ToString() + " " + data_values[6].ToString() + " " + data_values[7].ToString());
        }
    }
    public static List<float[]> getData()
    {
        return data;
    }
}


