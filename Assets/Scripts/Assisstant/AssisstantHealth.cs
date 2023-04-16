using Controller;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assisstant
{
    public class AssisstantHealth : MonoBehaviour
    {
        [SerializeField] private float maxHealth;
        [SerializeField] private Image healthBar;
        private float _currentHealth;

        private void Awake()
        {
            _currentHealth = maxHealth;
            healthBar.fillAmount = 1;
        }
        public void TakeDamage(float value) 
        {
            _currentHealth -= value;
            healthBar.fillAmount = _currentHealth / maxHealth;

            if (_currentHealth <= 0)
            {
                Dead();
            }
        }

        public void Dead() 
        {
            gameObject.tag = "Untagged";
            AssisstantController.Instance.CheckAssisstants();
            Destroy(gameObject);
        }
    }
}
