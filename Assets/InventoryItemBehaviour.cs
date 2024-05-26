using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets
{
    public class InventoryItemBehaviour : CommonBehaviour
    {
        public IInventoryItem Item { get; set; }

        private void Update()
        {
            Item?.Update();
        }
    }
}
