/**
 * Class used for saving.
 */
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;

namespace Profile.SaveAndLoad
{
    public class SaveData
    {
        public void WriteProfileSave(string profileName, ProfileData profileData)
        {
            // Debug.Log("Save - on !");
            // check if the folder exists
            if (!System.IO.Directory.Exists(Application.persistentDataPath + "/saves"))
            {
                // if not, create the folder
                System.IO.Directory.CreateDirectory(Application.persistentDataPath + "/saves");
            }

            // save the file in the folder // create the binary formatter, etc.
            BinaryFormatter bf = new BinaryFormatter();

            FileStream file;
            if (System.IO.File.Exists(Application.persistentDataPath + "/saves/" + profileName + ".dat"))
            {
                file = File.OpenWrite(Application.persistentDataPath + "/saves/" + profileName + ".dat");
            }
            else
            {
                file = File.Create(Application.persistentDataPath + "/saves/" + profileName + ".dat");
            }

            Console.Write("Saved the file here : ");
            Console.WriteLine(Application.persistentDataPath + "/saves/" + profileName + ".dat");

            bf.Serialize(file, profileData);
            // file.Flush();
            file.Close();
            // file.Dispose();
        }
    }
}
