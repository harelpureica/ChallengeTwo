

namespace ChallengeTwo.VisualLayer.AR
{
    //this is a  base interface for ar features .
    public  interface IARFeatureBase
    {
        //initializes the feature.
         void Initialize();

        //sets the visuals visible/invisible.
         void Visualize(bool visible);

        //enables/disables the feature.
         void Enable(bool enabled);

        //destroys the created meshes.
        void ClearMesh();

    }
}
