using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    private List<PlayerInput> players = new List<PlayerInput>();
    [SerializeField]
    private List<Transform> startingPoints;
    [SerializeField]
    private List<LayerMask> playerLayers;
    [SerializeField]
    private List<GameObject> playerPrefabs;
    private int playerIndex;
    private PlayerInputManager playerInputManager;
    [SerializeField]
    private TMP_Text joinText, startText;
    private int playerJoinIndex = 3;

    private void Awake()
    {
        playerInputManager = FindObjectOfType<PlayerInputManager>();
    }

    private void OnEnable()
    {
        playerInputManager.onPlayerJoined += AddPlayer;
    }

    private void OnDisable()
    {
        playerInputManager.onPlayerJoined -= AddPlayer;
    }

    public void AddPlayer(PlayerInput player)
    {
        playerIndex = players.Count;
        playerJoinIndex--;

        if (playerJoinIndex == 0)
        {
            joinText.enabled = false;
            startText.enabled = false;
        }
        else
            joinText.text = "Players Joined " + "(" + playerJoinIndex + ")";

        // Determine the correct player prefab to instantiate

        if (playerIndex == 2)
        {
            //Debug.Log("Skipped Element");
        }
        else
        {
            GameObject playerPrefab = playerPrefabs[playerIndex];  // Get the correct player prefab based on the number of players
            playerInputManager.playerPrefab = playerPrefab;  // Set the prefab for the new player
        }

        players.Add(player);

        //need to use the parent due to the structure of the prefab
        Transform playerParent = player.transform.parent;
        playerParent.position = startingPoints[players.Count - 1].position;

        //convert layer mask (bit) to an integer 
        int layerToAdd = (int)Mathf.Log(playerLayers[players.Count - 1].value, 2);

        //set the layer
        playerParent.GetComponentInChildren<CinemachineFreeLook>().gameObject.layer = layerToAdd;
        //add the layer
        playerParent.GetComponentInChildren<Camera>().cullingMask |= 1 << layerToAdd;
        //set the action in the custom cinemachine Input Handler
        playerParent.GetComponentInChildren<InputHandler>().horizontal = player.actions.FindAction("Look");

    }
}