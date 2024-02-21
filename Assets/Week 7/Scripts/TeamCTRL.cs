using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamCTRL : MonoBehaviour
{
    public Slider chargeSlider;
    float charge;
    public float maxCharge;
    Vector2 direction;
    public static BallPlayer SelectedPlayer { get; private set; }

    public static void SetSelectedPlayer(BallPlayer player)
    {
        if (SelectedPlayer != null) {
            SelectedPlayer.Select();//deselect previous baller
        }
        player.Select();
        SelectedPlayer = player;//select new baller
    }

    private void FixedUpdate()
    {
        if (direction != Vector2.zero)
        {
            SelectedPlayer.Move(direction);
            direction = Vector2.zero;
            charge = 0;
            chargeSlider.value = charge;
        }
    }

    private void Update()
    {
        if (SelectedPlayer == null) return;
        if (Input.GetKeyDown(KeyCode.Space)) //down
        {
            charge = 0;
            Mathf.Clamp(charge, 0, maxCharge);
            direction = Vector2.zero;
        }

        if (Input.GetKey(KeyCode.Space)) //key
        {
            charge += Time.deltaTime;
            chargeSlider.value = charge;
        }

        if (Input.GetKeyUp(KeyCode.Space)) //up
        {
            direction = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - SelectedPlayer.transform.position).normalized * charge;
        }
    }
}
