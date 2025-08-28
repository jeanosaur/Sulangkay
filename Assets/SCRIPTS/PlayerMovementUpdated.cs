using System.Collections;
using UnityEngine;

public class PlayerMovementUpdated : MonoBehaviour
{
    //for PLayer Data
    public PlayerData Data;

    #region  Variables
    // Components for Player
    public Rigidbody2D rb { get; private set; }
    // Variables that will control the player's movement//
    public bool isFacingRight { get; private set; }
    public bool isJumping { get; private set; }
    // Timers
    public float LastOnGroundTime;


    #endregion

}
