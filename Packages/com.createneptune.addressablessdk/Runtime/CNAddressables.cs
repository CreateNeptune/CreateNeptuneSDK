using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace CreateNeptune.Addressables
{
    public class CNAddressables
    {
        public static TObject LoadAssetReference<TObject>(AssetReference assetReference)
        {
            if (assetReference.Asset == null)
            {
                assetReference.LoadAssetAsync<TObject>();
                assetReference.OperationHandle.WaitForCompletion();
            }

            if (assetReference.OperationHandle.Status == AsyncOperationStatus.Succeeded)
            {
                return (TObject)((object)assetReference.Asset);
            }

            Debug.LogError("Asset Reference failed to load!");
            return default(TObject);
        }

        public static void LoadAssetReferenceAsync<TObject>(AssetReference assetReference, Action<TObject> Callback)
        {
            if (assetReference.Asset == null)
            {
                assetReference.LoadAssetAsync<TObject>();
                assetReference.OperationHandle.Completed += (opHandle) =>
                {
                    if (opHandle.Status == AsyncOperationStatus.Succeeded)
                    {
                        Callback((TObject)((object)assetReference.Asset));
                    }
                    else
                    {
                        Debug.LogError("Asset Reference failed to load!");
                    }
                };

            }
            else
            {
                if (assetReference.OperationHandle.Status == AsyncOperationStatus.Succeeded)
                {
                    Callback((TObject)((object)assetReference.Asset));
                }
                else
                {
                    Debug.LogError("Asset Reference failed to load!");
                }
            }
        }
    }
}
