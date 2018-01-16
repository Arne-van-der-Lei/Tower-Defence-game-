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
    }

    namespace impl
    {
        public class BlockView : MonoBehaviour, IBlockView
        {
            
            public event EventHandler<BlockViewClickChangedEventArgs> OnClickChanged;
            
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
