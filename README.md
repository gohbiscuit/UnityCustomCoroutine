"# UnityCustomCoroutine" 

Custom Coroutine Classes to perform yielding of coroutine that has the following feature:
- waits until all nested/inline coroutine has completed it's execution
- appending of tasks and starts them sequentially in order
- easy to manage code and enhance readability

# UnityCustomCoroutine
This package contains the following components
- Task.cs (Custom Coroutine Classes)
- CustomActionManager.cs (Custom classes for managing delegates event handling)
- TestClass.cs (Class to test Task.cs and CustomActionManager delegates)
- 
- Utility packages contains
-   Debug.cs (debug wrapper class that hides logging on release build)
-   FpsCounter.cs (Fps counter display)
-   Profiler (Show memory usage)

## Installation
Pre-requisite: Unity3d version 5++ software download it at http://unity3d.com/get-unity.
1. Clone it to your working directory, 

2. Open the project that you have clone using Unity3d.

3. Run the StartScene.

4. Examine TestObject prefab and console for more info. (Can also see the Scripts attached to it).

## Usage
Run the project and see TestClass.cs for more details on how to use it

#1 - Add all tasks and start when needed
CustomCoroutine t = this.CreateCustomCoroutine (DoSomethingCoroutine ());
t.AddCoroutine(DoAnotherCoroutine());
...
t.Start();

#2 - Start task immediately
this.StartCustomCoroutine(DoMyCoroutine());

#3- Wait until done
IEnumerator CoroutineFunc()
{
...
yield return this.StartCustomCoroutine(MyCoroutine()).UntilDone;

or

CustomCoroutine t = this.CreateCustomCoroutine (MyCoroutine ());
t.Start();
yield return t.UntilDone;
}

## Contributing
1. Fork it!
2. Create your feature branch: `git checkout -b my-new-feature`
3. Commit your changes: `git commit -am 'Add some feature'`
4. Push to the branch: `git push origin my-new-feature`
5. Submit a pull request :D

## History
First created 31/05/2016 by Edwin. Cheers.

## Credits

The classes was made with some references from online forums, as well as crediting my mentor Muxian Wu.

References:
http://answers.unity3d.com/questions/1040319/whats-the-proper-way-to-queue-and-space-function-c.html
http://twistedoakstudios.com/blog/Post83_coroutines-more-than-you-want-to-know

http://blog.zephyr-ware.com/delegates-and-events/
http://www.codeproject.com/Articles/20550/C-Event-Implementation-Fundamentals-Best-Practices


## License
The MIT License (MIT) Open Source Free
