# I3E ASG1

## Controls
- W-A-S-D (Move player forward, left, right & backward)
- SpaceBar (Allows plkayer to jump up)
- Shift (Allows player to Sprint)
- "E" (Allows player to interact with gameObjects like collecting coins & opening doors)
- Recommended: W + Spacebar + Shift (Player can "fly"/ move a great distance when jumping across platforms)
  
## Platforms
- Windows PC
  
## Premise
Player was kidnapped by a demon lord, they wake up in his lair. The path to the outside is hidden and they must find a special key to reveal it. The money they had on 
their person was stolen and scattered around the map. They must retrieve their stolen coins and successfully reach the helicopter pad to escape. 


## Game Outline

It is not a MUST to collect all the coins to win the game. Hoever, every coin collected will contribute to the player's total score.

There are a total of 10 coin collectibles & 2 special tokens (revealPath & Victory token):

Each coin collected contributes 50 points to the player's total score. The max score adds up to 1500 points if the player succeeds in collecting all the coins & tokens.

1. The player starts off the game in stage 1. There are instructions scattered throughout the map on the walls that players can visually see.
   Their goal is to reach stage 3 where the helicopter pad is located to conquer the game.
   Stage 1 involves a total of 3 distinct puzzles that feature, spinning platforms, vanishing blocks and a simple parkour obby. To "escape" the lair,
   the player has to collect a special token to reveal a hidden path that allows the player to cross the lava moat and exit via the door. (Note that
   the hidden path token has no value, it's purpose is to reveal the path. The only hazard in this stage is the lava floor, stepping on it causes instant death which
   will respawn the player back to their spawn point. ( A death message will pop up on the UI and disappear shortly after.)
   
   Answer key: It's very easy to beat the level, the player just needs to take note of their timing before they act. The game requires a lot of jumping and sprinting as
   doing so allows the player to cover a larger distance when hopping across platforms. So they essentially need to time their jumps. The vanishing script only
   affects the sphere in the middle, the other spheres from start to end are static same goes for the spinning platforms. It's all about timing.

2. Once the player has "escaped" the lair via the door they will encounter a teleport block that will bring them to stage 2. Stage 2 involves a lot of vertical moving blocks. The player
   has to go through this stage to reach the final stage (stage 3). They can also claim a number of coins on the way. The hazard for this stage is the same as stage 1. A lava
   floor. If the player falls onto the lava, they will die and respawn back to the start of stage 2. There are no checkpoints in this parkour puzzle so they will have to work
   their way up again from the start. This stage uses floating platforms that players have to hop across. There are some platforms that move up and down, allowing players
   to ascend and make their way to the next stage.

   Answer key: Sprint & jump. Wait and time your jumps. Not all platforms move at the same frequency. Some alternate, one wrong move and the player could fall to their demise.
   This level is not difficult, in fact its quite easy to prevent death as long as the player is patient and careful.

3. The final stage was inspired by an apocalyptic world. Now that our protagonist has escaped the demon lord's lair they return to a world of ruin. The hazard in this stage is different
   from that of stage 1 & 2. Instead of instant death, stepping on the "toxic" floor will damage the player by 10 HP every 2 seconds. The player has to hop across barrels to avoid the
   toxic sludge and make their way to the sunken buildings. They can hop on elevator platforms that will take them to the top of the building where a health pad awaits them. After which,
   they must hop across window ledges to make it to the next building. The path to the third building is made with thin window frames, one wrong move and you'll fall. There are some secrets
   to look out for in this stage, players are advised to keep their eyes peeled to successfully obtain all coins in the game. The third building features a simple maze and connects to the
   building with the heli pad via spinning platforms.

   Answer key: Players must be observant in this level. This stage requires some decision making and proper timing when it comes to the parkour puzzles. JUMP & SPRINT.

4. The player wins once they collide with the victory token (AKA signal flare), players will gain a bonus of 1000 points if they succeed in reaching this point. A congratulatory UI
   message will pop up to declare their victory.
   

## Bugs & Limitations
- Player must go to the corner of the door to interact with it (open door), no corner = no interaction
- There is no audio/visual feedback for the coins. (Only change can be seen via coin counter)
- There is no audio feedback for player death.
- No "E" interaction UI
- Special tokens have no manual interaction ("No E") but can be interacted via player Object collision
- Player will fall off moving blocks if not careful, if a block moves the player will not stay on it and will slide off.
- There are no checkpoints. Some stages will require players to start from scratch if they go off course.

## Credits & references
- Door opening sound: https://pixabay.com/sound-effects/search/door%20open/ ("Door Open" by freesound_community):
  Edited with ClipChamp (https://clipchamp.com/en/) & converted into mp3 with FreeConvert (https://www.freeconvert.com/mp4-to-mp3)
- Background Music: https://freetouse.com/music/category/retro ("Gameboy" by Walen)
  
- Mathf.PingPong Guide (https://docs.unity3d.com/ScriptReference/Mathf.PingPong.html)
- StartCouroutine Guide (https://docs.unity3d.com/ScriptReference/MonoBehaviour.StartCoroutine.html)
- WaitForSeconds Guide (https://docs.unity3d.com/ScriptReference/WaitForSeconds.html)
- Enumerator Guide (https://www.geeksforgeeks.org/c-sharp/c-sharp-enumeration-or-enum/)
- Transform.eulerAngles Guide (https://docs.unity3d.com/ScriptReference/Transform-eulerAngles.html)
- Vector 3 Guide (https://youtu.be/sYf4bSj9j2w?si=zCsPuRiIDIHU1VT5)
- Block movement Guide (https://youtu.be/EMhTROG0nAw?si=q0VreGqtd9kemj0Z)
- Rigidbody Guide (https://docs.unity3d.com/ScriptReference/Rigidbody.html)
- time.deltatime Guide (https://docs.unity3d.com/ScriptReference/Time-deltaTime.html)
- characterController Guide (https://docs.unity3d.com/ScriptReference/CharacterController.html)
- All gameObjects were made with Unity.proBuilder & materials were made with default unity settings.
- Player UI was designed with TextMeshPro imports.
