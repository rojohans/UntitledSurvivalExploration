

using System;
using UnityEngine;

namespace usea.graphics.model
{
    public class ExampleModel : MonoBehaviour
    {
        // ###### PUBLIC ######
        public void IncreaseCharge()
        {
            m_remainingCharge = Math.Min(MAX_CHARGE, m_remainingCharge + m_chargeIncrement);
        }

        public void SetChargeIncrement(float newChargeIncrement)
        {
            m_chargeIncrement = newChargeIncrement;
        }

        public void DecreaseCharge(float chargeDecrease)
        {
            m_remainingCharge = Math.Max(0, m_remainingCharge - chargeDecrease);
        }

        public float GetChargeRate()
        {
            return m_remainingCharge / MAX_CHARGE;
        }

        // ###### PRIVATE ######
        private const float MAX_CHARGE = 10;
        private float m_remainingCharge = 5;
        private float m_chargeIncrement = 1;
    }
}