# Game Basic Information #

## Summary ##

**A paragraph-length pitch for your game.**

Overcoming your inhibitions is difficult for anyone, especially for those who have already given up hope on themselves. An unemployed video game addict, Urumir spends his days browsing online forums and replaying the same old games. His days are bleak and dreary, until one day when he makes his daily trip to the local convenience store. There he meets an untimely end against a speeding Subaru, passing away instantly, his trusty tracksuit failing to protect him. The next thing he knows is opening his eyes in an entirely new world - His body no longer the same, instead composed as an adorable slime. Confused, alone, scared, he tentatively explored the new lands around him, and found a warm welcome from the people of the Isles. In their care he finds the know-how and support he needs to survive in an unfamiliar world. With newfound confidence and desire for exploration, Urumir ventured out farther and farther into the world, accumulating new experiences and abilities, realizing how much time he wasted in his previous life. On and on for years he went, until finally, satisfied he saw all there was to see, Urumir began the journey home to the place he first woke. But there he is met with a bleak sight. Alletas the Demon King had ravaged the Isles, razing down entire villages and towns. With his loved ones mercilessly slaughtered and his home destroyed, Urumir's story takes a drastic shift. He looks to redeem the wasted years wallowed away on nothing, fully coming into his own as a man of valor and honor. To avenge his friends, he must cleanse the land of demonic creatures and strike the Demon King Atellas down from his throne.
*Kudo points if you can spot the two anime isekai references!*

## Gameplay Explanation ##

**In this section, explain how the game should be played. Treat this as a manual within a game. It is encouraged to explain the button mappings and the most optimal gameplay strategy.**

When powered up, Urumir is able to maintain a strong form (2 or more hearts), an amalgamation of the beasts he fought and absorbed throughout his adventures. However, when weakened (1 heart left), Urumir powers down and returns to his primal state as a slime with a ferocious bite.
The game currently supports mouse and keyboard input only. By default, Urumir can move left using A or left arrow key, and right using D or right arrow key. He can use also W or the up arrow key to jump, and may press the key once again while airborne to double jump. Left-clicking in Urumir's strong form results in a forward smash which slightly knocks enemies back, while left-clicking in his weak form will result in a melee bite. 
Defeating a Demon King is no easy task, but Urumir has many tools to work with. In Urumir's strong form, he gains extra abilities. He is able to use spacebar to phase, dashing through enemies and environmental obstacles such as fire pits which would normally damage him. He may right-click to shoot a projectile and damage enemies from a distance. He is also able to use D or the down arrow key to perform a down smash.
If a player were to speedrun this game, they would likely want to rush the platforming sections, evade enemies, and utilize Urumir's dashing mechanic as much as possible to cross tough terrain. However, this requires a good grasp of platforming mechanics and precision. An experienced platformer player may be able to get away with this, but they may be easily punished if they fall into water as it results in an instant death, and will need to restart from the beginning of the level. To play it safe, players should defeat all the enemies and take their time traversing through the destroyed land.

**If you did work that should be factored in to your grade that does not fit easily into the proscribed roles, add it here! Please include links to resources and descriptions of game-related material that does not fit into roles here.**

# Main Roles #

Your goal is to relate the work of your role and sub-role in terms of the content of the course. Please look at the role sections below for specific instructions for each role.

Below is a template for you to highlight items of your work. These provide the evidence needed for your work to be evaluated. Try to have at least 4 such descriptions. They will be assessed on the quality of the underlying system and how they are linked to course content. 

*Short Description* - Long description of your work item that includes how it is relevant to topics discussed in class. [link to evidence in your repository](https://github.com/dr-jam/ECS189L/edit/project-description/ProjectDocumentTemplate.md)

Here is an example:  
*Procedural Terrain* - The background of the game consists of procedurally-generated terrain that is produced with Perlin noise. This terrain can be modified by the game at run-time via a call to its script methods. The intent is to allow the player to modify the terrain. This system is based on the component design pattern and the procedural content generation portions of the course. [The PCG terrain generation script](https://github.com/dr-jam/CameraControlExercise/blob/513b927e87fc686fe627bf7d4ff6ff841cf34e9f/Obscura/Assets/Scripts/TerrainGenerator.cs#L6).

You should replay any **bold text** with your relevant information. Liberally use the template when necessary and appropriate.

## User Interface (Jerrie)

The user interface is designed based on the core game logic and any information we believe is necessary for the player to have when challenging the Demon King. There are four scenes, three of which are for purposes of the user interface only. Any buttons or interactables in the UI have simple shadows when hovered or clicked to provide feedback to the player, letting them know a button is interactable or that they have successfully clicked the button. All user interfaces were tested for any major discrepancies between differing monitor specs and should display properly for all aspect ratios and resolutions.

![image](https://user-images.githubusercontent.com/15057519/121341896-b9319600-c8e6-11eb-9904-3bc270f82e10.png)

- *Start Screen UI* - The scene that first appears when the player runs the game. Can go directly into the gameplay, check the controls, or quit the game. [Image of UI](https://user-images.githubusercontent.com/15057519/121342716-88059580-c8e7-11eb-9fd5-898a5781be8d.png).
- *Controls Scene UI* - The scene that appears when a player wants to check the controls of the game. Tips are also included so the player knows all of the functionalities of the game logic beforehand, something which seemed to be necessary after gameplay testing. Can go back to the main menu or quit the game. [Image of UI](https://user-images.githubusercontent.com/15057519/121343293-2265d900-c8e8-11eb-843c-b563a0d7d7f9.png).
- *Credits Scene UI* - Credits our groupmates for their hard work in their respective roles! Can go back to the main menu or quit the game. [Image of UI](https://user-images.githubusercontent.com/15057519/121343458-504b1d80-c8e8-11eb-9737-2085e39cab92.png).

### Gameplay UI ###
The Gameplay UI is a bit more interesting as it has many pop-up menus for the player to interact with.
![image](https://user-images.githubusercontent.com/15057519/121344105-f9921380-c8e8-11eb-87bd-4dab7b37c7d3.png)
- *Heart Bar* - The Heart Bar UI is also anchored to the bottom right of the screen to adjust to any resolution, as well as communicate with the player how many lives they have left. Upon taking damage, the player will lose hearts.
- *Controls Pop-up Menu* - After gameplay testing, many players did not learn that they could double jump, phase through fire pits, or down smash by themselves. We added a control scene and a control UI so players don't need to figure out the controls through trial and error, and can always refer back to the controls by pausing the game and pulling up the controls pop-up menu.
- *Three Pop-up Menus* - In addition to the controls pop-up menu, there are three additional pop-up menus in our Gameplay scene, the [Victory Menu](https://user-images.githubusercontent.com/15057519/121344920-e0d62d80-c8e9-11eb-8ab9-cc53bd920043.png), the [Pause Menu](https://user-images.githubusercontent.com/15057519/121345022-fc413880-c8e9-11eb-8af2-fd5d19a0ad25.png), and the [Defeat Menu](https://user-images.githubusercontent.com/15057519/121345051-0400dd00-c8ea-11eb-8e80-20df11a52106.png). Players can always pause the game by pressing their escape key, and victory and defeat screens appear according to the game logic.

## Movement/Physics

**Describe the basics of movement and physics in your game. Is it the standard physics model? What did you change or modify? Did you make your movement scripts that do not use the physics system?**

## Animation and Visuals

**List your assets including their sources and licenses.**

**Describe how your work intersects with game feel, graphic design, and world-building. Include your visual style guide if one exists.**

## Input (Johnson)

**Default Configuration (as seen in the control menu of the game):**

![image](https://user-images.githubusercontent.com/50163129/121334293-6350f400-c8ce-11eb-8c1b-2f4360c8ef9c.png)

**Platform and InputStyle**

Our Project supports Unity Game version 2021.1.0f1 for MAC and Windows platforms. The main input style chosen was keyboard and mouse. However, only a keybord is needed to be able to use all inputs as seen above.

**Implementation**

Following the command pattern exercise, we made an IPlayerCommand interface for executing each command. Meanwhile, a PlayerController class script was used to manage all the input for the commands that the player could use. These commands include: MovePlayerLeft, MovePlayerRight, MovePlayerUp, PlayerAbilityDash, PlayerAbilityMelee, PlayerAbilityShoot, PlayerAbilityDownSmash, all of which are executed using the inputs shown above (in the Default Configuration). I implemented the logic and physics for these commands and timed them with JT's animations to give off the overall feel of the player movement/ abilities.

MovePlayerLeft - Moves the player left when given a negative x velocity 

MovePlayerRight- Moves the player Right when given a positve x velocity 

MovePlayerUp - Moves the player up (lets them Jump). I added a IsGrounded check, so that the player can double jump when it is not grounded.

PlayerAbilityMelee - The player swings their fist, damaging all enemies caught in its range. 

PlayerAbilityProjectile - The player shoots a projectile towards the direction that it is facing.

PlaterAbilityDownSmash - The player does a powerful explosive attack underneath it, hurting all enemies in range.

## Game Logic

**Document what game states and game data you managed and what design patterns you used to complete your task.**

# Sub-Roles

## Audio - (Johnson)

**Sound Style**

Following the dark asthetics of our game's visuals and story, the main theme was chosen to convey a constant state of dread and pressure. There is also a win theme and a lose theme. The win theme fittingly conveys a happy and uplifting ending, as you have just slain the evil Demon King that killed your people. Meanwhile, the lose theme is quite sad and dejected, which encourages the player to hit the play again button and have another attempt at the game. Finally, there is a final boss theme. This one is quite upbeat and epic, since we wanted the final part of the game to be as intense as possible.

Furthermore, throughout the game, I added alot of audio cues to give it more depth. I took some inspiration from popular mainstream games. For example, the walking sound is very similar to that of walking on gravel in Minecraft. Another example would be how the damage sound for the player is very similar to alot of 2D action platformers such as Hollow Knight. However, there were a lot of sound effects such as the water and fire SFX, that were chosen because they gave the player a distinct audio queue that something bad happened. I choose these sounds because they were vividly realistic which makes the player take notice of how dangerous the environment can be. This was done in the hopes that they would be encouraged to avoid these obstacles as well as improve their gameplay.

**Implementation**

All the audio that was implemented in the game was attached to a AudioManager prefab in each scene of our game. This prefab held an AudioManager.cs script that could play and stop all the audio that was attached to it, which includes all the themes and sound effects within the game. Along with this is a Sound Script used to allow us to change various properties of the audio while testing. These properties included: volume, pitch, and the ability to loop (which was very handy for playing themes). Lastly, there was a SwitchMusicTrigger.cs file. This was used to change the main theme to the epic boss music, once the player had entered the boss' area.

**Assets:**

* Various License Free Sound Effects from: [Zapsplat](https://www.zapsplat.com/sound-effect-categories/)
* Unity Store Licensing: [FootSteps](https://assetstore.unity.com/packages/audio/sound-fx/foley/footsteps-essentials-189879), [Main Theme](https://assetstore.unity.com/packages/audio/ambient/platformer-music-pack-lite-178337), [Win Theme](https://assetstore.unity.com/packages/audio/ambient/platformer-music-pack-lite-178337), [Lose Theme](https://assetstore.unity.com/packages/audio/ambient/platformer-music-pack-lite-178337), [Boss Theme](https://assetstore.unity.com/packages/audio/music/electronic/dark-boss-fight-side-scroller-background-78149)

**References:** 

* [Audio Manager Tutorial](https://www.youtube.com/watch?v=6OT43pvUyfY), 
* [Switch Music Tracks](https://www.youtube.com/watch?v=XoH8Qyqje1g)

## Gameplay Testing

**Add a link to the full results of your gameplay tests.**

**Summarize the key findings from your gameplay tests.**

## Narrative Design

**Document how the narrative is present in the game via assets, gameplay systems, and gameplay.** 

## Press Kit and Trailer

**Include links to your presskit materials and trailer.**

**Describe how you showcased your work. How did you choose what to show in the trailer? Why did you choose your screenshots?**



## Game Feel

**Document what you added to and how you tweaked your game to improve its game feel.**
