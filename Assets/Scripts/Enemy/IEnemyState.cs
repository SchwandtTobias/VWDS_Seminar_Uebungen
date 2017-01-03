using UnityEngine;

public interface IEnemyState
{
    void UpdateState();

    void OnTriggerEnter2D(Collider2D _Other);

    void OnTriggerExit2D(Collider2D _Other);

    void ToPatrolState();

    void ToAlertState();

    void ToChaseState();
}
