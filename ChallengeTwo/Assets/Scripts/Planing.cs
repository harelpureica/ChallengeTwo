
namespace ChallengeTwo
{
    public class Planing 
    {
        /*
         * challenge Requirments: ----------------------------------
         * 
         * implement an Ar app  for mobile With ARDK 
         * placing 3d car object and moving it by input
         * + show/ hide scan 
         * docs:each class ,struct, inject, field and method gets a helper comment  
         * 
         * terms to know:
         * 
         * "auto real time Meshing" is the term i used for the meshing features that is provided with  ARDK'S  arMesh prefab/ arMeshManager.
         * "manual scanning" is the term i used for the area scaning features  that is provided with  ARDK'S arScannigCamera prefab /ArScanManager component.
         *  
         * technical goals:-----------------------
         *          
         * devision to layers: visual(mono's,visuals,gameplay),infrastructure(services)and data(configuration,user,player,scene independent)
         * using both "auto real time Meshing"  with armeshManager and "manual scanning"  or area scan with arscanManager (for learning)
         * using zenject di framework         
         * modular reusable components
         * modular ScriptableObjects settings and data-layer Encapsulation ,scene independent,saving configuration,easy to change.
         * each module should be easy To test 
         * easy to scale up 
         * follow S.O.L.I.D as much as posible
         * add some extra features(physicsBasedCar,loadingscreen,startScreen,etc...)
         * to be able to test features on both  pc and mobile (addaptive input,using ar mocking world for ar features)
         * 
         *  additions:
         *  using some pub-sub/event bus/signal bus for messaging
         *           
         * elements groupings:----------------------------
         * 
         * --visual layer--
         * 
         * reusableComponents:         
         * car:                 
         * AR Features:                    
         * ui:
         * Menus:
         * 
         * --data layer--
         * 
         * configuration 
         *
         * --infrastructure layer--
         * 
         * scenesManaging
         * loading 
         * input 
         *          
         * 
         */

    }
}
