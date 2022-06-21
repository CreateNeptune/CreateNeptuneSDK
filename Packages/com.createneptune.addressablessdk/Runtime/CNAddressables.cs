using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace CreateNeptune.Addressables
{
    public class CNAddressables
    {
        public static object LoadAssetReference<TObject>(AssetReference assetReference)
        {
            if (assetReference.Asset == null)
            {
                assetReference.LoadAssetAsync<TObject>();
                assetReference.OperationHandle.WaitForCompletion();
            }

            if (assetReference.OperationHandle.Status == AsyncOperationStatus.Succeeded)
            {
                return assetReference.Asset;
            }

            Debug.LogError("Asset Reference failed to load!");
            return null;
        }
    }
}
