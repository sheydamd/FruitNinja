# Fruit Spawner (Unity C# Script)

This project contains a Unity C# script that spawns and throws random fruit objects inside a defined 3D area over time.
It is suitable for arcade-style games (e.g. Fruit Ninja–like mechanics), physics-based spawning, or general object spawning systems.

## Overview
The Spawner script:

- Randomly selects fruit prefabs

- Spawns them inside a defined collider volume

- Applies an upward force to simulate throwing

- Destroys spawned objects after a fixed lifetime

- Uses coroutines for smooth timed spawning

## Script Breakdown

1. Spawn Area
` [SerializeField] private Collider spawnArea;`

2. Fruit Prefabs

```c#
public GameObject[] fruitPrefabs;
```

3. Spawn Timing
```c#
public float minSpawnDelay = 0.25f;
public float maxSpawnDelay = 1f;
```
4. Throw Settings
```c#
public float minAngle = -15f;
public float maxAngle = 15f;
public float minForce = 18f;
public float maxForce = 22f;
```
5. Lifetime
```c#
public float maxLifetime = 5f;
```
### How It Works

When the object is enabled, the Spawn() coroutine starts
A short initial delay is applied

Each loop:

A random fruit prefab is selected
A random position inside the collider is calculated
The fruit is instantiated with a random angle
A physics force is applied upward
The fruit is destroyed after maxLifetime
The process repeats indefinitely

### How to Use

- Attach the Spawner script to a GameObject

- Add a Collider (Box Collider recommended)

- Assign fruit prefabs to fruitPrefabs

- Make sure prefabs have a Rigidbody

- Adjust spawn settings in the Inspector

- Press Play