using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CreateNeptune
{
    public class Preloader : Singleton<Preloader>
    {
        [SerializeField] private GameObject[] singletons;

        protected override void OnSuccessfulAwake()
        {
            foreach(GameObject singleton in singletons)
            {
                Instantiate(singleton);
            }
        }
    }
}
