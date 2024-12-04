David C 100860614

This will explain the implementation/choices of the design patterns for this project.
The game I am to recreate is duck hunt (1+8 = 9 + 1 + 4 = 14 = Even).

The command pattern will be used for whenever the player hits/destroys a decoy object it will reverse their mouse inputs. I am interpreting this as rewinding the players mouse inputs from the past 0.5-1 second(s).

The plan is to implement a system that records the players mouse input in a stack around every 0.1s so that the stack doesn't have a thousand mouse positions it needs to rewind through if the player quickly snaps their mouse to the other side of the screen. When the player hits a decoy it will run a command that checks the previous x number of items in the stack (I will be explaining this as if the rewind amount is 0.5 seconds but it can be more), which will be 5 positions since 0.5/0.1 is 5. It will read the stack and see the written positions of the mouse and snap your mouse to that location. The stacks max size will be 5 positions as we don't need to track more than that. If we want to update the stack we remove the bottom most position (which is 0), move everything down and add the new position.

Object Pooling will be used to reuse the same ducks/pigeons so that we don't need to instantiate/create new ducks.

We create an initial pool and whenever a duck is needed we disable whatever is in the queue and disable the duck when it's purpose is done, whether that be it got shot down or it flew away. 

The design pattern of my choice is a singleton as it will be used for many actions that would otherwise take up a lot more scripts than needed. 

The GameManager will be responsible for spawning ducks, keeping track of players mouse actions (shooting ducks or navigating menus if implemented), keeping track of score, keeping track of shots left, etc.
