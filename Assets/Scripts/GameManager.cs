using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player player;
    public ParticleSystem explosion;

    public float respawnTime = 3.0f;
    public int lives;
    public int score;

    public float respawnInvulnerabilityTime = 3.0f;

    public void AsteroidDestroyed(Asteroid asteroid)
    {
        this.explosion.transform.position = asteroid.transform.position;
        this.explosion.Play();

        IncreaseScore(asteroid.size);
    }

    private void IncreaseScore(float asteroidSize)
    {
        if (asteroidSize <= 0.75f)
            score += 100;
        else if (asteroidSize <= 1.2f)
            score += 50;
        else
            score += 25;
    }

    public void PlayerDied()
    {
        this.explosion.transform.position = this.player.transform.position;
        this.explosion.Play();

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
