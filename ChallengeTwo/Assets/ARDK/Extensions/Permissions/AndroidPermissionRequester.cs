// Copyright 2022 Niantic, Inc. All Rights Reserved.


using UnityEngine;
using Niantic.ARDK.Utilities.Permissions;
using System.Threading.Tasks;

namespace Niantic.ARDK.Extensions.Permissions
{
    /// Quick solution for requesting permissions from an Android device. No permission request popup will
    /// appear if the user has (1) already granted permission or (2) denied permission and requested
    /// not to be asked again.
    ///
    /// @note Other MonoBehaviour's Start methods will get called before the permission flow finishes,
    /// so it isn't safe to initialize ARDK resources in Start that depend on the result of this
    /// request.
    public class AndroidPermissionRequester : MonoBehaviour
    {
        // If we're not using these, we get warnings about them not being used. However, we don't want
        // to completely hide the fields, because that might cause Unity to delete the serialized values
        // on other platforms, which would reset the data on the prefab back to the defaults. So, we just
        // squelch "unused variable" warnings here.
#pragma warning disable CS0414
        [SerializeField]
        private ARDKPermission[] _permissions = null;

#pragma warning restore CS0414

#if UNITY_ANDROID


        public async Task<bool> RequestCameraPermissionsAsync()
        {

            if (!PermissionRequester.HasPermission(ARDKPermission.Camera))
            {
                var permissionStatus = await PermissionRequester.RequestPermissionAsync(ARDKPermission.Camera);
                if (permissionStatus == PermissionStatus.Granted)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return true;

        }
#endif
    }
}
