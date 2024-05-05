using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
    // Fallþræðisafvirkja sem keyrir þegar önnur hlutur er innan árekstrar
    void OnTriggerStay2D(Collider2D other)
    {
        // Sækir RubyController hlutinn á annarri einingu sem áreksturinn varðar
        RubyController controller = other.GetComponent<RubyController>();

        // Ef RubyController hluturinn er ekki null
        if (controller != null)
        {
            // Breytir lífshöfuði RubyController um -1
            controller.ChangeHealth(-1);
        }
    }
}
