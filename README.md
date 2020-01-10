# Oculus Quest VRTK - Hand Tracking and Controller Support

A wrapper Unity framework for VRTK 4.0 that supports a seamless way to support both Oculus Quest's Controller Input Scheme as well as Oculus Quest's Hand Tracking Input Scheme. 

## What Is Included

- HandSDK Framework
- A Sample Scene illustrates using either controllers or hand tracking for VR Climbing that is integrated into VRTK
- SDKs & Unity Assets (*Please consider updating these assets from the Unity Asset Store*):
  - [VRTK Prefabs 4.0 v1.1.8](https://github.com/ExtendRealityLtd/VRTK.Prefabs)
  - [Oculus SDK (v12)](https://assetstore.unity.com/packages/tools/integration/oculus-integration-82022)
  - [LowPoly SciFi Pack](https://assetstore.unity.com/packages/3d/environments/sci-fi/free-lowpoly-scifi-110070)
  - [Starfield Skybox](https://assetstore.unity.com/packages/2d/textures-materials/sky/starfield-skybox-92717)
  
## Setup

First, you will need to setup a scene that supports VRTK and Oculus Quest. You can take a look at the OVR Camera Rig and Traced Alias provided in the sameple scene.

Once VRTK is succesfully linked to the OVR Camera Rig, you can drop the included Input Manager into your scene. You will then need to assign the corresponding GameObjects to both the Touch COntrollers script and Hands Controller script, which can be found from the OVR Camera Rig. 

## How To Use

This framework simply abstracts how Oculus Input is handled differently between hand tracking and controllers. As such, in order to have a common set of inputs, the framework maps the pinch actions provided by Oculus Hand Tracking to 4 core button inputs :
  - Trigger : Index Finger Pinch
  - Grip : Middle Finger Ping
  - A Button : Ring Finger Pinch
  - B Button : Pinky Pinch
 
The above mapping are defaults and these defaults can be overridden on the HandsController script ( located on the Input Manager prefab ). Should you need to, you can get the input data directly from the Touch Controller script as well as Hands Controller script.
 
However, if you are just interested in getting input from the active controller input scheme ( either physical controllers or hand tracking ), those methods are accessible via the Singleton Input Manager, which is responsible for getting input from the active control scheme.
  - GetButton(Hand , Button) : Get whether a controller button or hand pinch is pressed or not
  - GetAxis(Hand , Button) : Get the range of how much a controller button is pressed or how much pinch strength is used

For the purposes of VRTK integration, you can also use the provided OVRButton and OVRAxis prefabs, which are responsible for hooking into VRTK Boolean Actions or Float/Axis Actions respectively. See the sample scene to see how the Trigger Input is used to hook into VRTK for climbing. 
 
## Video Documentation

Coming Soon!
