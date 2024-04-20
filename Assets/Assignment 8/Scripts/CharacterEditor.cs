using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace CharacterEditor
{
    public class CharacterEditor : MonoBehaviour
    {
        [SerializeField] Button nextMaterial;
        [SerializeField] Button nextBodyPart;
        [SerializeField] Button loadGame;

        [SerializeField] Character character;

        int id;
        BodyTypes bodyType = BodyTypes.Head;

        private void Awake()
        {
            //TODO: Setup some button listeners to call the NextMaterial, NextBodyPart, and LoadGame functions
            nextMaterial.onClick.AddListener(NextMaterial);
            nextBodyPart.onClick.AddListener(NextBodyPart);
            loadGame.onClick.AddListener(LoadGame);
        }

        void NextMaterial()
        {
            //TODO: Add 1 to the value of id and if it is 3 or more then reset back to 0
            id = (id + 1) % 3;
            //TODO: Make a switch case for each BodyType and save the value of id to the correct PlayerPref
            switch (bodyType)
            {
                case BodyTypes.Arm:
                    PlayerPrefs.SetInt("ArmMaterialID", id);
                    break;
                case BodyTypes.Leg:
                    PlayerPrefs.SetInt("LegMaterialID", id);
                    break;
                case BodyTypes.Head:
                    PlayerPrefs.SetInt("HeadMaterialID", id);
                    break;
                case BodyTypes.Body:
                    PlayerPrefs.SetInt("BodyMaterialID", id);
                    break;
            }
            Debug.Log("Material Changed");
            //TODO: Tell the character to load to get the updated body piece
            character.Load();
        }

        void NextBodyPart()
        {
            //TODO: Setup a switch case that will go through the different body types
            //      ie if the current type is Head and we click next then set it to Body
            switch (bodyType)
            {
                case BodyTypes.Head:
                    bodyType = BodyTypes.Body;
                    break;
                case BodyTypes.Body:
                    bodyType = BodyTypes.Arm;
                    break;
                case BodyTypes.Arm:
                    bodyType = BodyTypes.Leg;
                    break;
                case BodyTypes.Leg:
                    bodyType = BodyTypes.Head;
                    break;
            }
            Debug.Log("Body Part Selected");
            //TODO: Then setup another switch case that will get the current saved value
            //      from the player prefs for the current body type and set it to id
            id = PlayerPrefs.GetInt(bodyType.ToString() + "MaterialID", 0);
        }

        void LoadGame()
        {

            SceneManager.LoadScene("Game");
        }
    }
}