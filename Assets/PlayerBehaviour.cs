using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets
{
    public class PlayerBehaviour : CommonBehaviour
    {
        public Camera CameraComponent { get; private set; }

        public Inventory Inventory { get; set; }

        private float _bulletRateTimeout = 0.25f;

        private float _lastBulletFiredTime = float.MinValue;

        public PlayerBehaviour()
        {
            Inventory = new Inventory();
        }

        void Awake()
        {
            CameraComponent = GetComponent<Camera>();
        }

        void Start()
        {
        }

        void Update()
        {
            if (Input.GetMouseButton(1) && _lastBulletFiredTime + _bulletRateTimeout <= Time.time)
            {
                var magazine = Inventory.Enumerate<Magazine>().OrderBy(o => o.BulletCount).FirstOrDefault();

                if(magazine != null)
                {
                    magazine.Fire();

                    Debug.Log($"Fire: {magazine.BulletCount}");

                    if (magazine.BulletCount == 0)
                    {
                        Inventory.Remove(magazine);

                        magazine.Destroy();
                    }

                    _lastBulletFiredTime = Time.time;
                }
            }
        }

        void LateUpdate()
        {
           
        }
    }
}
