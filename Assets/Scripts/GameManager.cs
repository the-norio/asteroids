using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player player;
    public float respawnTime = 3.0f;
    public int lives;

    public float respawnInvulnerabilityTime = 3.0f;


    public void PlayerDied()
    {
        this.lives--;
        if (this.lives <= 0)
            GameOver();
        else
            Invoke(nameof(RespawnPlayer), this.respawnTime);
    }

    private void RespawnPlayer()
    {
        this.player.transform.position = Vector3.zero;
        this.player.gameObject.layer = LayerMask.NameToLayer("IgnoreCollisions");
        this.player.gameObject.SetActive(true);
        Invoke(nameof(TurnOnCollisions), respawnInvulnerabilityTime);
    }

    private void TurnOnCollisions()
    {
        this.player.gameObject.layer = LayerMask.NameToLayer("Player");
    }

    private void GameOver()
    {
        // TODO
    }
}
