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