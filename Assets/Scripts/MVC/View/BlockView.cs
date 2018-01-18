using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

namespace View
{
    public class BlockViewClickChangedEventArgs : EventArgs
    {
        public BlockViewClickChangedEventArgs(bool click)
        {
            Click = click;
        }

        public bool Click { get; private set; }
    }

    public interface IBlockView
    {
        event EventHandler<BlockViewClickChangedEventArgs> OnClickChanged;
        bool Color { set; }
        bool HasTower { set; }
    }

    namespace impl
    {
        public class BlockView : MonoBehaviour, IBlockView
        {
            public bool Color
            {
                set
                {
                    _renderer.material.color = value ? new Color(255, 0, 0) : new Color(255, 255, 255);
                }
            }

            [SerializeField]private bool _HasTower = false;

            public bool HasTower
            {
                set
                {
                    _HasTower = value;
                }

                get
                {
                    return _HasTower;
                }
            }

            private MeshRenderer _renderer;

            public event EventHandler<BlockViewClickChangedEventArgs> OnClickChanged;

            public void Start()
            {
                _renderer = GetComponent<MeshRenderer>();
            }

            private void OnMouseUp()
            {
                if (OnClickChanged != null)
                {
                    OnClickChanged(this, new BlockViewClickChangedEventArgs(true));
                }
            }
        }
    }
}
