using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class CSVWritter : MonoBehaviour
{

    [SerializeField]InputField inputField;
    // Start is called before the first frame update
    void Start()
    {
 
    }

    public void WritingCSV(string text)
    {
        StreamWriter writer;
        FileInfo file = new FileInfo(Application.dataPath +"/Resources/CSV/"+inputField.text+".csv");
        writer = file.AppendText();
        writer.WriteLine(text);
        writer.Flush();
        writer.Close();
    }
}
