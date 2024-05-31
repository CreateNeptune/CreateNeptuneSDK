### 1.0.0

-Release

### 1.0.1

-test change of adding InputManager to CreateNeptune namespace

### 1.0.2

-test

### 1.1.0

-separated CreateNeptune.cs into Singleton.cs, CNExtensions.cs, and MPAction.cs  
-added Preloader.cs and CNCanvas.cs

### 1.1.1

-added root namespace to asmdef

### 1.1.2

-fixed bug with InputManager not behaving correctly when there is no EventSystem active  
-separated InputManagerEvents into their own scripts

### 1.1.3

-added toggle for DDOL on Singleton
-changed Vector2 to Vector3 in MPAction scaling function

### 1.1.4

-made OnEnable() and OnDisable() virtual in CNCanvas.cs

### 1.1.5

-changed how drag events are sent from InputManager.cs

### 1.1.6

-added OnDestroy() method to ensure singleton consistency in Singleton.cs
-added Singleton<T0, T1> extension class to Singleton.cs

### 1.1.7

-added FindItemIndexInArray<T>() to CNExtensions.cs

### 1.1.8

-changed object pooling code to use SetParent() in CNExtensions.cs

### 1.1.9

-added CheckFlag to CNExtensions.cs

### 1.2.0

-replaced string easing inputs with enum
-made MPAction a static class
-removed ability to Destroy an object after a scale (down)--this should be handled elsewhere going forward
-NOTE: Will break most previous projects. You will need to replace string inputs with the new MPAction.EaseType

### 1.3.0

-added ScreenshotUtility
  
### 1.3.3

-changed timeToFade in CNCanvas.cs from private to protected

### 1.3.4

-added TryGetSerializationInfoValue to CNExtensions.cs

### 1.3.5

-Changed input checks to sqrMagnitude for efficiency
-Added a check on mobile input for IsPointerOverGameObject in TouchPhase.Began instead of TouchPhase.Ended since this is always false on end on mobile.

### 1.3.6

-Added GetPooledObject<T> to CNExtensions.cs

### 1.3.7

-Changed FindIndexOfItemInArray<T> to work with value types

### 1.3.8

-Added Shuffle<T> overload for LinkedList<T>

### 1.3.9

-Change MPAction.FadeObject to prioritize CanvasGroups over other UI components

### 1.3.10

-Added null checking to CNExtensions.FindIndexOfItemInArray

### 1.3.11

-Changed dragging logic to accomodate drags that exceed the threshold then at some point go under the threshold

### 1.4.0

-Added generic SaveDataUtility class and events. Designed for saving and loading JSON.

### 1.4.1

-Added SafeStartCoroutine() to CNExtensions.cs

### 1.4.2

-Added implementation for TextMeshProUGUI in MPAction.ColorObject()

### 1.4.3

-Added GetEasedTime function, which implements all easing functions, as well as new elastic easing type. 

### 1.4.4

-Removed an experimental static include.

### 1.4.5

-Added bool loaded to SaveDataSingleton.
-Added SetDefaultValues() to SaveDataSingleton.

### 1.4.6

-Altered MPAction.RotateObject to use Quaternion.Lerp for shortest-path rotations instead of using Vector3.Lerp.

### 1.4.7

-Changed SaveDataSingleton to explicitly not update a save file if Serialize outputs null

### 2.0.0

- Deprecated MPAction and moved its contents to two new classes, CNEase and CNAction, with more ease types and flexibility for methods

### 3.1.0

- Added overloads for all MPActions which take only a CNEase.EaseType, for convenience when working in the inspector

### 3.2.0

- The LoadGame() in SaveDataSingleton is now virtual to support functionality such as version control before deserializing the Json Object.

### 3.2.1

- The previous update (3.2.0) was reverted. LoadGame method is not virtual anymore.
- The ProcessJSON method was added to the SaveDataSingleton class to provide a centralized point for processing and handling deserialized JSON save data. It allows for customization in child classes by overriding it to support smooth transitions when migrating data from older versions to newer ones.

### 3.2.2

- The ProcessJSON method was added to the SaveDataSingleton class in the previous version. It is now protected rather than public.

### 3.2.3

- Added simpler overloads for CNExtensions.GetPooledObject and CNExtensions.GetPooledObject<T> 
- Added scale setting to the base CNExtensions.GetPooledObject function
- Made the old versions of CNExtensions.GetPooledObject and CNExtensions.GetPooledObject<T> obsolete
