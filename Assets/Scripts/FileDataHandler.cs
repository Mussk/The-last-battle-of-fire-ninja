using UnityEngine;
using System;
using System.IO;
using Newtonsoft.Json;



public class FileDataHandler<T>
{
    private string dataDirPath = "";

    private string dataFileName;

    
    public FileDataHandler(string dataDirPath, string dataFileName)
    {
        this.dataDirPath = dataDirPath;
        this.dataFileName = dataFileName;
    }


    public T LoadToWebGL() 
    {
        string webGLData = WebGLStorage.Load(dataFileName); 
        T loadedData = default;

        try
        {
            loadedData = JsonConvert.DeserializeObject<T>(webGLData);

        }
        catch (Exception ex)
        { 
            
            Debug.LogError("Error occured when trying to load data from file: " + dataFileName + "\n" + ex);  
        
        }


        return loadedData;
    }



    public T Load()
    {
        string fullPath = Path.Combine(dataDirPath, dataFileName);
        T loadedData = default;
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
                
                loadedData = JsonConvert.DeserializeObject<T>(dataToLoad);

               
            }
            catch (Exception e)
            {
                Debug.LogError("Error occured when trying to load data from file: " + fullPath + "\n" + e);

            }
        }
        return loadedData;
    }


    public void SaveToWebGL(T data) 
    {
        try
        {
            string jsonString = JsonConvert.SerializeObject(data);

            WebGLStorage.Save(dataFileName, jsonString);

        }
        catch (Exception e)
        {
            Debug.LogError("Error occured when trying to save data to file: " + dataFileName + "\n" + e);

        }

    }


    public void Save(T data) 
    {

        string fullPath = Path.Combine(dataDirPath,dataFileName);
        try 
        {

            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));


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
