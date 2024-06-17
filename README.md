# LTSTest

What I would've done if I had more time

My intention with the connection feature was to have a single, predefined connection point on each of the objects.
The player could hold one object in their hand, and when holding it near the other object, a highlight will show 
demonstrating to the player that a connection could be made. 

Upon release of the grab button, the recently held object will then become connected to the other. 

I was unable to achieve this within the time limit.

I initially attempted to use a FixedJoint component. This was unsuccesful as the two objects would have an unstable connection.
They would orbit around each other and could easily disconnect. They would also connect anywhere rather than having a predefined connection point. 

Next I attempted parenting the objects to each other. This also did not work as the player could instantly disconnect the newly connected objects.

Given more time I would have also added the requested on screen text to guide the player, text indicating a connection and also audio indicating this.

