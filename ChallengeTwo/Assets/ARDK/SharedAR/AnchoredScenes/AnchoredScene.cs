// Copyright 2023 Niantic, Inc. All Rights Reserved.

using System;
using System.Collections.Generic;

using Niantic.ARDK.AR.WayspotAnchors;
using Niantic.ARDK.LocationService;

namespace Niantic.Experimental.ARDK.SharedAR.AnchoredScenes
{
  // Struct that contains information about a virtual scene anchored to a VPS location
  // This can be stored to Marsh (AR backend servers) through the AnchoredSceneService, and later
  //  retrieved to spawn persistent content. 
  // @note Currently Create and Get are supported. Updates to an Anchored Scene from a mobile device 
  //  will be supported in a future release.
  /// @note This is an experimental feature. Experimental features should not be used in
  /// production products as they are subject to breaking changes, not officially supported, and
  /// may be deprecated without notice
  [Serializable]
  public struct AnchoredScene
  {
    // String representation of a Guid. This is generated by the service after creating an Anchored Scene,
    //  and is used to retrieve a scene in a future session.
    public string SceneId { get; internal set; }

    // Human readable name for the scene. Specified when the scene is created.
    public string Name { get; set; }

    // LatLng center of the scene. This is used to query existing scenes by location.
    public LatLng Location { get; set; }

    // Defines the type of scene this is. This is used to filter existing nearby scenes.
    public string Kind { get; set; }

    // List of Wayspot Anchors associated with this scene
    public List<WayspotAnchorPayload> WayspotAnchors { get; set; }

    // Dictionary of string:byte[] to store persistent game state associated with this scene.
    public Dictionary<string, byte[]> PersistentGameData { get; set; }
  }
}