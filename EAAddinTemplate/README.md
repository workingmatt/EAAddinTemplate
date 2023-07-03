# EA Add-In Template

Sparx Enterprise Architect allows development of custom Add-Ins. This is the most basic example of such an Add-In for process testing or as a convenient start point for creating a more complex.  

Once the example is built take note of the path to EAAddinTemplate.dll  

1. Start regex as an administrator.  
1. Go to Computer\HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\Sparx Systems\EAAddins  
1. Right click on EAAddins and create a new key: EAAddinTemplate (the name of the project/namespace)  
1. Double click the (Default) in the right hand pane and set the Value to project.classname e.g. EAAddinTemplate.MyAddInClass
1. Close regex

Now register the dll  
1. Open a command prompt as administrator  
1. Change directory to C:\Windows\Microsoft.NET\Framework\v4.xxxxx  
1. regasm <path>\EAAddinTemplage.dll /codebase  

Open Sparx EA, open a model, navigate to Specialize menu ribbon and check that MyAddin dropdown menu is there.  
