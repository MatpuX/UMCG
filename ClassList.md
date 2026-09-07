
# Vicon HMD Foundation Classes

___
## Project Classes
### AppEditor.cs

#### Summary
A project-specific editor that informs a scriptable object (the app asset), providing a singular location to update values of game settings. These settings include overarching variables (such as host address, port, Vicon mode, etc). Changing the settings themselves (rather than their values) requires making changes to the AppEditor.cs file.

#### Functions
<table>
  <thead>
    <tr>
      <th width = "20%">Function and Parameters</th>
      <th width = "35%">Description</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td><code>+ OnScene(SceneView view)</code></td>
      <td>Inactive in Foundation. This function has been used in other builds to create on-screen drawings that only appear in the Scene window.</td>
    </tr>
    <tr>
      <td><code>+ OnInspectorGUISettings()</code></td>
      <td>Creates the Editor GUI layout of application settings and writes to JSON settings file.</td>
    </tr>
  </tbody>
</table>


#### Creating New Settings
```
settings[“host”] = EditorGUILayout.TextField(“Host”, settings.StringOf(“host”, "10.0.0.10”));
```

- **Key Name: “host”** <br>
Used in other scripts to find the setting’s value. To obtain the settings file in which to searc for the key, the script function should include a call to FetchSettings() in the app asset.<br>
```
var settings = main.App.FetchSettings();
```

- **Input type allowed in editor: TextField** <br>
Determines what type of field will be used for input in the Editor. Examples of other input types can be found in Unity's [EditorGUILayout documentation](https://docs.unity3d.com/ScriptReference/EditorGUILayout.html).

- **Editor Display Name: “Host”** <br>
This is the text that will appear in the Editor when viewing the scriptable object. This should be short, but descriptive. 

- **JSON Fallback identifier: StringOf**<br>
Should match the type of entry – NumberOf for numbers, StringOf for text or mixed alphanumeric and symbols. 

- **Default variable value: (example, "10.0.0.10”)** <br>
Initial value at App object creation.  <p>
<img width="602" alt="unity_appeditor" src="https://github.com/user-attachments/assets/0f09e565-5122-4dd7-a537-b3d994be7fe2" />
  
___
  
### FileEditor.cs

#### Summary
A project-specific editor copied from the In Situ library affecting behaviour of Main.cs in the Unity editor. This script controls the GUI elements in the inspector including recording, file management, and playback. 

#### Variables
<code>+ bool Compress</code><br>
sets whether or not the recorded file saves as a compressed .gz 

#### Functions
<table>
  <thead>
    <tr>
      <th width = "25%">Function and Parameters</th>
      <th width = "25%">Description</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td><code>+ OnInspectorGUI()</code></td>
      <td>Sets Editor GUI functionality for the script Main.cs</td>
    </tr>
    <tr>
      <td><code>+ Save(App app, Main target)</code></td>
      <td>Responsible for save settings of recorded data.</td>
    </tr>
    <tr>
      <td><code>+ Load(App app, Transform parent)</code></td>
      <td>Reads a compressed file and loads it for replay/export</td>
    </tr>
  </tbody>
</table>

___

### App.cs

#### Summary
A script containing asset creation for application settings and states. This should not be edited directly unless adding variables or functions within the scope of the application. Changes to settings and on-scene gizmos should be made in the local copy of AppEditor.cs. 

#### Variables
- <code>+ Telemetry : Telemetry</code>
- <code>+ EaseFunc : Ease.Func</code>
- <code>+ Hitters : List(Hitter)</code>
- <code>+ PlaybackAsset : Playback</code>
  
___

### Callibrate.cs

#### Summary
This script is responsible for game behaviour during the game state: StateCallibrate (see Main.cs for more information on states). 

#### Variables
<table>
  <thead>
    <tr>
      <th width = "25%"> Variable Name / Type </th>
      <th width = "40%"> Description </th>
      <th width = "35%"> Image </th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td><code>+ OverrideAlpha : float</code> </td>
      <td> NonSerialized: <br>Value for fade override </td>
      <td rowspan=21 valign = top> <img width="550" alt="unity_callibrateIns" src="https://github.com/user-attachments/assets/f17b8411-df1e-4d2e-9b09-02b0df524788" /></td>
    </tr>
    <tr>
      <td><code>+ Alpha : float</code></td>
      <td>NonSerialized: <br>Value for fade</td>
    </tr>
    <tr>
      <td><code>+ State : int</code></td>
      <td>NonSerialized:<br>State value determines UI display and timing of UI advance</td>
    </tr>
    <tr>
      <td><code>+ SnapshotTimer : float</code></td>
      <td>NonSerialized:<br> Compared to BaseTimer to ensure callibration timing is accurate</td>
    </tr>
    <tr>
      <td><code>+ BaseTimer : float</code></td>
      <td>NonSerialized:<br> A time reference for comparison in statements</td>
    </tr>
    <tr>
      <td><code>+ Material : Material</code></td>
      <td>NonSerialized:<br> Material of the fadeout object (inner_sphere prefab)</td>
    </tr>
    <tr>
      <td><code>+ MaterialColor : Color</code></td>
      <td>NonSerialized:<br> Color attached to Material</td>
    </tr>
    <tr>
      <td><code>+ SkipIfPossible : bool</code></td>
      <td>Allow skipping callibration.</td>
    </tr>
    <tr>
      <td><code>+ UseSpaceForward : bool</code></td>
      <td>Use Vector.forward of player object to determine left/right</td>
    </tr>
    <tr>
      <td><code>+ Head : PoseTransform</code></td>
      <td>Reference to HMD pose transform</td>
    </tr>
    <tr>
      <td><code>+ Left : PoseBehaviour</code></td>
      <td>Reference to left hand pose</td>
    </tr>
    <tr>
      <td><code>+ Right : PoseBehaviour</code></td>
      <td>Reference to right hand pose</td>
    </tr>
    <tr>
      <td><code>+ Offset : Vector3</code></td>
      <td>Rendered offset for Calibration UI</td>
    </tr>
    <tr>
      <td><code>+ Canvas : Canvas</code></td>
      <td>Canvas specific for Calibration state, referenced for enable/disable </td>
    </tr>
    <tr>
      <td><code>+ Text : TMP_Text</code></td>
      <td>Text within container for user instructions</td>
    </tr>
    <tr>
      <td><code>+ Follow : Transform</code></td>
      <td>Connect text/container orientation to HMD location/rotation</td>
    </tr>
    <tr>
      <td><code>+ Group : Canvas Group</code></td>
      <td>Reference to group, ensures changes made effect all objects within the group.</td>
    </tr>
    <tr>
      <td><code>+ Fadeout : Renderer</code></td>
      <td>inner_sphere prefab object's mesh renderer</td>
    </tr>
    <tr>
      <td><code>+ Camera : Camera</code></td>
      <td>Player Camera</td>
    </tr>
    <tr>
      <td><code>+ CalibrateMask : LayerMask</code></td>
      <td>Mask enabled for calibration</td>
    </tr>
    <tr>
    <td><code>+ DefaultMask : LayerMask</code></td>
    <td>Non-Calibration mask for other game states</td>
    </tr>
  </tbody>
</table>


#### Functions
<table>
  <thead>
    <tr>
      <th width = "25%">Function and Parameters</th>
      <th width = "25%">Description</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td><code>+ Initialize(Main main)</code></td>
      <td>Performs various checks against callibratin passes and references.</td>
    </tr>
    <tr>
      <td><code>+ TrySnapshot(App app)</code></td>
      <td>Updates camera rotation offset.</td>
    </tr>
    <tr>
      <td><code>+ UpdateActive(Main main, float deltaTime)</code></td>
      <td>Sets baseline snapshot of user poses and head transform rotation</td>
    </tr>  
  </tbody>
</table>

___

### Game.cs

#### Summary
Much of the Game.cs functionality in previous versions of the project was built for running game objectives, such as spawning objects. In this foundation project, the remaining functionality is largely related to time-tracking and UI management and kept for ease of future development.

#### Variables
<table>
  <thead>
    <tr>
      <th width = "25%"> Variable Name / Type </th>
      <th width = "40%"> Description </th>
      <th width = "35%"> Image </th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td><code>+ GameStart : float</code></td>
      <td>NonSerialized:<br>Marks the initial time of game state becoming Game</td>
      <td rowspan=7 valign=top><img width="550" alt="unity_gameIns" src="https://github.com/user-attachments/assets/ea7dfe5b-f3c8-4f52-88ab-cdb69b9b4a20" /></td>
    </tr>
    <tr>
      <td><code>+ NextSpawn : float</code></td>
      <td>NonSerialized:<br>Can be used as an interval for spawning objects</td>
    </tr>
    <tr>
      <td><code>+ SpawnIndex : uint</code></td>
      <td>NonSerialized:<br>used for randomization with Hash.Noise</td>
    </tr>
    <tr>
      <td><code>+ Alpha : float</code> </td>
      <td>NonSerialized:<br>clamped 0-1 value for UI elements alpha value</td>
    </tr>
    <tr>
      <td><code>+ main : Main</code></td>
      <td>Reference to the main script. Used to gain references to App, Menu, Callibration, etc.</td>
    </tr>
    <tr>
      <td><code>+ Canvas : Canvas</code></td>
      <td>Canvas container for UI elements</td>
    </tr>
    <tr>
      <td><code>+ Group : CanvasGroup</code></td>
      <td>Reference to group, ensures changes made effect all objects within the group.</td>
    </tr>
  </tbody>
</table>
</code>

#### Functions
<table>
  <thead>
    <tr>
      <th width = "25%">Function and Parameters</th>
      <th width = "25%">Description</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td><code>+ Initialize(Main main)</code></td>
      <td>Initial time setup, object clearing, and seed setting at state change to StateGame</td>
    </tr>
    <tr>
      <td><code>+ UpdateActive(Main main, float deltaTime)</code></td>
      <td>Regulation of NextSpawn time, SpawnIndex value, ui fade-in, hitter weight logic</td>
    </tr>    
    <tr>
      <td><code>+ UpdateInactive(float deltaTime)</code></td>
      <td>UI fade-out</td>
    </tr>
    <tr>
      <td><code>+ VectorOf(float yew, float pitch, float distance)</code></td>
      <td>Vector calculation</td>
    </tr>
  </tbody>
</table>

___

### Hittable.cs

#### Summary
An inheritable abstract class, used to denote objects as interactable with Hitter objects. The Hitter class uses collision with this class to call the function Hit. Therefore, creating individual classes for different object types and outcomes means that the hit logic is already in place.

#### Functions
- _Hit(Hitter hitter)_ <br>
  abstract class: Hit will be called from the Hitter when a collision is detected and code executed. 
  
___

### Hitter.cs

#### Summary
Attaching the Hitter script to an object provides a collision system for Vicon markers. For example, using the left_hand pose for the Pose variable of this script would allow the user's left hand (as named/noted in the Vicon subject) to interact with objects having the Hittable script. 

#### Variables
<table>
  <thead>
    <tr>
      <th width = "25%"> Variable Name / Type </th>
      <th width = "40%"> Description </th>
      <th width = "35%"> Image </th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td><code>+ Colliders : Colldier[]</code></td>
      <td>NonSerialized:<br>Array of colliders for hitter object</td>
      <td rowspan=8 valign=top> <img width="550" alt="unity_hitterIns" src="https://github.com/user-attachments/assets/963b3ba4-d44d-44ae-bbaf-13d4a18a3db7" /></td>
    </tr>
    <tr>
      <td><code>+ Alpha : float</code></td>
      <td>NonSerialized:<br>Clamped 0-1 value to handle fade in/out of hitter objects</td>
    </tr>
    <tr>
      <td><code>+ EntityID : int</code></td>
      <td>NonSerialized:<br>Identifying integer for writing to JSON file</td>
    </tr>
    <tr>
      <td><code>+ Marker : string</code></td>
      <td>NonSerialized:<br>Obtains the Vicon marker name from the Pose object</td>
    </tr>
    <tr>
      <td><code>+ App : App</code></td>
      <td>Reference to the App data asset. </td>
    </tr>
    <tr>
      <td><code>+ Pose : PoseBehaviour</code></td>
      <td>Pose associated with the Vicon Marker the hitter should associate with</td>
    </tr>
    <tr>
      <td><code>+ Weight : float</code></td>
      <td>Currently unused for game logic</td>
    </tr>
    <tr>
      <td><code>+ Radius : float</code></td>
      <td>Distance from the Vicon Marker which should register a collision</td>
    </tr>
  </tbody>
</table>

#### Functions
<table>
  <thead>
    <tr>
      <th width = "20%">Function and Parameters</th>
      <th width = "10%">Returns</th>
      <th width = "35%">Description</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td><code>+ Hide()</code></td>
      <td>void</td>
      <td>Fade alpha to 0</td>
    </tr>
    <tr>
      <td><code>+ Reset()</code></td>
      <td>void</td>
      <td>Re-initialize App variable and set Weight to 1</td>
    </tr>
    <tr>
      <td><code>+ Write(Telemetry telemetry, Hitter hitter)</code></td>
      <td>void</td>
      <td>Static function, writes hitter telemetry data during recording</td>
    </tr>
    <tr>
      <td><code>+ Read(insitu.telemetry.Object obj, out string marker, out float radius, out float alpha, out Vector3 position)</code></td>
      <td>bool</td>
      <td>Static function, reads hitter telemetry data for export to JSON or replay via playback script</td>
    </tr>    
  </tbody>
</table>

___

### Main.cs

#### Summary
The Main script manages the application and recording states, Vicon state and connection or Vicon simulator, and file management for recording/exporting.

#### Variables
<table>
  <thead>
    <tr>
      <th width = "27%"> Variable Name / Type </th>
      <th width = "38%"> Description </th>
      <th width = "35%"> Image </th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td><code>+ COMPRESS : bool = true</code></td>
      <td></td>
      <td rowspan=18 valign=top><img width="550" alt="unity_mainIns" src="https://github.com/user-attachments/assets/236da5a5-bdc7-47c9-b8da-d3e93733f623" />
 </td>
    </tr>
    <tr>
      <td><code>+ RECORDNONE : int = 0</code></td>
      <td>Constant state identity for recording. Indicates that recording is not active.</td>
    </tr>
    <tr>
      <td><code>+ RECORDSTART : int = 1</code></td>
      <td>Constant state identity for recording. Indicates initialization of recording data.</td>
    </tr>
    <tr>
      <td><code>+ RECORDRUNNING : int = 2</code></td>
      <td>Constant state identity for recording. Indicates recording actively running and data being written.</td>
    </tr>
    <tr>
      <td><code>+ RECORDSTOP : int = 3</code></td>
      <td>Constant state identity for recording. Indicates the recording is in the process of stopping before returning to RecordNone.</td>
    </tr>
    <tr>
      <td><code>+ STATEMENU : int = 0</code></td>
      <td>Constant state identity for application. Indicates Menu state.</td>
    </tr>
    <tr>
      <td><code>+ STATECALLIBRATE : int = 1</code></td>
      <td>Constant state identity for application. Indicates Callibration state.</td>
    </tr>
    <tr>
      <td><code>+ STATEGAME : int = 2</code></td>
      <td>Constant state identity for application. Indicates Game state.</td>
    </tr>
    <tr>
      <td><code>+ RunThreaded : bool = true</code></td>
      <td>Static indicator for Vicon connectivity.</td>
    </tr>
    <tr>
      <td><code>+ RecordingState : int</code></td>
      <td>NonSerialized:<br>Accessible indicator of current recording state. Changes are written as:<br><code>RecordingState = RecordRunning;</code></td>
    </tr>
    <tr>
      <td><code>+ CurrentState : int</code></td>
      <td>NonSerialized:<br>Accessible indicator of current application state. Changes are written as:<br><code>CurrentState = StateCallibrate;</code></td>
    </tr>
    <tr>
      <td><code>+ StateHandle : int</code></td>
      <td>Defunct in this iteration of the project. </td>
    </tr>
    <tr>
      <td><code>+ LastBlockIndex : int</code></td>
      <td>Comparison to BlockIndex to determine Vicon state writing</td>
    </tr>
    <tr>
      <td><code>+ App : App</code></td>
      <td>Reference to App data asset</td>
    </tr>
    <tr>
      <td><code>+ Simulator : ViconSimultor</code></td>
      <td>Reference to simulated Vicon subject</td>
    </tr>
    <tr>
      <td><code>+ Callibrate : Callibrate</code></td>
      <td>Reference to Callibration state script: Callibrate.cs</td>
    </tr>
    <tr>
      <td><code>+ Menu : Menu</code></td>
      <td>Reference to Menu state script: Menu.cs</td>
    </tr>
    <tr>
      <td><code>+ Game : Game</code></td>
      <td>Reference to Game state script: Game.cs</td>
    </tr>
  </tbody>
</table>

#### Functions
<table>
  <thead>
    <tr>
      <th width = "20%">Function and Parameters</th>
      <th width = "10%">Returns</th>
      <th width = "35%">Description</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td><code>+ Connect(bool safely)</code></td>
      <td>null or WaitForSecondsRealTime(5)</td>
      <td>IEnumerator: Attempts connection to Vicon host and port.</td>
    </tr>
    <tr>
      <td><code>+ ConnectSimulator()</code></td>
      <td>null</td>
      <td>IEnumerator: start the vicon simulator</td>
    </tr> 
    <tr>
      <td><code>+ OnState(Vicon.State state) </code></td>
      <td>void</td>
      <td>During recording, write vicon state telemetry</td>
    </tr> 
    <tr>
      <td><code>+ StartGame()</code></td>
      <td>void</td>
      <td>Change application state to StateGame and run Game.Initialize(this)</td>
    </tr> 
    <tr>
      <td><code>+ UpdateVicon()</code></td>
      <td>void</td>
      <td></td>
    </tr> 
    <tr>
      <td><code>+ </code></td>
      <td></td>
      <td></td>
    </tr> 
  </tbody>
</table>
  
___

### Menu.cs

#### Summary
Conrols the Menu state of the application. This state is intended as a holding area for the player, where there are no active objectives.

#### Variables
<table>
  <thead>
    <tr>
      <th width = "27%"> Variable Name / Type </th>
      <th width = "38%"> Description </th>
      <th width = "35%"> Image </th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td><code>+ Alpha : float </code></td>
      <td>Value clamped 0-1 to control fade in/out of UI assets.</td>
      <td rowspan=3 valign= top> <img width="550" alt="unity_menuIns" src="https://github.com/user-attachments/assets/681a4974-b899-4aa0-96ad-91cbd6f8c479" /></td>
    </tr>
    <tr>
      <td><code>+ Canvas : Canvas </code></td>
      <td><code>Canvas container for Menu UI, used for enabling and disabling canvas. </code></td>
    </tr>
    <tr>
      <td><code>+ Group : CanvasGroup </code></td>
      <td><code>References all UI elements within Canvas </code></td>
    </tr>
  </tbody>
</table>

#### Functions
<table>
  <thead>
    <tr>
      <th width = "20%">Function and Parameters</th>
      <th width = "10%">Returns</th>
      <th width = "35%">Description</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td><code>+ UpdateActive(Main main, float deltaTime) </code></td>
      <td>void</td>
      <td>Increase Alpha value to fade UI in</td>
    </tr>
    <tr>
      <td><code>+ UpdateInactive(float deltaTime) </code></td>
      <td>void</td>
      <td>Decrease Alpha value to fade UI out</td>
    </tr>
  </tbody>
</table>
___

### Playback.cs

#### Summary
Responsible for translation of compressed file into playback tracking. When a file is loaded via [Main](#maincs), a copy of the playback prefab is instantiated under the "main" GameObject. This playback allows the user to view tracked markers and hitters at specific timestamps as instantiated objects under the playback prefab. 
#### Variables
<table>
  <thead>
    <tr>
      <th width = "27%"> Variable Name / Type </th>
      <th width = "38%"> Description </th>
      <th width = "35%"> Image </th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td><code>+ File : insitu.telemetry.File </code></td>
      <td>NonSerialized:<br>File referenced for read/write functionality</td>
      <td rowspan=10 valign= top><img width="550" alt="unity_playbackIns" src="https://github.com/user-attachments/assets/ca28a4b4-2924-4556-8114-6abe213c0106" /></td>
    </tr>
    <tr>
      <td><code>+ CurrentTime : float</code></td>
      <td>NonSerialized:<br>Allows reference to time within recorded files for replay</td>
    </tr>
    <tr>
      <td><code>+ VelocityTime: float</code></td>
      <td>Applied to SmoothDamp to determine CurrentTime</td>
    </tr>
    <tr>
      <td><code>+ Hitters : List(PlaybackHitter) </code></td>
      <td>NonSerialized:<br>List of hitters active during recorded period, used to populate playback hitter assets</td>
    </tr>
    <tr>
      <td><code>+ State : Vicon.State</code></td>
      <td>NonSerialized:<br>Vicon state used in parsing during file playback</td>
    </tr>
    <tr>
      <td><code>+  FilePath : string</code></td>
      <td>NonSerialized:<br>Location of playback file</td>
    </tr>
    <tr>
      <td><code>+ TargetTime : float</code></td>
      <td>NonSerialized:<br>Used to seek a specific timestamp during playback</td>
    </tr>
    <tr>
      <td><code>+ main : Main</code></td>
      <td>Reference to main script on object main.</td>
    </tr>
    <tr>
      <td><code>+ HitterAsset : PlaybackHitter</code></td>
      <td>Asset attached to hitters, prefab used to assign reference</td>
    </tr>
    <tr>
      <td><code>+ UnityState : UnityState</code></td>
      <td>Used to retrieve Vicon state if current State.version = 0</td>
    </tr>
  </tbody>
</table>

#### Functions
<table>
  <thead>
    <tr>
      <th width = "20%">Function and Parameters</th>
      <th width = "10%">Returns</th>
      <th width = "35%">Description</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td><code>+ Range(out float min, out float max) </code></td>
      <td>bool</td>
      <td>Checks length of File frames and returns true if greater than 0. min and max floats are output based on timestamp of first and last frames</td>
    </tr>
    <tr>
      <td><code>+ Clean() </code></td>
      <td>void</td>
      <td>Set .Active to false for all hitters</td>
    </tr>
    <tr>
      <td><code>Apply() </code></td>
      <td>void</td>
      <td>For hitters active in recording, call Apply from PlaybackHitter</td>
    </tr>
    <tr>
      <td><code>+ Parse(array<insitu.telemetry.Object> objects, int index, float alpha)</code></td>
      <td>int</td>
      <td>Return value based on reading the data recording file </td>
    </tr>
    <tr>
      <td><code>+ ParseHitter(insitu.telemetry.Object obj, float alpha) </code></td>
      <td>bool</td>
      <td>Returns false if no hitters. Otherwise instantiates if not already present in playback scene and updates Radius, Alpha, and Position</td>
    </tr>
    <tr>
      <td><code>+ ToJson(insitu.telemetry.File file) </code></td>
      <td>Json.Object</td>
      <td>Write contents of File to a json object</td>
    </tr>
  </tbody>
</table>
___

### PlaybackHitter.cs

#### Summary

#### Variables
<table>
  <thead>
    <tr>
      <th width = "27%"> Variable Name / Type </th>
      <th width = "38%"> Description </th>
      <th width = "35%"> Image </th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td><code>+ Active : bool</code></td>
      <td>NonSerialized:<br>Whether or not the hitter is active in the playback</td>
      <td rowspan=10 valign= top><img width="550" alt="unity_playbackIns" src="https://github.com/user-attachments/assets/ca28a4b4-2924-4556-8114-6abe213c0106" /></td>
    </tr>
    <tr>
      <td><code>+ Id : int </code></td>
      <td>NonSerialized:<br>Checked against telemetry object variable "entity" when parsed.</td>
    </tr>
    <tr>
      <td><code>+ Radius : float</code></td>
      <td>NonSerialized:<br>Radius around Vicon Marker which will be recognized for collision events. </td>
    </tr>
    <tr>
      <td><code>+ Alpha : float</code></td>
      <td>NonSerialized:<br> Determins alpha of hitter for fade in/out</td>
    </tr>
    <tr>
      <td><code>+ Position : Vector3</code></td>
      <td>NonSerialized:<br>Hitter localPosition during playback </td>
    </tr>
  </tbody>
</table>

#### Functions
  <table>
  <thead>
    <tr>
      <th width = "20%">Function and Parameters</th>
      <th width = "10%">Returns</th>
      <th width = "35%">Description</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td><code>+ Apply(float time) </code></td>
      <td>void</td>
      <td>For use in Playback from recording. Updates playback Hitter's localPosition, Radius, and localScale.</td>
    </tr>
  </tbody>
</table>

___
## Library Classes (In Situ)

### Unity State

### Unity State Segment
UnityStateSegment is a script that allows an object in Unity to use information contained within a Vicon segment. It forms the connection between Vicon markers within a segment. 

### Unity State Marker
UnityStateMarker is a script that allows an object in Unity to use a Vicon marker’s position. It references a single point and only contains positional data. When applied to a placeholder “pose” game object, that pose can then be used as a link to specific Vicon markers for reference and inclusion in code. 

### Space.cs
