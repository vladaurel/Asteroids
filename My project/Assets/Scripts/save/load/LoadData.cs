/**
 * This class manages the loading. In case that the folder and / or file don't exist - it will create them and populate them.
 */
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Profile.SaveAndLoad
{
    public class LoadData
    {

        // public int lives;
        private bool allowTesting = true;

        public ProfileData LoadProfile(string profileName)
        {
            // Debug.Log(Application.persistentDataPath + "/saves/" + profileName + ".dat");
            ProfileData profile;

            // check if the saves folder exists.
            if (System.IO.Directory.Exists(Application.persistentDataPath + "/saves"))
            {
                // if yes - check if the file with the specific name exists
                if (File.Exists(Application.persistentDataPath + "/saves/" + profileName + ".dat"))
                {
                    Debug.Log("Loading the file from here :");
                    Debug.Log(Application.persistentDataPath + "/saves/" + profileName + ".dat");
                    // if yes, load it, deformat it from binary ( it will be written in binary )
                    BinaryFormatter bf = new BinaryFormatter();
                    FileStream fileIs = File.Open(Application.persistentDataPath + "/saves/" + profileName + ".dat", FileMode.Open);
                    profile = (ProfileData)bf.Deserialize(fileIs);
                    fileIs.Close();
                }
                else
                {
                    // if not, (create the file) 
                    profile = CreateNewProfile(profileName);
                }
            }
            else
            {
                // if not, create the folder
                System.IO.Directory.CreateDirectory(Application.persistentDataPath + "/saves");
                // (create the file) // ... 
                profile = CreateNewProfile(profileName);
            }
            return profile;
        }


        // In the case we simply need to create a new profile.
        public ProfileData CreateNewProfile(string profileName, int difficulty = 1)
        {
            ProfileData profile = new ProfileData();

            //===================================================
            // TEMP TESTING - adding anything that I want to test here 
            if (allowTesting)
            {



            }
            //===================================================


            // save the newly created profile 
            SaveData saveData = new SaveData();
            saveData.WriteProfileSave(profileName, profile);
            return profile;
        }
    }
}
