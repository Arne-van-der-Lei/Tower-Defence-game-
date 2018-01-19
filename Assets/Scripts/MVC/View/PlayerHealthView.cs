using UnityEngine;
using UnityEngine.UI;

namespace View
{
    public interface IPlayerHealthView
    {
        int Health{set;}
    }

    namespace Impl
    {
        public class PlayerHealthView : MonoBehaviour, IPlayerHealthView
        {

#pragma warning disable 649
            [SerializeField] private Text _Health;
#pragma warning restore 649

            public int Health
            {
                set
                {
                    _Health.text = "" + value;
                }
            }
        }
    }
}