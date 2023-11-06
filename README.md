
# Is Unity's physics engine deterministic?

While we can state that Unity's physics engine, NVIDIA PhysX, is theoretically deterministic, especially in cases involving high velocities or numerous collisions, small discrepancies may occur due to calculation errors or rounding errors. Therefore, Unity's physics engine may not always produce perfectly deterministic results in practical applications. It is crucial for us to design with unexpected variations in mind. The issue of determinism can become more pronounced in specific use cases requiring detailed physics calculations. 


## Features

- I prevented the unnecessary sphere spawning using Object Pooling.


  
## What is the lesson to be learned from this project?

Unity generally provides acceptable deterministic behavior for an average game, but it's important to remember that variations can still occur in certain situations. I wanted to illustrate that the path taken by spheres launched from a Sphere Launcher is not deterministic.

  
