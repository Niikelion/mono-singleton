# Mono-singleton

## Description

Mono-singleton is a small package providing utility classes that help dealing with singletons and `MonoBehaviour` partial singletons.

## Features

* `Singleton` class with lazy object creation for non `UnityEngine.Object` types

* `MonoSingleton` class for `MonoBehaviour` subclasses

## Simple singletons

To make class `A` a singleton, simply inherit from `Singleton` class:

```csharp
using Singletons;

public class A: Singleton<A>
{
    public bool Foo() => true;
}
```

Now, you can access static `Instance` from `A`:

```csharp
bool val = A.Instance.Foo();
```

## Mono singletons

Mono singletons api is the same as simple singletons, except for the base class: `MonoSingleton`

Please note, that unlike singletons, mono singletons are not created on access to `Instance`, but are registered on `Awake` of type inheriting from `MonoSingleton`.

By default every instance of mono singleton `A` that is created while other instance of `A` exists will be destroyed. You can override this behaviour by overriding `OnDuplicate`:

```csharp
using UnityEngine;
using Singletons;

public class A: MonoSingleton<A>
{
    protected override bool OnDuplicate(A _)
    {
        Debug.Log("Duplicate instance found! Duplicate not deleted.");
        return true;
    }
}
```


