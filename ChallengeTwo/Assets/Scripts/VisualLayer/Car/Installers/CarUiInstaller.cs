using ChallengeTwo.VisualLayer.UIUtils;
using UnityEngine;
using Zenject;

namespace ChallengeTwo.VisualLayer.Car.Installers
{
    //this class is responsible for installing the needed bindings for car's ui .
    public class CarUiInstaller:MonoInstaller<CarUiInstaller>
    {
        #region Fields
        // the ui button for accelerating.
        [SerializeField]
        private HoldingButton _gazPedalBtn;

        // the ui button to aplly force backwards(reverse).

        [SerializeField]
        private HoldingButton _breakesPedalBtn;        
       
        //the parent object of the cars ui.

        [SerializeField]
        private GameObject _uiParent;

        //the ui button for the wheels steering ui,
        [SerializeField]
        private HoldingButton _streeinWheelButton;

        //the wheels center position.
        
        [SerializeField]
        private RectTransform _wheelCenter;
        #endregion

        #region Methods
        //binds the needed input and outputs for the cars ui.
        public override void InstallBindings()
        {           
            Container
                .Bind<HoldingButton>()
                .WithId("Gaz")
                .FromInstance(_gazPedalBtn)
                .AsTransient();

            Container
               .Bind<HoldingButton>()
               .WithId("Breakes")
               .FromInstance(_breakesPedalBtn)
               .AsTransient();

            Container
               .Bind<HoldingButton>()
               .WithId("SteeringWheelButton")
               .FromInstance(_streeinWheelButton)
               .AsTransient();

            Container
               .Bind<CarSteeringWheel>()
               .AsTransient();

            Container
               .Bind<GameObject>()
               .WithId("UiParent")
               .FromInstance(_uiParent)
               .AsTransient();
           
            Container
                .Bind<RectTransform>()
                .WithId("SteeringWheelCenter")
                .FromInstance(_wheelCenter)
                .AsTransient();

            Container
                .Bind<CarUi>()
                .AsSingle();


        }
        #endregion
    }
}
