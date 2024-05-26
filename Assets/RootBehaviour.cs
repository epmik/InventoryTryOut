using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets
{
    internal class RootBehaviour : CommonBehaviour
    {
        private const int TargetFrameRate = 60;

        private GameObject _cameraGameObject;

        private Camera _camera;

        private System.Random _random;

        void Awake()
        {
            QualitySettings.vSyncCount = 0;
            Application.targetFrameRate = TargetFrameRate;

            _cameraGameObject = Game.CameraGameObject();

            _camera = _cameraGameObject.GetComponent<Camera>();

            _random = new System.Random();
        }

        void Start()
        {
            RandomPositionInventoryItems();
        }

        void RandomPositionInventoryItems()
        {
            var root = Game.GameObjectByName("Root");

            for (var i = 0; i < 1; i++)
            {
                var item = new Flashlight();

                item.GameObject.transform.SetParent(root.transform, false);

                item.GameObject.transform.position = RandomPosition();

                item.GameObject.GetComponent<InventoryItemBehaviour>().Item = item;
            }

            for (var i = 0; i < 5; i++)
            {
                var item = new Binocular();

                item.GameObject.transform.SetParent(root.transform, false);

                item.GameObject.transform.position = RandomPosition();

                item.GameObject.GetComponent<InventoryItemBehaviour>().Item = item;
            }

            for (var i = 0; i < 2; i++)
            {
                var item = new Potion();

                item.GameObject.transform.SetParent(root.transform, false);

                item.GameObject.transform.position = RandomPosition();

                item.GameObject.GetComponent<InventoryItemBehaviour>().Item = item;
            }

            for (var i = 0; i < 5; i++)
            {
                var item = new Magazine();

                item.GameObject.transform.SetParent(root.transform, false);

                item.GameObject.transform.position = RandomPosition();

                item.GameObject.GetComponent<InventoryItemBehaviour>().Item = item;
            }
        }

        Vector3 RandomPosition()
        {
            return new Vector3(_random.Next(-10, 10), 0, _random.Next(2, 20));
        }

        void Update()
        {
            if (Input.GetKeyUp(KeyCode.F12) || Input.GetKeyUp(KeyCode.R))
            {
                RandomPositionInventoryItems();
            }

            if (Input.GetKeyUp(KeyCode.D))
            {
                var item = Game.PlayerBehaviour().Inventory.DropLastItem();

                if(item != null)
                {
                    item.GameObject.transform.position = RandomPosition();

                    item.GameObject.SetActive(true);
                }
            }

            var ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Input.GetMouseButtonDown(0) && Physics.Raycast(ray, out RaycastHit raycastHit))
            {
                raycastHit.transform.gameObject.SetActive(false);

                Game.PlayerBehaviour().Inventory.Add(raycastHit.transform.gameObject.GetComponent<InventoryItemBehaviour>().Item);
            }
        }

        void LateUpdate()
        {
           
        }
    }
}
