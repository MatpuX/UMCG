
# Vicon HMD Empty Unity Foundation
This project is intended to be used as a foundation from which research projects can be built. The following functionality is meant to be used in the Unity Editor and not all function is operational in a build version:
- Import of marker data from Vicon Nexus
- Calibration of marker data to Unity space
- Unity object reference to marker position
- Collision detection of marker position using a Unity class and object
- Position data recording
- Data replay in Scene window
- Vicon simulation for testing, building, and debugging

## Table of Contents
![image](https://github.com/user-attachments/assets/87238b34-e991-4bd5-8f41-9ecb2eae885b)

___
## Requirements and Dependencies
### Version and Template 

   - Minimum Version: 2022.2.0f1<br> 
     Earlier versions may generate errors. 
   - Recommended Version: 2022.3.20f1 LTS 
   - Template: Unity 3D
      - Universal Render Pipeline
      - Compatible with Built-In Render Pipeline.
      - Untested in HDRP.
> [!IMPORTANT]
> *This project was developed within the URP and some small changes will need to be made for built-in.*
___
### Necessary Packages and Libraries 
Recommended installation in the order listed below due to dependencies. 

#### Packages: Microsoft 
If not present, these packages can be installed either from the Unity Package Manager via tarball for the versions listed below, or via [MixedRealityFeatureTool.exe](https://www.microsoft.com/en-us/download/details.aspx?id=102778)

1. Mixed Reality Toolkit 2/10 
   - Mixed Reality Toolkit Foundation (v. 2.8.3)
   - Mixed Reality Toolkit Standard Assets (v. 2.8.3)
2. Other Features 1/4 
   - Mixed Reality Input (v. 0.9.2006)
3. Platform Support 1/5 
   - Mixed Reality OpenXR Plugin (v. 1.9.0)

#### ADG: In Situ library 
The In Situ libraries can be found in \Packages\lib and should automatically install. If you receive errors that the namespace ADG is missing, you may need to manually install the libraries using the Package Manager.

1. ADG – In situ 
2. ADG – In situ XR

___
## Setup
- [X] Click "Use This Template" to create a new repository from this foundation
- [X] Verify Unity version 2022.2.0f1 is installed in Unity Hub (if it is not, Unity Hub will prompt the download)
- [X] Open the Package Manager in Unity (Unity/Windows/Package Manager)
- [X] Verify there are no errors with the required packages, libraries, and dependencies.
- [X] Update Vicon Settings in Unity
- [X] Ensure the Shared Subject String and vicon subject match (in Unity Simulator, TestSub2)
- [X] Add any necessary additional poses for Unity object interaction with vicon markers
- [X] Create a new **Hitter** GameObject under the Hitters hierarchy object for any new poses

### Vicon Settings in Unity / Windows
Vicon settings can be changed in the app data object:<br>
| Description  | Image |
| :---------- |  ------------- | 
| **Location**:<br> Assets/project/data/app | <img width="250" alt="unity_appLocation" src="https://github.com/user-attachments/assets/53f715e9-b85c-4882-9921-e9fdce682e65" /> | 
| **App Settings in Inspector**<br><ol><li>Host Address:</li> <ul><li>VR Lab 1: 10.0.0.10</li></ul><li>Port:</li> <ul><li>VR Lab 1: 801</li></ul><li>Vicon Mode:<br>The method in which the datastream is obtained from Vicon.<br>For most use cases, this will be ClientPullPreFetch</li><li>Vicon Mode(2)<br>This project is currently configured for Vicon Nexus.</li>  | <img width="250" alt="unity_appSettings" src="https://github.com/user-attachments/assets/a6cb237a-70d5-455b-b783-9d7a809b0c14" /> |

> [!IMPORTANT]
> 1. To read Vicon input, the computer running the Unity project needs to be connected to the Network **vrlab1** <br>
> 2. Assign the IP manually to: **10.0.0.1#** where # is a value beween 1 and 9<br>
>    - If connecting with multiple computers, each needs a different number.
> 3. Set the IPv4 mask to 255.255.255.0

### Vicon/Unity Communication
In order for Unity to recognize motion tracking and update relative game objects appropriately, ensure that the following steps are taken:
<a name="unity-poses"> </a>
1. <ins>Shared Subject String</ins> <br>
   A scriptable object used to hold the subject name from Vicon as a shared string. This value is used as reference to link objects in the game to specific markers or segments as received from Vicon.
   - Location: Assets/project/data
   - **This must be manually updated to match the subject created in Vicon.**
   - Should a project have multiple Vicon subjects (multiplayer games or environments), each Vicon subject will require its own subject object. 
2. <ins>Unity Object Reference for Vicon markers: **Pose** objects</ins><br>
   - Location: Unity Hierarchy, **poses**
   - If a Unity reference object is needed for a Vicon marker, it needs to have a pose object.
   - A pose object needs to have an attached C# script: Unity State Marker (or Unity State Segment for Segments)
   - References for script variables:
      - the Shared Subject String (above)
      - **Name: Must match the marker name from Vicon subject (or simulated subject)**
   - Note: Simulated names may sometimes have issues with recognition. Attempt to rename them in the Unity State Marker script, update the pose name, and try again.
3. <a name="unity-hitters"></a><ins>Collision tracking of Vicon marker</ins><br>
   The project uses the class **Hitter** and abstract inheritable class **Hittable** to track object interactions. <br>
   - **Hitter** includes read/write functionality for data recording and can be used to verify data reporting of vicon position.
      - For each object, the radius indicates the distance from the marker which collision is enabled.
      - the Pose field relates to the above pose object (the class Unity State Marker attached to it)
   - **Hittable** contains an abstract function Hit
      - Create a new C# script class for a hittable object and inherit from Hittable<br>
        _public class ExampleObject : Hittable_
      - create an override function for Hit: <br>
        _public override void Hit(Hitter hitter)_ <br>
        This function contains what happens to the object it is attached to when it collides with a Hitter object.

### Unity Setup: Scene & HMD 
<table>
   <thead>
      <tr>
         <th width = "65%"> Description</th>
         <th width = "35%"> Image</th>
      </tr>
   </thead>
   <tbody>
      <tr>
         <td width = "65%" valign="top"> <b>Universal Render Pipeline</b> <br> This project was created using the URP template. For project builds requiring the Built-In Render Pipeline or HDRP, this project's functionality can be imported into a new or existing project sa a package, but will require updating Shaders.</td>
         <td width = "35%"> <img width="250" alt="unity_shaderStandard" src="https://github.com/user-attachments/assets/8412e990-00f7-4219-9a06-d3c6b62fdf2d" /></td>
      </tr>
      <tr>
         <td width = "65%"> <b>VR Player Object</b> <br>This unity project is already configured for VR. When a VR HMD is connected to the computer, running the project in Unity Editor will automatically connect the Vicon input data to the HMD system.<ul><li>World position Vector3.zero is calibrated for the player location.</li><li> <b>Simulator</b> The Unity class Simulator must be disabled (unchecked in the Unity Hierarchy) to use this project with live Vicon data. It is used for debugging and hijacks the vicon feed.</li></td>
         <td width = "35%"><img width="250" alt="image" src="https://github.com/user-attachments/assets/074d01ca-539b-4a2f-a5ce-0e73dd2d0f7a" /> </td>
      </tr>
      <tr>
         <td width = "65%">
            <b>Layers and Masks</b> <BR>
            Some functionality of the software requires an additional layer not present in the Unity default template: the calibration bubble, inner_sphere. This should already be present in the project as layer Fade. If it is not available, follow these steps to add it:
            <ul>
               <li> 
                  Select an object in the Hierarchy so that it appears in the Inspector panel.  
               </li>
               <li>
                  In the Inspector panel, click the dropdown for Layers
               </li>
               <li>
                  Select “Add Layer”
               </li>
               <li> 
                  In an empty User Layer field, type a name for the layer.
               </li>
            </ul> 
         </td>
         <td width = "35%">
            <img width="250" alt="unity_addlayer" src="https://github.com/user-attachments/assets/012b66e9-d609-4293-b877-81feb3caab62" />
         </td>
   </tbody>
</table><br>
            
___

## Project Behaviours and Feature Functionality
<table>
   <thead>
      <tr>
         <th width = "65%"> Description</th>
         <th width = "35%"> Image</th>
      </tr>
   </thead>
   <tbody>
      <tr>
         <td width = "65%" valign="top"><a name="unity-main"></a>
            <h3>Game States</h3>
            There are three game states to this project. They can be manually navigated in the Editor through the Main script (attached to game object "main")<br>
            <ul>
               <li>
                  <b>Menu</b>: This is a default resting state for the application and the launch state. The application will stay in this state unless prompted otherwise. 
               </li>
               <li>
                  <b>Calibration</b>: This state callibrates the vicon readings, user position, and the translation of those readings to Unity data. <br>This state can be engaged from the project hierarchy under the **menu** object. Once callibration is complete, the application will return to the Menu State.
               </li>
               <li>
                  <b>Game</b>: Where game based code is enabled, including data for timing relevant to data recording. All data recording should be done in the Game State to ensure accurate reporting. As with the Calibration state, this state can be engaged from the menu object.
               </li>
            </ul>
         </td>
         <td width = "35%">
            <img width ="250" src=https://github.com/user-attachments/assets/930b785d-672d-4c4b-85b9-e6dfa40caea0>
         </td>
      </tr>
      <tr>
         <td width = "65%" valign="top">
            <h3>Data Recording and Playback</h3>
            <ol>
               <li>
                  <b>Start Recording:</b><br>
                  Begins writing Vicon marker data and Hitter information to a compressed file.
               </li>
               <li>
                  <b>Open:</b><br>
                  <ul><li>Loads a compressed file to be read in playback. Open files can also be exported to an uncompressed JSON file for data review.<br></li>
                  <li>If a file is open, the "Target Time" slider can be used to show tracked positions (intervals of .02 seconds)</li>
                  <li>For playback, files must be opened in the same project from which they were recorded</li>
                  </ul>
               </li>
               <li>
                  <b>JSON Export:</b><br>
                  Uncompresses the open file and saves as .json. This format can be read in MatLab, Visual Studio, etc.
               </li>
            </ol>
         </td>
         <td width = "35%">
            <img width ="250" src=https://github.com/user-attachments/assets/914feb4c-8a9e-40b6-8f85-9f521182a6c1>
         </td>
      </tr>
      <tr>
         <td width = "65%"><a name="unity-simulator"></a>
            <h3>Vicon Simulator</h3>
            The simulator is used for debugging and testing in the Unity Engine. It hijacks the Vicon connection at application start and launches a simulated subject. The simultor script <i>must</i> be disabled to connect to the Vicon network.<br>
               <ul>
                  <li>
                     Each subject is added to the <i>Vicon Simulator</i> script, so testing can occur with multiple simulated subjects. The simulated subject's name should be used to populate the shared string field in the same way a live Vicon subject name would be used.
                  </li>
                  <li>
                     Simulated markers are children of the Subject GameObject and must be added to the script <i>Vicon Simulator Subject.</i>
                  </li>
                  <li>
                     Each simulated marker must have the Unity State Marker script attached. Use the Name from these markers when setting up <a href="#unity-poses">poses</a>.
                  </li>
                  <li>
                     In Editor runtime, the markers under the simulator object can be moved to emulate Vicon movement.
                  </li>
               </ul>
         </td>
         <td width = "35%">
            <img width ="250"src=https://github.com/user-attachments/assets/4525a79f-17c0-4aea-8d05-2849edefbd39 />
         </td>
      </tr>
   </tbody>
</table><br>

___
# Appendix

## Hierarcy Structure
<table>
   <tbody>
      <tr>
         <td>
            <ul>
               <li> EventSystem</li>
               <li><a href="#unity-hitters"> hitters</a></li>
                  <ul>
                     <li> prefab(s): hitter object</li>
                  </ul>
               <li> <a href = "#unity-main">main</a><br>
               A hub for state scripts and references. </li>
               <li> modifiers</li>
               <ul>
                  <li> correction and smoothing behaviours for translation of Vicon data to Unity</li>
               </ul>
               <li> player</li>
               <ul>
                  <li> camera</li>
                     <ul>
                     <li> prefab: inner_sphere <br>
                        (calibration object that hides the surrounding environment)</li>
                     </ul></ul>   
               <li> <a href="#unity-poses">poses</a></li>
               <ul>
                  <li> children correlating to Vicon markers</li>
               </ul>
               <li> <a href="#unity-simulator">simulator</a></li>
               <ul>
                  <li> simulated subject</li>
                  <ul>
                     <li> simulated markers and segments of subject</li>
                  </ul></ul>
               <li> space<br>
                 used to calibrate Vicon axis with the Unity axis (requires wand)</li>
               <li> state<br>
                 converts Vicon state to Unity state (used mostly in debugging)</li>
               <li> view<br>
                 containers for <a href="#unity-main">game state</a> scripts and UI</li>
               <ul>
                  <li> calibrate</li>
                  <li> menu</li>
                  <li> game</li>
               </ul>
               <li> world<br>
                 environment assets, lights, etc.</li>
            </ul>
            </td>
         <td>
            <img width="300" alt="unity_hierarchy" src="https://github.com/user-attachments/assets/a678ef5c-5fa7-43dc-8cf5-b87df133568b" />
         </td>
         </tr>
  </tbody></table>
  
## Folder Structure: Project
- **Assets/project**
   - /code
      - /editor/AppEditor.cs
      - /editor/FileEditor.cs
      - App.cs
      - Callibrate.cs
      - Game.cs
      - Hittable.cs
      - Hitter.cs
      - Main.cs
      - Menu.cs
      - Playback.cs
      - PlaybackHitter.cs
   - /data
      - app
      - ~~gizmos~~ 
      - ~~lighting~~
      - ~~pipeline~~
      - ~~processing~~
      - ~~profile~~
      - ~~renderer~~ <a href="#footnote1"><i>Note *</i></a>
      - subject
   - /material
   - /prefab
      - hitter
      - playback
      - playback_hitter
   - /scene
   - /texture
 
  <a name="footnote1"></a>* While these data types exist, they are not currently used in the foundation project. They may be leveraged for use in building from the foundation.
