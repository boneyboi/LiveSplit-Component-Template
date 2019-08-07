# LiveSplit-Component-Template
A template for learning how to create a component for LiveSplit

# Credits
Special Thanks to Furman and the Summer Research Fellowship program through the Center for Engaged Learning for funding this project!

# Necessary .dlls
  - LiveSplit.Core.dll
  - UpdateManager.dll
  - WinformsColor.dll

Follow this or use the template to understand how to create your own component for LiveSplit
# How to build a component
  1. Open visual studio, or create a new C# project, or open the template
  2. Create a new Windows Form App
  3. Add the 3 .dlls (LiveSplit.Core.dll, UpdateManager.dll, WinformsColor.dll) to the project folder
  4. Add those .dlls as references in the project
  5. Go to the projects properties, change the output type to class library or .dll
  6. There is no need for program.cs or Form1.cs so you can just delete them
  7. Add a new item to the C# project folder, add a new class library named “<your component’s name>Factory.cs”
  8. This class will contain information about your component, such as what index it is located under, it’s display name, version, etc.
  9. Add a new item to the C# project folder, add a new class library named “<your component’s name>Component.cs”
  10. This class controls what the component will do
  11. Add a new item to the C# project folder, add a new user control named whatever you want
  12. This user control will contain the settings page for your component and the variables saved in the layout
  13. This is all that is necessary for getting started on a component, I would recommend looking at the tutorial in order to look at       exactly what needs to go in the classes and user control
  14. Once you are done making your own component, just build it and then take the .dll from the bin\debug folder and place it in           livesplit’s component folder!
