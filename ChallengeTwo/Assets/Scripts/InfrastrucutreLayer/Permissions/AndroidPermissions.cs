using Cysharp.Threading.Tasks;
using Niantic.ARDK.Utilities.Permissions;

namespace ChallengeTwo.InfrastrucutreLayer.Permissions
{
    //this class is responsible for Requesting camera permissions from the user  .

    public class AndroidPermissions 
    {
        #region Methods  
        // Requests camera permissions from the user ,return true only if it was granted  .

        public async UniTask<bool> RequestCameraPermissionsAsync()
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
        #endregion
    }
}
