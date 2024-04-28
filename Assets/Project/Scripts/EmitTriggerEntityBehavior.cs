using System.Collections;
using UnityEngine;

namespace Assets.Project.Scripts
{
    public class EmitTriggerEntityBehavior : MonoBehaviour
    {

        private void OnTriggerEnter2D(Collider2D collision)
        {
            var entity = Contexts.sharedInstance.game.CreateEntity();
            entity.AddCollision(gameObject, collision.gameObject);            
        }
    }
}