using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FactoryPool
{
    public class Pool<T> where T : IBullet
    {
        Func<T> _factoryMethod; 

        Action<T> _turnOnCallback; 

        Action<T> _turnOffCallback;

        List<T> _currentStock;

        public Pool(Func<T> factoryMethod, Action<T> turnOnCallback, Action<T> turnOffCallback, int initialAmount)
        {
            _factoryMethod = factoryMethod;
            _turnOnCallback = turnOnCallback;
            _turnOffCallback = turnOffCallback;

            _currentStock = new List<T>();

            for (int i = 0; i < initialAmount; i++)
            {
                var createdObject = _factoryMethod();

                _turnOffCallback(createdObject);

                _currentStock.Add(createdObject);

            }
        }

        public T GetObject()
        {
            T objectToReturn;

            if (_currentStock.Count != 0)
            {
                objectToReturn = _currentStock[0];

                _currentStock.RemoveAt(0);
            }
            else 
            {
                objectToReturn = _factoryMethod();
            }

            _turnOnCallback(objectToReturn);

            return objectToReturn;
        }

        public void ReturnObjectToPool(T obj)
        {
            _turnOffCallback(obj);

            _currentStock.Add(obj);
        }
    }
}