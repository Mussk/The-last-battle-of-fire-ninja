using UnityEngine;
using System;
using System.IO;
using Newtonsoft.Json;
using System.Linq;


public class FileDataHandler 
{
    private string dataDirPath = "";

    private string dataFileName = "";


    public FileDataHandler(string dataDirPath, string dataFileName)
    {
        this.dataDirPath = dataDirPath;
        this.dataFileName = dataFileName;
    }

    public SerializedData Load()
    {
        string fullPath = Path.Combine(dataDirPath, dataFileName);
        SerializedData loadedData = null;
        if (File.Exists(fullPath))
        {
            try
            {

                string dataToLoad = "";
                using (FileStream stream = new FileStream(fullPath, FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        dataToLoad = reader.ReadToEnd();

                    }
                }
                
                loadedData = JsonConvert.DeserializeObject<SerializedData>(dataToLoad);
            }
            catch (Exception e)
            {
                Debug.LogError("Error occured when trying to load data from file: " + fullPath + "\n" + e);

            }
        }
        return loadedData;
    }


    public void Save(SerializedData data) 
    {

        string fullPath = Path.Combine(dataDirPath,dataFileName);
        try 
        {

            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));

            data.SkinData = data.SkinData.Distinct().ToList();

            string dataToStore = JsonConvert.SerializeObject(data);

            Debug.Log(dataToStore);

            using (FileStream stream = new FileStream(fullPath, FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    
                    writer.Write(dataToStore);
                }
            }
        }
        catch(Exception e) 
        {
            Debug.LogError("Error occured when trying to save data to file: " + fullPath + "\n" + e);
        
        }
    }

}
