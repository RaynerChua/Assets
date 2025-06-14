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
Game objective: Collect coins , escape the lair and reach the helicopter rescue pad.
Player was kidnapped by a demon lord, they wake up in his lair. The path to the outside is hidden and they must find a special key to reveal it. The money they had on 
their person was stolen and scattered around the map. They must retrieve their stolen coins and successfully reach the helicopter pad to escape. 


## Game Outline


## Bugs & Limitations
- Player must go to the corner of the door to interact with it (open door), no corner = no interaction
- There is no audio/visual feedback for the coins. (Only change can be seen via coin counter)
- There is no audio feedback for player death.
- No "E" interaction UI
- Special tokens have no manual interaction ("No E") but can be interacted via player Object collision

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
