using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlTexto : MonoBehaviour
{
	[SerializeField] GameObject player1, player2;
	[SerializeField] Text municionP1, municionP2, misilesP1, misilesP2, ganador;

	void Start() 
	{
		municionP1.text = "";
		municionP2.text = "";
		ganador.text = "";
	}

	public void CambiarTextoMunicion(GameObject player, int amount)
	{
		if (player == player1) municionP1.text = "Ammo: " + amount.ToString();
		else if (player == player2) municionP2.text = "Ammo: " + amount.ToString();
	}

	public void CambiarTextoMisiles(GameObject player, int amount)
	{
		if (player == player1) misilesP1.text = "Ammo: " + amount.ToString();
		else if (player == player2) misilesP2.text = "Ammo: " + amount.ToString();
	}

	public void JugadorGanador (GameObject perdedor)
	{
		if (perdedor == player1) ganador.text = "Ganó el jugador 2";
		else ganador.text = "Ganó el jugador 1";
	}
    public void JugadorGanadorAros(GameObject perdedor)
    {
        if (perdedor == player1) ganador.text = "Ganó el jugador 1";
        else ganador.text = "Ganó el jugador 2";
    }
}