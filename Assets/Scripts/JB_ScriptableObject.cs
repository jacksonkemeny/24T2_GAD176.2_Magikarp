using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new projectile", menuName = "create new projectile", order = 0)]
public class JB_ScriptableObject : ScriptableObject
{
    public string projectileName;
    public int projectileDamage;
    public int projectileSpeed;
    public JB_ProjectileSpawner projectileSpawner;
    // Start is called before the first frame update
    void Start()
    {
        projectileSpawner.Shoot();
    }

    
    // Update is called once per frame
    void Update()
    {
        
    }
}
